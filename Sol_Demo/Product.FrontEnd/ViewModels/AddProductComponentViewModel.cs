using MediatR;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Product.FrontEnd.Business.Commands;
using Product.FrontEnd.Business.Commands.AddProducts;
using Product.FrontEnd.Business.Commands.Shared;
using Product.FrontEnd.Models;
using Product.FrontEnd.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Product.FrontEnd.ViewModels
{
    public abstract class AddProductComponentViewModel : ComponentBase
    {
        #region Constructor

        public AddProductComponentViewModel()
        {
            Product = new ProductModel();
            this.CloseDialogCommand = async () => await Mediator.Publish<OnCloselDialogCommand<AddProductComponentViewModel>>(new OnCloselDialogCommand<AddProductComponentViewModel>()
            {
                //ViewModel = this,
                //OnStateHasChanged = () => base.StateHasChanged(),
                //OnBaseInvoke = (self) =>
                //{
                //    base.InvokeAsync(() =>
                //    {
                //        self.Invoke();
                //    });
                //},
                OnInvokeAction = (onCancelAction) =>
                {
                    base.InvokeAsync(() =>
                    {
                        onCancelAction.Invoke(this, () => base.StateHasChanged());
                    });
                }
            });

            this.ShowAddDialog = async () => await Mediator.Publish<OnShowDialogCommand<AddProductComponentViewModel>>(new OnShowDialogCommand<AddProductComponentViewModel>()
            {
                OnInvokeAction = (onShowAction) =>
                {
                    base.InvokeAsync(() =>
                    {
                        onShowAction.Invoke(this, () => base.StateHasChanged());
                    });
                }
            });

            this.OnSubmitCommand = async (editContext) =>
            {
                await this.Mediator.Publish<OnAddProductSubmitCommand>(new OnAddProductSubmitCommand()
                {
                    Edit = editContext,
                    ViewModel = this,
                    OnStateHasChanged = () => base.StateHasChanged()
                });
            };
        }

        #endregion Constructor

        #region Public Property

        [Parameter]
        public EventCallback RefreshEvent { get; set; }

        [Inject]
        public IMediator Mediator { get; set; }

        public Action ShowAddDialog { get; set; }

        #endregion Public Property

        #region Protected Property

        protected internal bool IsDisplay { get; set; }

        protected internal String ErrorMessage { get; set; }

        protected internal ProductModel Product { get; set; }

        protected Action CloseDialogCommand { get; set; }

        protected Action<EditContext> OnSubmitCommand { get; set; }

        #endregion Protected Property
    }
}