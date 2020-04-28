using Dapper;
using Romina.Api.Models;
using Romina.Api.Settings;
using System.Data.SqlClient;
using System.Linq;

namespace Romina.Api.Repositories
{
    public class ProductRepository: IProductRepository
    {
        private readonly SqlSettings settings;

        public ProductRepository(SqlSettings settings)
        {
            this.settings = settings;
        }

        public Product GetProductById(string id)
        {
            Product product = null;
            using (SqlConnection connection = new SqlConnection(settings.ConnectionString))
            {
                var products = connection.Query<Product>("SELECT * FROM PRODUCT WHERE ID= @id",id)
                    .ToList();

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
