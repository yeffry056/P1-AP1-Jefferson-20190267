using Microsoft.EntityFrameworkCore;
using P1_AP1_Jefferson_20190267.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1_AP1_Jefferson_20190267.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Aportes> Aportes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = DATA\P1-AP1-jefferson-2019-0267.db");
        }
    }
}
