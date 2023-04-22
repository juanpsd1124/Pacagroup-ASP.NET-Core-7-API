﻿using System;
using Pacagroup.Ecommerce.Domain.Entity;
using Pacagroup.Ecommerce.Domain.Interface;
using Pacagroup.Ecommerce.Infrastructure.Interface;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Pacagroup.Ecommerce.Domain.Core
{
    public class CustomersDomain : ICustomersDomain
    {
        private readonly IUnitOfWork _unitOfWork;
        public CustomersDomain(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #region Métodos Síncronos

        public bool Insert(Customers customers)
        {
            return _unitOfWork.Customers.Insert(customers);
        }

        public bool Update(Customers customers)
        {
            return _unitOfWork.Customers.Update(customers);
        }

        public bool Delete(string customerId)
        {
            return _unitOfWork.Customers.Delete(customerId);
        }

        public Customers Get(string customerId)
        {
            return _unitOfWork.Customers.Get(customerId);
        }

        public IEnumerable<Customers> GetAll()
        {
            return _unitOfWork.Customers.GetAll();
        }

        #endregion

        #region Métodos Asíncronos

        public async Task<bool> InsertAsync(Customers customers)
        {
            return await _unitOfWork.Customers.InsertAsync(customers);
        }

        public async Task<bool> UpdateAsync(Customers customers)
        {
            return await _unitOfWork.Customers.UpdateAsync(customers);
        }

        public async Task<bool> DeleteAsync(string customerId)
        {
            return await _unitOfWork.Customers.DeleteAsync(customerId);
        }

        public async Task<Customers> GetAsync(string customerId)
        {
            return await _unitOfWork.Customers.GetAsync(customerId);
        }

        public async Task<IEnumerable<Customers>> GetAllAsync()
        {
            return await _unitOfWork.Customers.GetAllAsync();
        }

        #endregion
    }
}
