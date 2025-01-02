using System;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Security;
using NewReminderASP.Domain.Entities;

namespace NewReminderASP.WebUI.Areas
{
    public class BaseController : Controller
    {
        /// <summary>
        /// Выполняет динамическую сортировку и пагинацию данных.
        /// </summary>
        protected IQueryable<T> DynamicSortAndPaginate<T>(
            IQueryable<T> data,
            string orderBy,
            string sortOrder,
            int page,
            int pageSize)
        {
            if (string.Equals(orderBy, "Roles", StringComparison.OrdinalIgnoreCase))
            {
                return SortUsersByRoles(data, sortOrder, page, pageSize);
            }

            if (!string.IsNullOrEmpty(orderBy))
            {
                data = DynamicSort(data, orderBy, sortOrder);
            }

            return Paginate(data, page, pageSize);
        }

        /// <summary>
        /// Выполняет динамическую сортировку по указанному полю.
        /// </summary>
        protected IQueryable<T> DynamicSort<T>(IQueryable<T> data, string orderBy, string sortOrder)
        {
            if (string.IsNullOrEmpty(orderBy)) return data;

            try
            {
                var param = Expression.Parameter(typeof(T));
                var key = Expression.PropertyOrField(param, orderBy);
                var keySelector = Expression.Lambda(key, param);

                return sortOrder?.ToLower() == "asc"
                    ? Queryable.OrderBy(data, (dynamic)keySelector)
                    : Queryable.OrderByDescending(data, (dynamic)keySelector);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Ошибка при сортировке по полю '{orderBy}'", ex);
            }
        }

        /// <summary>
        /// Сортировка пользователей по ролям.
        /// </summary>
        private IQueryable<T> SortUsersByRoles<T>(IQueryable<T> data, string sortOrder, int page, int pageSize)
        {
            return sortOrder?.ToLower() == "asc"
                ? data.OrderBy(u => GetUserRoles(u)).Skip((page - 1) * pageSize).Take(pageSize)
                : data.OrderByDescending(u => GetUserRoles(u)).Skip((page - 1) * pageSize).Take(pageSize);
        }

        /// <summary>
        /// Возвращает роли пользователя.
        /// </summary>
        private string GetUserRoles<T>(T user)
        {
            if (user is User userEntity)
            {
                return userEntity.UserRoles?
                    .Select(r => r.Role?.Name)
                    .Where(name => !string.IsNullOrEmpty(name))
                    .Aggregate((a, b) => $"{a}, {b}") ?? string.Empty;
            }

            return string.Empty;
        }

        /// <summary>
        /// Выполняет пагинацию.
        /// </summary>
        private IQueryable<T> Paginate<T>(IQueryable<T> data, int page, int pageSize)
        {
            var totalItems = data.Count();
            var totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

            page = Math.Max(1, Math.Min(page, totalPages));

            return data.Skip((page - 1) * pageSize).Take(pageSize);
        }

        /// <summary>
        /// Выход пользователя и перенаправление на страницу входа.
        /// </summary>
        protected ActionResult SignOutAndRedirectToLogin(string area)
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Login", new { area });
        }
    }
}
