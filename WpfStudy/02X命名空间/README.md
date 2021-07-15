### 02X命名空间
- x 名称空间里有什么？
        x 名称空间映射的是 xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"。他包含的类均与解析XAML语言相关，称之为“XAML命名空间”。与 c# 语言一样，XAML也有自己的编译器，XAML 语言会被解析编译成为中间语言存储在程序集中。
        XAML 命名空间可以分为 Attribute、标志扩展和 XAML 指令元素三类。
        参考：https://docs.microsoft.com/zh-cn/dotnet/desktop/xaml-services/namespace-language-features?view=netdesktop-5.0

- x 名称空间中的 Attribute
        Attribute 与 Property 是两个层面的东西，Attribute 是语言层面是给编译器看的， Property 是面向对象层面是给编程逻辑用的，而且一个 XAML 标签的 Attribute 里大部分都对应着对象的 Property。
    - x:Class
        告诉 XAML 编译器将 XAML 标签的编译结果与后台代码中指定的类合并。在使用x:Class时必须遵循以下要求:
        - 只能用于根结点。
        - 使用 x:Class 的根结点的类型要与 x:Class 的值所指示的类型保持一致。
        - x:Class 的值所指示的类型在声明时必须使用partial关键字。
    - x:ClassModifier
        告诉 XAML 编译由标签编译生成的类具有怎样的访问控制级别。
        - 标签必须具有 x:Class Attribute。
        - x: ClassModifier 的值必须与 x:Class 所指示类的访问控制级别一致。
        - x: ClassModifier 的值随后台代码的编译语言不同而有所不同，参见TypeAttributes枚举类型。
    - x:Name
        XAML 的标签声明的是对象，一个XAML标签会对应着一个对象，这个对象一般是一个控件类的实例。在NET平台上，类是引用类型，引用类型的实例在使用时一般是以“引用者 -> 实例”的形式成对出现的，通过引用者来访问实例。x:Name为对象指定名称。
        x:Name 的作用有两个
        - 告诉XAMIL编译器，当一个标签带有 x:Name 时除了为这个标签生成对应实例外还要为这个实例声明一个引用变量，变量名就是 x:Name 的值
        - 将 XAML 标签所对应对象的 Name 属性(如果有)也设为 x:Name 的值，并把这个值注册到 UI 树上，以方便查找，增强代码的统一性和可读性。


