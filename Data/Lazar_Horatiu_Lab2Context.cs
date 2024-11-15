using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Lazar_Horatiu_Lab2.Models;

namespace Lazar_Horatiu_Lab2.Data
{
    public class Lazar_Horatiu_Lab2Context : DbContext
    {
        public Lazar_Horatiu_Lab2Context (DbContextOptions<Lazar_Horatiu_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Lazar_Horatiu_Lab2.Models.Book> Book { get; set; } = default!;
        public DbSet<Lazar_Horatiu_Lab2.Models.Publisher> Publisher { get; set; } = default!;
        public DbSet<Lazar_Horatiu_Lab2.Models.Author> Author { get; set; } = default!;
    }
}
