using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicScooleXml.Service
{
    internal static class PractiService
    {
        public static Func<List<string>, bool> startWithA = (list) => list.Any(a => a.StartsWith("a"));

        public static Func<List<string>, bool> isEmptyItem = (list) => list.Any(a => string.IsNullOrEmpty(a));

        public static Func<List<string>, bool> ifContainsA = (list) => list.All(a => a.Contains("a"));

        public static Func<List<string>, List<string>> toUpper = (list) => list.Select(newL => newL.ToUpper()).ToList();

        public static Func<List<string>, List<string>> toUpper2 = (list) =>
        (from str in list
         select str.ToUpper())
        .ToList();

        public static Func<List<string>, List<string>> treeLenItem = (list) => list.Where(newL => newL.Length > 3).ToList();

        public static Func<List<string>, List<string>> treeLenItem2 = (list) =>
        (from str in list
         where str.Length > 3
         select str).ToList();

        public static Func<List<string>, string> joinStr = (list) => list.Aggregate("", (a, str) => a + " " + str);

        public static Func<List<string>, int> joinInt = (list) => list.Aggregate(0, (a, str) => a + str.Length);

        public static Func<List<string>, List<int>> lenList = (list) => list.Select(newL => newL.Length).ToList();

        public static Func<List<string>, List<int>> treeLenItemWithAggregate = (list) => list.Aggregate(new List<int>(), (acc, n) => [..acc, n.Length]);

    }
}
