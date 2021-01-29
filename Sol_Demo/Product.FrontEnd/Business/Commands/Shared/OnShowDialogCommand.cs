using MediatR;
using Product.FrontEnd.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Product.FrontEnd.Business.Commands
{
    public sealed class OnShowDialogCommand<TViewModel> : INotification
    {
        public Action<Action<TViewModel, Action>> OnInvokeAction { get; set; }
    }
}