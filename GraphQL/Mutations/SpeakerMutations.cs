﻿using GraphQL.Data;
using GraphQL.Data.Context;
using GraphQL.Inputs;
using GraphQL.Payloads;
using HotChocolate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.Mutations
{
    public class SpeakerMutations
    {
        public async Task<AddSpeakerPayload> AddSpeaker(AddSpeakerInput input, [Service] ApplicationDbContext context)
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