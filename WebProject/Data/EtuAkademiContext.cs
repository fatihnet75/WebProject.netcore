using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebProject.Models;


namespace EtüAkademiContext.Data
{
    public class EtuAkademiContext : DbContext
    {
        public EtuAkademiContext(DbContextOptions<EtuAkademiContext> options)
            : base(options)
        {
        }

        public DbSet<WebProject.Models.Person> Person { get; set; }
        public DbSet<WebProject.Models.Bolum> Bolum { get; set; }
        public DbSet<WebProject.Models.Project> Project { get; set; }


    }
}
