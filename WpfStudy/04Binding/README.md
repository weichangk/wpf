## Binding
https://docs.microsoft.com/zh-cn/dotnet/desktop/wpf/data/data-binding-overview?view=netframeworkdesktop-4.8

WPF��Ϊһ��ר�ŵ�չʾ�㼼������������ۺͶ���ֻ�����ı�����󣬸���Ҫ�������������ϰ�������Ա��˼ά�����Ĺ̶������߼��㡢��չʾ����Զ�����߼���Ĵ�����λ��
WPF�������������Ĺؼ����������� Data Binding �����Լ���֮���׵� Dependency Property ϵͳ�� DataTemplate��

չʾ��ʹ��WPF�����ʵ�֣���չʾ�����߼���Ĺ�ͨʹ�� Data Binding ��ʵ�֡�Data Binding �� WPF ϵͳ���𵽵������ݸ��ٹ�·�����á�
�����������ٹ�·���ӹ��õ����ݻ��Զ��ʹ��û����������ʾ�����û��޸Ĺ�������Ҳ���Զ������߼��㣬һ�����ݱ��ӹ����ֻᱻ�ʹ��û��硣
������߼������һ��ǿ���������治ͣ��ת���üӹ��õ���������������û����������֡�ͼ�Ρ���������ʽ��������ʾ����������ǡ���������UI����
Binding ���������������������˷ֱ��� Binding ��Դ(Source)��Ŀ��(Target)��Binding Դ���߼���Ķ���, Binding Ŀ���� U1 ��Ŀؼ�����


### Binding ����
����Դ��һ������һ���������Ͽ����кܶ����ݣ���Щ������ͨ�����Ա�¶����硣�����ĸ���������ͨ�� Binding �ʹ� UI Ԫ�ص��أ����仰˵, UI�ϵ�Ԫ�ع��ĵ����ĸ�����ֵ�ı仯�أ�
������Ծͳ�ΪBinding��·��(Path)�����������Ի����У�Binding��һ���Զ����ƣ���ֵ�仯������Ҫ������֪ͨ Binding����Binding�ѱ仯���ݸ�UIԪ�ء�
����������һ�����Ծ߱�����֪ͨ Binding ֵ�Ѿ��仯��������?
�����������Ե� set ����м���һ�� PropertyChanged �¼�������Ϊ����Դ����ʵ�� System.ComponentModel ���ƿռ��е� INotifyPropertyChanged �ӿڡ�
��ΪBinding����������Դ��Binding �ͻ��Զ�������������ӿڵ� PropertyChanged �¼���


### Binding Դ(Source)��·��(Path)
Binding ��ԴҲ�������ݵ�Դͷ��Binding��Դ��Ҫ�󲢲����̣�ֻҪ����һ�����󣬲���ͨ������(Property)�����Լ������ݣ���������ΪBinding��Դ��
������ΪBindingԴ�Ķ�������Զ�֪ͨBinding�Լ�������ֵ�Ѿ��仯����������Ҫ����ʵ�� INotifyPropertyChanged �ӿڣ��������Ե� set ����м��� PropertyChanged �¼���
����ʹ�����ֶ�����Ϊ����Դ�⣬���и����ѡ�񣬱���ؼ����Լ����Լ����������Ӽ�Ԫ�ص�Դ����һ���ؼ���Ϊ��һ���ؼ�������Դ���Ѽ�����Ϊ ItemsControl ������Դ��ʹ�� XML ��Ϊ TreeView �� Menu ������Դ���Ѷ���ؼ�������һ���������Ƹߵ㡱�ϣ������ɴ಻��Bindingָ������Դ�������Լ�ȥ�ҡ�


#### �ѿؼ���Ϊ Binding Դ�� Binding ��־��չ
��xaml��ʹ��Binding��־��չ���ؼ���Ϊ�����ؼ���BindingԴ
����� UIElement ���Զ����������ԣ���������������ԣ�ֻ�����Գ��⣩Ĭ��֧�����ݰ󶨡����������� DependencyObject �����Ͳ��ܶ����������ԣ����� UIElement ���Ͷ������� DependencyObject����

#### ���� Binding �ķ������ݸ���
���� Binding ��������������� Mode������������ BindingMode ö�١�BindingMode ��ȡֵΪ TwoWay, OneWay, OnTime��OneWayToSource��Default��
Default ֵ��ָ Binding ��ģʽ�����Ŀ���ʵ�������ȷ�����������ǿɱ༭��(��TextBox.Text����), Default �Ͳ���˫��ģʽ������ֻ����(��TextBlock.Text)����õ���ģʽ��

- OneWay ��Դ���Եĸ��Ļ��Զ�����Ŀ�����ԣ�����Ŀ�����Եĸ��Ĳ��ᴫ����Դ���ԡ� ����󶨵Ŀؼ�Ϊ��ʽֻ����������͵İ����á�
- TwoWay ����Դ���Ի�Ŀ������ʱ���Զ�������һ���� �����͵İ������ڿɱ༭�����������ȫ����ʽ UI ���������������Ĭ��Ϊ OneWay �󶨣���ĳЩ�������ԣ�ͨ��Ϊ�û��ɱ༭�ؼ������ԣ����� TextBox.Text �� CheckBox.IsChecked��Ĭ��Ϊ TwoWay �󶨡� ����ȷ���������԰���Ĭ��������ǵ�����˫��ı�̷����ǣ�ʹ�� DependencyProperty.GetMetadata ��ȡ����Ԫ���ݣ�Ȼ���� FrameworkPropertyMetadata.BindsTwoWayByDefault ���ԵĲ���ֵ��
- OneWayToSource �� OneWay ���෴����Ŀ�����Ը���ʱ���������Դ���ԡ� ʾ��������ֻ��Ҫ�� UI ���¼���Դֵ�������
- OneTime ��ʹԴ���Գ�ʼ��Ŀ�����ԣ����������������ġ� ������������ķ������ģ����������������еĶ��������ģ�����Ĳ�����Ŀ�������з�ӳ�� ����ʺ�ʹ�õ�ǰ״̬�Ŀ��ջ�����ʵ��Ϊ��̬���ݣ�������͵İ��ʺϡ� �������ʹ��Դ�����е�ĳ��ֵ����ʼ��Ŀ�����ԣ�����ǰ��֪�����������ģ�������͵İ�Ҳ���á� ��ģʽʵ������ OneWay �󶨵�һ�ּ���ʽ������Դֵ�����ĵ�������ṩ���õ����ܡ�

����Դ���µ����أ�
TwoWay �� OneWayToSource ������Ŀ�������еĸ��ģ��������Ĵ�����Դ����Ϊ����Դ�������磬���Ա༭�ı�����ı��Ը��Ļ���Դֵ��
Binding.UpdateSourceTrigger ����ȷ������Դ���µ����ء�
��ͬ���������Ծ��в�ͬ��Ĭ�� UpdateSourceTrigger ֵ�� ������������Ե�Ĭ��ֵΪ PropertyChanged���� TextBox.Text ���Ե�Ĭ��ֵΪ LostFocus�� PropertyChanged ��ʾԴ����ͨ����ÿ��Ŀ�����Ը���ʱ������ ��ʱ���������� CheckBox �������򵥿ؼ��� �������ı��ֶΣ�ÿ�λ����󶼽��и��»ή�����ܣ��û�Ҳû�л������ύ��ֵ֮ǰʹ�� Backspace ���޸ļ������

- LostFocus��TextBox.Text ��Ĭ��ֵ�����ؼ�ʧȥ����ʱ������
- PropertyChanged ÿ��Ŀ�����Ը���ʱ������
- Explicit ����Ӧ�ó������UpdateSource����ʱ�Żᴥ����

Binding ������ NotifyOnSourceUpdated �� NotifyOnTargetUpdated ���� bool ���͵����ԡ������Ϊtrue����Դ��Ŀ�걻���º� Binding �ἤ����Ӧ�� SourceUpdated �¼��� TargetUpdated �¼�������ͨ�������������¼����ҳ�����Щ���ݻ�ؼ��������ˡ�


#### Binding ��·�� Path
�� XAML �����л��� Binding ��Ĺ����������б�����һ���ַ�������ʾ Path���� Path ��ʵ�������� PropertyPath��
Binding ��·�� Path ��֧�ֶ༶·��(����һ· . ��ȥ)�����Ե����ԣ������������������������Ե����� .[index]��
��� Binding ��·�� Path �Ǽ������ͣ�����ʹ��б���﷨��������ϵ����Ի��Ǽ��Ͽ���ʹ�ö༶б���﷨��һ· / ��ȥ��

û�� Path �� Binding
Binding Դ����������ݿ��Բ���Ҫ Path ��ָ�������͵�, string�� int�Ȼ������;������������ǵ�ʵ������������ݣ��޷�ָ��ͨ�������ĸ�����������������ݣ���ʱֻ�轫 Path ��ֵ����Ϊ��." �Ϳ����ˡ���XAML��������� "." ����ʡ�Բ�д������C#������ȴ����ʡ�ԡ�


#### Ϊ Binding ָ��Դ(Source)�ļ��ַ���
Binding ��Դ�����ݵ���Դ������ֻҪһ������������ݲ���ͨ�����԰����ݱ�¶�����������ܵ���Binding��Դ��ʹ�á�����Ϊ Binding �� Source ָ�����ʵĶ���Binding ������ȷ�����������İ취�У�

- ����ͨCLR���͵�������ָ��ΪSource������.NET Framework�Դ����͵Ķ�����û��Զ������͵Ķ����������ʵ����INotifyPropertyChanged�ӿڣ����ͨ�������Ե�set����Ｄ��PropertyChanged�¼���֪ͨBinding�����ѱ����¡�
- ����ͨCLR�������Ͷ���ָ��ΪSource���������顢List<T>�� ObservableCollection<T>�ȼ������͡�һ���ǰѿؼ���ItemsSource����ʹ��Binding������һ�����϶����ϡ�
- ��ADO.NET���ݶ���ָ��ΪSource������DataTable��DataView�ȶ���
- ʹ��XmlDataProvider��XML����ָ��ΪSource��XML��Ϊ��׼�����ݴ洢�ʹ����ʽ�����޴����ڣ�����������ʾ�������ݶ�����߼��ϣ�һЩWPF�ؼ��Ǽ���ʽ��(��TreeView��Menu)�����԰���״�ṹ��XML������ΪԴָ������֮������Binding��
- ����������(Dependency Object)ָ��ΪSource���������󲻽�������ΪBinding��Ŀ�꣬ͬʱҲ������ΪBinding��Դ���������п����γ�Binding�������������е��������Կ�����ΪBinding��Path��
- ��������DataContextָ��ΪSource (WPF Data Binding��Ĭ����Ϊ)����ʱ�������������������Ѿ���ȷ֪�������ĸ����Ի�ȡ���ݣ���������ĸ�������ΪBindingԴ������ȷ������ʱ��ֻ���Ƚ���һ��Binding��ֻ��������Path��������Source,�����Binding�Լ�ȥѰ��Source��Binding���Զ��ѿؼ���DataContext�����Լ���Source(�������ſؼ���һ��һ�������ң�ֱ���ҵ�����Pathָ�����ԵĶ���Ϊֹ)��
- ͨ��ElementNameָ��Source����C#���������ֱ�ӰѶ�����ΪSource��ֵ��Binding����XAML�޷����ʶ�������ֻ��ʹ�ö����Name�������ҵ�����
- ͨ��Binding��RelativeSource������Ե�ָ��Source�����ؼ���Ҫ��ע�Լ��ġ��Լ������Ļ����Լ��ڲ�Ԫ�ص�ĳ��ֵ����Ҫʹ�����ְ취��
- ��ObjectDataProvider����ָ��ΪSource��������Դ�����ݲ���ͨ�����Զ���ͨ��������¶������ʱ��,����ʹ�������ֶ�������װ����Դ�ٰ�����ָ��ΪSource��
- ��ʹ��LINQ�����õ������ݶ�����ΪBinding��Դ��

##### ʹ��DataContext��ΪBinding��Դ
- ��UI�ϵĶ���ؼ���ʹ��Binding��עͬһ������ʱ,����ʹ��DataContext��
- ����ΪSource�Ķ����ܱ�ֱ�ӷ��ʵ�ʱ�򡣱���B�����ڵĿؼ����A�����ڵĿؼ������Լ���BindingԴʱ����A�����ڵĿؼ���private���ʼ�����ʱ��Ϳ��԰�����ؼ�(���߿ؼ���ֵ)��Ϊ����A��DataContext (���������public���ʼ����)�Ӷ���¶���ݡ�
- ����ͬ�㼶������DataContext���൱��һ�����ݵġ��Ƹߵ㡱��ֻҪ�����ݷ���ȥ�����Ԫ�ؾͶ��ܿ�����DataContext����Ҳ��һ���������ԣ����ǿ���ʹ��Binding����������һ������Դ�ϡ�

##### ʹ�ü��϶�����Ϊ�б�ؼ���ItemsSource
WPF�е��б�ʽ�ؼ���������ItemsControl�࣬��ȻҲ�ͼ̳���ItemsSource������ԡ�ItemsSource���Կ��Խ���һ��IEnumerable�ӿ��������ʵ����Ϊ�Լ���ֵ(���пɱ����������ļ��϶�ʵ��������ӿڣ��������顢List<T>��)��ÿ��ItemsControl�������඼�����Լ���Ӧ����Ŀ����(Item Container)������, ListBox����Ŀ������ListBoxltem��ComboBox����Ŀ������ComhoBoxltem��ItemsSource���ŵ���һ��һ�������ݡ�
����Binding��ֻҪΪһ��ItemsControl����������itemsSource����ֵ��Itemslontrol����ͻ��Զ��������е�����Ԫ�ء�Ϊÿ������Ԫ��׼��һ����Ŀ��������ʹ��Binding����Ŀ����������Ԫ��֮�佨���������
��xaml�п���ʹ��DataTemplateʵ�ֶԼ��϶�������ݰ󶨡�
ʹ�ü���������Ϊ�б�ؼ���ItemsSourceʱһ��ῼ��ʹ��ObservableCollection<T>����List<T>��ΪObservableCollection<T>��ʵ����INotifyCollectionChanged��INotifyPropertyChanged�ӿڣ��ܰѼ��ϵı仯����֪ͨ��ʾ�����б�ؼ���ʵ���з���List<T>Ҳ���Ը��±仯������

##### ʹ��ADO.NET������ΪBinding��Դ
DataTable����ֱ������ΪItemsSource��ֵ����ҪDataTable.DefaultView�����ǰ�DataTable�������һ�������DataContext���������ItemsSource��һ����û��ָ��Source��û��ָ��Path��Binding��������ʱ, Bindingȴ���Զ��ҵ�����DefaultView�������Լ���Source��ʹ�á�



















