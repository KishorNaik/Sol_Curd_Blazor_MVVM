using MediatR;
using Product.FrontEnd.Business.Commands.DeleteProducts;
using Product.FrontEnd.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Product.FrontEnd.Business.CommandHandlers.DeleteProducts
{
    public sealed class OnDeleteYesCommandHandler : INotificationHandler<OnDeleteYesCommand>
    {
        private readonly IProductService productService = null;

        public OnDeleteYesCommandHandler(IProductService productService)
        {
            this.productService = productService;
        }

        async Task INotificationHandler<OnDeleteYesCommand>.Handle(OnDeleteYesCommand notification, CancellationToken cancellationToken)
        {
            var apiResponse = await this.productService.DeleteProductApiAsync(notification.ViewModel.SelectedProduct);

            if (apiResponse == true)
            {
                notification.ViewModel.IsDisplay = false;
                notification.OnStateHasChanged();
                await notification.ViewModel.RefreshEvent.InvokeAsync("Refresh Event");
            }
        }
    }
}