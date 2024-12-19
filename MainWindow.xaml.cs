using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp5
{

        

        public partial class MainWindow : Window
        {
        private List<string> strings = new List<string>() { "1", "2", "3" };
        private List<MyUserControl> _controls = new();
        private List<MyUserControl> Controls = new();
        public MainWindow()
            {
                InitializeComponent();
            _controls.Add(new MyUserControl() { Number = 33 });
            _controls.Add(new MyUserControl() { Number = 44 });
            _controls.Add(new MyUserControl() { Number = 55 });
            Controls = _controls;

            Controls = Controls.Where(n => n.Number > 0).ToList();
            listBox.ItemsSource = Controls;
            listBox.Items.Refresh();
            
            List<int> ints = _controls.Select(Control => Control.Number).ToList();
            ints = ints.OrderByDescending(n => n).ToList();
            strings = strings.Where(s => s.Contains("1")).ToList();

            Debug.WriteLine(_controls);
        }

        //Фильтрация
        private List<MyUserControl> FilterByNumber(int number, List<MyUserControl> controls)
        {
            return Controls.Where(control => control.Number > 0).ToList();
        }

        private bool Filter(MyUserControl control) => control.Number > 0;

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse((sender as TextBox).Text, out int result))
            {
                Controls = FilterByNumber(result, _controls);
                listBox.ItemsSource = Controls;
                listBox.Items.Refresh();
            }
        }

        private void ComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string s = e.AddedItems[0] as string;
            s.Replace('a', 'b');
        }
    }
    
}