using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text;
using CafeteriaWebApi.Models;
using Xunit;
using CafeteriaWebApi.Services;
using Moq;

namespace CafeteriaWebApi.Controllers
{

    public class BookingControllerTest
    {

            protected BookingController ControllerUnderTest { get; }
             protected Mock<IBookingServices> BookingServiceMock { get; }

        public BookingControllerTest()
            {
                BookingServiceMock = new Mock<IBookingServices>();
                ControllerUnderTest = new BookingController(BookingServiceMock.Object);
            }

            public class ReadAllAsync : BookingControllerTest
            {
                [Fact]
                public async void Must_Return_Ok_With_Bookings()
                {
                    // Arrange
                    var expectedValues = new BookingModel[]
                    {
                    new BookingModel {
                        BookingId = "Test",
                        CustomerName = "Test",
                        BookingDate = DateTime.Now,
                        Email = "Test",
                        ReferenceId = "Test",
                        ContactNumber = "Test",
                        TotalPersons = 3,
                        Message = "Test",
                         BookingStatus  = new BookingStatusModel
                         {
                             Id = 1,
                             StatusDate = DateTime.Now,
                             StatusName = "Test",
                             StatusDescription = "Test"
                         }

                    },
                    new BookingModel {
                        BookingId = "Test1",
                        CustomerName = "Test1",
                        BookingDate = DateTime.Now,
                        Email = "Test1",
                        ReferenceId = "Test1",
                        ContactNumber = "Test1",
                        TotalPersons = 3,
                        Message = "Test1",
                         BookingStatus  = new BookingStatusModel
                         {
                             Id = 2,
                             StatusDate = DateTime.Now,
                             StatusName = "Test1",
                             StatusDescription = "Test1"
                         }

                    }
                   
                    };

                BookingServiceMock
                  .Setup(x => x.ReadAllAsync())
                  .ReturnsAsync(expectedValues);

                // Act
                var result = await ControllerUnderTest.ReadAllAsync();

                    // Assert
                    var okResult = Assert.IsType<OkObjectResult>(result);
                    Assert.Same(expectedValues, okResult.Value);
                }
            }
        
    }
}
