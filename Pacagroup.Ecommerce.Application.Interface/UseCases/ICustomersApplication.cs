using System;
using System.Collections.Generic;
using System.Text;
using Pacagroup.Ecommerce.Application.DTO;
using Pacagroup.Ecommerce.Transversal.Common;
using System.Threading.Tasks;

namespace Pacagroup.Ecommerce.Application.Interface.UseCases
{
    public interface ICustomersApplication
    {
        #region Métodos Síncronos

        Response<bool> Insert(CustomerDTO customersDto);
        Response<bool> Update(CustomerDTO customersDto);
        Response<bool> Delete(string customerId);

        Response<CustomerDTO> Get(string customerId);
        Response<IEnumerable<CustomerDTO>> GetAll();
        ResponsePagination<IEnumerable<CustomerDTO>> GetAllWithPagination(int pageNumber, int pageSize);

        #endregion

        #region Métodos Asíncronos
        Task<Response<bool>> InsertAsync(CustomerDTO customersDto);
        Task<Response<bool>> UpdateAsync(CustomerDTO customersDto);
        Task<Response<bool>> DeleteAsync(string customerId);

        Task<Response<CustomerDTO>> GetAsync(string customerId);
        Task<Response<IEnumerable<CustomerDTO>>> GetAllAsync();
        Task<ResponsePagination<IEnumerable<CustomerDTO>>> GetAllWithPaginationAsync(int pageNumber, int pageSize);
        #endregion
    }
}
