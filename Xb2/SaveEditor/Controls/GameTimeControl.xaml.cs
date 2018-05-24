using System.Windows;
using Xb2.Save;

namespace SaveEditor.Controls
{
    /// <summary>
    /// Interaction logic for GameTimeControl.xaml
    /// </summary>
    public partial class GameTimeControl
    {
        public GameTimeControl()
        {
            InitializeComponent();
        }

        public GameTime Value
        {
            get => (GameTime)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }

        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register(nameof(Value), typeof(GameTime), typeof(GameTimeControl),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
    }
}
