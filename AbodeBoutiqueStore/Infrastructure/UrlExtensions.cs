using Microsoft.AspNetCore.Http;

/* the UrlExtensions class provides the PathAndQuery method which passes in the
 * page url when the button is clicked (or where the method is executed from),
 * as a dynamically generated return url gathered via on the HttpRequest.
 * In this case is used for the "Continue Shopping" button in the sopping cart.
 */
namespace AbodeBoutiqueStore.Infrastructure
{
    public static class UrlExtensions
    {
        public static string PathAndQuery(this HttpRequest request) =>
            request.QueryString.HasValue
                ? $"{request.Path}{request.QueryString}"
                : request.Path.ToString();
    }
}