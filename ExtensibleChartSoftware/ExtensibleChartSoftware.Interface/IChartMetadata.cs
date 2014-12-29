using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensibleChartSoftware.Interface
{
    public interface IChartMetadata
    {
        string ChartObjectName { get; }
        string Category { get; }
    }
}
