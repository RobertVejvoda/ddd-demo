using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Inf.Booking.Api.Application.Commands
{
    public interface ICommandHandler<T> where T : ICommand
    {
        Task<int> HandleAsync(T message, CancellationToken cancellationToken = default);
    }
}
