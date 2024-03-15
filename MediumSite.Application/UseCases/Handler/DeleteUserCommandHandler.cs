using AutoMapper;
using MediatR;
using MediumSite.Application.Abstractions;
using MediumSite.Application.UseCases.Commands;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediumSite.Application.UseCases.Handler
{
    public class DeleteUserCommandHandler: AsyncRequestHandler<DeleteUserCommand>
    {

        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public DeleteUserCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == request.Id && x.IsDeleted != true);

            _context.Users.Remove(user);

            await _context.SaveChangesAsync();
        }


    }
}
