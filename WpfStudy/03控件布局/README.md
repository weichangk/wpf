### 03控件布局

- 按类别分类的控件 https://docs.microsoft.com/zh-cn/dotnet/desktop/wpf/controls/controls-by-category?view=netframeworkdesktop-4.8
- WPF 内容模型 https://docs.microsoft.com/zh-cn/dotnet/desktop/wpf/controls/wpf-content-model?view=netframeworkdesktop-4.8

##### 六类控件
- 布局控件：可以容纳多个控件或嵌套其他布局控件，用于在UI上组织和排列控件。Grid、StackPanel、DockPanel 等控件都属此类，它们拥有共同的父类Panel。
- 内容控件：只能容纳一个其他控件或布局控件作为它的内容。Window、Button 等控件属于此类，因为只能容纳一个控件作为其内容，所以经常需要借助布局控件来规划其内容。它们的共同父类是 ContentControl。
- 带标题内容控件：相当于一个内容控件，但可以加一个标题(Header)，标题部分亦可容纳一个控件或布局。GroupBox、Tabltem 等是这类控件的典型代表。它们的共同父类是 HeaderedContentControl。
- 条目控件：可以显示一列数据，一般情况下这列数据的类型相同。此类控件包括ListBox、ComboBox 等。它们的共同基类是ItemsControl。此类控件在显示集合类型数据方面功能非常强大。
- 带标题条目控件：相当于一个条目控件加上一个标题显示区。TreeViewltem、Menultem 都属于此类控件。这类控件往往用于显示层级关系数据，结点显示在其 Header 区域，子级结点则显示在其条目控件区域。此类控件的共同基类是 HeaderedItemsControl。
- 特殊内容控件：比如 TextBox 容纳的是字符串、TextBlock 可以容纳可自由控制格式的文本、Image 容纳图片类型数据，这类控件相对比较独立。

##### 六类控件派生关系
- DependencyObject >> Visusl >> UIElement >> FrameworkElement
	- Panle
	- Control
		- ConentControl
			- HeaderedContentControl
		- ItemControl
			- HeaderedItemsControl
		- TextBox
	- TextBlock
	- Images

- WPF 是枸建在 .NET Framework 上的一个子系統，它也是一个用于开发应用程序的框架(Framework), FrameworkElement 的 Framework 指的就是WPF Framework。而 FrameworkElement 类在 UIElement 类的基础上添加了很多专门用于 WPF 开发的API(比如SetBinding方法)，所以从这个类开始才算是进入 WPF 开发框架。


##### WPF 内容模型


##### UI布局



