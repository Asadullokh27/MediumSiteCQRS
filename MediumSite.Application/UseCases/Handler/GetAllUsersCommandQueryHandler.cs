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
    public class GetAllUsersCommandQueryHandler: IRequestHandler<GetAllUsersCommandQuery, List<User>>
    {

        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetAllUsersCommandQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<User>> Handle(GetAllUsersCommmandQuery request, CancellationToken cancellationToken)
        {
            var users = await _context.Users.ToListAsync();

            return users;
        }

    }
}
