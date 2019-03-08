using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Moq.Protected;
using Xunit;

namespace HttpExplore
{
    public class SiteAnalyzerTests
    {
        [Fact]
        public async void GetContentSizeReturnsCorrectLength()
        {
            // Arrange
            const string testContent = "test content";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(testContent)
                });
            var underTest = new SiteAnalyzer(new HttpClient(mockMessageHandler.Object));

            // Act
            var result = await underTest.GetContentSize("http://anyurl");

            // Assert
            Assert.Equal(testContent.Length, result);
        }

        [Fact]
        public async void HandlerReturnsCorrectException()
        {
            var mockHandler = new Mock<HttpMessageHandler>();
            //mockHandler.Protected()
            //    .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(),
            //        ItExpr.IsAny<CancellationToken>())
            //    .ReturnsAsync(new Exception("blah"));
        }
    }
}
