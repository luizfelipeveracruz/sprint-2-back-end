using Microsoft.EntityFrameworkCore;
using senai.hroads.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Context
{
    public class HRoadsContext : DbContext
    {

        public DbSet<TipoHabilidade> TipoHabilidade { get; set; }

        public DbSet<TipoUsuario> TipoUsuarios { get; set; }

        public DbSet<InfoClasse> InfoClasses { get; set; }

        public DbSet<Habilidade> Habilidades { get; set; }

        public DbSet<Classe> Classes { get; set; }

        public DbSet<Personagem> Personagems { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=NOTE0113H4\\SQLEXPRESS ; Database=senai.hroads.webApi; user ID=sa; pwd=Senai@132");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<TipoUsuario>().HasData(

                new TipoUsuario
                {
                    idTipoUsuario = 2,
                    titulo = "Administrador"
                },

                new TipoUsuario
                {
                    idTipoUsuario = 4,
                    titulo = "Cliente"
                }

                );

            modelBuilder.Entity<Usuario>().HasData(

                    new Usuario
                    {
                        idUsuarios = 1,
                        email = "admin@admin.com",
                        senha = "admin",
                        idTipoUsuario = 2
                    },

                    new Usuario
                    {
                        idUsuarios = 2,
                        email = "cliente@cliente.com",
                        senha = "cliente",
                        idTipoUsuario = 4
                    }
                    );

            base.OnModelCreating(modelBuilder);
        }
    }
}
