using GraphQL.Common;
using GraphQL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.GraphQL.Sessions.Payloads
{
    public class SessionPayloadBase : Payload
    {
        public Session? Session { get; set; }
        protected SessionPayloadBase(Session session)
        {
            Session = session;
        }

        protected SessionPayloadBase(IReadOnlyList<UserError> errors) : base(errors)
        {
        }

    }
}
