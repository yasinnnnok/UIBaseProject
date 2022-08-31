using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.Context
{
    public  class SimpleContextDb :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //MSİ - EV
            //optionsBuilder.UseSqlServer("Server=DESKTOP-4V1JSR7\\SQLEXPRESS;Database=UIBaseDb;Integrated Security=true;");
            //MONSTER //base yapı 
           optionsBuilder.UseSqlServer("Server=DESKTOP-BVJGQT1\\SQLEXPRESS;Database=UIBaseDb;Integrated Security=true;");

        }

        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
       // public DbSet<EmailParameter> EmailParameters { get; set; }
        //public DbSet<Anakart> Anakarts { get; set; }
        //public DbSet<Cpu> Cpus { get; set; }
        //public DbSet<EkranKarti> EkranKartis { get; set; }
        //public DbSet<Firma> Firmas { get; set; }
        //public DbSet<IsletimSistemi> IsletimSistemis { get; set; }
        //public DbSet<Kategori> Kategoris { get; set; }
        //public DbSet<MarkaModel> MarkaModels { get; set; }
        //public DbSet<Urun> Uruns { get; set; }
        //public DbSet<Verilen> Verilens { get; set; }

    }
}
