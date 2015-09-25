using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using wpf_les3_a.helper_classes;

namespace wpf_les3_a
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const int allowedClosingMargin = 5;
        PointCollection points = new PointCollection();
        List<pcvoPolygon> polygons = new List<pcvoPolygon>();

        public MainWindow()
        {
            InitializeComponent();
        }

        #region UI handlers

        private void canvas_clickHandler(object sender, MouseButtonEventArgs e)
        {
            Point position = e.GetPosition(canvas);

            points.Add(new Point(position.X, position.Y));

            if (points.Count > 1)
            {
                Point begin = points[0];
                Point end = points[points.Count - 1];

                if (withinRange(begin, end))
                {
                    PointCollection polygonPoints = points.Clone();
                    polygonPoints.RemoveAt(points.Count - 1);
                    createPolygon(polygonPoints);

                    points.Clear();
                    refreshCanvas(canvas);

                    pcvoPolygon a = new pcvoPolygon();
                   
                }
                else
                {
                    Line line = new Line();
                    line.Visibility = System.Windows.Visibility.Visible;
                    line.StrokeThickness = 4;
                    line.Stroke = System.Windows.Media.Brushes.Black;
                    line.X1 = points[points.Count - 2].X;
                    line.X2 = points[points.Count - 1].X;
                    line.Y1 = points[points.Count - 2].Y;
                    line.Y2 = points[points.Count - 1].Y;
                    canvas.Children.Add(line);
                }
            }
        }

        #endregion

        #region helpers

        private bool withinRange(Point begin, Point end)
        {
            if (((begin.X > end.X - allowedClosingMargin) && (begin.X < end.X + allowedClosingMargin))
                && ((end.X > end.X - allowedClosingMargin) && (end.X < end.X + allowedClosingMargin)))
            {
                return true;
            }

            return false;
        }

        private void refreshCanvas(Canvas canvas)
        {
            canvas.Children.Clear();

            foreach (pcvoPolygon p in polygons)
            {
                canvas.Children.Add(p.getPolygon());
            }
        }
        
        private void createPolygon(PointCollection points)
        {
            pcvoPolygon p = new pcvoPolygon();
            p.points = points;

            polygons.Add(p);
            canvas.Children.Add(p.getPolygon());
        }

        #endregion
    }
}
