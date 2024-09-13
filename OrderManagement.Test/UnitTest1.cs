using Moq;
using OrderManagement.Api.Controllers;
using OrderManagement.Application;
using OrderManagement.Application.Interface;
using OrderManagement.Application.ResquestModel;
using System.Text.Json;

namespace OrderManagement.Test
{
    public class UnitTest1
    {
        [Fact]
        public void OrderCreationTest()
        {
            var order = new OrderRequestModel() { Id = 0, CustomerId = 2, Amount = 999.00M, Date = DateTime.Today };
            var expectedorder = new ResponseModel()
            {
                IsSuccess = true,
                Message = OrderManagementConstant.orderValidationMesage.OrderCreated,
                Data = null,
                Errors = null
            };
            var orderServicesmoq = new Mock<IOrder>();
            var oc = new OrderController(orderServicesmoq.Object);
            var result = oc.CreateOrder(order);

            Assert.NotNull(result);
            Assert.Equal(expectedorder, result.Value);

        }
    }
}