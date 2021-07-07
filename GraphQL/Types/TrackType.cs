using GraphQL.Data.Context;
using GraphQL.Data.Models;
using GraphQL.DataLoader;
using GraphQL.Extensions;
using HotChocolate;
using HotChocolate.Resolvers;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GraphQL.Types
{
    public class TrackType : ObjectType<Track>
    {
        protected override void Configure(IObjectTypeDescriptor<Track> descriptor)
        {
            //Implementando o Node e os resolvers padrão para organização do json da request graphql de acordo com o DataLoader do type
            descriptor
                .ImplementsNode()
                .IdField(t => t.Id)
                .ResolveNode((ctx, id) => ctx.DataLoader<TrackByIdDataLoader>().LoadAsync(id, ctx.RequestAborted));

            descriptor
                .Field(t => t.Sessions)
                .ResolveWith<TrackResolvers>(t => t.GetSessionsAsync(default!, default!, default!, default!))
                .UseDbContext<ApplicationDbContext>()
                .Name("sessions");
        }

        private class TrackResolvers
        {
            public async Task<IEnumerable<Session>> GetSessionsAsync(
                Track track,
                [ScopedService] ApplicationDbContext dbContext,
                SessionByIdDataLoader sessionById,
                CancellationToken cancellationToken)
            {
                int[] sessionIds = await dbContext.Sessions
                    .Where(s => s.Id == track.Id)
                    .Select(s => s.Id)
                    .ToArrayAsync();

                return await sessionById.LoadAsync(sessionIds, cancellationToken);
            }
        }
    }
}
