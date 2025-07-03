using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace CarBook.Application.Services
{   //Dependency Injection 
    public static class ServiceRegistiration
    {                                                                             //servicimin hangi türde olduğu
        public static void AddApplicationService(this IServiceCollection services,IConfiguration configuration)
        {
            //mediatr için her bir sınıfım için tek tek eklemeye uğraşmicam
            services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly
            (typeof(ServiceRegistiration).Assembly));
                    //sınıfımın ismini veriyorum.
        }
    }
}
