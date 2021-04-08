using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamAspNet.Models.Context
{
    public class ExamContext : IdentityDbContext<User, Role, Guid>
    {
        public ExamContext(DbContextOptions<ExamContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Match> Matches { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

    }
}
