using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Budget.Models
{
    public class BudgetDbContext :DbContext
    {
        public BudgetDbContext()
        : base("name=BudgetDB")
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Expense> Expenses { get; set; }

    }
}