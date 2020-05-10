using Moq;
using Romina.Api.Handlers;
using Romina.Api.Repositories;
using Xunit;

namespace Romina.Api.UnitTests.Handlers
{
    public class ProductHandlerTests
    {
        private Mock<IProductRepository> _productRepository;

        public ProductHandlerTests()
        {
            _productRepository = new Mock<IProductRepository>();
        }

        [Fact(Skip = "Dan to complete - Once done remove this line and uncomment the line below")]
        //[Fact]
        public void GetProductsByFilter_WhenProductsExist_OrderByMakeThenModelThenDescrption()
        {
            //ARRANGE
            var filter = "nike";
            var handler = new ProductHandler(_productRepository.Object); // creating a handler

            // set up the product repository to return products 
            // ensure the count of products returned are 3 
            // ensure that only one product has 'nike' in its make 
            // ensure that only one product has 'nike' in its model
            // ensure that only one product has 'nike' in its description 

            //ACT 
            // call GetProductsByFilter() on the productHandler

            // ASSERT 
            // ensure returned products are not null / empty 
            // ensure the first product in the list is the one with nike in its make
            // ensure second product in the list is the one with nike in its model
            // ensure last product is the one with nike in its description
        }
    }
}
