using GraphQL.Common;
using GraphQL.Constantes;
using GraphQL.Data.Context;
using GraphQL.Data.Models;
using GraphQL.Extensions;
using GraphQL.GraphQL.Sessions.Inputs;
using GraphQL.GraphQL.Sessions.Payloads;
using HotChocolate;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GraphQL.GraphQL.Sessions
{
    [ExtendObjectType(GraphQlConstantes.Mutation_Type)]
    public class SessionMutations
    {
        [UseApplicationDbContext]
        public async Task<AddSessionPayload> AddSessionsAsync(AddSessionInput input, [ScopedService] ApplicationDbContext dbContext, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(input.Title))
            {
                return new AddSessionPayload(
                    new UserError("O Título não pode ser Nulo.", "TITULO_VAZIO"));
            }

            if (input.SpeakerIds.Count == 0)
            {
                return new AddSessionPayload(
                    new UserError("Nenhum Entrevistador (SPEAKER) listado", "ENTREVISTADOR/SPEAKER_VAZIO"));
            }

            var session = new Session
            {
                Title = input.Title,
                Abstract = input.Abstract
            };

            foreach (int speakerId in input.SpeakerIds)
            {
                session.SessionSpeakers.Add(new SessionSpeaker { SessionId = speakerId });
            }

            dbContext.Sessions.Add(session);
            await dbContext.SaveChangesAsync(cancellationToken);

            return new AddSessionPayload(session);
        }
    }
}
