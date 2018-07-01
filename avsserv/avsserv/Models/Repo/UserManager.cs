using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using avsserv.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;

namespace avsserv.Models.Repo
{
    public class UserManager : IUserManager
    {
        private IEmployeesRepo _repo;
        public UserManager(IEmployeesRepo repo)
        {
            _repo = repo;
        }
        public EmployeesViewModel GetCurrentUser(HttpContext httpContext)
        {
            string currentUserId = this.GetCurrentUserId(httpContext).ToString();

            if (currentUserId == null)
                return null;

            return _repo.GetByID(currentUserId);
        }

        public string GetCurrentUserId(HttpContext httpContext)
        {
            if (!httpContext.User.Identity.IsAuthenticated)
                return null;

            Claim claim = httpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);

            if (claim == null)
                return null;

            string currentUserId = claim.Value;
            return currentUserId;
        }

        public async void SignIn(HttpContext httpContext, EmployeesViewModel user, bool isPersistent = false)
        {
            ClaimsIdentity identity = new ClaimsIdentity(this.GetUserClaims(user), CookieAuthenticationDefaults.AuthenticationScheme);
            ClaimsPrincipal principal = new ClaimsPrincipal(identity);

            await httpContext.SignInAsync(
              CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties() { IsPersistent = isPersistent }
            );
        }

        public async void SignOut(HttpContext httpContext)
        {
            await httpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }

        public EmployeesViewModel Validate(string LoginName)
        {
            var user = _repo.UserLogin(LoginName);

            return user;
        }

        private IEnumerable<Claim> GetUserClaims(EmployeesViewModel user)
        {
            List<Claim> claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.ID.ToString()));
            claims.Add(new Claim(ClaimTypes.GivenName, user.FirstName));
            claims.Add(new Claim(ClaimTypes.Name, user.EmpNo.ToString()));
            return claims;
        }
    }
}
