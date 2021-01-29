using MediatR;
using Product.FrontEnd.Business.Commands;
using Product.FrontEnd.Models;
using Product.FrontEnd.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Product.FrontEnd.Business.Commands.OnShowDialog
{
    public sealed class OnShowAddDialogCommandHandler : INotificationHandler<OnShowDialogCommand<AddProductComponentViewModel>>
    {
        Task INotificationHandler<OnShowDialogCommand<AddProductComponentViewModel>>.Handle(OnShowDialogCommand<AddProductComponentViewModel> notification, CancellationToken cancellationToken)
        {
            notification.OnInvokeAction.Invoke((addProductViewModel, OnStateHasChanged) =>
            {
                addProductViewModel.IsDisplay = true;
                addProductViewModel.Product = addProductViewModel.Product ?? new ProductModel();
                OnStateHasChanged?.Invoke();
            });

            return Task.CompletedTask;
        }
    }
}