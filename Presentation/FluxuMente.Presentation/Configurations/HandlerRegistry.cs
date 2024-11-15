using Microsoft.Maui.Handlers;

namespace FluxuMente.Presentation.Configurations
{
    public class HandlerRegistry
    {
        public static void RegisterHandlers()
        {
            RegisterEntry();
            RegisterEditor();
        }

        private static void RegisterEntry()
        {
            EntryHandler.ElementMapper.AppendToMapping("CustomEntry", (handler, view) =>
            {
                if (handler.PlatformView is Microsoft.UI.Xaml.Controls.TextBox nativeEntry)
                {
                    nativeEntry.Style = null;
                    nativeEntry.Padding = new Microsoft.UI.Xaml.Thickness(16, 0, 0, 0);
                    nativeEntry.BorderThickness = new Microsoft.UI.Xaml.Thickness(0);
                }
            });
        }

        private static void RegisterEditor()
        {
            EditorHandler.ElementMapper.AppendToMapping("CustomEditor", (handler, view) =>
            {
                if (handler.PlatformView is Microsoft.UI.Xaml.Controls.TextBox nativeEntry)
                {
                    nativeEntry.Style = null;
                    nativeEntry.Padding = new Microsoft.UI.Xaml.Thickness(0);
                    nativeEntry.BorderThickness = new Microsoft.UI.Xaml.Thickness(0);
                }
            });
        }
    }
}
