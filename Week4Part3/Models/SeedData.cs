using Microsoft.EntityFrameworkCore;
using ProductModel;
using Week4Part3.Data;

namespace Week4Part3.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Week4Part3Context(
            serviceProvider.GetRequiredService<
                DbContextOptions<Week4Part3Context>>()))
            {
                if (context == null || context.Product == null)
                {
                    throw new ArgumentNullException("Null Context");
                }

                if(!context.Product.Any())
                {
                    Category cat1 = new Category
                    {
                        Description = "Hardware"
                    };
                    Category cat2 = new Category
                    {
                        Description = "Electrical Appliance"
                    };

                    context.Category.Add(cat1);
                    context.Category.Add(cat2);

                    Supplier supp1 = new Supplier
                    {
                        SupplierName = "ACME",
                        SupplierAddressLine1 = "Collooney",
                        SupplierAddressLine2 = "Sligo"
                    };

                    Supplier supp2 = new Supplier
                    {
                        SupplierName = "Swift Electric",
                        SupplierAddressLine1 = "Finglas",
                        SupplierAddressLine2 = "Dublin"
                    };

                    context.Supplier.Add(supp1);
                    context.Supplier.Add(supp2);

                    Product pro1 = new Product
                    {
                        Description = "9 Inch Nails",
                        UnitPrice = 0.1f,
                        QuantityInStock = 200,
                        dateFirstIssued = DateTime.Today,
                        associatedCategory = cat1,
                        Suppliers = [ supp1 ]
                    };

                    Product pro2 = new Product
                    {
                        Description = "9 Inch Bolts",
                        UnitPrice = 0.2f,
                        QuantityInStock = 120,
                        dateFirstIssued = DateTime.Today,
                        associatedCategory = cat1,
                        Suppliers = [ supp1 ]
                    };

                    Product pro3 = new Product
                    {
                        Description = "Chimney Hoover",
                        UnitPrice = 100.30f,
                        QuantityInStock = 10,
                        dateFirstIssued = DateTime.Today,
                        associatedCategory = cat2,
                        Suppliers = [supp2]
                    };

                    Product pro4 = new Product
                    {
                        Description = "Washing Machine",
                        UnitPrice = 399.50f,
                        QuantityInStock = 7,
                        dateFirstIssued = DateTime.Today,
                        associatedCategory = cat2,
                        Suppliers = [supp2]
                    };

                    context.Product.Add(pro1);
                    context.Product.Add(pro2);
                    context.Product.Add(pro3);
                    context.Product.Add(pro4);
                }
                context.SaveChanges();
            }
        }
    }
}
