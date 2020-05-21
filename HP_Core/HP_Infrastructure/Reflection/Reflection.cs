using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace HP_Infrastructure.Reflection
{
    public class Reflection
    {
    }

    // Using Reflection knowledges.
    // managed code can read its own metadata to find assemblies.
    // It allows code to inspect other code within the same system.
    // Your code can view the object and find out if it has the "doSomething" method.
    //With reflection in C#, you can dynamically create an instance of a type and bind that type to an existing object.
    //Moreover, you can get the type from an existing object and access its properties.
    //When you use attributes in your code, reflection gives you access as it provides objects of Type that describe modules, assemblies, and types.

    //You need to use Reflection when you want to inspect the contents of an assembly.
    // Assemblies contain modules.
    // Modules contain types
    // Types contain members.
    public class ReflectionTesting
    {
        //https://www.csharp-examples.net/reflection-examples/
        // Use Module to get all global and non-global methods defined in the module.
        //It allows view attribute information at runtime.
        public void AllowViewAttributeInfo()
        {
            System.Reflection.MemberInfo info = typeof(ReflectionTesting);


            Assembly testAssembly = Assembly.LoadFile(@"c:\Test.dll"); // Dynamically load assembly from file test.dll.

            // Get type of class Calculator from just loaded assembly?..
            Type calcType = testAssembly.GetType("Test.Calculator");


            // Create instance of class Calculator
            object calcInstance = Activator.CreateInstance(calcType);


            // set value of property : public dobule number
            PropertyInfo numPropertyInfo = calcType.GetProperty("Number");

        }

    }

    public class SpanTesting
    {
        //      Span<T> references some contiguous memory that has already been allocated. We now have a window over that memory.
        //      Span<T> is defined as a ref struct, which means it is limited to being allocated only on the stack.
        //      This reduces some potential use cases such as storing it as a field in a class or using it in async methods.
    }

}
