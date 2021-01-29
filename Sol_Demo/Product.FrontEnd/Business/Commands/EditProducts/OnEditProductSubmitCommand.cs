using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using Product.FrontEnd.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Product.FrontEnd.Business.Commands.EditProducts
{
    public sealed class OnEditProductSubmitCommand : INotification
    {
        public EditContext Edit { get; set; }

        public EditProductComponentViewModel ViewModel { get; set; }

        public Action OnStateHasChanged { get; set; }
    }
}