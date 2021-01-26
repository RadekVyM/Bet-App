using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BetApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabItem : ContentView
    {
        #region Public members

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

        public static readonly BindableProperty IsSelectedProperty =
            BindableProperty.Create(nameof(IsSelected), typeof(bool), typeof(TabItem), false, BindingMode.OneWay, propertyChanged: (bindable, o, n) =>
            {
                TabItem view = bindable as TabItem;

                if (view.IsSelected)
                {
                    view.boxView.IsVisible = true;
                    view.label.SetDynamicResource(Label.TextColorProperty, "DetailColour");
                }
                else
                {
                    view.boxView.IsVisible = false;
                    view.label.SetDynamicResource(Label.TextColorProperty, "PrimaryBackgroundColour");
                }
            });

        public static readonly BindableProperty TextProperty =
            BindableProperty.Create(nameof(Text), typeof(string), typeof(TabItem), "", BindingMode.OneWay, propertyChanged: (bindable, o, n) =>
            {
                TabItem view = bindable as TabItem;
                view.label.Text = view.Text;
            });


        #endregion

        public TabItem()
        {
            InitializeComponent();
        }

    }
}