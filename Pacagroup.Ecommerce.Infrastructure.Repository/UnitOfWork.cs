using Pacagroup.Ecommerce.Infrastructure.Interface;

namespace Pacagroup.Ecommerce.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IUsersRepository users, ICustomersRepository customers)
        { 
            Users = users;
            Customers = customers;
        }

        public IUsersRepository Users { get; }
        public ICustomersRepository Customers { get; }

        public void Dispose() 
        { 
            System.GC.SuppressFinalize(this);
        }

    }
}
