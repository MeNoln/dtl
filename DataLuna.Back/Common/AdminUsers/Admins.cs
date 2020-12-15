using System;
using System.Collections.Generic;

namespace DataLuna.Back.Common.AdminUsers
{
    public class AdminUser
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
    }

    public static class AdminsCollection
    {
        public static IEnumerable<AdminUser> Admins
            => new List<AdminUser>
                {
                    new AdminUser
                    {
                        Login = "admin",
                        Password = "admin",
                        Token = "8da193366e1554c08b2870c50f737b9587c3372b656151c4a96028af26f51334"
                    }
                };
    }
}