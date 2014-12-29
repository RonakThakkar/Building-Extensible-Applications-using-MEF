using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace ExtensibleChartSoftware.ThirdParty.UMLChart
{
    [Export(typeof(Interface.ChartObject))]
    [ExportMetadata("ChartObjectName", "Class")]
    [ExportMetadata("Category", "UML")]
    public class ClassObject : Interface.ChartObject
    {
        public override System.Windows.FrameworkElement Create()
        {
            StackPanel panel = new StackPanel();
            panel.Orientation = Orientation.Vertical;
            panel.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            panel.Background = new SolidColorBrush(Colors.LightBlue);
            panel.Margin = new System.Windows.Thickness(5);

            Rectangle rectangle1 = new Rectangle();
            rectangle1.Width = 200;
            rectangle1.Height = 30;
            rectangle1.Stroke = new SolidColorBrush(Colors.Black);
            panel.Children.Add(rectangle1);

            Rectangle rectangle2 = new Rectangle();
            rectangle2.Width = 200;
            rectangle2.Height = 50;
            rectangle2.Stroke = new SolidColorBrush(Colors.Black);
            panel.Children.Add(rectangle2);

            Rectangle rectangle3 = new Rectangle();
            rectangle3.Width = 200;
            rectangle3.Height = 50;
            rectangle3.Stroke = new SolidColorBrush(Colors.Black);
            panel.Children.Add(rectangle3);

            return panel;
        }
    }
}
