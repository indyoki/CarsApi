﻿namespace CarsApi.Models
{
    public class UserAccount
    {
        public virtual int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
