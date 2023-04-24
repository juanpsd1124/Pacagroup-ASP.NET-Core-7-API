using Dapper;
using Pacagroup.Ecommerce.Application.Interface.Persistence;
using Pacagroup.Ecommerce.Persistence.Context;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Pacagroup.Ecommerce.Domain.Entities;

namespace Pacagroup.Ecommerce.Persistence.Repositories
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly DapperContext _context;
        public CategoriesRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "Select * From Categories";

                var customers = await connection.QueryAsync<Category>(query, commandType: CommandType.Text);
                return customers;
            }
        }
    }
}
