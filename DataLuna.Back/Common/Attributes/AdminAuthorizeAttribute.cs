using System;
using Microsoft.AspNetCore.Mvc;

namespace DataLuna.Back.Common.Attributes
{
    public class AdminAuthorizeAttribute : TypeFilterAttribute
    {
        public AdminAuthorizeAttribute() : base(typeof(AdminAuthorizeFilter)) {}
    }
}