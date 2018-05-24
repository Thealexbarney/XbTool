using System.Windows;

namespace SaveEditor.Controls
{
    /// <summary>
    /// Interaction logic for LabeledField.xaml
    /// </summary>
    public partial class LabeledField
    {
        public LabeledField()
        {
            InitializeComponent();

            //LayoutRoot.DataContext = this;
        }

        public string Label
        {
            get => (string)GetValue(LabelProperty);
            set => SetValue(LabelProperty, value);
        }

        public static readonly DependencyProperty LabelProperty =
            DependencyProperty.Register(nameof(Label), typeof(string),
                typeof(LabeledField), new PropertyMetadata(""));

        public object Value
        {
            get => GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }

        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register(nameof(Value), typeof(object), typeof(LabeledField),
            new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
    }
}
