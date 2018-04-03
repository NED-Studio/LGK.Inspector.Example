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

        public override object Draw(IMemberInfo memberInfo, object memberValue)
        {
            var value = (SimpleExample.CustomType)memberValue;

            if (value == null)
            {
                EditorGUILayout.LabelField(memberInfo.Name, "null (CustomType)");
            }
            else if (memberInfo.IsReadOnly)
            {
                EditorGUILayout.LabelField(memberInfo.Name, value.ToString());
            }
            else
            {
                value.Value = EditorGUILayout.IntField(memberInfo.Name, value.Value);

                return value;
            }

            return memberValue;
        }
    }
}
