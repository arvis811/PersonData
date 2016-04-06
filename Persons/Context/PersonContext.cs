using Persons.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persons.Context
{
    public class PersonContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
    }
}
