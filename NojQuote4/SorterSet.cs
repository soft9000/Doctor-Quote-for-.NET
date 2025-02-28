using System;
using System.Collections.Generic;

namespace Ordered
{
    class SorterSet
    {
        public static List<KeyValuePair<string, int>> Sort(Dictionary<string, int> source)
        {
            var array = new List<KeyValuePair<string, int>>(source.Count);
            foreach (var key in source.Keys)
            {
                array.Add(new KeyValuePair<string, int>(key, source[key]));
            }
            array.Sort(new Comp());
            return array;
        }

        internal static SortedDictionary<string, int> Combine(SortedDictionary<string, int> reader, SortedDictionary<string, int> topics)
        {
            var results = new SortedDictionary<string, int>();

            foreach (var tkey in topics.Keys)
            {
                results[tkey] = topics[tkey];
            }
            foreach (var rkey in reader.Keys)
            {
                if (results.ContainsKey(rkey)) // IMDA: Students, Take Note!
                {
                    results[rkey] = results[rkey] + reader[rkey];
                }
                else
                {
                    results[rkey] = reader[rkey];
                }
            }
            return results;
        }
    }

    class VConmp : System.Collections.IComparer /// unloved (see below)
    {
        public int Compare(object x, object y)
        {
            var a = (KeyValuePair<string, int>)x;
            var b = (KeyValuePair<string, int>)y;
            if (a.Value > b.Value)
                return 1;
            return a.Value < b.Value ? -1 : 0;
        }
    }


    class Comp : IComparer<KeyValuePair<string, int>>
    {
        public int Compare(KeyValuePair<string, int> a, KeyValuePair<string, int> b)
        {
            if (a.Value > b.Value) return 1;
            return a.Value < b.Value ? -1 : 0;
        }
    }

}
