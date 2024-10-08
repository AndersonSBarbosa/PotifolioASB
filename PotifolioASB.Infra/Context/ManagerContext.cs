﻿using PotifolioASB.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace PotifolioASB.Repository.Context
{
    public class ManagerContext : DbContext
    {
        public ManagerContext()
        { }

        public ManagerContext(DbContextOptions<ManagerContext> options) : base(options)
        { }

        public DbSet<Fluxo> Fluxo { get; set; }
        public DbSet<Responsavel> Responsavel { get; set; }
        public DbSet<Ocorrencia> Ocorrencia { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
