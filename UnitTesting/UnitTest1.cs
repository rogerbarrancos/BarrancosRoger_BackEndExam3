using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTesting
{

    db connectDB = new db();

    [TestClass]
    public class UnitTest1
    {
       

        [TestMethod]
        public void sendEmptyvariables()
        {
            using (var http = new HttpClientTestingFactory())
            {



            }
            


        }


        //public void GetReturnsProduct()
        //{
        //    // Arrange
        //    var controller = new ProductsController(repository);
        //    controller.Request = new HttpRequestMessage();
        //    controller.Configuration = new HttpConfiguration();

        //    // Act
        //    var response = controller.Get(10);

        //    // Assert
        //    Product product;
        //    Assert.IsTrue(response.TryGetContentValue<Product>(out product));
        //    Assert.AreEqual(10, product.Id);
        //}






    }
}
