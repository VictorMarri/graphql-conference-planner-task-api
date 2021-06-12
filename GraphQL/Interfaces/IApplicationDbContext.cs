using GraphQL.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Speaker> Speakers { get; }
    }
}
