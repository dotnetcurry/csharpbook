using System;
using System.Collections.Generic;

namespace DelegatesAndEvents
{
    class Program
    {
        public delegate int Transform(int n);

        static void Main(string[] args)
        {
            NamedMethods();
            AnonymousMethods();
            LambdaExpressions();
            LambdaExpressionsSingleStatement();
            LambdaExpressionsScope();
            CombiningDelegates();
            SubscribingToEvents();
            SubscribingToInstrumentedEvents();
        }

        private static void NamedMethods()
        {
            Transform incrementFunction = Increment;
            var incremented = incrementFunction(1); // 2

            var list = new List<int> { 1, 2, 3, 4, 5 };
            TransformAll(list, Increment); // list = { 2, 3, 4, 5, 6 }
            TransformAll(list, Decrement); // list = { 0, 1, 2, 3, 4 }
        }

        private static void AnonymousMethods()
        {
            Transform incrementFunction = delegate (int n)
            {
                return n + 1;
            };
            var incremented = incrementFunction(1); // 2

            var list = new List<int> { 1, 2, 3, 4, 5 };
            TransformAll(list, delegate (int n)
            {
                return n - 1;
            }); // list = { 0, 1, 2, 3, 4 }
        }

        private static void LambdaExpressions()
        {
            Transform incrementFunction = n =>
            {
                return n + 1;
            };
            var incremented = incrementFunction(1); // 2
        }

        private static void LambdaExpressionsSingleStatement()
        {
            Transform incrementFunction = n => n + 1;
            var incremented = incrementFunction(1); // 2

            var list = new List<int> { 1, 2, 3, 4, 5 };
            ProcessAll(list, x => x - 1); // list = { 0, 1, 2, 3, 4 }
        }

        private static void LambdaExpressionsScope()
        {
            var list = new List<int> { 1, 2, 3, 4, 5 };

            var increment = 1;
            ProcessAll(list, x => x + increment); // list = { 2, 3, 4, 5, 6 }

            increment = 3;
            ProcessAll(list, x => x + increment); // list = { 5, 6, 7, 8, 9 }
        }

        private static void CombiningDelegates()
        {
            Action firstDelegate = () =>
            {
                Console.WriteLine("First delegate invoked.");
            };
            Action secondDelegate = () =>
            {
                Console.WriteLine("Second delegate invoked.");
            };

            Action combinedDelegate = firstDelegate;
            Console.WriteLine("First call.");
            combinedDelegate();

            combinedDelegate += secondDelegate;
            Console.WriteLine("Second call.");
            combinedDelegate();

            combinedDelegate -= firstDelegate;
            Console.WriteLine("Third call.");
            combinedDelegate();
        }

        private static void SubscribingToEvents()
        {
            var instance = new NotifyingClass();
            EventHandler<MethodEventArgs> handler = (sender, eventArgs) =>
            {
                Console.WriteLine($"Event handler called with {eventArgs.Argument}.");
            };
            instance.MethodInvoked += handler; // subscribe to event
            instance.MethodInvoked -= handler; // unsubscribe from event
        }

        private static void SubscribingToInstrumentedEvents()
        {
            var instance = new InstrumentedNotifyingClass();
            EventHandler<MethodEventArgs> handler = (sender, eventArgs) =>
            {
                Console.WriteLine($"Event handler called with {eventArgs.Argument}.");
            };

            instance.MethodInvoked += handler;
            instance.Method(42);
            instance.MethodInvoked -= handler;
        }

        private static int Increment(int n)
        {
            return n + 1;
        }

        private static int Decrement(int n)
        {
            return n - 1;
        }

        private static void TransformAll(List<int> list, Transform transform)
        {
            for (var i = 0; i < list.Count; i++)
            {
                list[i] = transform(list[i]);
            }
        }

        private static void ProcessAll(List<int> list, Func<int, int> processFn)
        {
            for (var i = 0; i < list.Count; i++)
            {
                list[i] = processFn(list[i]);
            }
        }
    }
}
