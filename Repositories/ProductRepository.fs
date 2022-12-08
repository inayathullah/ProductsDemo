namespace ProductsDemo.Repositories
open ProductsDemo.Dtos

type  IProductRepository =
    abstract GetProduct: int -> Async<ProductDto option>
    abstract GetProducts: Async<ProductDto list>

type ProductRepository() =
    interface IProductRepository with 
        member this.GetProduct productId =
            async {
                if productId <> 5 then 
                    let product =
                        {
                            Id = productId
                            Name = "Product Name"
                            Price = 99.9m
                        } 
                    return Some product
                else
                    return None
            }

        member this.GetProducts =
            async {
                // Retrieve list of product data from database or other data source
                let products = [
                    {
                        Id = 1
                        Name = "Product 1"
                        Price = 9.99m
                    }
                    {
                        Id = 2
                        Name = "Product 2"
                        Price = 19.99m
                    }
                    {
                        Id = 3
                        Name = "Product 3"
                        Price = 29.99m
                    }
                ]
                return products
            }