using MediatR;
using Microsoft.AspNetCore.Components;
using Product.FrontEnd.Business.Commands.ProductGrid;
using Product.FrontEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.FrontEnd.ViewModels
{
    public abstract class ProductGridComponentViewModel : ComponentBase
    {
        #region Constructor

        public ProductGridComponentViewModel()
        {
            this.ShowAddProductDialogCommand = () => AddProductVM.ShowAddDialog.Invoke();

            this.RefreshStateCommand = async () =>
              {
                  await Mediator.Publish<OnGetProductDataCommand>(new OnGetProductDataCommand()
                  {
                      ViewModel = this
                  });

                  base.StateHasChanged();
              };

            this.OnEditCommand = async (getGuId) =>
            {
                await Mediator.Publish<OnEditProductCommand>(new OnEditProductCommand()
                {
                    GetGuid = getGuId,
                    ViewModel = this,
                    OnStateHasChanged = () => base.StateHasChanged()
                });
            };

            this.OnDeleteCommand = async (getGuId) =>
              {
                  await Mediator.Publish<OnDeleteProductCommand>(new OnDeleteProductCommand()
                  {
                      GetGuid = getGuId,
                      ViewModel = this,
                      OnStateHasChanged = () => base.StateHasChanged()
                  });
              };
        }

        #endregion Constructor

        #region Public  Property

        [Inject]
        public IMediator Mediator { get; set; }

        #endregion Public  Property

        #region Protected Property

        protected internal bool IsLoad { get; set; }

        protected internal List<ProductModel> ListProducts { get; set; }

        protected AddProductComponentViewModel AddProductVM { get; set; }

        protected internal EditProductComponentViewModel EditProductVM { get; set; }

        protected internal DeleteProductComponentViewModel DeleteProductVM { get; set; }

        protected internal ProductModel SelectedProduct { get; set; }

        protected internal String ErrorMessage { get; set; }

        protected Action ShowAddProductDialogCommand { get; set; }

        protected Action RefreshStateCommand { get; set; }

        protected Action<Guid> OnEditCommand { get; set; }

        protected Action<Guid> OnDeleteCommand { get; set; }

        #endregion Protected Property



        protected async override Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                //await Task.Delay(1000);

                ////await this.GetProductDataAsync();

                //IsLoad = true;

                //base.StateHasChanged();

                await Mediator.Publish<OnLoadProductRenderCommand>(new OnLoadProductRenderCommand()
                {
                    ViewModel = this,
                    OnStateHasChanged = () => base.StateHasChanged()
                });
            }
        }
    }
}