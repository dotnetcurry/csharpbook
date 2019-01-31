using System;
using System.Collections.Generic;

namespace CovarianceContravariance
{
    class Program
    {
        public delegate TCovariant VariantDelegate<out TCovariant, in TContravariant>(TContravariant input);

        static void Main(string[] args)
        {
            IList<string> list = new List<string>();
            //IList<object> lessDerivedList = list; // won't compile

            IEnumerable<string> strings = new List<string>();
            IEnumerable<object> objects = strings;

            Predicate<object> objectPredicate = obj => obj.ToString().Length > 5;
            Predicate<string> stringPredicate = objectPredicate;

            Func<object, string> originalDelegate = obj => obj.ToString();
            Func<string, object> variantDelegate = originalDelegate;

        }
    }
}
