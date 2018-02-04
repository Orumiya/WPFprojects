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

namespace WPFprojects
{
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : Page
    {
        private Frame mainFrame;
        public Menu(Frame mainFrame)
        {
            InitializeComponent();
            this.mainFrame = mainFrame;
        }

        private void Button_game1_Click(object sender, RoutedEventArgs e)
        {
            ElementShooterPage page2 = new ElementShooterPage(this.mainFrame);
            this.mainFrame.Content = page2;
        }
    }
}
