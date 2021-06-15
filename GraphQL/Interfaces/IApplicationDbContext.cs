using GraphQL.Data;
using GraphQL.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Speaker> Speakers { get; }
        DbSet<Attendee> Attendees { get; }
        DbSet<Session> Sessions { get; }
        DbSet<Track> Tracks { get; }
        

    }
}
