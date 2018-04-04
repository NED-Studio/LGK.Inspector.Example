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

        public override object Draw(IMemberInfo memberInfo, object memberValue, string label)
        {
            var value = (SimpleExample.CustomType)memberValue;

            if (value == null)
            {
                EditorGUILayout.LabelField(label, "null (CustomType)");
            }
            else if (memberInfo.IsReadOnly)
            {
                EditorGUILayout.LabelField(label, value.ToString());
            }
            else
            {
                value.Value = EditorGUILayout.IntField(label, value.Value);

                return value;
            }

            return memberValue;
        }
    }
}
