using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using VegStore.Service;
using VegStore.ViewModels;
using VegStore.Pages;

namespace VegStore
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
                .UseMauiCommunityToolkit();

#if DEBUG
    		builder.Logging.AddDebug();
#endif      
            AddVegetableServices(builder.Services);
            return builder.Build();
        }

        private static IServiceCollection
            AddVegetableServices(IServiceCollection services)
        {
            services.AddSingleton<VegetableService>();

            services.AddSingleton<HomePage>()
                    .AddSingleton<HomeViewModel>();

            services.AddTransientWithShellRoute<AllVegesPage, AllVegesViewModel>(nameof(AllVegesPage));
            services.AddTransientWithShellRoute<DetailPage, DetailsViewModel>(nameof(DetailPage));
            //services.AddTransientWithShellRoute<CartPage, CartViewModel>(nameof(CartPage));

            services.AddSingleton<CartViewModel>();
            services.AddTransient<CartPage>();
            
            return services;
        }
    } 
}
