﻿using AutoMapper;
using MediatR;
using MediumSite.Application.Abstractions;
using MediumSite.Application.UseCases.Commands;
using MediumSite.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediumSite.Application.UseCases.Handler
{
    public class CreateUserCommandHandler: AsyncRequestHandler<CreateUserCommand>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;
        public CreateUserCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
        {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
        }

        //Something

        protected async override Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request);
            await _applicationDbContext.Users.AddAsync(user);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);
        }

    }
}
