using MediatR;
using Product.FrontEnd.Business.Commands.AddProducts;
using Product.FrontEnd.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Product.FrontEnd.Business.CommandHandlers.AddProducts
{
    public sealed class OnAddProductSubmitCommandHandler : INotificationHandler<OnAddProductSubmitCommand>
    {
        private readonly IProductService productService = null;

        public OnAddProductSubmitCommandHandler(IProductService productService)
        {
            this.productService = productService;
        }

        async Task INotificationHandler<OnAddProductSubmitCommand>.Handle(OnAddProductSubmitCommand notification, CancellationToken cancellationToken)
        {
            var flag = notification.Edit?.Validate();
            if (flag == false) return;

            var apiResponse = await this.productService.AddProductApiAsync(notification.ViewModel.Product);

            if (apiResponse == true)
            {
                notification.ViewModel.IsDisplay = false;
                notification.ViewModel.Product = null;
                notification.OnStateHasChanged.Invoke();
                await notification.ViewModel.RefreshEvent.InvokeAsync("Refresh Event");
            }
            else
            {
                notification.ViewModel.ErrorMessage = $"{notification.ViewModel.Product.ProductName} product already exists in database";
                notification.OnStateHasChanged.Invoke();
            }
        }
    }
}