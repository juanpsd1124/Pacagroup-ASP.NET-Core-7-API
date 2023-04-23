﻿using Dapper;
using Pacagroup.Ecommerce.Domain.Entity;
using Pacagroup.Ecommerce.Infrastructure.Data;
using Pacagroup.Ecommerce.Infrastructure.Interface;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Pacagroup.Ecommerce.Infrastructure.Repository
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly DapperContext _context;
        public CategoriesRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task <IEnumerable<Categories>> GetAll()
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "Select * From Categories";

                var customers = await connection.QueryAsync<Categories>(query, commandType: CommandType.Text);
                return customers;
            }
        }
    }
}
