using GraphQL.Data.Models;
using GraphQL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.Data.Context
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<Speaker> Speakers { get; set; } = default!;

        public DbSet<Attendee> Attendees { get; set; } = default!;

        public DbSet<Session> Sessions { get; set; } = default!;

        public DbSet<Track> Tracks { get; set; } = default!;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Attendee>()
                .HasIndex(a => a.UserName)
                .IsUnique();

            //Muitos-para-Muitos: Session <--> Attendee
            modelBuilder
                .Entity<SessionAttendee>()
                .HasKey(sa => new { sa.SessionId, sa.AttendeeId });

            //Muitos-para-muitos = Speaker <--> Sessions
            modelBuilder
                .Entity<SessionSpeaker>()
                .HasKey(ss => new { ss.SessionId, ss.SpeakerId });
        }

       
    }
}
