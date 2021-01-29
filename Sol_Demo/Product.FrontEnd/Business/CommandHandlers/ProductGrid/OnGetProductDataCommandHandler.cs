using MediatR;
using Product.FrontEnd.Business.Commands.ProductGrid;
using Product.FrontEnd.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Product.FrontEnd.Business.Commands.ProductGrid
{
    public sealed class OnGetProductDataCommandHandler : INotificationHandler<OnGetProductDataCommand>
    {
        private readonly IProductService productService = null;

        public OnGetProductDataCommandHandler(IProductService productService)
        {
            this.productService = productService;
        }

        async Task INotificationHandler<OnGetProductDataCommand>.Handle(OnGetProductDataCommand notification, CancellationToken cancellationToken)
        {
            try
            {
                notification.ViewModel.ListProducts = (await this.productService?.GetProductsAsync()).ToList();

                if (notification.ViewModel.ListProducts == null || notification.ViewModel.ListProducts?.Count == 0)
                {
                    notification.ViewModel.ErrorMessage = "No Record Found";
                }
            }
            catch
            {
                throw;
            }
        }
    }
}