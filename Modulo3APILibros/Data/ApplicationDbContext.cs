﻿using Microsoft.EntityFrameworkCore;
using Modulo3APILibros.Entities;

namespace Modulo3APILibros.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }

        public DbSet<Libro> Libros { get; set; }
        public DbSet<Autor> Autores { get; set; }
    }
}
