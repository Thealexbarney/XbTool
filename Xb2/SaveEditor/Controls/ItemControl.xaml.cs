using System.Windows;
using Xb2.Save;

namespace SaveEditor.Controls
{
    /// <summary>
    /// Interaction logic for Item.xaml
    /// </summary>
    public partial class ItemControl
    {
        public ItemControl()
        {
            InitializeComponent();
        }

        public GfItemInfo Value
        {
            get => (GfItemInfo)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }

        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register(nameof(Value), typeof(GfItemInfo), typeof(ItemControl),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
    }
}
