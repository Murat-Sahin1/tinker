using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tinker.Application.Interfaces.Repositories;
using tinker.Domain.Entities;
using tinker.Persistence.Contexts;

namespace tinker.Persistence.Repositories
{
    public class CustomerRepository : GenericRepositoryAsync<Customer>, ICustomerRepository
    {
        public CustomerRepository(AppDbContext dbcontext) : base(dbcontext) 
        {
        }
    }
}
