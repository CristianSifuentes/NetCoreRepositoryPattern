using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using repositorypattern.Models;
using System;

namespace repositorypattern.Context
{
    public class EventContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public EventContext(IConfiguration configuration, DbContextOptions options) : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<Comedian> Comedians { get; set; }
        public DbSet<Gig> Gigs { get; set; }
        public DbSet<Venue> Venues { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("ComedyEvent"));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Event>()
                .HasData(new
                {
                    EventId = 1,
                    EventName = "Test",
                    EventDate = new DateTime(2019, 12, 07),
                    VenuId = 1
                });

            builder.Entity<Gig>()
            .HasData(new
            {
                GigId = 1,
                EventId = 1,
                ComedianId = 1,
                GigHeadline = "test",
                GigLengthInMinutes = 60

            },new
            {
                GigId = 2,
                EventId = 1,
                ComedianId = 2,
                GigHeadline = "test2",
                GigLengthInMinutes = 45

            });

            builder.Entity<Comedian>()
    .HasData(new
    {
        ComedianId = 1,
        FirstName = "Test",
        LastName = "Test",
        ContactPhone = "12312312"
    }, new
    {
        ComedianId = 2,
        FirstName = "Test",
        LastName = "Test",
        ContactPhone = "12312312"
    });



        }
    }
}
