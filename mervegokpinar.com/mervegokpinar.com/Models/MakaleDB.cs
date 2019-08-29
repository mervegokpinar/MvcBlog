using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;



namespace mervegokpinar.com.Models
{
    public class MakaleDB:DbContext
    {
        public MakaleDB()
        {
          base.Database.Connection.ConnectionString= "server=IZM-IT004\\SQLEXPRESS;database=mervegokpinar;uid=sa;pwd=Merve35.";
        }
        public DbSet<Makale> Makales { get; set; }
    }
}