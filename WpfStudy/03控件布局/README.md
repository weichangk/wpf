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

##### 控件派生关系
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

- WPF 是枸建在 .NET Framework 上的一个子系統，它也是一个用于开发应用程序的框架(Framework), FrameworkElement 指的就是WPF Framework。而 FrameworkElement 类在 UIElement 类的基础上添加了很多专门用于 WPF 开发的API(比如SetBinding方法)，所以从这个类开始才算是进入 WPF 开发框架。
- UIElement 是 WPF 核心级实现的基类，这些实现是在 Windows Presentation Foundation (WPF) 元素和基本表示特性上生成的。
- FrameworkElement 提供 Windows Presentation Foundation (WPF) 元素的属性、事件和方法的 WPF 框架级别集。 此类表示所提供的 WPF 框架级别实现基于 UIElement 定义的 WPF 核心级别 API。


##### WPF 内容模型

WPF 的 UI 元素类型
- ContentControl 	一个任意对象。
- HeaderedContentControl 	一个标头和一个项（两者都是任意对象）。
- ItemsControl 	一个任意对象集合。
- HeaderedItemsControl 	一个标头和一个项集合（全部都是任意对象）。

ContentControl 类包含一段任意内容。它的内容属性为 Content。以下控件从继承 ContentControl 并使用其内容模型：
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

HeaderedContentControl 类继承 ContentControl，并显示带有标题的内容。 它从中继承 content 属性， Content ContentControl 并定义类型为的 Header 属性 Object；因此，两者都可以是任意对象。以下控件从继承 HeaderedContentControl 并使用其内容模型：
- Expander
- GroupBox
- TabItem

ItemsControl 类继承 Control 并且可以包含多个项，例如字符串、对象或其他元素。 它的内容属性为 ItemsSource 和 Items。 ItemsSource 通常用于填充 ItemsControl 数据集合。以下控件从继承 ItemsControl 并使用其内容模型：
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

HeaderedItemsControl 类继承 ItemsControl 并且可以包含多个项，例如字符串、对象或其他元素以及标头。 它继承 ItemsControl 内容属性ItemsSource 和 Items，并定义 Header 可以为任意对象的属性。以下控件从继承 HeaderedItemsControl 并使用其内容模型：
- MenuItem
- ToolBar
- TreeViewItem

Panel 类定位和排列子 UIElement 对象。它的内容属性为 Children。下面的类从类继承 Panel ，并使用其内容模型：
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

Decorator 类将视觉效果应用于或围绕单个子级 UIElement 。 它的内容属性为 Child 。 以下类从继承 Decorator 并使用其内容模型：
- AdornerDecorator
- Border
- BulletDecorator
- ButtonChrome
- ClassicBorderDecorator
- InkPresenter
- ListBoxChrome
- SystemDropShadowChrome
- Viewbox

Adorner 是 FrameworkElement 绑定到的自定义 UIElement。 装饰器呈现在中 AdornerLayer，后者是始终位于装饰元素或装饰元素集合之上的呈现图面。 装饰器的呈现独立于呈现 UIElement 装饰器所绑定到的。 装饰器通常使用位于装饰元素左上角的标准2D 坐标原点，相对于其绑定到的元素进行定位。
- Adorner 	一个抽象基类，从中继承所有的具体装饰器实现。
- AdornerLayer 	一个类，表示一个或多个装饰元素的装饰器的呈现层。
- AdornerDecorator 	一个类，使装饰器层与元素集合相关联。

可让用户输入文本的类 
- TextBox 	纯文本 	
- RichTextBox 	带格式文本 	
- PasswordBox 	隐藏文本（字符已屏蔽） 





##### UI布局
WPF作为专门的用户界面技术，布局功能是它的核心功能之一。
布局元素属于 Panel 族，这一族元素的内容属性是 Children，即可以接受多个控件作为自己的内容并对这些控件进行布局控制。
WPF 的布局理念就是把一个布局元素作为 ContentControl 或 HeaderedContentControl 族控件的 Content，再在布局元素里添加要被布局的子级控件，如果UI局部需要更复杂的布局，那就在这个区域放置一个子级的布局元素，形成布局元素的嵌套。


WPF中的布局元素有如下几个：
- Grid：网格。可以自定义行和列并通过行列的数量、行高和列宽来调整控件的布局。近似于HTML中的Table。
- StackPanel：栈式面板。可将包含的元素在竖直或水平方向上排成一条直线,当移除一个元素后，后面的元素会自动向前移动以填充空缺。
- Canvas：画布。内部元素可以使用以像素为单位的绝对坐标进行定位，类似于 WindowsForm 编程的布局方式。
- DockPanel：泊靠式面板。内部元素可以选择泊靠方向，类似于在WindowsForm编程中设置控件的 Dock 属性。
- Wrapanel：自动折行面板。内部元素在排满一行后能够自动折行，类似于HTML中的流式布局。


Grid：网格
- https://docs.microsoft.com/zh-cn/dotnet/api/system.windows.controls.grid?view=net-5.0#definition
- 03控件布局\01Grid.xaml

Grid元素会以网格的形式对内容元素们(即它的Children)进行布局。Grid的特点如下:
- 可以定义任意数量的行和列，常灵活。
- 行的高度和列的宽度可以使用绝对数值、相对比例或自动调整的方式进行精确设定，并可设置最大和最小值。
- 内部元素可以设置自己的所在的行和列，还可以设置自己纵向跨几行、横向跨几列。
- 可以设置Children元素的对齐方向。

基于这些特点, Grid适用的场合有：
- UI布局的大框架设计。
- 大量UI元素需要成行或者成列对齐的情况。
- UI整体尺寸改变时，元素需要保持固有的高度和宽度比例。
- U1后期可能有较大变更或扩展。


StackPanel：栈式面板
- https://docs.microsoft.com/zh-cn/dotnet/api/system.windows.controls.stackpanel?view=net-5.0
- 03控件布局\02StackPanel.xaml

StackPanel 可以把内部元素在纵向或横向上紧凑排列、形成栈式布局，通俗地讲就是把内部元素像垒积木一样“撂起来”。当把排在前面的积木块抽掉之后排在它后面的元素会整体向前移动、补占原有元素的空间。基于这个特点, StackPanel适合的场合有:
- 同类元素需要紧凑排列(如制作菜单或者列表)。
- 移除其中的元素后能够自动补缺的布局或者动画。

StackPanel 使用3个属性来控制内部元素的布局，它们是 Orientation，HorizontalAlignment 和 VerticalAlignment
- Orientation 决定内部元素是横向累积还是纵向累积
- HorizontalAlignment 决定内部元素水平方向上的对齐方式
- VerticalAlignment 决定内部元素竖直方向上的对齐方式








