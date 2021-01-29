using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using Product.FrontEnd.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Product.FrontEnd.Business.Commands.AddProducts
{
    public sealed class OnAddProductSubmitCommand : INotification
    {
        public EditContext Edit { get; set; }

        public AddProductComponentViewModel ViewModel { get; set; }

        public Action OnStateHasChanged { get; set; }
    }
}