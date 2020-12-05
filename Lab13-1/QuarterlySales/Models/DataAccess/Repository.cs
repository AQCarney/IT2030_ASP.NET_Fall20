using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace QuarterlySales.Models
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected SalesContext context { get; set; }
        private DbSet<T> dbset { get; set; }

        public Repository(SalesContext ctx)
        {
            this.context = ctx;
            this.dbset = this.context.Set<T>();
        }
    }    
}
