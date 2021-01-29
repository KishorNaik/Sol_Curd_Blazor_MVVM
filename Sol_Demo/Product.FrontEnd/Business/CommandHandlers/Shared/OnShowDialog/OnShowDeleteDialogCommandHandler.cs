using MediatR;
using Product.FrontEnd.Business.Commands;
using Product.FrontEnd.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Product.FrontEnd.Business.CommandHandlers.Shared.OnShowDialog
{
    public sealed class OnShowDeleteDialogCommandHandler : INotificationHandler<OnShowDialogCommand<DeleteProductComponentViewModel>>
    {
        Task INotificationHandler<OnShowDialogCommand<DeleteProductComponentViewModel>>.Handle(OnShowDialogCommand<DeleteProductComponentViewModel> notification, CancellationToken cancellationToken)
        {
            notification.OnInvokeAction.Invoke((deleteProductComponentViewModel, OnStateHasChanged) =>
            {
                deleteProductComponentViewModel.IsDisplay = true;
                OnStateHasChanged.Invoke();
            });

            return Task.CompletedTask;
        }
    }
}