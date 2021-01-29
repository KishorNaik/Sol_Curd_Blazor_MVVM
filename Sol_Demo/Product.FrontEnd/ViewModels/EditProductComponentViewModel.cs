using MediatR;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Product.FrontEnd.Business.Commands;
using Product.FrontEnd.Business.Commands.EditProducts;
using Product.FrontEnd.Business.Commands.Shared;
using Product.FrontEnd.Models;
using Product.FrontEnd.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Product.FrontEnd.ViewModels
{
    public abstract class EditProductComponentViewModel : ComponentBase
    {
        #region Constructor

        public EditProductComponentViewModel()
        {
            this.ShowEditDialog = async () => await Mediator.Publish<OnShowDialogCommand<EditProductComponentViewModel>>(new OnShowDialogCommand<EditProductComponentViewModel>()
            {
                OnInvokeAction = (onShowAction) =>
                {
                    base.InvokeAsync(() =>
                    {
                        onShowAction.Invoke(this, () => base.StateHasChanged());
                    });
                }
            });

            this.CloseDialogCommand = async () => await Mediator.Publish<OnCloselDialogCommand<EditProductComponentViewModel>>(new OnCloselDialogCommand<EditProductComponentViewModel>()
            {
                OnInvokeAction = (onCloseAction) =>
                {
                    base.InvokeAsync(() =>
                    {
                        onCloseAction?.Invoke(this, () => base.StateHasChanged());
                    });
                }
            });

            this.OnEditSubmitCommand = async (editContext) => await Mediator.Publish<OnEditProductSubmitCommand>(new OnEditProductSubmitCommand()
            {
                Edit = editContext,
                ViewModel = this,
                OnStateHasChanged = () => base.StateHasChanged()
            }); ;
        }

        #endregion Constructor

        #region Public Property

        [Parameter]
        public ProductModel SelectedProduct { get; set; }

        [Parameter]
        public EventCallback RefreshEvent { get; set; }

        //[Inject]
        //public IProductService ProductServiceObj { get; set; }

        [Inject]
        public IMediator Mediator { get; set; }

        public Action ShowEditDialog { get; set; }

        #endregion Public Property

        #region Protected Property

        protected internal bool IsDisplay { get; set; }

        protected internal String ErrorMessage { get; set; }

        protected internal Action CloseDialogCommand { get; set; }

        protected Action<EditContext> OnEditSubmitCommand { get; set; }

        #endregion Protected Property

        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                base.StateHasChanged();
            }
        }
    }
}