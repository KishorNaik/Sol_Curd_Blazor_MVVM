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
    public sealed class OnShowEditDialogCommandHandler : INotificationHandler<OnShowDialogCommand<EditProductComponentViewModel>>
    {
        Task INotificationHandler<OnShowDialogCommand<EditProductComponentViewModel>>.Handle(OnShowDialogCommand<EditProductComponentViewModel> notification, CancellationToken cancellationToken)
        {
            notification.OnInvokeAction.Invoke((editProductComponentViewModel, OnStateHasChanged) =>
            {
                editProductComponentViewModel.IsDisplay = true;
                OnStateHasChanged.Invoke();
            });

            return Task.CompletedTask;
        }
    }
}