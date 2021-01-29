using MediatR;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Product.FrontEnd.Business.Commands.Shared;

namespace Product.FrontEnd.Business.Commands.Shared
{
    public sealed class OnCancelCommandHandler : INotificationHandler<OnCancelCommand>
    {
        async Task INotificationHandler<OnCancelCommand>.Handle(OnCancelCommand notification, CancellationToken cancellationToken)
        {
            try
            {
                await notification.JSRuntime.InvokeVoidAsync(identifier: "onCancel");
            }
            catch
            {
                throw;
            }
        }
    }
}