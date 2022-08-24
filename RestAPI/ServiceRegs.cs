using vxnet.Domain.Repository;
using vxnet.Domain.Service;

namespace RestAPI
{
    public static class ServiceRegs
    {
        public static void RegisterDependecies(this IServiceCollection services, IConfiguration configuration)
        {
            Repos(services);
            Services(services);
        }

        static void Repos(IServiceCollection services)
        {
            services.AddScoped(typeof(IRepo<>), typeof(Repo<>));
        }

        static void Services(IServiceCollection services)
        {
            services.AddScoped<IShopService, ShopService>();
        }
    }
}
