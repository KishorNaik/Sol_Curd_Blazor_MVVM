using MediatR;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace Product.FrontEnd.Business.Commands.Shared
{
    public class OnCloselDialogCommand<TViewModel> : INotification where TViewModel : ComponentBase
    {
        //public TViewModel ViewModel { get; set; }

        //public Action OnStateHasChanged { get; set; }

        //public Action<Action> OnBaseInvoke { get; set; }

        public Action<Action<TViewModel, Action>> OnInvokeAction { get; set; }
    }
}