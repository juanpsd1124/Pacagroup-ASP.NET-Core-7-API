using Pacagroup.Ecommerce.Domain.Entity;


namespace Pacagroup.Ecommerce.Application.Interface.Persistence
{
    public interface IUsersRepository
    {
        Users Authenticate(string username, string password); 


    }
}
