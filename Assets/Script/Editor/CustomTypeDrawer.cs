// See LICENSE file in the root directory
//

using System;
using UnityEditor;

namespace LGK.Inspector.Example
{
    public class CustomTypeDrawer : Inspector.CustomTypeDrawer
    {
        public override Type TargetType
        {
            get { return typeof(SimpleExample.CustomType); }
        }

        public override void Draw(IFieldInfo fieldInfo, object owner)
        {
            var value = (SimpleExample.CustomType)fieldInfo.GetValue(owner);

            if (value == null)
            {
                EditorGUILayout.LabelField(fieldInfo.Name, "null (CustomType)");
                return;
            }

            var newValue = EditorGUILayout.IntField(fieldInfo.Name, value.Value);

            if (value.Value != newValue)
                fieldInfo.SetValue(owner, newValue);
        }

        public override void Draw(IPropertyInfo propertyInfo, object owner)
        {
            var value = (SimpleExample.CustomType)propertyInfo.GetValue(owner);

            if (value == null)
            {
                EditorGUILayout.LabelField(propertyInfo.Name, "null (CustomType)");
                return;
            }

            if (propertyInfo.IsReadOnly)
            {
                EditorGUILayout.LabelField(propertyInfo.Name, value.ToString());
            }
            else
            {
                var newValue = EditorGUILayout.IntField(propertyInfo.Name, value.Value);

                if (value.Value != newValue)
                    propertyInfo.SetValue(owner, newValue);
            }
        }
    }
}
