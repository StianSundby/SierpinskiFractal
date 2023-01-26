using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Fractal
{
    public partial class MainWindow : Window
    {
        public static readonly Random rnd = new();
        private static bool _gameRunning = true;

        public MainWindow()
        {
            InitializeComponent();
        }

        private static void InitializeSimulation(Panel canvas, TextBlock counter)
        {
            DrawRectangle(canvas, 175, 0, "topCenter"); //top center dot
            DrawRectangle(canvas, 0, 350, "bottomLeft"); //bottom left corner dot
            DrawRectangle(canvas, 350, 350, "bottomRight"); //bottom right corner dot

            var startDotOne = GetStartingDot(canvas, 1);
            var startDotTwo = GetStartingDot(canvas, 2);
            var lastDotDrawn = DrawDot(canvas, startDotOne, startDotTwo);

            StartGame(canvas, lastDotDrawn, counter);
        }

        private static async void StartGame(Panel canvas, List<double> lastDotDrawn, TextBlock counter)
        {
            var lastDot = lastDotDrawn;
            while (_gameRunning)
            {
                await Task.Delay(1);
                var randomDot = GetStartingDot(canvas, 1);
                var lastDotCache = DrawDot(canvas, randomDot, lastDot);
                lastDot = lastDotCache;
                counter.Text = canvas.Children.Count.ToString();
            }
        }

        private static List<double> DrawDot(Panel canvas, IReadOnlyList<double> dotOne, IReadOnlyList<double> dotTwo)
        {
            var pointLeft = (dotOne[1] + dotTwo[1]) / 2;
            var pointTop = (dotOne[0] + dotTwo[0]) / 2;
            var nextDot = new List<double>
            {
                pointTop,
                pointLeft
            };
            DrawRectangle(canvas, pointLeft, pointTop, null);
            return nextDot;
        }

        private static List<double> GetStartingDot(Panel canvas, int dotToReturn)
        {
            var startingDotOne = new List<double>();
            var startingDotTwo = new List<double>();
            var options = new List<string>
            {
                "topCenter",
                "bottomLeft",
                "bottomRight"
            };
            var index = rnd.Next(options.Count);
            while (!startingDotOne.Any() && !startingDotTwo.Any())
            {
                foreach (Rectangle child in canvas.Children)
                {
                    if (child.Name == options[index] && !startingDotOne.Any())
                    {
                        startingDotOne = GetDotPosition(child);
                        options.RemoveAt(index);
                        index = rnd.Next(options.Count);
                    }

                    if (child.Name != options[index] || !startingDotOne.Any())
                    {
                        startingDotTwo = GetDotPosition(child);
                    }
                }
            }

            return dotToReturn == 1 ? startingDotOne : startingDotTwo;
        }

        private static void DrawRectangle(Panel canvas, double left, double top, string? dotName)
        {
            var currentDot = new Rectangle();
            Panel.SetZIndex(currentDot, 1);
            currentDot.Height = 2;
            currentDot.Width = 2;
            currentDot.Fill = new SolidColorBrush(Colors.Black);
            currentDot.Margin = new Thickness(left, top, 0, 0); // Sets the position.
            currentDot.Name = !string.IsNullOrEmpty(dotName) ? dotName : string.Empty;
            canvas.Children.Add(currentDot);
        }

        private static List<double> GetDotPosition(FrameworkElement dot)
        {
            var top = dot.Margin.Top;
            var left = dot.Margin.Left;
            var dotPositions = new List<double>
            {
                top,
                left
            };
            return dotPositions;
        }

        private void StopButton_OnClick(object sender, RoutedEventArgs e)
        {
            _gameRunning = false;
        }

        private void StartButton_OnClick(object sender, RoutedEventArgs e)
        {
            InitializeSimulation(MainCanvas, Counter);
        }
    }
}