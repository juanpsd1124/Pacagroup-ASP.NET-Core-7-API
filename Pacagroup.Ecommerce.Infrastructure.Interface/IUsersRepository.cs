using Pacagroup.Ecommerce.Domain.Entity;


namespace Pacagroup.Ecommerce.Infrastructure.Interface
{
    public interface IUsersRepository
    {
        Users Authenticate(string username, string password); 


    }
}
