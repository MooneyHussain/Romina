using Dapper;
using Romina.Api.Models;
using Romina.Api.Settings;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Romina.Api.Repositories
{
    public class ProductRepository: IProductRepository
    {
        private readonly SqlSettings settings;
        private readonly IDatabaseConnectionFactory _databaseConnectionFactory;

        public ProductRepository(SqlSettings settings, IDatabaseConnectionFactory databaseConnectionFactory)
        {
            this.settings = settings;
            _databaseConnectionFactory = databaseConnectionFactory;
        }

        public List<Product> Query(string filter)
        {
            // this method takes in a filter aka 'nike trainers'
            // and searches the database for any products that match this
            // --- implementation can all be added later (for now don't worry)

            throw new NotImplementedException();
        }

        public Product GetProductById(string id)
        {
            Product product = null;
            using (var connection = _databaseConnectionFactory.GetConnection(settings.ConnectionString))
            {
                var products = connection.Query<Product>("SELECT * FROM PRODUCT WHERE ID= @id",id)
                    .ToList();

                product = products[0];
            }

            return product;
        }
    }

    public interface IDatabaseConnectionFactory
    {
        IDbConnection GetConnection(string connectionString);
    }

    public interface IProductRepository
    {
        Product GetProductById(string id);
        List<Product> Query(string filter);
    }
}
