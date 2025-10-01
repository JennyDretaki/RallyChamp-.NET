using Microsoft.EntityFrameworkCore;
using RallyChampAPI.Entities;
using System;

namespace RallyChampAPI.DBContext
{
    public class RallyChampContext : DbContext
    {
        public RallyChampContext(DbContextOptions<RallyChampContext> options)
            : base(options)
        {
        }

        public DbSet<Race> Races { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Result> Results { get; set; }
    }
}