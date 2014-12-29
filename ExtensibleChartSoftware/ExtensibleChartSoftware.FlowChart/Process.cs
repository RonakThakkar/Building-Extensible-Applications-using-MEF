using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace ExtensibleChartSoftware.FlowChart
{
    [Export(typeof(Interface.ChartObject))]
    [ExportMetadata("ChartObjectName", "Process")]
    [ExportMetadata("Category", "FlowChart")]
    public class Process : Interface.ChartObject
    {
        public override FrameworkElement Create()
        {
            Rectangle rectangle = new Rectangle();
            rectangle.Width = 200;
            rectangle.Height = 100;
            rectangle.Stroke = new SolidColorBrush(Colors.Black);
            rectangle.RadiusX = 7;
            rectangle.RadiusY = 7;
            rectangle.Margin = new System.Windows.Thickness(5);

            return rectangle;
        }
    }
}
