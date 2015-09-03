using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCSharp5References.Chapter4
{
    // A custom enumeration.
    enum EmpType
    {
        Manager,       // = 0
        Grunt,         // = 1
        Contractor,    // = 2
        VicePresident  // = 3
    }

    //You are free to change the initial value
    //Elements of an enumeration need not be sequential
    enum EmpType_initial_value
    {
        Manager = 10,
        Grunt = 1,
        Contractor = 100,
        VicePresident = 9
    }

    // This time, EmpType maps to an underlying byte.
    enum EmpType_byte : byte
    {
        Manager = 0,
        Grunt = 1,
        Contractor = 255,
        VicePresident = 255
    }
    //For a low-memory device such as window mobile phone7, changing the underlying type of an enumeration will help you to conserve memory as possible as you can
    //the initial values should be whitin its value range.
    //for example, byte type of enumeration will be fit the range of between 0 to 255

    class FunWithEnums
    {
        public FunWithEnums()
        {
            Console.WriteLine("**** Fun with Enums *****");
            EmpType emp = EmpType.Contractor;
            AskForBonus(emp);

            // Prints out "emp is a Contractor".
            Console.WriteLine("emp is a {0}.", emp.ToString());

            // Prints out "Contractor = 100".
            Console.WriteLine("{0} = {1}", emp.ToString(), (byte)emp);

            EmpType e2 = EmpType.Contractor;

            // These types are enums in the System namespace.
            DayOfWeek day = DayOfWeek.Monday;
            ConsoleColor cc = ConsoleColor.Gray;
            EvaluateEnum(e2);
            EvaluateEnum(day);
            EvaluateEnum(cc);

            Console.ReadLine();
        }

        #region Enum as parameter
        // Enums as parameters.
        static void AskForBonus(EmpType e)
        {
            switch (e)
            {
                case EmpType.Manager:
                    Console.WriteLine("How about stock options instead?");
                    break;
                case EmpType.Grunt:
                    Console.WriteLine("You have got to be kidding...");
                    break;
                case EmpType.Contractor:
                    Console.WriteLine("You already get enough cash...");
                    break;
                case EmpType.VicePresident:
                    Console.WriteLine("VERY GOOD, Sir!");
                    break;
            }
        }
        #endregion

        #region Analyse Enum
        // This method will print out the details of any enum.
        static void EvaluateEnum(System.Enum e)
        {
            Console.WriteLine("=> Information about {0}", e.GetType().Name);

            //Print storage for the enum.
            Console.WriteLine("Underlying storage type: {0}", Enum.GetUnderlyingType(e.GetType()));
            
            //Enum.GetUnderlyingType() requires you to pass in a System.Type as the first parameter.
            //Type represents the metadata description of a given .Net Entity

            //There's two possible way to get metadata. The first one is to use the GetType() method, which is
            //common to all types in the .NET base class libraries. The second approach is to make use of the C# typeof operator.
            //doing this gives you benefit that you don't need to have a variable of the entity you wish to obtain a metadata description
            Console.WriteLine("EmpType uses a {0} for storage", Enum.GetUnderlyingType(typeof(EmpType)));


            // Get all name/value pairs for incoming parameter.
            Array enumData = Enum.GetValues(e.GetType());
            Console.WriteLine("This enum has {0} members.", enumData.Length);
            // Now show the string name and associated value, using the D format
            // flag (see Chapter 3).
            for (int i = 0; i < enumData.Length; i++)
            {
                Console.WriteLine("Name: {0}, Value: {0:D}", enumData.GetValue(i));
            }
            Console.WriteLine();
        }
        #endregion
    }
}
