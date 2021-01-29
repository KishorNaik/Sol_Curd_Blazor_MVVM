using MediatR;
using Product.FrontEnd.Business.Commands.ProductGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Product.FrontEnd.Business.CommandHandlers.ProductGrid
{
    public sealed class OnEditProductCommandHandler : INotificationHandler<OnEditProductCommand>
    {
        Task INotificationHandler<OnEditProductCommand>.Handle(OnEditProductCommand notification, CancellationToken cancellationToken)
        {
            notification.ViewModel.SelectedProduct =
             notification
                 ?.ViewModel
                 ?.ListProducts
                 ?.FirstOrDefault((productModel) => productModel.ProductIdentity == notification.GetGuid);

            notification.OnStateHasChanged.Invoke();

            notification.ViewModel.EditProductVM.ShowEditDialog.Invoke();

            return Task.CompletedTask;
        }
    }
}