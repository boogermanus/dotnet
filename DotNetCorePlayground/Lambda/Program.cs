using System;
using System.Linq.Expressions;

namespace Lambda
{
    class Program
    {
        static void Main(string[] args)
        {
            AnonymousDelegate();
            AnonymousMethod();
            ExploreExpression();
            ExploreCompileExpression();
            TestEventClassWithoutEvent();
            TestEventClassWithEvent();
            TestEventClassWithHandler();
            FirstClass();
            FirstClassTwo();
            Closure();
        }

        #region Delegate
        private static Func<string, string> displayMessageDelegate =
        delegate (string str)
        {
            return $"Message: {str}";
        };

        private static void AnonymousDelegate()
        {
            Console.WriteLine(displayMessageDelegate("A simple anonymous method sample"));
        }
        #endregion

        #region Lambda
        private static Func<string, string> displayMessageAnonymous = s => $"Message: {s}";

        private static void AnonymousMethod()
        {
            Console.WriteLine(displayMessageAnonymous("A simple anonymous method sample"));
        }
        #endregion

        #region Expressions
        private static void ExploreExpression()
        {
            Expression<Func<int, int, int>> expression = (x, y) => x * y;

            BinaryExpression body = (BinaryExpression)expression.Body;
            ParameterExpression left = (ParameterExpression)body.Left;
            ParameterExpression right = (ParameterExpression)body.Right;

            Console.WriteLine(expression.Body);
            Console.WriteLine($"\tThe left part of the expression: {left.Name}");
            Console.WriteLine($"\tThe NodeType: {body.NodeType}");
            Console.WriteLine($"\tThe right part of the expression: {right.Name}");
            Console.WriteLine($"\tThe Type: {body.Type}");

        }

        private static void ExploreCompileExpression()
        {
            // old and busted
            Expression<Func<int, int, int>> expression = (x, y) => x * y;
            CompileAndExecute(expression, 2, 3);

            // new hotness
            CompileAndExecute((x, y) => x + y, 2, 3);
        }

        private static void CompileAndExecute(Expression<Func<int, int, int>> pExpression, int a, int b)
        {
            int result = pExpression.Compile()(a, b);

            Console.WriteLine($"the result of the expression {pExpression.Body} with a = {a} and b = {b} is {result}");

        }
        #endregion

        #region Events


        public class EventClassWithoutEvent
        {
            public Action OnChange { get; set; }

            public void Raise()
            {
                if (OnChange != null)
                    OnChange();
            }

        }
        private static void TestEventClassWithoutEvent()
        {
            EventClassWithoutEvent e = new EventClassWithoutEvent();

            e.OnChange += () => Console.WriteLine("1st: Event");
            e.OnChange += () => Console.WriteLine("2nd: Event");
            e.OnChange += () => Console.WriteLine("3rd: Event");

            e.Raise();

            // this will erase any previous delegates attached
            e.OnChange = () => Console.WriteLine("4th: Event");

            e.Raise();
        }
        public class EventClassWithEvent
        {
            public event Action OnChange = () => { };

            public void Raise()
            {
                OnChange();
            }
        }
        private static void TestEventClassWithEvent()
        {
            EventClassWithEvent e = new EventClassWithEvent();

            e.OnChange += () => Console.WriteLine("1st: Event");
            e.OnChange += () => Console.WriteLine("2nd: Event");
            e.OnChange += () => Console.WriteLine("3rd: Event");

            e.Raise();
            // this is an error
            // e.OnChange = () => Console.WriteLine("4th: Event");

            // this is the right way
            e.OnChange += () => Console.WriteLine("4th: Event");

            e.Raise();
        }
        public class MyEventArgs : EventArgs
        {
            public int EventValue { get; set; }
            public MyEventArgs(int pValue)
            {
                EventValue = pValue;
            }
        }

        public class EventClassWithEventHandler
        {
            public event EventHandler<MyEventArgs> OnChange = (sender, e) => { };

            public void Raise(int pValue)
            {
                OnChange(this, new MyEventArgs(pValue));
            }
        }
        private static void TestEventClassWithHandler()
        {
            EventClassWithEventHandler e = new EventClassWithEventHandler();

            e.OnChange += (sender, ea) => Console.WriteLine($"1st Event: {ea.EventValue} - {sender.GetType().Name}");
            e.Raise(10);

            e.OnChange += (sender, ea) => Console.WriteLine($"2nd Event: {ea.EventValue}");
            e.Raise(20);

        }
        #endregion

        private static Func<string, string> displayMessage = (str) => $"Message: {str}";

        #region First Class
        private static void FirstClass()
        {
            var str = displayMessage("Assign displayMessageDelegate() to variable");
            Console.WriteLine(str);
        }

        private static void FirstClassTwo()
        {
            FirstClassTwoPass(displayMessage, "Old and Busted");
            FirstClassTwoPass((str) => $"Message: New {str}", "Hotness");
        }

        private static void FirstClassTwoPass(Func<string, string> pFunc, string pMsg)
        {
            Console.WriteLine(pFunc(pMsg));
        }
        #endregion

        #region Closure
        private static Func<int, int> ClosureFunction()
        {
            int localVar = 1;
            Func<int, int> returnFunction = scopeVar =>
             {
                 localVar *= 2;
                 return scopeVar + localVar;
             };

            return returnFunction;
        }

        private static void Closure()
        {

            var function = ClosureFunction();

            for (int i = 0; i < 10; i++)
                Console.WriteLine($"Invoking {i}: closure({i}) = {function(i)}");

            // short hand
            int localVar = 1;

            Func<int, int> wFunction = (scopeVar) =>
            {
                localVar *= 2;
                return scopeVar + localVar;
            };

            for (int i = 0; i < 10; i++)
                Console.WriteLine($"Invoking {i}: wFunction({i}) = {wFunction(i)}");

        }
        #endregion
    }

}
