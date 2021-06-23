using GraphQL.Constantes;
using GraphQL.Data;
using GraphQL.Data.Context;
using GraphQL.Extensions;
using GraphQL.Inputs;
using GraphQL.Payloads;
using HotChocolate;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.Mutations
{
    //public const string Mutation = "Mutation" -> Constantes
    [ExtendObjectType(GraphQlConstantes.Mutation_Type)]
    public class SpeakerMutations
    {
        [UseApplicationDbContext]
        public async Task<AddSpeakerPayload> AddSpeaker(
            AddSpeakerInput input, 
            [ScopedService] ApplicationDbContext context)
        {
            var speaker = new Speaker
            {
                Name = input.Name,
                Bio = input.Bio,
                WebSite = input.WebSite
            };

            context.Speakers.Add(speaker);
            await context.SaveChangesAsync();

            return new AddSpeakerPayload(speaker);
        }
    }
}
