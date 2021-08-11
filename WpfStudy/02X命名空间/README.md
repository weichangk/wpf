### 02X命名空间
- x 名称空间里有什么？

        x 名称空间映射的是 xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"。他包含的类均与解析XAML语言相关，称之为“XAML命名空间”。与 c# 语言一样，XAML也有自己的编译器，XAML 语言会被解析编译成为中间语言存储在程序集中。
        XAML 命名空间可以分为 Attribute、标志扩展和 XAML 指令元素三类。
        参考：https://docs.microsoft.com/zh-cn/dotnet/desktop/xaml-services/namespace-language-features?view=netdesktop-5.0

- x 名称空间中的 Attribute。Attribute 与 Property 是两个层面的东西，Attribute 是语言层面是给编译器看的， Property 是面向对象层面是给编程逻辑用的，而且一个 XAML 标签的 Attribute 里大部分都对应着对象的 Property。
    - x:Class 告诉 XAML 编译器将 XAML 标签的编译结果与后台代码中指定的类合并。在使用x:Class时必须遵循以下要求:
        - 只能用于根结点。
        - 使用 x:Class 的根结点的类型要与 x:Class 的值所指示的类型保持一致。
        - x:Class 的值所指示的类型在声明时必须使用partial关键字。

    - x:ClassModifier 告诉 XAML 编译由标签编译生成的类具有怎样的访问控制级别。
        - 标签必须具有 x:Class Attribute。
        - x: ClassModifier 的值必须与 x:Class 所指示类的访问控制级别一致。
        - x: ClassModifier 的值随后台代码的编译语言不同而有所不同，参见TypeAttributes枚举类型。

    - x:Name XAML 的标签声明的是对象，一个XAML标签会对应着一个对象，这个对象一般是一个控件类的实例。在NET平台上，类是引用类型，引用类型的实例在使用时一般是以“引用者 -> 实例”的形式成对出现的，通过引用者来访问实例。x:Name为对象指定名称。x:Name 的作用有两个      
        - 告诉XAMIL编译器，当一个标签带有 x:Name 时除了为这个标签生成对应实例外还要为这个实例声明一个引用变量，变量名就是 x:Name 的值
        - 将 XAML 标签所对应对象的 Name 属性(如果有)也设为 x:Name 的值，并把这个值注册到 UI 树上，以方便查找，增强代码的统一性和可读性。

    - x:FieldModifier 使用x:Name后, XAML标签对应的实例就具有了自己的引用变量，而且这些引用变量都是类的字段。既然是类的字段就免不了要关注一下它们的访问级别。默认情况下，这些字段的访问级别按照面向对象的封装原则被设置成了 internal。在编程的时候，有时候我们需要从一个程序集访问另一个程序集中窗体的元素，这时候就需要把被访问控件的引用变量改为 public 级别，x:FieldModifier 就是用来在XAML里改变引用变量访问级别的。
    - x:Key 在XAML文件中，可以把很多需要多次使用的内容提取出来放在资源字典(Resource Dictionary)里，需要使用这个资源的时候就用它的 Key 把它检索出来。XAML 和 C# 可以通过 {StaticResource = key} 和 this.FindResource("key")使用在资源字典中添加了x:Key的的元素。
    - x:Shared x:Shared 一定要与 x:key 配合使用，如果x:Shared的值为true，那么每次检索到这个对象时到的都是同一个对象，如果x:Shared的值为false，每次检索到这个对象时，我们得到的都是这个对象的一个新副本，x:Shared的值默认为true。

- x 名称空间中的标志扩展
    - x:Type 提供作为 Type 指定 XAML 类型的基础类型的 CLR 对象。
    - x:Null 指定 null 作为 XAML 成员的值。
    - x:Array 为元素提供Type类型的集合数据源
    - x:Static 在XAML文档中使用数据类型的 static 成员，因为 XAML 不能编写逻辑代码，所以使用 x:Static 访问的 static 成员一定是数据类型的属性或字段。

- x 名称空间中的标志扩展
    - x:Code 允许在 XAML 生产中放置代码。
    - x:XData WPF类库中包含多种数据提供者，其中有一个类叫 XmlDataProvider 专门用于提供XML化的数据。如果想在XAML里声明一个带有数据的 XmlDataProvider 实例，那么 XmlDataProvider 实例的数据就要放在 x:XData 标签的内容里。














