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
    public sealed class OnDeleteProductCommandHandler : INotificationHandler<OnDeleteProductCommand>
    {
        Task INotificationHandler<OnDeleteProductCommand>.Handle(OnDeleteProductCommand notification, CancellationToken cancellationToken)
        {
            notification.ViewModel.SelectedProduct =
             notification
                 ?.ViewModel
                 ?.ListProducts
                 ?.FirstOrDefault((productModel) => productModel.ProductIdentity == notification.GetGuid);

            notification.OnStateHasChanged.Invoke();

            notification.ViewModel.DeleteProductVM.ShowDeleteDialog.Invoke();

            return Task.CompletedTask;
        }
    }
}