using GraphQL.Data;
using GraphQL.Data.Context;
using HotChocolate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.Queries
{
    public class SpeakerQuery
    {
        public IQueryable<Speaker> GetSpeakers([Service] ApplicationDbContext context)
            => context.Speakers;
    }
}
