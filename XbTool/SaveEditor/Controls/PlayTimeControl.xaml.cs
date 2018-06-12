using System.Windows;
using XbTool.Save;

namespace SaveEditor.Controls
{
    /// <summary>
    /// Interaction logic for PlayTimeControl.xaml
    /// </summary>
    public partial class PlayTimeControl
    {
        public PlayTimeControl()
        {
            InitializeComponent();
        }
        public ElapseTime Value
        {
            get => (ElapseTime)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }

        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register(nameof(Value), typeof(ElapseTime), typeof(PlayTimeControl),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
    }
}
