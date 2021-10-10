### 资源
WPF不但支持程序级的传统资源，同时还推出了独具特色的对象级资源，每个界面元素都可以携带自己的资源并可被自己的子级元素共享。比如各种模板、程序样式和主题就经常放在对象级资源里。在WPF程序中数据就分为四个等级存储：数据库里的数据相当于存放在仓库里，资源文件里的数据相当于放在旅行箱里, WPF对象资源里的数据相当于放在随身携带的背包里，变量中的数据相当于拿在手里。

#### WPF对象级资源的定义与查找
每个WPF的界面元素都具有一个名为Resources的属性，这个属性继承自FrameworkElement类，其类型为ResourceDictionary, ResourceDictionary能够以“键一值”对的形式存储资源，当需要使用某个资源时，使用“键一值”对可以索引到资源对象。在保存资源时, ResourceDictionary视资源对象为object类型，所以在使用资源时先要对资源对象进行类型转换, XAML编译器能够根据标签的Attribute自动识别资源类型，如果类型不对就会抛出异常，但在C#代码里检索到资源对象后，类型转换的事情就只能手动处理了。

在检索资源时，先查找控件自己的Resources属性，如果没有这个资源程序会沿着逻辑树向上级控件查找，如果连最顶层容器都没有这个资源，程序就会去查找Application.Resources (也就是程序的顶级资源)，如果还没找到就抛出异常了。

System命名空间引入到xaml代码并映射为sys命名空间：xmlns:sys="clr-namespace:System;assembly=mscorlib"

在c#中可通过this.FindResource("key")获取资源对象，类型转换只能手动处理。sys:数据类型在xaml中怎么进行转换？？？ 还没找到方法，后续补充。。。


#### 动态资源和静态资源
当资源被存储进资源词典后，可以通过两种方式来使用这些资源：静态方式和动态方式。Static和Dynamic，Static指的是程序的非执行状态而Dynamic指的是程序运行状态。对于资源的使用, Static和Dynamic也是这个意思。静态资源使用(StaticResource)指的是在程序载入内存时对资源的一次性使用，之后就不再去访问这个资源了。动态资源使用(DynamicResource)使用指的是在程序运行过程中仍然会去访问资源。如果确定某些资源只在程序初始化的时候使用一次之后不会再改变，就应该使用StaticResource，而程序运行过程中还有可能改变的资源应该以DynamicResource形式使用。

在c#中可通过this.Resources["key"]设置动态资源

#### 向程序添加二进制资源
如果想让外部文件编译进目标成为二进制资源，必须在属性窗口中把文件的BuildAction属性值设为Resource，并不是每种文件都会自动设为Resource，比如图片文件会, mp3文件就不会，一般情况下如果Build Action属性被设为Resource，则Copy to Output Directory属性就设为Do not copy。如果不希望以资源的形式使用外部文件，可以把Build Action设为None，而把Copy to Output Directory设为Copy always。

#### 使用Pack URL路径访问二进制资源
WPF引入了统一资源标识Uri(Unified Resource Identifier)来标识和访问资源。其中较为常见的情况是用Uri加载图像。Uri表达式的一般形式为：协议+授权+路径
- 协议：pack://
- 授权：有两种，一种用于访问编译时已经知道的文件，用application:///。一种用于访问编译时不知道、运行时才知道的文件，用siteoforigin:///。
- 路径：分为绝对路径和相对路径。一般选用相对路径，普适性更强。
- 访问二进制资源使用application:///。pack://application:,,,在XAML中可以省略，C#中不可以。
- 访问外部文件使用siteoforigin:///。pack://SiteOfOrigin:,,,在XAML和C#中都不可以。
```
<Image x:Name="t3_image2" Source="pack://application:,,,/08资源/Resources/grinning-face-emoji.png" Stretch="None"></Image>
<Image x:Name="t3_image3" Source="/08资源/Resources/grinning-face-emoji.png" Stretch="None"></Image>
<Image x:Name="t3_image4" Stretch="None"></Image>

t3_image1.Source = new BitmapImage(new Uri("pack://SiteOfOrigin:,,,/08资源/Resources/yawning-face.png"));
t3_image4.Source = new BitmapImage(new Uri("pack://application:,,,/08资源/Resources/grinning-face-emoji.png"));
```




