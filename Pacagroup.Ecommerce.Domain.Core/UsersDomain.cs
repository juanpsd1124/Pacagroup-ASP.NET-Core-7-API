using Pacagroup.Ecommerce.Domain.Entity;
using Pacagroup.Ecommerce.Domain.Interface;
using Pacagroup.Ecommerce.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pacagroup.Ecommerce.Domain.Core
{
    public class UsersDomain : IUsersDomain
    {

        private readonly IUsersRepository _usersRepository;

        public UsersDomain (IUsersRepository usersRepository){
            _usersRepository = usersRepository;
        }
        public Users Authenticate(string userName, string Password) 
        { 
            return _usersRepository.Authenticate(userName, Password);
        }

       
    }
}
