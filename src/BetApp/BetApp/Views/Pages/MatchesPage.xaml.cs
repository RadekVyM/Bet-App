﻿using BetApp.Core;
using Microsoft.Extensions.DependencyInjection;
using Xamarin.Forms;
using Xamarin.Forms.Shapes;
using Xamarin.Forms.Xaml;

namespace BetApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MatchesPage : ContentPage
    {
        double cornerRadius = 36;

        public PathGeometry CollectionViewClip { get; set; }

        public MatchesPage()
        {
            InitializeComponent();

            SizeChanged += MatchesPageSizeChanged;

            BindingContext = ((App)App.Current).ServiceProvider.GetRequiredService<IMatchesPageViewModel>();
        }

        private void MatchesPageSizeChanged(object sender, System.EventArgs e)
        {
            CollectionViewClip = new PathGeometry
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

            OnPropertyChanged(nameof(CollectionViewClip));
        }
    }
}