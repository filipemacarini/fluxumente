namespace FluxuMente.Presentation.Configurations
{
    public static class FontRegistry
    {
        public static void ConfigureFonts(MauiAppBuilder builder)
        {
            builder.ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("Roboto-Medium.ttf", "Roboto");
                fonts.AddFont("Roboto-Regular.ttf", "RobotoR");
                fonts.AddFont("RobotoMono-Medium.ttf", "RobotoMono");
                fonts.AddFont("icons.ttf", "Icons");
            });
        }
    }
}
