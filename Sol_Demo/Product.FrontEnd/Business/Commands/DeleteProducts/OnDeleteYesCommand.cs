using MediatR;
using Product.FrontEnd.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Product.FrontEnd.Business.Commands.DeleteProducts
{
    public sealed class OnDeleteYesCommand : INotification
    {
        public DeleteProductComponentViewModel ViewModel { get; set; }

        public Action OnStateHasChanged { get; set; }
    }
}