using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using UcusRez.Models;
using System.Collections.Generic;


namespace UcusRez.Models
{
    public class DbUcus: DbContext
    {
        private readonly IConfiguration _configuration;  

        public DbUcus(IConfiguration configuration)
        {
            _configuration=configuration;
        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Bilet> Bilets { get; set; }
        public DbSet<Giris> Giriss { get; set; }
        public DbSet<Guzergah> Guzergahs { get; set; }
        public DbSet<Kayit> Kayits { get; set; }
        public DbSet<Ucak> Ucaks { get; set; }
        public DbSet<Ucus> Ucuss { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));

            }

        }
    }
}
