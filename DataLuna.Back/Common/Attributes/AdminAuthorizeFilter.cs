using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using DataLuna.Back.Common.AdminUsers;

namespace DataLuna.Back.Common.Attributes
{
    public class AdminAuthorizeFilter : IAuthorizationFilter
    {
        private const string ADMIN_AUTH_HEADER = "Dtl-Authorization";

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.Request.Headers.TryGetValue(ADMIN_AUTH_HEADER, out var headerValues))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            string token = headerValues.FirstOrDefault();
            if (string.IsNullOrEmpty(token))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            var admin = AdminsCollection.Admins.FirstOrDefault(f => f.Token == token);
            if (admin == null)
            {
                context.Result = new UnauthorizedResult();
                return;
            }
        }
    }
}