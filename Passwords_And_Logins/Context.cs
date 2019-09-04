using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passwords_And_Logins
{
    class Context:DbContext
    {
        public Context():base("L")
        {

        }
        public DbSet<User> users { get; set; }
        public DbSet<Account> accounts { get; set; }
    }
}
