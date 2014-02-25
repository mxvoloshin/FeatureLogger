using Autodesk.Map.IM.Data;
using Autodesk.Map.IM.Update;

namespace FeatureLogger
{
    public class StructureUpdatePlugIn : DocumentStructureUpdatePlugIn
    {
        public override DMCodeNumber DataModelCode
        {
            get { return new DMCodeNumber(10, 0, 0); }
        }

        public override string DataModelCodeText
        {
            get { return @"FeatureLogger"; }
        }

        public override CategoryType Category()
        {
            return CategoryType.Extension;
        }
    }
}
