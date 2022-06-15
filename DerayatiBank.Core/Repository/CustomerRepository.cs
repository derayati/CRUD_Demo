using DerayatiBank.Core.DbContexts;
using DerayatiBank.Core.Entities;
using DerayatiBank.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerayatiBank.Core.Repository
{
    public class CustomerRepository : IRepository<Customer>
    {
        ApplicationDbContext _dbContext;
        public CustomerRepository(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }
        public async Task<Customer> Create(Customer _object)
        {
            var obj = await _dbContext.Customers.AddAsync(_object);
            _dbContext.SaveChanges();
            return obj.Entity;
        }

        public void Delete(Customer _object)
        {
            _dbContext.Remove(_object);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Customer> GetAll()
        {
            try
            {
                return _dbContext.Customers.ToList();
            }
            catch (Exception ee)
            {
                throw;
            }
        }

        public Customer GetById(Guid Id)
        {
            return _dbContext.Customers.Where(x => x.Id == Id).FirstOrDefault();
        }

        public async Task<Customer> GetByIdAsync(Guid id)
        {
            return await _dbContext.Customers.FindAsync(id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _dbContext.Customers.ToListAsync().ConfigureAwait(false);
        }

        public void Update(Customer _object)
        {
            _dbContext.Customers.Update(_object);
            _dbContext.SaveChanges();
        }
    }
}
