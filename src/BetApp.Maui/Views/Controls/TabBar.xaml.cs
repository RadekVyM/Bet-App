using Microsoft.Maui.Controls;

namespace BetApp.Maui.Views.Controls;

public partial class TabBar : ContentView
{
    public static readonly BindableProperty ItemsProperty =
        BindableProperty.Create(nameof(Items), typeof(IEnumerable<BaseShellItem>), typeof(TabBar), new List<BaseShellItem>(), BindingMode.OneWay, propertyChanged: OnItemsChanged);

    public static readonly BindableProperty SelectedItemProperty =
        BindableProperty.Create(nameof(SelectedItem), typeof(BaseShellItem), typeof(TabBar), null, BindingMode.OneWay, propertyChanged: OnSelectedItemChanged);

    public IEnumerable<BaseShellItem> Items
    {
        get => (IEnumerable<BaseShellItem>)GetValue(ItemsProperty);
        set => SetValue(ItemsProperty, value);
    }

    public BaseShellItem SelectedItem
    {
        get => (BaseShellItem)GetValue(SelectedItemProperty);
        set => SetValue(SelectedItemProperty, value);
    }

    public event EventHandler ItemClicked;


    public TabBar()
	{
		InitializeComponent();
	}


    private void UpdateSelectedItem(object newValue)
    {
        foreach (var item in stackLayout)
        {
            if (item is not TabBarItem tabBarItem)
                continue;

            tabBarItem.IsSelected = tabBarItem.BindingContext == newValue;
        }
    }


    private void TabBarItemClicked(object sender, EventArgs e)
    {
        ItemClicked?.Invoke(sender, e);
    }

    private static void OnItemsChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var tabBar = bindable as TabBar;

        if (newValue is not IEnumerable<BaseShellItem> items)
            return;

        BindableLayout.SetItemsSource(tabBar.stackLayout, items);
        tabBar.UpdateSelectedItem(tabBar.SelectedItem);
    }

    private static void OnSelectedItemChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var tabBar = bindable as TabBar;

        tabBar.UpdateSelectedItem(newValue);
    }
}
