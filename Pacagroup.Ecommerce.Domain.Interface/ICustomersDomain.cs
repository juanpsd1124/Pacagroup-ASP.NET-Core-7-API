using System;
using System.Collections.Generic;
using System.Text;
using Pacagroup.Ecommerce.Domain.Entity;
using System.Threading.Tasks;

namespace Pacagroup.Ecommerce.Domain.Interface
{
    public interface ICustomersDomain
    {
        #region Métodos Síncronos

        bool Insert(Customers customer);
        bool Update(Customers customer);
        bool Delete(string customerId);
        IEnumerable<Customers> GetAllWithPagination(int pageNumber, int pageSize);
        int Count();

        Customers Get(string customerId);
        IEnumerable<Customers> GetAll();
        Task<IEnumerable<Customers>> GetAllWithPaginationAsync(int pageNumber, int pageSize);
        Task<int> CountAsync();

        #endregion

        #region Métodos Asíncronos
        Task<bool> InsertAsync(Customers customer);
        Task<bool> UpdateAsync(Customers customer);
        Task<bool> DeleteAsync(string customerId);

        Task<Customers> GetAsync(string customerId);
        Task<IEnumerable<Customers>> GetAllAsync();
        #endregion
    }
}
