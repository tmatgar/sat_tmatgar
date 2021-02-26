using Microsoft.AspNetCore.Mvc;

namespace Sat.Recruitment.Host
{
    public static class HostConstants
    {
        public const string ApplicationName = "Sat-Recruitment-Api-Public";
        public const string EmailContact = "toni.matiasgarcia@hotmail.com";
        public const string ApiDeprecatedMessage = "This API version is deprecated";
        public const string ApiAccess = "Access for the Sat-Recruitment API";

        public static string ApiTitle(ApiVersion version) => $"Sat-Recruitment-Api Swagger {version}";
    }
}
