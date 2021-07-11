using GraphQL.Data.Models;
using HotChocolate.Types.Relay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.GraphQL.Sessions.Inputs
{
    public record ScheduleSessionInput(
        [ID(nameof(Session))]
        int SessionId,
        [ID(nameof(Track))]
        int TrackId,
        DateTimeOffset StartTime,
        DateTimeOffset EndTime);
    
}
