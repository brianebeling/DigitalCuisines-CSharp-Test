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
using RSSLibrary;
using RSSLibrary.Models;

namespace RichClientApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            
            var rssReader = new RSSReader();

            var feed = new NotifyTaskCompletion<Feed>(rssReader.ReadFeedAsync());

            if (feed.Status == TaskStatus.Faulted)
            {
                // TODO Handle exception in UI for example
                return;
            }
            Feed.ItemsSource = feed.Result.Channel.Items;
        }
    }
}
