using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.AppDbContext
{
    public class CredentiaDbContext : DbContext
    {

        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<CNA_Application> CNA_Applications { get; set; }
        public CredentiaDbContext(DbContextOptions options) : base(options)
        {
        }

    }
}
