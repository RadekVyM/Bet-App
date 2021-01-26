using BetApp.Core;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Shapes;
using Xamarin.Forms.Xaml;

namespace BetApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MatchDetailPage : ContentPage
    {
        public const string FirtsTabText = "MARKET";
        public const string SecondTabText = "MATCHED BET";
        public const string ThirdTabText = "UNMATCHED";

        double cornerRadius = 36;
        private object selectedTab;

        public PathGeometry BoxViewClip { get; set; }
        public object SelectedTab
        {
            get => selectedTab;
            set
            {
                selectedTab = value;
                OnPropertyChanged(nameof(SelectedTab));
            }
        }

        public MatchDetailPage()
        {
            InitializeComponent();

            SizeChanged += MatchDetailPageSizeChanged;

            BindingContext = ((App)App.Current).ServiceProvider.GetRequiredService<IMatchDetailPageViewModel>();

            TabTapped(firstTabItem, EventArgs.Empty);
        }

        private void MatchDetailPageSizeChanged(object sender, System.EventArgs e)
        {
            BoxViewClip = new PathGeometry
            {
                Figures = new PathFigureCollection
                {
                    new PathFigure
                    {
                        IsClosed = true, IsFilled = true, StartPoint = new Point(0, 0),
                        Segments = new PathSegmentCollection
                        {
                            new LineSegment(new Point(Width, 0)),
                            new LineSegment(new Point(Width, cornerRadius)),
                            new QuadraticBezierSegment(new Point(Width, 0), new Point(Width - cornerRadius, 0)),
                            new LineSegment(new Point(cornerRadius, 0)),
                            new QuadraticBezierSegment(new Point(0, 0), new Point(0, cornerRadius))
                        }
                    }
                }
            };

            OnPropertyChanged(nameof(BoxViewClip));
        }

        private void TabTapped(object sender, EventArgs e)
        {
            var view = sender as TabItem;

            SelectedTab = view.BindingContext;

            scrollView.Content = view.BindingContext.ToString() switch
            {
                FirtsTabText => scrollView.Content = Resources.GetValue<DataTemplate>("FirstTabContentDataTemplate").CreateContent() as View,
                SecondTabText => scrollView.Content = Resources.GetValue<DataTemplate>("SecondTabContentDataTemplate").CreateContent() as View,
                ThirdTabText => scrollView.Content = Resources.GetValue<DataTemplate>("ThirdTabContentDataTemplate").CreateContent() as View,
                _ => null
            };
        }
    }
}