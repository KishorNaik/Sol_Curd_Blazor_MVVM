using MediatR;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Product.FrontEnd.Business.Commands.Shared;
using Product.FrontEnd.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Product.FrontEnd.ViewComponent.Shared
{
    public partial class InputProductComponent
    {
        //private readonly IMediator mediator = null;

        public InputProductComponent()
        {
            OnCancel = () => Mediator.Publish<OnCancelCommand>(new OnCancelCommand() { JSRuntime = this.JSRuntime });
        }

        #region Public Property

        [Parameter]
        public ProductModel Product { get; set; }

        [Parameter]
        public EventCallback OnSubmit { get; set; }

        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        [Inject]
        public IMediator Mediator { get; set; }

        #endregion Public Property

        #region Protected Property

        protected Action OnCancel { get; set; }

        #endregion Protected Property
    }
}