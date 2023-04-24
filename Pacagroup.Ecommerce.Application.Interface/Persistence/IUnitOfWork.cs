using System;
using System.Threading.Tasks;
using System.Threading;

namespace Pacagroup.Ecommerce.Application.Interface.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomersRepository Customers { get; }
        IUsersRepository Users { get; }

        ICategoriesRepository Categories { get; }
        IDiscountRepository Discounts { get; }
        Task<int> Save(CancellationToken cancellationToken);
    }
}
