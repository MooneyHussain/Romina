using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Microsoft.Extensions.Configuration;
using Romina.Api.Models;

namespace Romina.Api.Repositories
{
    public class ProductRepository: IProductRepository
    {
        public Product GetProductById(string id)
        {
            Product product = null;
            using (SqlConnection connection = new SqlConnection("localConnectionString"))
            {
                var products = connection.Query<Product>("SELECT * FROM PRODUCT WHERE ID= @id",id).ToList();
                product = products[0];
            }

            return product;
        }
    }

    public interface IProductRepository
    {
        Product GetProductById(string id);
    }

}
