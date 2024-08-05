using Entities.DAOs;
using Microsoft.EntityFrameworkCore;
using Repositories.Implementation.Extensions.Utility;
using System.Linq.Dynamic.Core;

namespace Repositories.Implementation.Extensions
{
    public static class RepositoryPhongBanExtensions
    {

        public static IQueryable<Phongban> Search(this IQueryable<Phongban> phongban, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return phongban;

            var lowerCaseTerm = searchTerm.Trim().ToLower();

            return phongban.Where(e => e.Tenpb.ToLower().Contains(lowerCaseTerm));
        }

        public static IQueryable<Phongban> Sort(this IQueryable<Phongban> phongban, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return phongban.OrderBy(e => e.Tenpb);

            var orderQuery = OrderQueryBuilder.CreateOrderQuery<Phongban>(orderByQueryString);

            Console.WriteLine(orderQuery);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return phongban.OrderBy(e => e.Tenpb);

            return phongban.OrderBy(orderQuery);
        }
    }
}
