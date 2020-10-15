using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
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
        #region Public Property

        [Parameter]
        public ProductModel SelectedProduct { get; set; }

        [Parameter]
        public EventCallback RefreshEvent { get; set; }

        [Inject]
        public IProductService ProductServiceObj { get; set; }

        #endregion Public Property

        #region Protected Property

        protected bool IsDisplay { get; set; }

        protected String ErrorMessage { get; set; }

        #endregion Protected Property

        #region Private Method

        private async Task<bool> EditUpdateApiCall()
        {
            return await this.ProductServiceObj?.UpdateProductApiAsync(this.SelectedProduct);
        }

        #endregion Private Method

        #region Public Method

        public void ShowEditDialog()
        {
            IsDisplay = true;
            base.StateHasChanged();
        }

        #endregion Public Method

        #region Protected Event Handler

        protected void CancelEditDialog()
        {
            IsDisplay = false;
            base.StateHasChanged();
            RefreshEvent.InvokeAsync("Refresh");
        }

        protected async Task OnSubmit(EditContext editContext)
        {
            var flag = editContext?.Validate();
            if (flag == false) return;

            var apiResponse = await this.EditUpdateApiCall();

            if (apiResponse == true)
            {
                IsDisplay = false;
                base.StateHasChanged();
                await this.RefreshEvent.InvokeAsync("Refresh Event");
            }
            else
            {
                ErrorMessage = $"{SelectedProduct.ProductName} product already exists in database";
                base.StateHasChanged();
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
    }
}