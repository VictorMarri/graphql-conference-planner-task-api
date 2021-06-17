using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.Common
{
    public class UserError
    {
        public string Message { get; }
        public string Code { get; }

        public UserError(string message, string code)
        {
            Message = message;
            Code = code;
        }
    }
}
