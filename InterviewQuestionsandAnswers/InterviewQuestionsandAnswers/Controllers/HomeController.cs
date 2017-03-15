//Has C# interview questions


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InterviewQuestionsandAnswers.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}



/*
 * 1.	What is the difference between a high-level language and a low-level language?
The low level programming language gives absolute control over everything the machine will do. The low level programing also known as assembly is also one 
of its example. Once complied it give fastest execution and most precise control possible. The main difference between high level and low level programming 
language is how the code is compiled into binary form. The assembler is known as the compiler for the assembly code. The high level and low level language differ in
the way they are written and complied. The high level programming language is easy to maintain, and is portable from one machine to another or one platform to another. 

2.	What is meant by the term "Managed Code"
Managed code is code written in high level programming language. The managed code within a managed execution environment ensures type safety, array bound and 
index checking, exception handling, and garbage collection. The managed execution environment involves process of choosing right compiler, compiling codes 
to MSIL which also generates the required metadata, compile the MSIL ode to native machine code and executing the code with the variety of services available. 


3.	Provide a clear, concise explanation of OOP.
OOP is modern Object Oriented Programming language, class is mandatory in OOP language. The class does not contain memory but the blueprint of an object 
that contains variables for storing data and functions to perform operations on the data. It is only logical representation of data. An object is the instance
of the class.  

The class is called in form of an object using “new” operator. For example 
Public class arvind { }
Arvind is the name of the class and the object arvind with variables is called using the new operator. 
Arvind objarvind = new arvind();
The object oriented programming supports three concepts which is as follows:
Encapsulation, polymorphism, inheritance


4.	What is a Constructor?
A constructor is a class member executed when an instance of the class is created. It has the same name as the class and can be overloaded with 
different signatures. It does not have a return type.

Class Customer
{
String _fristName;
String _lastName;


Public Customer (string FirstName, string LastName)
{
this._firstName = FirstName;
this._lastName = LastName;
}

Public void PrintFullName()
{
Console.WriteLine(“Full Name = {0}”, this.firstName + “” + this._lastName);
}
}


5.	What is the difference between String and StringBuilder
System.String is immutable and StringBuilder is mutable. Immutable means that value stored in the string object cannot be changed. The String will create 
new object in the heap instead of utilizing the previous object. https://www.youtube.com/watch?v=4lFAs6FYTXg StringBuilder is used as an object and is derived from System.Text namespace. 



6.	What is the difference between struct and class?
A struct is a value type and class is a reference type. Structs are stored on stack, where as classes are stored in heap. Value hold their value in memory 
where they are declared but reference types hold a reference to an object in memory. When struct is copied into another struct, a new copy of that struct gets 
created and modifications on one struct will not affect the values contained by the other struct. When one class is copied into another class we only get a copy 
of the reference variable. Both of the reference variables point to the same object on the heap. So, operations on one variable will affect the values contained 
by the other reference variable. 


7.	What is boxing?
Boxing is the process of explicitly converting a value type into a corresponding reference type. 


8.	What is the difference between abstract class and interfaces?
Abstract classes can have implementations for some of its members(Methods), but the interface can’t have implementation for any of its members. 
Interfaces cannot have fields where as an abstract class can have fields. 
An interface can inherit from another interface only and cannot inherit from an abstract class, where as an abstract class can inherit from another 
abstract class or another interface. 
A class can inherit from multiple interfaces at the same time, whereas a class cannot inherit from multiple classes at the same time. 
Abstract class members can have access modifiers whereas interface members cannot have access modifiers.
*/
/*
9. Explain in your own words the OOP term “Polymorphism”.
Polymorphism is many shaped. The objects of a derived class may be treated as objects of a base class in places such as method parameters and collections of 
arrays. At this time the object's declared type is no longer identical to its run time type. Base classes may define and implement virtual methods and derived
classes can override them. THis means that they can own their own definition and implementation. 
*/
public class shape
{
    public int x { get; set; }

    public virtual void draw()
    {
        Console.WriteLine("Drawing a shape");
    }

    public class circle : shape
    {
        public override void draw()
        {
            Console.WriteLine("This is a circle");
            base.draw();
        }
        
    }
}

/*10. What does the “static” keyword mean in .NET OOP?
 * A static function is not associated with an instance of the class
 * 
 * A static class is a class which can only contatin static members, and cannot be instantiated. 
 */
class SomeClass
{
    public int InstanceMethod() { return 1; }
    public static int StaticMethod() { return 42; }

    SomeClass instance = new SomeClass();
    //instance.InstanceMethod();   //Fine
    //instance.StaticMethod();     //Won't compile

    //SomeClass.InstanceMethod();  //Won't compile
    //SomeClass.StaticMethod();    //Fine

        }

/*11. What is Method overloading? 
      What is Constructor chaining?

    Method overloading is defining several methods with the same name but different parameters.

    Calling one constructor from another is known as constructor chaining
 */
 //method overloading
 public class SillyMath
{
    public static int Plus(int num1, int num2)
    {
        return Plus(num1, num2);
    }
    public static int Plus(int num1, int num2, int num3)
    {
        return num1 + num2 + num3;
    }
}
//Constructor chaining
public class sample
{
    public sample() : this(10)// defines the value is set to 10 can be done "public sample(10)"
    {

    }
    public sample(int Age) //defines takes one parameter
    {

    }
}

/*12. What is the difference between a value type and a reference type
 * Value type stores value not memory address. It stores the value be int, string, long, bool has values. Struct are value type as well
 * 
 * Reference type is pointing to the memory. The value is stored in heap and garbage collector cleans it. Example class and objects.
 */ 
