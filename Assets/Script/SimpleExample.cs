// See LICENSE file in the root directory
//

using UnityEngine;

namespace LGK.Inspector.Example
{
    public class SimpleExample : MonoBehaviour
    {
        byte Id;
        IInspectorService m_InspectorService;

        // Use this for initialization
        void Start()
        {
            m_InspectorService = new UnityInspectorService();

            Build();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Build();
            }
        }

        void Build()
        {
            var customTypeComponent = new GenericExample<CustomType>();
            customTypeComponent.PublicGetPublicSet = new CustomType();

            m_InspectorService.Register(++Id, new object[] {
                    new GenericExample<bool>(),
                    new GenericExample<byte>(),
                    new GenericExample<sbyte>(),
                    new GenericExample<short>(),
                    new GenericExample<ushort>(),
                    new GenericExample<int>(),
                    new GenericExample<uint>(),
                    new GenericExample<long>(),
                    new GenericExample<ulong>(),
                    new GenericExample<char>(),
                    new GenericExample<string>(),
                    new GenericExample<TestEnum>(),
                    new GenericExample<float>(),
                    new GenericExample<double>(),
                    new GenericExample<Vector2>(),
                    new GenericExample<Vector3>(),
                    new CustomDrawerTestComponent(),
                    customTypeComponent,
                });
        }

        public enum TestEnum
        {
            Enum1,
            Enum2
        }

        public class CustomDrawerTestComponent
        {
            public int Value = 2;
        }

        public class CustomType
        {
            public int Value;
        }

        public class NestedLevel1<T>
        {
            public T Nested1Field;

            public T Nested1Property { get; set; }

            public NestedLevel2<T> NestedLevel2 = new NestedLevel2<T>(); 
        }

        public class NestedLevel2<T>
        {
            public T Nested2Field;

            public T Nested2Property { get; set; }
        }

        public class GenericExample<T>
        {
            private T privateValue;
            private T internalValue;
            private T publicValue;

            private T[] arrayValuesNull;
            private T[] arraValues = new T[5];

            public NestedLevel1<T> NestedField = new NestedLevel1<T>();

            public T BoolGetOnly
            {
                get { return privateValue; }
            }

            public T PublicSetOnly
            {
                set { privateValue = value; }
            }

            public NestedLevel1<T> NestedProperty { get; set; }

            public T PriveSetPrivateGet { private get; set; }

            public T PrivateGetPublicSet { private get; set; }

            public T PublicGetPrivateSet { get; private set; }

            public T PublicGetPublicSet { get; set; }
        }
    }
}
