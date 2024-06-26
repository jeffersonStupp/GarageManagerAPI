﻿using GarageManager.Database.Configs;
using GarageManager.Models;
using GarageManagerAPI.Data.Configs;
using GarageManagerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GarageManager.Database.Contexto
{
    public class GarageManagerContext : DbContext
    {
        public DbSet<Cliente> CLIENTES { get; set; }
        public DbSet<Usuario> USUARIOS { get; set; }
        public DbSet<Produto> PRODUTOS { get; set; }
        public DbSet<Parametrizacao> PARAMETRIZACAO { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-SJ1Q4M7\\SQLEXPRESS;Initial catalog=GARAGEMANAGER;Trusted_connection=true;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteConfig());
            modelBuilder.ApplyConfiguration(new UsuarioConfig());
            modelBuilder.ApplyConfiguration(new ParametrizacaoConfig()); 
            modelBuilder.ApplyConfiguration(new ProdutoConfig());

        }
    }
}