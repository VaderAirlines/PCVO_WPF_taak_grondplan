using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace wpf_les3_a.helper_classes {
    public class pcvoPolygon {
        //privates
        private Polygon polygon;

        //.ctor
        public pcvoPolygon() {
            this.polygon = new Polygon();
            this.polygon.Stroke = Brushes.Black;
            this.polygon.StrokeThickness = 2;
            this.polygon.Fill = Brushes.Beige;

            this.polygon.MouseEnter += mouseEnterHandler;
            this.polygon.MouseLeave += mouseLeaveHandler;
            this.polygon.MouseRightButtonUp += enablePolygonEditing;
        }

        //properties
        public PointCollection points {
            get { return this.polygon.Points; }
            set { this.polygon.Points = value; }
        }

        public Polygon getPolygon() {
            return this.polygon;
        }

        //private polygon handlers
        private void mouseEnterHandler(object sender, System.Windows.Input.MouseEventArgs e) {
            this.polygon.Fill = Brushes.AliceBlue;
        }

        private void mouseLeaveHandler(object sender, System.Windows.Input.MouseEventArgs e) {
            this.polygon.Fill = Brushes.Beige;
        }

        private void enablePolygonEditing(object sender, System.Windows.Input.MouseButtonEventArgs e) {
            MessageBox.Show("Right mouse click");
        }

    }


}
