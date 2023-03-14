using CarsApi.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;

namespace CarsApi.Auth
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly CarsDbContext _context;
        public BasicAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock, CarsDbContext carsDbContext) : base(options, logger, encoder, clock)
        {
            _context = carsDbContext;
        }

        protected async override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if(!Request.Headers.ContainsKey("Authorization"))
                return AuthenticateResult.Fail("Please provide correct username and password");

            var headerValue = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
            if(headerValue == null)
                return AuthenticateResult.Fail("Please provide correct username and password");

            var credentials = Encoding.UTF8.GetString(Convert.FromBase64String(headerValue.Parameter))?.Split(":"); //credentials are passed in => username:password
            if(credentials == null)
                return AuthenticateResult.Fail("Please provide correct username and password");

            string username = credentials[0], password = credentials[1];
            
            if(await _context.Users.AnyAsync(u => u.UserName.ToLower() == username.ToLower() && u.Password == password))
            {
                //Generate Auth ticket
                var claim = new[] { new Claim(ClaimTypes.Name, username) };
                var identity = new ClaimsIdentity(claim, Scheme.Name);
                var principal = new ClaimsPrincipal(identity);
                
                var ticket = new AuthenticationTicket(principal, Scheme.Name);
                
                return AuthenticateResult.Success(ticket);
            }

            return AuthenticateResult.Fail("Unauthorized");
        }
    }
}
