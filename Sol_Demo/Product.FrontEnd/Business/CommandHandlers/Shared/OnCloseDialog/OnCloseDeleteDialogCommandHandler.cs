using MediatR;
using Product.FrontEnd.Business.Commands.Shared;
using Product.FrontEnd.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Product.FrontEnd.Business.CommandHandlers.Shared.OnCloseDialog
{
    public sealed class OnCloseDeleteDialogCommandHandler : INotificationHandler<OnCloselDialogCommand<DeleteProductComponentViewModel>>
    {
        Task INotificationHandler<OnCloselDialogCommand<DeleteProductComponentViewModel>>.Handle(OnCloselDialogCommand<DeleteProductComponentViewModel> notification, CancellationToken cancellationToken)
        {
            notification.OnInvokeAction.Invoke((deleteProductComponentViewModel, OnStateHasChanged) =>
            {
                deleteProductComponentViewModel.IsDisplay = false;
                OnStateHasChanged.Invoke();
                deleteProductComponentViewModel.RefreshEvent.InvokeAsync("Refresh");
            });

            return Task.CompletedTask;
        }
    }
}