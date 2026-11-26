using System.Net;

namespace DriVIABlazor.Services;

public static class ApiErrorHelper
{
    public static string GetErrorMessage(HttpStatusCode statusCode)
    {
        return statusCode switch
        {
            HttpStatusCode.BadRequest =>
                "Please check your entered information.",

            HttpStatusCode.Unauthorized =>
                "Please log in to continue.",

            HttpStatusCode.Forbidden =>
                "You do not have permission to perform this action.",

            HttpStatusCode.NotFound =>
                "The requested information could not be found.",

            HttpStatusCode.Conflict =>
                "This request conflicts with existing data. Please check your information.",

            HttpStatusCode.InternalServerError =>
                "Something went wrong. Please try again later.",

            HttpStatusCode.ServiceUnavailable =>
                "The service is temporarily unavailable. Please try again later.",

            _ =>
                "Unable to complete your request. Please try again."
        };
    }
}