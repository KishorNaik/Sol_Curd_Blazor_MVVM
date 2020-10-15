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
    public abstract class AddProductComponentViewModel : ComponentBase
    {
        #region Constructor

        public AddProductComponentViewModel()
        {
            Product = new ProductModel();
        }

        #endregion Constructor

        #region Public Property

        [Parameter]
        public EventCallback RefreshEvent { get; set; }

        [Inject]
        public IProductService ProductServiceObj { get; set; }

        #endregion Public Property

        #region Protected Property

        protected bool IsDisplay { get; set; }

        protected String ErrorMessage { get; set; }

        protected ProductModel Product { get; set; }

        #endregion Protected Property

        #region Private Method

        private async Task<bool> AddProductApiCall()
        {
            return await ProductServiceObj.AddProductApiAsync(this.Product);
        }

        #endregion Private Method

        #region Protected Event Handler

        protected void CancelAddDialog()
        {
            IsDisplay = false;
            Product = null;
            base.StateHasChanged();
            this.RefreshEvent.InvokeAsync("Refresh Event");
        }

        protected async Task OnSubmit(EditContext editContext)
        {
            var flag = editContext?.Validate();
            if (flag == false) return;

            var apiResponse = await this.AddProductApiCall();

            if (apiResponse == true)
            {
                IsDisplay = false;
                Product = null;
                base.StateHasChanged();
                await this.RefreshEvent.InvokeAsync("Refresh Event");
            }
            else
            {
                ErrorMessage = $"{Product.ProductName} product already exists in database";
                base.StateHasChanged();
            }
        }

        #endregion Protected Event Handler

        #region Public Method

        public void ShowAddDialog()
        {
            IsDisplay = true;
            Product = Product ?? new ProductModel();
            base.StateHasChanged();
        }

        #endregion Public Method
    }
}