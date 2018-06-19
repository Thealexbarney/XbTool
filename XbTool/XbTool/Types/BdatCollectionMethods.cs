using XbTool.Bdat;

namespace XbTool.Types
{
    public partial class BdatCollection
    {
        public IBdatTable this[string name] => (IBdatTable)GetType().GetField(name).GetValue(this);
    }
}
