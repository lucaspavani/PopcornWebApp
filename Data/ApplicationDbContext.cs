using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using PopcornWebApp.Models;

namespace PopcornWebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<PopcornWebApp.Models.Movies> Movies { get; set; }
        public DbSet<PopcornWebApp.Models.Rooms> Rooms { get; set; }
        public DbSet<PopcornWebApp.Models.AnimationTypes> AnimationTypes { get; set; }
        public DbSet<PopcornWebApp.Models.AudioTypes> AudioTypes { get; set; }
        public DbSet<PopcornWebApp.Models.Sessions> Sessions { get; set; }
    }
}
