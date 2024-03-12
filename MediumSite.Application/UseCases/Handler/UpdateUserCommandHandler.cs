using AutoMapper;
using MediatR;
using MediumSite.Application.Abstractions;
using MediumSite.Application.UseCases.Commands;
using MediumSite.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediumSite.Application.UseCases.Handler
{
    public class UpdateUserCommandHandler: IRequestHandler<UpdateUserCommand, User>
    {

        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public UpdateUserCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<User> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == request.Id && x.IsDeleted != true);

            if (user is not null)
            {
                user.ModifiedDate = DateTime.UtcNow;
                user.Name = request.Name;
                user.UserName = request.UserName;
                user.Email = request.Email;
                user.Bio = request.Bio;
                user.PhotoPath = request.PhotoPath;
                user.FollowersCount = request.FollowersCount;
                user.Login = request.Login;
                user.Password = request.Password;

                await _context.SaveChangesAsync();

            }

            return null;
        }

    }
}
