using MediatR;
using Product.FrontEnd.Business.Commands.ProductGrid;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Product.FrontEnd.Business.Commands.ProductGrid
{
    public sealed class OnLoadProductRenderCommandHandler : INotificationHandler<OnLoadProductRenderCommand>
    {
        private readonly IMediator mediator = null;

        public OnLoadProductRenderCommandHandler(IMediator mediator)
        {
            this.mediator = mediator;
        }

        async Task INotificationHandler<OnLoadProductRenderCommand>.Handle(OnLoadProductRenderCommand notification, CancellationToken cancellationToken)
        {
            await Task.Delay(1000);

            await mediator.Publish<OnGetProductDataCommand>(new OnGetProductDataCommand()
            {
                ViewModel = notification.ViewModel
            });

            notification.ViewModel.IsLoad = true;

            notification.OnStateHasChanged.Invoke();
        }
    }
}