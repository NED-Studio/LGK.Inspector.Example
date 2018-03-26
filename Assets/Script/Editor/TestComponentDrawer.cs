// See LICENSE file in the root directory
//

using System;
using UnityEditor;

namespace LGK.Inspector.Example
{
    public class TestComponentDrawer : CustomComponentDrawer
    {
        public override Type TargetType
        {
            get { return typeof(SimpleExample.CustomDrawerTestComponent); }
        }

        public override void Draw(IComponentInfo componentInfo)
        {
            EditorGUILayout.LabelField("Custom Component Drawer works!");
        }
    }
}
