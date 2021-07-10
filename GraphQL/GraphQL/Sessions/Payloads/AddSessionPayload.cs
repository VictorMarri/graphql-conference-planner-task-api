using GraphQL.Common;
using GraphQL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.GraphQL.Sessions.Payloads
{
    /// <summary>
    /// Retorno de uma operação = Payload
    /// </summary>
    public class AddSessionPayload : Payload 
    {
        public Session? Session { get; }

        public AddSessionPayload(Session session)
        {
            Session = session;
        }

        public AddSessionPayload(UserError error)
            : base(new[] { error })
        {
        }

    }
}
