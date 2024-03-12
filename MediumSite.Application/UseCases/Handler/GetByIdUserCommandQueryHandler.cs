using AutoMapper;
using MediatR;
using MediumSite.Application.Abstractions;
using MediumSite.Application.UseCases.Queries;
using MediumSite.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediumSite.Application.UseCases.Handler
{
    public class GetByIdUserCommandQueryHandler: IRequestHandler<GetByIdUserCommandQuery, User>
    {

        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetByIdUserCommandQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<User> Handle(GetByIdUserCommandQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == request.Id && x.IsDeleted != true);

            return user;
        }

    }
}
