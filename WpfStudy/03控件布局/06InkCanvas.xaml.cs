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
using System.Windows.Shapes;

namespace WpfStudy._03控件布局
{
    /// <summary>
    /// _06InkCanvas.xaml 的交互逻辑
    /// </summary>
    public partial class _06InkCanvas : Window
    {
        public _06InkCanvas()
        {
            InitializeComponent();
        }

        private void EditingModel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.InkCanvas.EditingMode = (InkCanvasEditingMode)this.EditingModel.SelectedItem;

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (InkCanvasEditingMode item in Enum.GetValues(typeof(InkCanvasEditingMode)))
            {
                this.EditingModel.Items.Add(item);
            }
            this.EditingModel.SelectedIndex = 0;
        }
    }
}
