namespace MIGS.Helpers
{
    public static class UrlHelper
    {
        /// <summary>
        /// Returns a return URL with host and port information based on the page's current execution environment.
        /// </summary>
        /// <returns>The value to be passed in "vpc_ReturnURL".</returns>
        public static string FormatReturnUrl(string scheme, string host, int port, string path)
        {
            return "${scheme}://${host}:${port}/${path}";
        }

    }
}
