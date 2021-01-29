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
    public sealed class OnCloseEditDialogCommmandHandler : INotificationHandler<OnCloselDialogCommand<EditProductComponentViewModel>>
    {
        Task INotificationHandler<OnCloselDialogCommand<EditProductComponentViewModel>>.Handle(OnCloselDialogCommand<EditProductComponentViewModel> notification, CancellationToken cancellationToken)
        {
            notification.OnInvokeAction.Invoke((editProductComponentViewModel, OnStateHasChanged) =>
            {
                editProductComponentViewModel.IsDisplay = false;
                OnStateHasChanged.Invoke();
                editProductComponentViewModel.RefreshEvent.InvokeAsync("Refresh");
            });

            return Task.CompletedTask;
        }
    }
}