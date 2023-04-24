using Microsoft.EntityFrameworkCore;
using Pacagroup.Ecommerce.Application.Interface.Persistence;
using Pacagroup.Ecommerce.Domain.Entities;
using Pacagroup.Ecommerce.Domain.Entities.Descuento;
using Pacagroup.Ecommerce.Persistence.Contexts;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System;

namespace Pacagroup.Ecommerce.Persistence.Repositories
{
    public class DiscountRepository : IDiscountRepository
    {
        protected readonly ApplicationDbContext _applicationDbContext;

        public DiscountRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        #region Métodos Sincronos
        public int Count()
        {
            throw new NotImplementedException();
        }
        public bool Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Discount Get(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Discount> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Discount> GetAllWithPagination(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }
        public bool Insert(Discount entity)
        {
            throw new NotImplementedException();
        }
        public bool Update(Discount entity)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Métodos Asincronos

        public async Task<bool> InsertAsync(Discount entity)
        {
            _applicationDbContext.Add(entity);
            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateAsync(Discount discount)
        {
            var entity = await _applicationDbContext.Set<Discount>().AsNoTracking().SingleOrDefaultAsync(x => x.Id.Equals(discount.Id));
            if (entity == null)
            {
                return await Task.FromResult(false);
            }
            entity.Name = discount.Name;
            entity.Description = discount.Description;
            entity.Percent = discount.Percent;
            entity.Status = discount.Status;

            _applicationDbContext.Update(entity);
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var entity = await _applicationDbContext.Set<Discount>()
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id.Equals(int.Parse(id)));

            if (entity == null)
            {
                return await Task.FromResult(false);
            }

            _applicationDbContext.Remove(entity);
            return await Task.FromResult(true);
        }

        public async Task<List<Discount>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _applicationDbContext.Set<Discount>().AsNoTracking().ToListAsync(cancellationToken);
        }

        public async Task<Discount> GetAsync(int id, CancellationToken cancellationToken)
        {
            return await _applicationDbContext.
                Set<Discount>().AsNoTracking().
                SingleOrDefaultAsync(x => x.Id.Equals(id), cancellationToken);
        }

        public Task<IEnumerable<Discount>> GetAllWithPaginationAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Discount> GetAsync(string id)
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<Discount>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
