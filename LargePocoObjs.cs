using System.Collections.Generic;
using System.Linq;

namespace CompositeProxy
{
    public class LargePocoObjs
    {
        string[] StringOnes;
        ulong[] LongOnes;
        string[] StringTwos;
        long[] LongTwos;
        string[] StringThrees;
        int[] Statuss;
        string[] StringFours;
        private readonly int lengthOfCollection;

        public LargePocoObjs(int lengthOfCollection)
        {
            StringOnes = new string[lengthOfCollection];
            LongOnes = new ulong[lengthOfCollection];
            StringTwos = new string[lengthOfCollection];
            LongTwos = new long[lengthOfCollection];
            StringThrees = new string[lengthOfCollection];
            Statuss = new int[lengthOfCollection];
            StringFours = new string[lengthOfCollection];
            this.lengthOfCollection = lengthOfCollection;
        }

        public struct LargePocoObjProxy
        {
            private readonly LargePocoObjs largePocoObjs;
            private readonly int index;
            public LargePocoObjProxy(LargePocoObjs largePocoObjs, int index)
            {
                this.largePocoObjs = largePocoObjs;
                this.index = index;
            }

            public ref string StringOne => ref largePocoObjs.StringOnes[index];
            public ref ulong LongOne => ref largePocoObjs.LongOnes[index];
            public ref string StringTwo => ref largePocoObjs.StringTwos[index];
            public ref long LongTwo => ref largePocoObjs.LongTwos[index];
            public ref string StringThree => ref largePocoObjs.StringThrees[index];
            public ref int Status => ref largePocoObjs.Statuss[index];
            public ref string StringFour => ref largePocoObjs.StringFours[index];
        }

        public IEnumerator<LargePocoObjProxy> GetEnumerator()
        {
            for (int pos = 0; pos < lengthOfCollection; pos++)
            {
                yield return new LargePocoObjProxy(this, pos);
            }
        }
    }
}