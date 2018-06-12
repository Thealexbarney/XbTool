using System.Windows;
using XbTool.Save;

namespace SaveEditor.Controls
{
    /// <summary>
    /// Interaction logic for RealTimeControl.xaml
    /// </summary>
    public partial class RealTimeControl
    {
        public RealTimeControl()
        {
            InitializeComponent();
        }

        public RealTime Value
        {
            get => (RealTime)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }

        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register(nameof(Value), typeof(RealTime), typeof(RealTimeControl),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
    }
}
