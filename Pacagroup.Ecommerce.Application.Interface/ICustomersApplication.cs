using System;
using Pacagroup.Ecommerce.Application.DTO;
using Pacagroup.Ecommerce.Transversal.Common;
using System.Threading.Tasks;

namespace Pacagroup.Ecommerce.Application.Interface
{
    public interface ICustomersApplication
    {
        #region Métodos Síncronos
        Response<bool> Insert(CustomersDTO customer);
        Response<bool> Update(CustomersDTO customer);
        Response<bool> Delete(string customerId);
        Response<CustomersDTO> Get(string customerId);
        Response<IEnumerable<CustomersDTO>> GetAll();
        #endregion

        #region Métodos Asíncronos

        Task<Response<bool>> InsertAsync(CustomersDTO customer);
        Task<Response<bool>> UpdateAsync(CustomersDTO customer);
        Task<Response<bool>> DeleteAsync(string customerId);
        Task<Response<CustomersDTO>> GetAsync(string customerId);
        Task<Response<IEnumerable<CustomersDTO>>> GetAllAsync();
        #endregion

    }
}
