using System;
using System.Collections.Generic;

namespace Chrismo.TagMotion
{
    public struct Filter
    {
        public struct Range
        {
            public int Min;
            public int Max;

            public Range(int pMin, int pMax)
            {
                Min = pMin;
                Max = pMax;
            }
        }

        public static Range Bitrate = new Range(0, 1500);
        public static Range Year = new Range(0, 2100);
        public static Range Duration = new Range(0, 500);

        public static string Artist;
        public static string Label;

        public static string Type;

        public static bool CopyOnlyFiltered;
    }
}