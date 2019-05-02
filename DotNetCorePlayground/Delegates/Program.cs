using System;
using System.IO;

namespace DotNetCore
{
    class Program
    {
        static void Main(string[] args)
        {
            CombineDelegates();
            RemoveDelegate();
            DuplicateDelegate();
            AddSubtractDelegate();
            GenericDelegateInvoke();
            TemplateDelegateInvoke();
            ActionDelegates();
            FuncDelegates();
            CovarianceInvoke();
        }
        #region Multicast Delegates
        // multicast delegate functions
        private delegate void CalculatorDelegate(int a, int b);
        private static void Add(int x, int y) =>
            Console.WriteLine($"{x} + {y} = {x + y}");

        private static void Subtract(int x, int y) =>
            Console.WriteLine($"{x} - {y} = {x - y}");

        private static void Multiply(int x, int y) =>
            Console.WriteLine($"{x} * {y} = {x * y}");

        private static void Divide(int x, int y) =>
            Console.WriteLine($"{x} / {y} = {x / y}");

        private static void CombineDelegates()
        {
            CalculatorDelegate calc =
            (CalculatorDelegate)Delegate.Combine(new CalculatorDelegate[]{
                Add,Subtract,Multiply,Divide
            });

            Delegate[] list = calc.GetInvocationList();
            Console.WriteLine($"Total delegates in calc: {list.Length}");

            calc(6, 3);
        }

        private static void RemoveDelegate()
        {
            CalculatorDelegate divDel = Divide;
            CalculatorDelegate calc =
            (CalculatorDelegate)Delegate.Combine(new CalculatorDelegate[]{
                Add,Subtract,Multiply,Divide
            });

            Delegate[] list = calc.GetInvocationList();
            Console.WriteLine($"Total delegates in calc: {list.Length}");

            calc(6, 3);

            CalculatorDelegate newCalc =
                (CalculatorDelegate)Delegate.Remove(calc, divDel);


            Console.WriteLine($"Total delegates in calc: {newCalc.GetInvocationList().Length}");

            newCalc(6, 4);
        }

        private static void DuplicateDelegate()
        {
            CalculatorDelegate subDel = Subtract;
            CalculatorDelegate calc =
            (CalculatorDelegate)Delegate.Combine(new CalculatorDelegate[]
            {
                Add,Subtract,Multiply,subDel, Divide
            });

            Delegate[] list = calc.GetInvocationList();
            Console.WriteLine($"Total delegates in calc: {list.Length}");

            calc(6, 3);
        }

        private static void AddSubtractDelegate()
        {
            CalculatorDelegate addDel = Add;
            CalculatorDelegate subDel = Subtract;
            CalculatorDelegate mulDel = Multiply;
            CalculatorDelegate divDel = Divide;

            // won't work, has to be a CalculatorDelegate
            // CalculatorDelegate multiCalc = Add + Subtract;

            // this will work
            CalculatorDelegate multiCalc = addDel + subDel;
            multiCalc += mulDel;
            multiCalc += divDel;

            Console.WriteLine($"Invoking multiCalc (four methods)");

            multiCalc(8, 2);

            // remove delegates
            // this doesn't work in .net core
            multiCalc = multiCalc - subDel;
            multiCalc -= mulDel;

            Console.WriteLine($"Invoking multiCalc (two methods)");
            
            multiCalc(8, 2);
        }
        #endregion

        #region Formula Delegate
        private delegate T FormulaDelegate<T>(T a, T b);
        private static int AddInt(int x, int y) => x + y;

        private static double AddDouble(double x, double y) => x + y;

        private static void GenericDelegateInvoke()
        {
            FormulaDelegate<int> intAddition = AddInt;
            FormulaDelegate<double> doubleAddition = AddDouble;

            Console.WriteLine("Invoking intAddition(2,3)");
            Console.WriteLine($"Result = {intAddition(2, 3)}");

            Console.WriteLine("Invoking doubleAddition(2.2, 3.5)");
            Console.WriteLine($"Result = {doubleAddition(2.2, 3.5)}");
        }
        #endregion

        #region Template Delegate
        private delegate TResult TemplateDelegate<T1, T2, TResult>(T1 a, T2 b);
        private static float AddIntDoubleConvert(int x, double y)
        {
            var result = (float)(x + y);
            Console.WriteLine($"(int){x} + (double){y} = {result}");
            return result;
        }

        private static int AddFloatDoubleConvert(float x, double y)
        {
            var result = (int)(x + y);
            Console.WriteLine($"(float){x} + (double){y} = {result}");
            return result;
        }
        private static void TemplateDelegateInvoke()
        {
            TemplateDelegate<int, double, float> del1 = AddIntDoubleConvert;
            TemplateDelegate<float, double, int> del2 = AddFloatDoubleConvert;

            Console.WriteLine("Invoking del1(5, 3.9)");
            float f = del1(5, 3.9);

            Console.WriteLine("Invokeing del2");
            int i = del2((float)4.3, 2.1);
        }
        #endregion
        
        #region Actions
        private static void AddIntDouble(int x, double y)
        {
            Console.WriteLine($"{x} + {y} = {x+y}");
        }

        private static void AddFloatDouble(float x, double y)
        {
            Console.WriteLine($"{x} + {y} = {x+y}");
        }

        private static void ActionDelegates()
        {
            Action<int, double> intDoubleAction = AddIntDouble;
            Action<float, double> floatDoubleAction = AddFloatDouble;
            Action<int, double> shortIntDoubleAction = (x, y) =>{Console.WriteLine($"{x} + {y} = {x+y}");};
            Action<float, double> shortFloatDoubleAction = (x,y) => {Console.WriteLine($"{x} + {y} = {x+y}");};

            intDoubleAction(1, 2.3);
            floatDoubleAction((float)1.2, 2.4);
            
            shortIntDoubleAction(1, 2.3);
            shortFloatDoubleAction((float)1.2, 2.4);
        }
        #endregion

        #region Func
        private static Func<int, double, float> func1 = AddIntDoubleConvert;
        private static Func<float, double, int> func2 = AddFloatDoubleConvert;

        private static void FuncDelegates()
        {
            Console.WriteLine("Invoking func1(5, 3.9)");
            float f = func1(5, 3.9);

            Console.WriteLine("Invokeing func2");
            int i = func2((float)4.3, 2.1);
        }
        #endregion

        #region Covariance
        private delegate TextWriter CovarianceDelegate();

        private static StreamWriter StreamWriterMethod()
        {
            DirectoryInfo[] arrDirs = new DirectoryInfo(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)).GetDirectories();
            
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            foreach(var dir in arrDirs)
            {
                sw.WriteLine(dir.Name);
            }

            return sw;

        }

        private static StringWriter StringWriterMethod()
        {
            StringWriter writer = new StringWriter();

            string[] arrString = new string[]{
                "Covariance",
                "example",
                "using",
                "StringWriter",
                "object"
            };

            foreach(string str in arrString)
            {
                writer.Write(str);
                writer.Write(' ');
            }

            return writer;
        }

        private static void CovarianceInvoke()
        {
            CovarianceDelegate cd = StreamWriterMethod;

            Console.WriteLine("Invoking CovarianceStreamWriter");
            StreamWriter writer1 = (StreamWriter)cd();
            writer1.AutoFlush = true;
            Console.SetOut(writer1);

            cd = StringWriterMethod;
            
            Console.WriteLine("Invoking CovarianceStringWriter");
            StringWriter writer2 = (StringWriter)cd();
            Console.WriteLine(writer2.ToString());

        }
        #endregion
    
        #region Contravariance
        private delegate void ContravarianceDelegate(StreamWriter sw);

        private static void TextWriterMethod(TextWriter tw)
        {
            string[] arr = new string[] {
                "Contravariance",
                "example",
                "using",
                "TextWriter",
                "object"
            };

            tw = new StreamWriter(Console.OpenStandardOutput());

            foreach(var str in arr)
            {
                tw.Write(str);
                tw.Write(' ');
            }
            tw.WriteLine();

            Console.SetOut(tw);
            tw.Flush();
        }

        private static void ContravarianceInvoke()
        {
            ContravarianceDelegate del = TextWriterMethod;

            TextWriter tw = null;

            Console.WriteLine("Invoking Contravariance");
            del((StreamWriter)tw);
        }
        #endregion
    }
}
