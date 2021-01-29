using MediatR;
using Product.FrontEnd.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Product.FrontEnd.Business.Commands.ProductGrid
{
    public sealed class OnGetProductDataCommand : INotification
    {
        public ProductGridComponentViewModel ViewModel { get; set; }
    }
}