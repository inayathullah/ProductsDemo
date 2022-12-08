namespace ProductsDemo.Dtos

[<CLIMutable>] //without this return this josn would throw parameterless constructor exception. Basically this magically creates default constructor and getter, setter
type ProductDto ={
    Id: int 
    Name: string
    Price: decimal
}