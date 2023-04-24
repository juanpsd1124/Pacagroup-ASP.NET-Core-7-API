using Pacagroup.Ecommerce.Application.DTO;
using Pacagroup.Ecommerce.Transversal.Common;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

namespace Pacagroup.Ecommerce.Application.Interface.UseCases
{
    public interface IDiscountsApplication
    {
        Task<Response<bool>> Create(DiscountDTO discountDto, CancellationToken cancellationToken = default);
        Task<Response<bool>> Update(DiscountDTO discountDto, CancellationToken cancellationToken = default);
        Task<Response<bool>> Delete(int id, CancellationToken cancellationToken = default);
        Task<Response<DiscountDTO>> Get(int id, CancellationToken cancellationToken = default);
        Task<Response<List<DiscountDTO>>> GetAll(CancellationToken cancellationToken = default);
    }   
}
