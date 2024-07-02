using Maui.BindableProperty.Generator.Core;

namespace BetApp.Maui.Views.Controls;

public partial class TabBar : ContentView
{
    [AutoBindable(DefaultValue = "new List<BaseShellItem>()")]
    readonly IEnumerable<BaseShellItem> items;
    [AutoBindable]
    readonly BaseShellItem selectedItem;
    
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

    partial void OnItemsChanged(IEnumerable<BaseShellItem> value)
    {
        BindableLayout.SetItemsSource(stackLayout, value);
        UpdateSelectedItem(SelectedItem);
    }

    partial void OnSelectedItemChanged(BaseShellItem value)
    {
        UpdateSelectedItem(value);
    }

    private void TabBarItemClicked(object sender, EventArgs e)
    {
        ItemClicked?.Invoke(sender, e);
    }
}