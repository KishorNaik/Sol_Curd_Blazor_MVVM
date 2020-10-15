using Microsoft.AspNetCore.Components;
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
        #region Public Property

        [Parameter]
        public ProductModel SelectedProduct { get; set; }

        [Inject]
        public IProductService ProductServiceObj { get; set; }

        [Parameter]
        public EventCallback RefreshEvent { get; set; }

        #endregion Public Property

        #region Protected Property

        protected bool IsDisplay { get; set; }

        #endregion Protected Property

        #region Private Method

        private async Task<bool> DeleteProductApiCall()
        {
            return await this.ProductServiceObj?.DeleteProductApiAsync(this.SelectedProduct);
        }

        #endregion Private Method

        #region Protected Event Handler

        protected void OnCancelDeleteDialog()
        {
            IsDisplay = false;
            base.StateHasChanged();
            this.RefreshEvent.InvokeAsync("Refresh Event");
        }

        protected async Task OnYes()
        {
            var apiResponse = await this.DeleteProductApiCall();

            if (apiResponse == true)
            {
                this.IsDisplay = false;
                base.StateHasChanged();
                await this.RefreshEvent.InvokeAsync("Refresh Event");
            }
        }

        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                base.StateHasChanged();
            }
        }

        #endregion Protected Event Handler

        #region Public Method

        public void ShowDeleteDialog()
        {
            IsDisplay = true;
            base.StateHasChanged();
        }

        #endregion Public Method
    }
}