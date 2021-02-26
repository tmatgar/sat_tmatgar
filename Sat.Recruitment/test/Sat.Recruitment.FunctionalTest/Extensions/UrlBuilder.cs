using static Sat.Recruitment.Api.ApiConstants;

namespace Sat.Recruitment.FunctionalTest.Extensions
{
    public static class UrlBuilder
    {       
        private static string AddQueryStringParam(this string url, string key, string value)
        {
            return url.Contains("?")
                ? $"{url}&{key}={value}"
                : $"{url}?{key}={value}";
        }
      
        private static string AddApiVersionParam(this string url)
        {
            return url.AddQueryStringParam("api-version", ApiVersion1);
        }

        public static class UsersUrl
        {
            public static string PostCreateUserTestUrl =>
                $"{ApiBase}/{Users}/create"
                    .AddApiVersionParam();           
        }
    }
}