using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MBY.Models;

namespace MBY.Models
{
    public class DBMBYDesignStudio : DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Ekip> Ekips { get; set; }
        public DbSet<Proje> Projes { get; set; }
        public DbSet<Iletisim> Iletisims { get; set; }
        public DbSet<Commination> Comminations { get; set; }
        public DbSet<Hakkimizda> Hakkimizdas { get; set; }

        public DBMBYDesignStudio(): base("DBMBYDesignStudio")
        {
            Database.SetInitializer(new Veritabaniolusturucu());
        }

        public class Veritabaniolusturucu : CreateDatabaseIfNotExists<DBMBYDesignStudio>
        {
            protected override void Seed(DBMBYDesignStudio context)
            {
                base.Seed(context);
            }
        }
    }
}