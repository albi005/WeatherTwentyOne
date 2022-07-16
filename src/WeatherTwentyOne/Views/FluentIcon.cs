using Microsoft.Maui.Controls.Shapes;
using Microsoft.Maui.Graphics;
using WeatherTwentyOne.Resources;

namespace WeatherTwentyOne.Views;

public class FluentIcon : ContentView
{
	private static readonly PathGeometryConverter pathGeometryConverter = new();

	public static BindableProperty SourceProperty = BindableProperty.Create(nameof(Source), typeof(string), typeof(FluentIcon), propertyChanged: OnSourceChanged);

	public FluentIcon()
	{
		Path path = new()
		{
			Aspect = Stretch.Uniform
		};
		path.SetDynamicResource(Shape.FillProperty, "Gradient");
		Content = path;
	}

    public string Source
    {
        get => (string)GetValue(SourceProperty);
        set => SetValue(SourceProperty, value);
    }

	private static void OnSourceChanged(BindableObject bindable, object oldValue, object newValue)
	{
		FluentIcon icon = (FluentIcon)bindable;
		string source = (string)newValue;
		if (source == null) return;
		string data = Strings.FluentIcons[source];
		Path path = (Path)icon.Content;
		path.Data = (Geometry)pathGeometryConverter.ConvertFrom(data);
	}
}
