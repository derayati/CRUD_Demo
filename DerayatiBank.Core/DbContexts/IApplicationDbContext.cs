using DerayatiBank.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerayatiBank.Core.DbContexts
{
    public interface IApplicationDbContext
    {
        DbSet<Customer> Customers { get; set; }
        Task<int> SaveChange();
    }
}
