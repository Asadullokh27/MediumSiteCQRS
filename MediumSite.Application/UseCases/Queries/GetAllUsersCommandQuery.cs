using MediatR;
using MediumSite.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediumSite.Application.UseCases.Queries
{
    public class GetAllUsersCommandQuery: IRequest<List<User>>
    {
    }
}
