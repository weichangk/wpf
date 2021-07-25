### 03�ؼ�����

- ��������Ŀؼ� https://docs.microsoft.com/zh-cn/dotnet/desktop/wpf/controls/controls-by-category?view=netframeworkdesktop-4.8
- WPF ����ģ�� https://docs.microsoft.com/zh-cn/dotnet/desktop/wpf/controls/wpf-content-model?view=netframeworkdesktop-4.8

##### ����ؼ�
- ���ֿؼ����������ɶ���ؼ���Ƕ���������ֿؼ���������UI����֯�����пؼ���Grid��StackPanel��DockPanel �ȿؼ��������࣬����ӵ�й�ͬ�ĸ���Panel��
- ���ݿؼ���ֻ������һ�������ؼ��򲼾ֿؼ���Ϊ�������ݡ�Window��Button �ȿؼ����ڴ��࣬��Ϊֻ������һ���ؼ���Ϊ�����ݣ����Ծ�����Ҫ�������ֿؼ����滮�����ݡ����ǵĹ�ͬ������ ContentControl��
- ���������ݿؼ����൱��һ�����ݿؼ��������Լ�һ������(Header)�����ⲿ���������һ���ؼ��򲼾֡�GroupBox��Tabltem ��������ؼ��ĵ��ʹ������ǵĹ�ͬ������ HeaderedContentControl��
- ��Ŀ�ؼ���������ʾһ�����ݣ�һ��������������ݵ�������ͬ������ؼ�����ListBox��ComboBox �ȡ����ǵĹ�ͬ������ItemsControl������ؼ�����ʾ�����������ݷ��湦�ܷǳ�ǿ��
- ��������Ŀ�ؼ����൱��һ����Ŀ�ؼ�����һ��������ʾ����TreeViewltem��Menultem �����ڴ���ؼ�������ؼ�����������ʾ�㼶��ϵ���ݣ������ʾ���� Header �����Ӽ��������ʾ������Ŀ�ؼ����򡣴���ؼ��Ĺ�ͬ������ HeaderedItemsControl��
- �������ݿؼ������� TextBox ���ɵ����ַ�����TextBlock �������ɿ����ɿ��Ƹ�ʽ���ı���Image ����ͼƬ�������ݣ�����ؼ���ԱȽ϶�����

##### �ؼ�������ϵ
- DependencyObject >> Visusl >> UIElement >> FrameworkElement
	- Adorner
	- Control
		- ConentControl
			- HeaderedContentControl
		- ItemControl
			- HeaderedItemsControl
		- TextBox
	- Decorator
	- Panle
	- TextBlock

- WPF ���۽��� .NET Framework �ϵ�һ����ϵ�y����Ҳ��һ�����ڿ���Ӧ�ó���Ŀ��(Framework), FrameworkElement ָ�ľ���WPF Framework���� FrameworkElement ���� UIElement ��Ļ���������˺ܶ�ר������ WPF ������API(����SetBinding����)�����Դ�����࿪ʼ�����ǽ��� WPF ������ܡ�
- UIElement �� WPF ���ļ�ʵ�ֵĻ��࣬��Щʵ������ Windows Presentation Foundation (WPF) Ԫ�غͻ�����ʾ���������ɵġ�
- FrameworkElement �ṩ Windows Presentation Foundation (WPF) Ԫ�ص����ԡ��¼��ͷ����� WPF ��ܼ��𼯡� �����ʾ���ṩ�� WPF ��ܼ���ʵ�ֻ��� UIElement ����� WPF ���ļ��� API��


##### WPF ����ģ��

WPF �� UI Ԫ������
- ContentControl 	һ���������
- HeaderedContentControl 	һ����ͷ��һ������߶���������󣩡�
- ItemsControl 	һ��������󼯺ϡ�
- HeaderedItemsControl 	һ����ͷ��һ����ϣ�ȫ������������󣩡�

ContentControl �����һ���������ݡ�������������Ϊ Content�����¿ؼ��Ӽ̳� ContentControl ��ʹ��������ģ�ͣ�
- Button
- ButtonBase
- CheckBox
- ComboBoxItem
- ContentControl
- Frame
- GridViewColumnHeader
- GroupItem
- Label
- ListBoxItem
- ListViewItem
- NavigationWindow
- RadioButton
- RepeatButton
- ScrollViewer
- StatusBarItem
- ToggleButton
- ToolTip
- UserControl
- Window

HeaderedContentControl ��̳� ContentControl������ʾ���б�������ݡ� �����м̳� content ���ԣ� Content ContentControl ����������Ϊ�� Header ���� Object����ˣ����߶�����������������¿ؼ��Ӽ̳� HeaderedContentControl ��ʹ��������ģ�ͣ�
- Expander
- GroupBox
- TabItem

ItemsControl ��̳� Control ���ҿ��԰������������ַ��������������Ԫ�ء� ������������Ϊ ItemsSource �� Items�� ItemsSource ͨ��������� ItemsControl ���ݼ��ϡ����¿ؼ��Ӽ̳� ItemsControl ��ʹ��������ģ�ͣ�
- Menu
- MenuBase
- ContextMenu
- ComboBox
- ItemsControl
- ListBox
- ListView
- TabControl
- TreeView
- Selector
- StatusBar

HeaderedItemsControl ��̳� ItemsControl ���ҿ��԰������������ַ��������������Ԫ���Լ���ͷ�� ���̳� ItemsControl ��������ItemsSource �� Items�������� Header ����Ϊ�����������ԡ����¿ؼ��Ӽ̳� HeaderedItemsControl ��ʹ��������ģ�ͣ�
- MenuItem
- ToolBar
- TreeViewItem

Panel �ඨλ�������� UIElement ����������������Ϊ Children������������̳� Panel ����ʹ��������ģ�ͣ�
- Canvas
- DockPanel
- Grid
- TabPanel
- ToolBarOverflowPanel
- ToolBarPanel
- UniformGrid
- StackPanel
- VirtualizingPanel
- VirtualizingStackPanel
- WrapPanel

Decorator �ཫ�Ӿ�Ч��Ӧ���ڻ�Χ�Ƶ����Ӽ� UIElement �� ������������Ϊ Child �� ������Ӽ̳� Decorator ��ʹ��������ģ�ͣ�
- AdornerDecorator
- Border
- BulletDecorator
- ButtonChrome
- ClassicBorderDecorator
- InkPresenter
- ListBoxChrome
- SystemDropShadowChrome
- Viewbox

Adorner �� FrameworkElement �󶨵����Զ��� UIElement�� װ������������ AdornerLayer��������ʼ��λ��װ��Ԫ�ػ�װ��Ԫ�ؼ���֮�ϵĳ���ͼ�档 װ�����ĳ��ֶ����ڳ��� UIElement װ�������󶨵��ġ� װ����ͨ��ʹ��λ��װ��Ԫ�����Ͻǵı�׼2D ����ԭ�㣬�������󶨵���Ԫ�ؽ��ж�λ��
- Adorner 	һ��������࣬���м̳����еľ���װ����ʵ�֡�
- AdornerLayer 	һ���࣬��ʾһ������װ��Ԫ�ص�װ�����ĳ��ֲ㡣
- AdornerDecorator 	һ���࣬ʹװ��������Ԫ�ؼ����������

�����û������ı����� 
- TextBox 	���ı� 	
- RichTextBox 	����ʽ�ı� 	
- PasswordBox 	�����ı����ַ������Σ� 





##### UI����
WPF��Ϊר�ŵ��û����漼�������ֹ��������ĺ��Ĺ���֮һ��
����Ԫ������ Panel �壬��һ��Ԫ�ص����������� Children�������Խ��ܶ���ؼ���Ϊ�Լ������ݲ�����Щ�ؼ����в��ֿ��ơ�
WPF �Ĳ���������ǰ�һ������Ԫ����Ϊ ContentControl �� HeaderedContentControl ��ؼ��� Content�����ڲ���Ԫ�������Ҫ�����ֵ��Ӽ��ؼ������UI�ֲ���Ҫ�����ӵĲ��֣��Ǿ�������������һ���Ӽ��Ĳ���Ԫ�أ��γɲ���Ԫ�ص�Ƕ�ס�


WPF�еĲ���Ԫ�������¼�����
- Grid�����񡣿����Զ����к��в�ͨ�����е��������иߺ��п��������ؼ��Ĳ��֡�������HTML�е�Table��
- StackPanel��ջʽ��塣�ɽ�������Ԫ������ֱ��ˮƽ�������ų�һ��ֱ��,���Ƴ�һ��Ԫ�غ󣬺����Ԫ�ػ��Զ���ǰ�ƶ�������ȱ��
- Canvas���������ڲ�Ԫ�ؿ���ʹ��������Ϊ��λ�ľ���������ж�λ�������� WindowsForm ��̵Ĳ��ַ�ʽ��
- DockPanel������ʽ��塣�ڲ�Ԫ�ؿ���ѡ�񲴿�������������WindowsForm��������ÿؼ��� Dock ���ԡ�
- Wrapanel���Զ�������塣�ڲ�Ԫ��������һ�к��ܹ��Զ����У�������HTML�е���ʽ���֡�


Grid������
- https://docs.microsoft.com/zh-cn/dotnet/api/system.windows.controls.grid?view=net-5.0#definition
- 03�ؼ�����\01Grid.xaml

GridԪ�ػ����������ʽ������Ԫ����(������Children)���в��֡�Grid���ص�����:
- ���Զ��������������к��У�����
- �еĸ߶Ⱥ��еĿ�ȿ���ʹ�þ�����ֵ����Ա������Զ������ķ�ʽ���о�ȷ�趨����������������Сֵ��
- �ڲ�Ԫ�ؿ��������Լ������ڵ��к��У������������Լ�����缸�С�����缸�С�
- ��������ChildrenԪ�صĶ��뷽��

������Щ�ص�, Grid���õĳ����У�
- UI���ֵĴ�����ơ�
- ����UIԪ����Ҫ���л��߳��ж���������
- UI����ߴ�ı�ʱ��Ԫ����Ҫ���ֹ��еĸ߶ȺͿ�ȱ�����
- U1���ڿ����нϴ�������չ��


StackPanel��ջʽ���
- https://docs.microsoft.com/zh-cn/dotnet/api/system.windows.controls.stackpanel?view=net-5.0
- 03�ؼ�����\02StackPanel.xaml

StackPanel ���԰��ڲ�Ԫ�������������Ͻ������С��γ�ջʽ���֣�ͨ�׵ؽ����ǰ��ڲ�Ԫ�����ݻ�ľһ����������������������ǰ��Ļ�ľ����֮�������������Ԫ�ػ�������ǰ�ƶ�����ռԭ��Ԫ�صĿռ䡣��������ص�, StackPanel�ʺϵĳ�����:
- ͬ��Ԫ����Ҫ��������(�������˵������б�)��
- �Ƴ����е�Ԫ�غ��ܹ��Զ���ȱ�Ĳ��ֻ��߶�����

StackPanel ʹ��3�������������ڲ�Ԫ�صĲ��֣������� Orientation��HorizontalAlignment �� VerticalAlignment
- Orientation �����ڲ�Ԫ���Ǻ����ۻ����������ۻ�
- HorizontalAlignment �����ڲ�Ԫ��ˮƽ�����ϵĶ��뷽ʽ
- VerticalAlignment �����ڲ�Ԫ����ֱ�����ϵĶ��뷽ʽ








