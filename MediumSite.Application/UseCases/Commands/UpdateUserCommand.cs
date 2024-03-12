using MediatR;
using MediumSite.Domain.DTOs;
using MediumSite.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediumSite.Application.UseCases.Commands
{
    public class UpdateUserCommand : UserDTO, IRequest<User>
    {

        public Guid Id { get; set; }

    }
}
