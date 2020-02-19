using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using test.Entidades;

namespace test.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Personas> Personas { get; set; }
        public DbSet<Inscripciones> Inscripciones { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source= Persona.db");
        }
    }
}
