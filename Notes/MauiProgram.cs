using Microsoft.Extensions.Logging;
using Notes.Services;
using Notes.Interfaces;
using Notes.Views;
using Notes.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;
using Microsoft.Extensions.Http;


namespace Notes
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
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            builder.Services.AddHttpClient();
            builder.Services.AddSingleton<IJokeService, JokeService>();

       
            //Dependency Injection
            builder.Services.AddTransient<NotesViewModel>();
            builder.Services.AddTransient<AllNotesPage>();
            builder.Services.AddTransient<AboutPage>();
            builder.Services.AddTransient<AboutViewModel>();
            //

            return builder.Build();
        }
    }
}