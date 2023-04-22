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

        private readonly IUnitOfWork _unitOfWork;

        public UsersDomain (IUnitOfWork unitOfWork){
            _unitOfWork = unitOfWork;
        }
        public Users Authenticate(string userName, string Password) 
        { 
            return _unitOfWork.Users.Authenticate(userName, Password);
        }

       
    }
}
