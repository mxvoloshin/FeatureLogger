using System;
using System.Collections.Generic;
using System.Linq;
using Autodesk.Map.IM.Data;
using Autodesk.Map.IM.GeometryConverter.API.Converters.WellKnownText;
using FeatureLogger.ServiceReference;

namespace FeatureLogger
{
    public class FeatureModifyFactory
    {
        private readonly List<ModificationInfo> _modifications;
        private readonly object _lockobject = new object();

        public FeatureModifyFactory()
        {
            _modifications = new List<ModificationInfo>();
        }

        public void AddUpdatingModificationInfo(ModificationInfo mInfo)
        {
            lock (_lockobject)
            {
                if (!_modifications.Contains(mInfo))
                    _modifications.Add(mInfo);   
            }
        }

        public Boolean RemoveUpdatingModificationInfo(ModificationInfo mInfo)
        {
            lock (_lockobject)
            {
                return _modifications.Remove(mInfo);
            }
        }

        public int RemoveUpdatingModificationInfo(Predicate<ModificationInfo> predicate)
        {
            lock (_lockobject)
            {
                return _modifications.RemoveAll(predicate);
            }
        }

        public ModificationInfo GetUpdatingModificationInfo(Func<ModificationInfo, bool> predicate)
        {
            lock (_lockobject)
            {
                return _modifications.FirstOrDefault(predicate);
            }
        }

        public ModificationInfo CreateFeatureModificationInfo(String currentUserName, ModifyState state, long fid, string featureClassName, string featureClassCaption)
        {
            var modifyInfo = new ModificationInfo
            {
                FID = fid,
                FeatureClass = featureClassName,
                FeatureClassCaption = featureClassCaption,
                ModifyTime = DateTime.Now,
                UserName = currentUserName,
                State = state
            };

            return modifyInfo;
        }

        public ModificationInfo CreateFeatureModificationInfo(String currentUserName, ModifyState state, long fid, string featureClassName, Feature feature)
        {
            var modifyInfo = CreateFeatureModificationInfo(currentUserName, state, fid, featureClassName, feature.FeatureClass.Caption);

            var semanticsInfo = CreateSemanticsModificationInfo(feature);
            modifyInfo.SemanticsInfo = semanticsInfo.ToArray();

            var geometryInfo = CreateGeometryModificationInfo(feature);
            modifyInfo.GeometryInfo = geometryInfo;

            return modifyInfo;
        }

        private static IEnumerable<SemanticsModificationInfo> CreateSemanticsModificationInfo(Row feature)
        {
            return feature.Attributes
                .Where(attribute => attribute != feature.Attributes.Geometry && attribute.Modified /*&& !attribute.IsDBNull*/) // get all non geometry attributes
                .Select(attribute => new SemanticsModificationInfo
                {
                    Attribute = attribute.Name,
                    AttributeCaption = attribute.Caption,
                    Value = attribute.IsDBNull ? "Null" : attribute.Value.ToString()
                });
        }
        private static GeometryModificationInfo CreateGeometryModificationInfo(Row feature)
        {
            if (feature.Attributes.Geometry != null && feature.Attributes.Geometry.Modified)
            {
                return new GeometryModificationInfo
                {
                    WKTGeometry = GeometryToWellKnownText.Write(feature.Geometry)
                };   
            }
            return null;
        }
    }
}
