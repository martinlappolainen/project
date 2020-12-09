using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace AutoCompleter.Models
{
    public class NimedContext : DbContext
    {
        public DbSet<Nimed> Nimeds { get; set; }
    }
}