using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using GraphQLProject.Interfaces;
using GraphQLProject.Models;
using GraphQLProject.Type;

namespace GraphQLProject.Mutations
{
    public class ProductMutation : ObjectGraphType
    {
        public ProductMutation(IProduct productService)
        {
            Field<ProductType>("createProduct",
                arguments: new QueryArguments(new QueryArgument<ProductInputType> { Name = "product" }),
                resolve: context => productService.AddProduct(context.GetArgument<Product>("product")));

            Field<ProductType>("updateProduct",
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType> { Name = "id" },
                    new QueryArgument<ProductInputType> { Name = "product" }),
                resolve: context =>
                {
                    var productId = context.GetArgument<int>("id");
                    var productObj = context.GetArgument<Product>("product");
                    return productService.UpdateProduct(productId, productObj);
                });

            Field<StringGraphType>("deleteProduct",
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context =>
                {
                    var productId = context.GetArgument<int>("id");
                    productService.DeleteProduct(productId);
                    return $"Product deleted for product id: {productId}";
                });
        }
    }
}
