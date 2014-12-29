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
    [ExportMetadata("ChartObjectName", "Terminator")]
    [ExportMetadata("Category", "FlowChart")]
    public class Terminator : Interface.ChartObject
    {
        public override FrameworkElement Create()
        {
            Rectangle terminator = new Rectangle();
            terminator.Width = 200;
            terminator.Height = 100;
            terminator.Stroke = new SolidColorBrush(Colors.Black);
            terminator.RadiusX = 50;
            terminator.RadiusY = 50;
            terminator.Margin = new System.Windows.Thickness(5);

            return terminator;
        }
    }
}
