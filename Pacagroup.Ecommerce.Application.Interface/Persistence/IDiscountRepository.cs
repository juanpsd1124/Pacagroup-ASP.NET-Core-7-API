using Pacagroup.Ecommerce.Domain.Entities.Descuento;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

namespace Pacagroup.Ecommerce.Application.Interface.Persistence
{
    public interface IDiscountRepository : IGenericRepository<Discount>
    {
        Task<Discount> GetAsync(int id, CancellationToken cancellationToken);
        Task<List<Discount>> GetAllAsync(CancellationToken cancellationToken);
    }
}
