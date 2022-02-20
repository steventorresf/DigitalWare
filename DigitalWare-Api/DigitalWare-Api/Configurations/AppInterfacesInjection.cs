namespace DigitalWare_Api.Configurations
{
    public static class AppInterfacesInjection
    {
        public static IServiceCollection AddInterfacesInjection(this IServiceCollection services)
        {
            #region Facades
            services.AddScoped<DigitalWare_Api_Facade.Interfaces.IClienteFacade, DigitalWare_Api_Facade.Implementations.ClienteFacade>();
            services.AddScoped<DigitalWare_Api_Facade.Interfaces.IConsultaFacade, DigitalWare_Api_Facade.Implementations.ConsultaFacade>();
            services.AddScoped<DigitalWare_Api_Facade.Interfaces.IFacturaFacade, DigitalWare_Api_Facade.Implementations.FacturaFacade>();
            services.AddScoped<DigitalWare_Api_Facade.Interfaces.IProductoFacade, DigitalWare_Api_Facade.Implementations.ProductoFacade>();
            #endregion

            #region Repositories
            services.AddScoped<DigitalWare_Api_Infrastructure.Interfaces.IClienteRepository, DigitalWare_Api_Infrastructure.Implementations.ClienteRepository>();
            services.AddScoped<DigitalWare_Api_Infrastructure.Interfaces.IConsultaRepository, DigitalWare_Api_Infrastructure.Implementations.ConsultaRepository>();
            services.AddScoped<DigitalWare_Api_Infrastructure.Interfaces.IFacturaRepository, DigitalWare_Api_Infrastructure.Implementations.FacturaRepository>();
            services.AddScoped<DigitalWare_Api_Infrastructure.Interfaces.IProductoRepository, DigitalWare_Api_Infrastructure.Implementations.ProductoRepository>();
            #endregion
            return services;
        }
    }
}
