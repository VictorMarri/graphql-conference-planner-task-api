﻿using GraphQL.Constantes;
using GraphQL.Data;
using GraphQL.Data.Context;
using GraphQL.DataLoader;
using GraphQL.Extensions;
using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Types.Relay;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GraphQL.Queries
{
    [ExtendObjectType(GraphQlConstantes.Query_Type)]
    public class SpeakerQueries
    {
        [UseApplicationDbContext]
        public Task<List<Speaker>> GetSpeakers([ScopedService] ApplicationDbContext context) // =>
        {
             return context.Speakers.ToListAsync();
        }

        public Task<Speaker> GetSpeakerAsync(
            [ID(nameof(Speaker))]int id, //Descrevendo pra engine de execução que esse aqui vai ser o ID 'Oficial' da entidade
            SpeakerByIdDataLoader dataLoader, 
            CancellationToken cancellationToken)
        {
            return dataLoader.LoadAsync(id, cancellationToken);
        }
    }
}
