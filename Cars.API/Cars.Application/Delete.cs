using Cars.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Application
{
    public class Delete
    {
        public class DeleteCommand : IRequest<Car>
        {
            public Guid Id { get; set; }
        }

        public class  Handler : IRequestHandler<DeleteCommand, Car>
        {
            
        }
    }
}
