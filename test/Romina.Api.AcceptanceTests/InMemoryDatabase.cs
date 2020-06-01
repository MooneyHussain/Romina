using System.Data.SQLite;
using Dapper;
using Romina.Api.Models;

namespace Romina.Api.AcceptanceTests
{
    public class InMemoryDatabase
    {
        public SQLiteConnection Connection;
        public InMemoryDatabase()
        {
            Connection = new SQLiteConnection("Data Source=:memory:");
            Connection.Open();
            Connection.Execute(@"CREATE TABLE [Products] (" +
                                   "[ProductId] [nvarchar](100) NOT NULL," +
                                   "[Make] [nvarchar](100) NOT NULL," +
                                   "[Model] [nvarchar](100) NOT NULL," +
                                   "[Description] [nvarchar](100) NOT NULL," +
                                   "[Price] [money] NOT NULL)");
        }

        public void Add(Product product)
        {

        }
    }
}