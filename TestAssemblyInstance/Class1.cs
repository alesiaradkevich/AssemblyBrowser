using System;

namespace ns1
{
    public class Class1
    {
        public int PublicField;
        private float PrivateFields;
        public int PublicProperty { get; private set; }
        public float ProvateProperty { get; set; }

        public static void Method1(int a, int b) { }
        private int Method2() { return 1; }
        protected virtual void Method3(string str) { }
    }
}
