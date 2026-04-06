namespace EcommerceTests.Core.Config
{
    public static class TestSettings
    {
        public static string BaseUrl => Environment.GetEnvironmentVariable("TEST_URL") ?? "https://practice.qabrains.com/ecommerce";
        public static string Browser => Environment.GetEnvironmentVariable("TEST_BROWSER") ?? "chrome";
    }
}
