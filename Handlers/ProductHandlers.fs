namespace ProductsDemo.Handlers

open Microsoft.AspNetCore.Mvc
open ProductsDemo.Repositories

module ProductHandlers =

    open Microsoft.AspNetCore.Http
    open FSharp.Control.Tasks
    open Giraffe
    open ProductsDemo.Repositories
    open ProductsDemo.Dtos

    let getProductHandler (productId: int) =
        fun (next : HttpFunc) (ctx : HttpContext) ->
            task {
                let productRepository = ctx.GetService<IProductRepository>();
                let! product = productRepository.GetProduct productId |> Async.StartAsTask
                return!
                    (match product with
                    | Some p -> Successful.OK p
                    | None  -> RequestErrors.NOT_FOUND "No product found") next ctx
            }
            
    let getProductsHandler =
        fun (next : HttpFunc) (ctx : HttpContext) ->
            task {
                let productRepository = ctx.GetService<IProductRepository>();
                let! products = productRepository.GetProducts |> Async.StartAsTask
                return! json products next ctx
            }