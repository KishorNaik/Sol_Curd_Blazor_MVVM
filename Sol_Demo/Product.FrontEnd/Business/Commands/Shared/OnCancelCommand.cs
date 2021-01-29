using MediatR;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Text;

namespace Product.FrontEnd.Business.Commands.Shared
{
    public sealed class OnCancelCommand : INotification
    {
        public IJSRuntime JSRuntime { get; set; }
    }
}