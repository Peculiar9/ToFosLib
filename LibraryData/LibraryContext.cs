using LibraryData.EntityModels;
using Microsoft.EntityFrameworkCore;
using System;

namespace LibraryData
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) 
        {

        }

        public DbSet<Patron> Patrons { get; set; }
    }
}
