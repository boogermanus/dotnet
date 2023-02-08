using System;
using System.Runtime.CompilerServices;

namespace Fundamentals
{
    public class RefInOut
    {
        private static readonly ConditionalWeakTable<InternalClass, RefId> _ids = new ConditionalWeakTable<InternalClass, RefId>();
        internal static void Test()
        {
            int i = 0;
            
            ValueTypePassByValue(i);
            Console.WriteLine($"{nameof(ValueTypePassByValue)}: {i}");
            
            ValueTypePassByRef(ref i);
            Console.WriteLine($"{nameof(ValueTypePassByRef)}: {i}");
            
            ValueTypePassByOut(out i);
            Console.WriteLine($"{nameof(ValueTypePassByOut)}: {i}");
            
            ValueTypePassByIn(in i);
            Console.WriteLine($"{nameof(ValueTypePassByIn)}: {i}");

            var instance = new InternalClass { Name = "Name1" };
            
            var originalId = instance.GetRefId();
            ReferenceTypePassByValue(instance);
            Console.WriteLine($"{nameof(ReferenceTypePassByValue)}: {instance.Name} {originalId == instance.GetRefId()}");
            
            originalId = instance.GetRefId();
            ReferenceTypePassByRef(ref instance);
            Console.WriteLine($"{nameof(ReferenceTypePassByRef)}: {instance.Name} {originalId == instance.GetRefId()}");
            
            originalId = instance.GetRefId();
            ReferenceTypePassByOut(out instance);
            Console.WriteLine($"{nameof(ReferenceTypePassByOut)}: {instance.Name} {originalId == instance.GetRefId()}");

            originalId = instance.GetRefId();
            ReferenceTypePassByIn(in instance);
            Console.WriteLine($"{nameof(ReferenceTypePassByIn)}: {instance.Name} {originalId == instance.GetRefId()}");

        }


        internal static void ValueTypePassByValue(int i)
        {
            i++;
        }
        
        internal static void ValueTypePassByRef(ref int i)
        {
            i++;
        }
        
        internal static void ValueTypePassByOut(out int i)
        {
            //var test = i == 0;  cannot read until set
            i = int.MaxValue;
        }

        internal static void ValueTypePassByIn(in int i)
        {
            // i is readonly
        }

        private static void StringByValue(string t)
        {
            t = "New String";
        }

        private static void StringByRef(ref string t)
        {
            t = "New String";
        }

        private static void StringByOut(out string t)
        {
            // Cannot read until set
            //if (string.IsNullOrEmpty(t))
            t = "New String";
        }

        private static void StringByIn(in string t)
        {
            if (string.IsNullOrEmpty(t))
            {
                // Readonly
                //t = "New String";
            }
        }

        internal static void ReferenceTypePassByValue(InternalClass c)
        {
            c.Name = nameof(ReferenceTypePassByValue);
            
            c = new InternalClass(); // this instance is not used at all
        }

        internal static void ReferenceTypePassByRef(ref InternalClass c)
        {
            c.Name = nameof(ReferenceTypePassByValue);
            c = new InternalClass { Name = c.Name + "Modified" };
        }

        internal static void ReferenceTypePassByOut(out InternalClass c)
        {
            //c.Name = nameof(ReferenceTypePassByOut);  cannot read until set
            c = new InternalClass { Name = nameof(ReferenceTypePassByOut) };
        }

        internal static void ReferenceTypePassByIn(in InternalClass c)
        {
            // c reference cannot be changed
            c.Name = nameof(ReferenceTypePassByIn);
        }
        
        internal class InternalClass
        {
            public string Name { get; set; }
            
            public Guid GetRefId()
            {
                return _ids.GetOrCreateValue(this).Id;
            }

        }
        
        internal class RefId
        {
            public Guid Id { get; } = Guid.NewGuid();
        }
    }
    
}