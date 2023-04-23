using Pacagroup.Ecommerce.Application.Interface.Persistence;

namespace Pacagroup.Ecommerce.Persistence.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IUsersRepository users, ICustomersRepository customers, ICategoriesRepository categories)
        { 
            Users = users;
            Customers = customers;
            Categories = categories;    
        }

        public IUsersRepository Users { get; }
        public ICustomersRepository Customers { get; }
        public ICategoriesRepository Categories { get; }

        public void Dispose() 
        { 
            System.GC.SuppressFinalize(this);
        }

    }
}
