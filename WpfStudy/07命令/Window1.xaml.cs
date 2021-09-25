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

namespace WpfStudy._07命令
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            InitializeCommand();
        }

        #region 了解命令
        //声明并定义命令
        private RoutedCommand MyRoutedCommand = new RoutedCommand("MyCommand", typeof(Window1));

        private void InitializeCommand()
        {
            //把命令赋值给命令源，并设置快捷键
            t1_btn1.Command = MyRoutedCommand;
            MyRoutedCommand.InputGestures.Add(new KeyGesture(Key.C, ModifierKeys.Alt));

            //指定命令目标
            t1_btn1.CommandTarget = t1_txtb1;

            //创建命令关联
            CommandBinding commandBinding = new CommandBinding();
            commandBinding.Command = MyRoutedCommand;
            commandBinding.CanExecute += MyRoutedCommandBinding_CanExecute;
            commandBinding.Executed += MyRoutedCommandBinding_Executed;

            //把命令关联安置在外围控件上
            this.t1_sp1.CommandBindings.Add(commandBinding);

        }

        //当命令到达目标之后，此方法被调用
        private void MyRoutedCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            this.t1_ListBox1.Items.Add($"Executed {sender}");
            t1_txtb1.Clear();
            //避免事件继续向上传递而降低程序性能
            e.Handled = true;
        }

        //当探测命令是否可执行的时候该方法会被调用
        private void MyRoutedCommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            this.t1_ListBox1.Items.Add($"CanExecute {sender}");
            if (string.IsNullOrEmpty(t1_txtb1.Text))
            {
                e.CanExecute = false;
            }
            else
            {
                e.CanExecute = true;
            }
            //避免事件继续向上传递而降低程序性能
            e.Handled = true;
        }
        #endregion

        #region 命令参数
        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(t2_txtName.Text))
            {
                e.CanExecute = false;
            }
            else
            {
                e.CanExecute = true;
            }
            //路由终止，提高系统性能
            e.Handled = true;
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Parameter.ToString() == "Student")
            {
                this.t2_lbInfos.Items.Add(string.Format("New Student:{0} 好好学习，天天向上。", t2_txtName.Text));
            }
            else if (e.Parameter.ToString() == "Teacher")
            {
                this.t2_lbInfos.Items.Add(string.Format("New Teacher:{0} 学而不厌，诲人不倦。", t2_txtName.Text));
            }
            //路由终止，提高系统性能
            e.Handled = true;
        }
        #endregion
    }
}
