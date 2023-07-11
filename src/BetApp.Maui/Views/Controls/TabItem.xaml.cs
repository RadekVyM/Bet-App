namespace BetApp.Maui.Views.Controls;

public partial class TabItem : ContentView
{
    public static readonly BindableProperty IsSelectedProperty =
        BindableProperty.Create(nameof(IsSelected), typeof(bool), typeof(TabItem), false, BindingMode.OneWay, propertyChanged: OnIsSelectedChanged);

    public static readonly BindableProperty TextProperty =
        BindableProperty.Create(nameof(Text), typeof(string), typeof(TabItem), "", BindingMode.OneWay, propertyChanged: OnTextChanged);

    public bool IsSelected
    {
        get => (bool)GetValue(IsSelectedProperty);
        set => SetValue(IsSelectedProperty, value);
    }

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }


    public TabItem()
	{
		InitializeComponent();
	}


    private static void OnIsSelectedChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var view = bindable as TabItem;

        if (view.IsSelected)
        {
            view.boxView.Opacity = 1;
            view.label.SetDynamicResource(Label.TextColorProperty, "Secondary");
        }
        else
        {
            view.boxView.Opacity = 0.01;
            view.label.SetDynamicResource(Label.TextColorProperty, "White");
        }
    }

    private static void OnTextChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var view = bindable as TabItem;
        view.label.Text = view.Text;
    }
}
