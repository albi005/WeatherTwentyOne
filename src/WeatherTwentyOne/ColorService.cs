using MaterialColorUtilities.Maui;
using MaterialColorUtilities.Palettes;
using MaterialColorUtilities.Schemes;
using Microsoft.Extensions.Options;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.LifecycleEvents;

namespace WeatherTwentyOne
{
    public class ColorService : DynamicColorService<CorePalette, Scheme<int>, Scheme<Color>, LightSchemeMapper, DarkSchemeMapper>
    {
        public ColorService(IOptions<DynamicColorOptions> options, IApplication application, ILifecycleEventService lifecycleEventService) : base(options, application, lifecycleEventService)
        {
        }

        protected override void Apply()
        {
            base.Apply();
            Application.Current.Resources["Gradient"] = new LinearGradientBrush(new()
            {
                new(SchemeMaui.PrimaryContainer, .1f),
                new(SchemeMaui.Primary, .9f),
            });
        }
    }
}
