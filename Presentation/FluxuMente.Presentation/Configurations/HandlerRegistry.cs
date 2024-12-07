using Microsoft.Maui.Handlers;

namespace FluxuMente.Presentation.Configurations
{
    public class HandlerRegistry
    {
        public static void RegisterHandlers()
        {
            RegisterEntry();
            RegisterEditor();
            RegisterPicker();
        }

        private static void RegisterEntry()
        {
            EntryHandler.ElementMapper.AppendToMapping("CustomEntry", (handler, view) =>
            {
                if (handler.PlatformView is Microsoft.UI.Xaml.Controls.TextBox nativeEntry)
                {
                    nativeEntry.Style = null;
                    nativeEntry.Padding = new Microsoft.UI.Xaml.Thickness(0);
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

        private static void RegisterPicker()
        {
            PickerHandler.ElementMapper.AppendToMapping("CustomPicker", (handler, view) =>
            {
                if (handler.PlatformView is Microsoft.UI.Xaml.Controls.ComboBox nativeEntry && view is Picker picker)
                {
                    if (picker.AutomationId == "SpecialPicker")
                        nativeEntry.CornerRadius = new Microsoft.UI.Xaml.CornerRadius(22);
                    else
                        nativeEntry.CornerRadius = new Microsoft.UI.Xaml.CornerRadius(16);

                    nativeEntry.BorderThickness = new Microsoft.UI.Xaml.Thickness(0);
                }
            });
        }
    }
}
