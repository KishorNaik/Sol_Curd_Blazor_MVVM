using MediatR;
using Product.FrontEnd.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Product.FrontEnd.Business.Commands.ProductGrid
{
    public sealed class OnEditProductCommand : INotification
    {
        public Guid GetGuid { get; set; }

        public ProductGridComponentViewModel ViewModel { get; set; }

        public Action OnStateHasChanged { get; set; }
    }
}