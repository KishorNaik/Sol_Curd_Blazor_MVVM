using MediatR;
using Product.FrontEnd.Business.Commands.EditProducts;
using Product.FrontEnd.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Product.FrontEnd.Business.CommandHandlers.EditProducts
{
    public sealed class OnEditProductSubmitCommandHandler : INotificationHandler<OnEditProductSubmitCommand>
    {
        private readonly IProductService productService = null;

        public OnEditProductSubmitCommandHandler(IProductService productService)
        {
            this.productService = productService;
        }

        async Task INotificationHandler<OnEditProductSubmitCommand>.Handle(OnEditProductSubmitCommand notification, CancellationToken cancellationToken)
        {
            var flag = notification.Edit?.Validate();
            if (flag == false) return;

            var apiResponse = await this.productService.UpdateProductApiAsync(notification.ViewModel.SelectedProduct);

            if (apiResponse == true)
            {
                notification.ViewModel.IsDisplay = false;
                notification.OnStateHasChanged.Invoke();
                await notification.ViewModel.RefreshEvent.InvokeAsync("Refresh Event");
            }
            else
            {
                notification.ViewModel.ErrorMessage = $"{notification.ViewModel.SelectedProduct.ProductName} product already exists in database";
                notification.OnStateHasChanged.Invoke();
            }
        }
    }
}