using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cars.Domain;
using Cars.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cars.Application
{
    
    public class List
    {
        public class Query : IRequest<List<Car>>;


        public class Handler: IRequestHandler<Query, List<Car>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<Car>> Handle(Query Request, CancellationToken cancellationToken)
            {
                return await _context.Cars.ToListAsync();
            }
        }
    }
}
