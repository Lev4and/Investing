namespace Investing.ResourceWebApplication.Extensions
{
    public static class EndpointsExtensions
    {
        public static void MapRoutes(this IEndpointRouteBuilder endpoint)
        {
            endpoint.MapDefaultRoute();
            endpoint.MapBcsAreaRoute();
            endpoint.MapImportAreaRoute();
        }

        private static void MapDefaultRoute(this IEndpointRouteBuilder endpoint)
        {
            endpoint.MapControllerRoute("default", "api/{controller=Home}/{action=Index}/{id?}");
        }

        private static void MapBcsAreaRoute(this IEndpointRouteBuilder endpoint)
        {
            endpoint.MapAreaControllerRoute("bcsArea", "Bcs", "api/bcs/{controller=Home}/{action=Index}/{id?}");
        }

        private static void MapImportAreaRoute(this IEndpointRouteBuilder endpoint)
        {
            endpoint.MapAreaControllerRoute("importArea", "Import", "api/import/{controller=Home}/{action=Index}/{id?}");
        }
    }
}
