using MediatR;
using Product.FrontEnd.Business.Commands.Shared;
using Product.FrontEnd.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Product.FrontEnd.Business.Commands.Shared.OnCloseDialog
{
    public sealed class OnCloseAddDialogCommandHandler : INotificationHandler<OnCloselDialogCommand<AddProductComponentViewModel>>
    {
        Task INotificationHandler<OnCloselDialogCommand<AddProductComponentViewModel>>.Handle(OnCloselDialogCommand<AddProductComponentViewModel> notification, CancellationToken cancellationToken)
        {
            //notification.OnBaseInvoke.Invoke(() =>
            //{
            //    notification.ViewModel.IsDisplay = false;
            //    notification.ViewModel.Product = null;
            //    notification?.OnStateHasChanged?.Invoke();
            //    notification.ViewModel.RefreshEvent.InvokeAsync("Refresh Event");
            //});

            notification.OnInvokeAction.Invoke((addProductViewModel, OnStateHasChanged) =>
            {
                addProductViewModel.IsDisplay = false;
                addProductViewModel.Product = null;
                OnStateHasChanged.Invoke();
                addProductViewModel.RefreshEvent.InvokeAsync("Refresh Event");
            });

            return Task.CompletedTask;
        }
    }
}