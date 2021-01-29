using MediatR;
using Microsoft.AspNetCore.Components;
using Product.FrontEnd.Business.Commands;
using Product.FrontEnd.Business.Commands.DeleteProducts;
using Product.FrontEnd.Business.Commands.Shared;
using Product.FrontEnd.Models;
using Product.FrontEnd.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Product.FrontEnd.ViewModels
{
    public abstract class DeleteProductComponentViewModel : ComponentBase
    {
        #region Constructor

        public DeleteProductComponentViewModel()
        {
            this.ShowDeleteDialog = async () => await Mediator.Publish<OnShowDialogCommand<DeleteProductComponentViewModel>>(
                new OnShowDialogCommand<DeleteProductComponentViewModel>()
                {
                    OnInvokeAction = (onShowAction) =>
                    {
                        base.InvokeAsync(() =>
                        {
                            onShowAction.Invoke(this, () => base.StateHasChanged());
                        });
                    }
                });

            this.CloseDialogCommand = async () => await Mediator.Publish<OnCloselDialogCommand<DeleteProductComponentViewModel>>(new OnCloselDialogCommand<DeleteProductComponentViewModel>()
            {
                OnInvokeAction = (onCloseAction) =>
                {
                    base.InvokeAsync(() =>
                    {
                        onCloseAction.Invoke(this, () => base.StateHasChanged());
                    });
                }
            });

            this.YesCommand = async () => await Mediator.Publish<OnDeleteYesCommand>(new OnDeleteYesCommand()
            {
                ViewModel = this,
                OnStateHasChanged = () => base.StateHasChanged()
            });
        }

        #endregion Constructor

        #region Public Property

        [Parameter]
        public ProductModel SelectedProduct { get; set; }

        [Inject]
        public IMediator Mediator { get; set; }

        [Parameter]
        public EventCallback RefreshEvent { get; set; }

        public Action ShowDeleteDialog { get; set; }

        #endregion Public Property

        #region Protected Property

        protected internal bool IsDisplay { get; set; }

        protected Action CloseDialogCommand { get; set; }

        protected Action YesCommand { get; set; }

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