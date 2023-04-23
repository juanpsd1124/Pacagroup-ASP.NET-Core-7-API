using System;
using System.Collections.Generic;
using System.Text;

namespace Pacagroup.Ecommerce.Infrastructure.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IUsersRepository Users { get; }
        ICustomersRepository Customers { get; }
        ICategoriesRepository Categories { get; }
    }
}
