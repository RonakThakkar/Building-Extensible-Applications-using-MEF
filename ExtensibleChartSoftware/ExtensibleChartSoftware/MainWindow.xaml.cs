using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
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

namespace ExtensibleChartSoftware
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        [ImportMany(typeof(Interface.ChartObject), AllowRecomposition = true)]
        public ObservableCollection<Lazy<Interface.ChartObject, Interface.IChartMetadata>> ChartObjects { get; set; }

        DirectoryCatalog directoryCatalog;
        CompositionContainer container;
        FileSystemWatcher watcher = new FileSystemWatcher(System.IO.Path.Combine(Environment.CurrentDirectory, "Plugins"));

        public MainWindow()
        {
            InitializeComponent();
            
            Compose();

            if (ChartObjects != null)
            {
                ICollectionView view = CollectionViewSource.GetDefaultView(ChartObjects);
                view.GroupDescriptions.Add(new PropertyGroupDescription("Metadata.Category"));
            }

            lstChartObjects.ItemsSource = ChartObjects;

            watcher.EnableRaisingEvents = true;
            watcher.Created += watcher_Created;
        }

        void watcher_Created(object sender, FileSystemEventArgs e)
        {
            Dispatcher.Invoke(() => { directoryCatalog.Refresh(); });
        }

        public void Compose()
        {
            try
            {
                string directoryPath = System.IO.Path.Combine(Environment.CurrentDirectory, "Plugins");
                directoryCatalog = new DirectoryCatalog(directoryPath, "*.dll");
                container = new CompositionContainer(directoryCatalog);
                container.ComposeParts(this);
            }
            catch (Exception ex)
            {

            }
        }

        private void ChartObject_Click(object sender, RoutedEventArgs e)
        {
            Button btnFlowChartObject = sender as Button;
            if (btnFlowChartObject != null)
            {
                Lazy<Interface.ChartObject, Interface.IChartMetadata> chartObject = btnFlowChartObject.DataContext as Lazy<Interface.ChartObject, Interface.IChartMetadata>;
                if (chartObject != null)
                {
                    //chartObject.Value.Draw(cDrawingBoard);
                    cDrawingBoard.Children.Add(chartObject.Value.Create());
                }
            }
        } 
    }
}
