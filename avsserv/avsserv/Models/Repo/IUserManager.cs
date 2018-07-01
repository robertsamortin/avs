using avsserv.ViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace avsserv.Models.Repo
{
    public interface IUserManager
    {
        EmployeesViewModel Validate(string LoginName);
        void SignIn(HttpContext httpContext, EmployeesViewModel user, bool isPersistent = false);
        void SignOut(HttpContext httpContext);
        string GetCurrentUserId(HttpContext httpContext);
        EmployeesViewModel GetCurrentUser(HttpContext httpContext);
    }
}
