using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using Plugin.PushNotification;

namespace FrivilligApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if ANDROID && DEBUG
            //Platforms.Android.DangerousAndroidMessageHandlerEmitter.Register();
            //Platforms.Android.DangerousTrustProvider.Register();
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
