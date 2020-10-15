using Microsoft.AspNetCore.Components;
using Product.FrontEnd.Models;
using Product.FrontEnd.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.FrontEnd.ViewModels
{
    public abstract class ProductGridComponentViewModel : ComponentBase
    {
        #region Public  Property

        [Inject]
        public IProductService ProductServiceObj { get; set; }

        #endregion Public  Property

        #region Protected Property

        protected bool IsLoad { get; set; }

        protected List<ProductModel> ListProducts { get; set; }

        protected AddProductComponentViewModel AddProductVM { get; set; }

        protected EditProductComponentViewModel EditProductVM { get; set; }

        protected DeleteProductComponentViewModel DeleteProductVM { get; set; }

        protected ProductModel SelectedProduct { get; set; }

        protected String ErrorMessage { get; set; }

        #endregion Protected Property

        #region Private Method

        private async Task GetProductDataAsync()
        {
            try
            {
                ListProducts = (await ProductServiceObj?.GetProductsAsync()).ToList();

                if (ListProducts == null || ListProducts?.Count == 0)
                {
                    ErrorMessage = "No Record Found";
                }
            }
            catch
            {
                throw;
            }
        }

        private ProductModel FilterProduct(Guid guid)
        {
            return ListProducts
                                ?.FirstOrDefault((productModel) => productModel.ProductIdentity == guid);
        }

        #endregion Private Method

        #region Protected Event Handler

        protected async Task RefreshState()
        {
            await GetProductDataAsync();

            base.StateHasChanged();
        }

        protected void OnAdd()
        {
            AddProductVM.ShowAddDialog();
        }

        protected void OnEdit(Guid guid)
        {
            this.SelectedProduct = this.FilterProduct(guid);
            base.StateHasChanged();

            EditProductVM.ShowEditDialog();
        }

        protected void OnDelete(Guid guid)
        {
            this.SelectedProduct = this.FilterProduct(guid);
            base.StateHasChanged();

            DeleteProductVM.ShowDeleteDialog();
        }

        protected async override Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await Task.Delay(1000);

                await this.GetProductDataAsync();

                IsLoad = true;

                base.StateHasChanged();
            }
        }

        #endregion Protected Event Handler
    }
}