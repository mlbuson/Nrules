
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using NRules;
using NRules.Fluent;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();

        // Configurar NRules
        var repository = new RuleRepository();
        repository.Load(x => x.From(typeof(PromocionRegla).Assembly));
        repository.Load(x => x.From(typeof(ManejoErroresRegla).Assembly));

        var factory = repository.Compile();
        var session = factory.CreateSession();

        services.AddSingleton<ISession>(session);
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
