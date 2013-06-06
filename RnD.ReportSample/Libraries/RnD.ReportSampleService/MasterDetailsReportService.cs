using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RnD.ReportSampleViewModel;

namespace RnD.ReportSampleService
{
    public class MasterDetailsReportService : IMasterDetailsReportService
    {
        public IEnumerable<MasterDetailsViewModel> GetMasterDetailsViewModels()
        {
            List<MasterDetailsViewModel> masterDetailsViewModelList;

            var categoryViewModels = new List<CategoryViewModel>
                            {
                                new CategoryViewModel { CategoryId=1, CategoryName = "Fruit"},
                                new CategoryViewModel {CategoryId=2, CategoryName = "Car"},
                                new CategoryViewModel {CategoryId=3, CategoryName = "Cloth"},
                            };

            // Create some products.
            var productViewModels = new List<ProductViewModel> 
                        {
                            new ProductViewModel {ProductId=1, ProductName="Apple", ProductPrice=15, CategoryId=1},
                            new ProductViewModel {ProductId=2, ProductName="Mango", ProductPrice=20, CategoryId=1},
                            new ProductViewModel {ProductId=3, ProductName="Orange", ProductPrice=15, CategoryId=1},
                            new ProductViewModel {ProductId=4, ProductName="Banana", ProductPrice=20, CategoryId=1},
                            new ProductViewModel {ProductId=5, ProductName="Licho", ProductPrice=15, CategoryId=1},
                            new ProductViewModel {ProductId=6, ProductName="Jack Fruit", ProductPrice=20, CategoryId=1},

                            new ProductViewModel {ProductId=7, ProductName="Toyota", ProductPrice=15000, CategoryId=2},
                            new ProductViewModel {ProductId=8, ProductName="Nissan", ProductPrice=20000, CategoryId=2},
                            new ProductViewModel {ProductId=9, ProductName="Tata", ProductPrice=50000, CategoryId=2},
                            new ProductViewModel {ProductId=10, ProductName="Honda", ProductPrice=20000, CategoryId=2},
                            new ProductViewModel {ProductId=11, ProductName="Kimi", ProductPrice=50000, CategoryId=2},
                            new ProductViewModel {ProductId=12, ProductName="Suzuki", ProductPrice=20000, CategoryId=2},
                            new ProductViewModel {ProductId=13, ProductName="Ferrari", ProductPrice=50000, CategoryId=2},

                            new ProductViewModel {ProductId=14, ProductName="T Shirt", ProductPrice=20000, CategoryId=3},
                            new ProductViewModel {ProductId=15, ProductName="Polo Shirt", ProductPrice=50000, CategoryId=3},
                            new ProductViewModel {ProductId=16, ProductName="Shirt", ProductPrice=200, CategoryId=3},
                            new ProductViewModel {ProductId=17, ProductName="Panjabi", ProductPrice=500, CategoryId=3},
                            new ProductViewModel {ProductId=18, ProductName="Fotuya", ProductPrice=200, CategoryId=3},
                            new ProductViewModel {ProductId=19, ProductName="Shari", ProductPrice=500, CategoryId=3},
                            new ProductViewModel {ProductId=20, ProductName="Kamij", ProductPrice=400, CategoryId=3},
                            
                        };

            var masterDetailsViewModels =
                productViewModels.Select(
                    x =>
                        {
                            var categoryViewModel = categoryViewModels.SingleOrDefault(c => c.CategoryId == x.CategoryId);
                            return categoryViewModel != null ? new MasterDetailsViewModel()
                                                                    {
                                                                        ProductId = x.ProductId,
                                                                        ProductName = x.ProductName,
                                                                        ProductPrice = x.ProductPrice,
                                                                        CategoryId = x.CategoryId,
                                                                        CategoryName =
                                                                            categoryViewModel.CategoryName
                                                                    } : null;
                        }).ToList
                    ();


            masterDetailsViewModelList = masterDetailsViewModels;

            return masterDetailsViewModelList.AsQueryable();
        }
        
        public IEnumerable<MasterDetailsViewModel> GetMasterDetailsViewModelsByCategoryId(int id)
        {
            List<MasterDetailsViewModel> masterDetailsViewModelList;

            var masterDetailsViewModels = GetMasterDetailsViewModels().Where(x => x.CategoryId == id).ToList();

            masterDetailsViewModelList = masterDetailsViewModels;

            return masterDetailsViewModelList.AsQueryable();
        }
    }
}
