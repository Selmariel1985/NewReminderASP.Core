using NewReminderASP.Domain.Entities;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace NewReminderASP.WebUI.Areas
{
    public class BaseController : Controller
    {
        protected IQueryable<T> DynamicSortAndPaginate<T>(IQueryable<T> data, string orderBy, string sortOrder, int page, int pageSize)
        {
            if (orderBy != "Roles") // Handle sorting by roles separately
            {
                if (!string.IsNullOrEmpty(orderBy))
                {
                    data = DynamicSort(data, orderBy, sortOrder);
                }

                int totalItems = data.Count();
                int totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

                page = Math.Max(1, Math.Min(page, totalPages));

                return data.Skip((page - 1) * pageSize).Take(pageSize);
            }
            else
            {
                return SortUsersByRoles(data, sortOrder, page, pageSize);
            }
        }

        protected IQueryable<T> DynamicSort<T>(IQueryable<T> data, string orderBy, string sortOrder)
        {
            if (string.IsNullOrEmpty(orderBy))
            {
                return data;
            }


            var param = System.Linq.Expressions.Expression.Parameter(typeof(T));
            var key = System.Linq.Expressions.Expression.PropertyOrField(param, orderBy);
            var keySelector = System.Linq.Expressions.Expression.Lambda(key, param);


            return sortOrder == "asc" ? Queryable.OrderBy(data, (dynamic)keySelector) : Queryable.OrderByDescending(data, (dynamic)keySelector);
        }

        private IQueryable<T> SortUsersByRoles<T>(IQueryable<T> data, string sortOrder, int page, int pageSize)
        {
            if (sortOrder == "asc")
            {
                return data.OrderBy(u => GetUserRoles(u))
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize);
            }
            else
            {
                return data.OrderByDescending(u => GetUserRoles(u))
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize);
            }
        }

        private string GetUserRoles<T>(T user)
        {
            var roles = (user as User)?.UserRoles.Select(r => r.Role.Name).ToList();
            return roles != null ? string.Join(", ", roles) : string.Empty;
        }

        protected ActionResult SignOutAndRedirectToLogin(string area)
        {
            FormsAuthentication.SignOut(); // Signs the user out
            return RedirectToAction("Login", "Login", new { area = area });
        }

    }

}

