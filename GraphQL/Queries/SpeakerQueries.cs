using GraphQL.Data;
using GraphQL.Data.Context;
using GraphQL.DataLoader;
using GraphQL.Extensions;
using HotChocolate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GraphQL.Queries
{
    public class SpeakerQueries
    {
        [UseApplicationDbContext]
        public Task<List<Speaker>> GetSpeakers([ScopedService] ApplicationDbContext context) // =>
        {
             return context.Speakers.ToListAsync();
        }

        public Task<Speaker> GetSpeakerAsync(int id, SpeakerByIdDataLoader dataLoader, CancellationToken cancellationToken)
        {
            return dataLoader.LoadAsync(id, cancellationToken);
        }
    }
}
