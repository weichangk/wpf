### 模板
在WPF中，通过引入模板(Template)微软将数据和算法的“内容”与“形式"解耦了。WPF中的Template分为两大类：ControlTemplate是算法内容的表现形式，一个控件怎样组织其内部结构才能让它更符合业务逻辑、让用户操作起来更舒服就是由它来控制的。它决定了控件“长成什么样子”，并让程序员有机会在控件原有的内部逻辑基础上扩展自己的逻辑。DataTemplate是数据内容的表现形式，一条数据显示成什么样子，是简单的文本还是直观的图形动画就由它来决定。可以理解为, Template就是“外衣”，ControlTemplate是控件的外衣, DataTemplate是数据的外衣。有了Template，使得WPF中的控件不再具有固定的形象，仅仅是算法内容或数据内容的载体。可以把控件理解为一组操作逻辑穿上了一套衣服，换套衣服它就能变成另外一个模样。

#### 数据的外衣DataTemplate
一样的内容可以用不同的形式来展现，软件设计称之为“数据-视图” (Data-View)模式。以往的开发技术如MFC、 Windows Forms、 ASPNET等视图要靠UserControl来实现, WPF不但支持UserControl还支持用DataTemplate为数据形成视图。从UserControl升级到DataTemplate一般就是复制、粘贴一下再改几个字符。使用UserControl实现“数据-视图” (Data-View)模式依赖于事件驱动，“把wpf当作winform来用”。应该使用wpf的数据驱动功能。显然，事件驱动是控件和控件之间沟通或者说是形式与形式之间的沟通，数据驱动则是数据与控件之间的沟通、是内容决定形式。使用DataTemplate就可以很方便地把事件驱动模式升级为数据驱动模式。

- ContentControl的ContentTemplate属性，相当于给ContentControl的内容穿衣服。
- ItemsControl的ItemTemplate属性，相当于给ItemsControl的数据条目穿衣服。
- GridViewColumn的CellTemplate属性，相当于给GridViewColumn单元格里的数据穿衣服。


#### 控件的外衣ControlTemplate
实际项目中, ControlTemplate主要有两大用武之地
- 通过更换ControlTemplate改变控件外观，使之具有更优的用户使用体验及外观。使得换肤更灵活。
- 借助ControlTemplate，程序员与设计师可以并行工作，程序员可以先用WPF标准控件进行编程，等设计师的工作完成后，只需把新的ControlTemplate应用到程序中就可以了。