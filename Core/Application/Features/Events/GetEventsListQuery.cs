using Core.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Features.Events
{
    public class GetEventsListQuery : IRequest<List<SportEvent>>
    {
    }
}
