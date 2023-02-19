using Task;
using Moq;

namespace TestTask
{
    public class UnitTest1
    { 
        [Fact]
        public void HttpResult_RewriteProperties_Url_SecuredUrl()
        {
            {
                // Arrange
                var HttpResult = new HttpResult();

                // Act

                string securedString = HttpResult.RewriteProperties("http://test.com/users/max/info?pass=123456");

                // Assert

                Assert.Equal("http://test.com/users/XXX/info?pass=XXXXXX", securedString);
            }
        }

        [Fact]
        public void HttpResult_RewriteProperties__NoUrl_EmptyUrl()
        {
            {
                // Arrange
                var HttpResult = new HttpResult();

                // Act

                string securedString = HttpResult.RewriteProperties("");

                // Assert

                Assert.Equal("", securedString);
            }
        }

        [Fact]
        public void HttpHandler_Process_EmptyUrls_EmptyUrls()
        {
            {
                // Arrange
                var httpLogHandler = new HttpHandler();

                // Act

                httpLogHandler.Process("", "", "");

                // Assert

                Assert.Equal("", httpLogHandler.CurrentLog.Url);
                Assert.Equal("", httpLogHandler.CurrentLog.RequestBody);
                Assert.Equal("", httpLogHandler.CurrentLog.ResponseBody);
            }
        }


        [Fact]
        public void HttpHandler_Process_BookingcomHttpResult_ClearSecureData()
        {
            {
                // Arrange
                var httpLogHandler = new HttpHandler();

                // Act

                httpLogHandler.Process("http://test.com/users/123/info?pass=123456", "http://test.com/?user=123&pass=123456", "http://test.com/?user=321&pass=123456");

                // Assert

                Assert.Equal("http://test.com/users/XXX/info?pass=XXXXXX", httpLogHandler.CurrentLog.Url);
                Assert.Equal("http://test.com/?user=XXX&pass=XXXXXX", httpLogHandler.CurrentLog.RequestBody);
                Assert.Equal("http://test.com/?user=XXX&pass=XXXXXX", httpLogHandler.CurrentLog.ResponseBody);
            }
        }
    }
}