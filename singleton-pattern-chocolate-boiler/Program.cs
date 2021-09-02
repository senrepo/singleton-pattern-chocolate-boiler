using System;

namespace singleton_pattern_chocolate_boiler
{
    class Program
    {
        static void Main(string[] args)
        {

            /* Question - Can we use global static variable instead of the Singleton pattern?
             * Answer - If you assign a object to a global variable, then you have to create that object when the application begins.
             * What if the object is resource intensive and your application could never use it.
             * With the Singleton pattern, we can create the objects only when they are needed at first (lazy loading/initializing of objects)
             * 
             * 
             */


            //Simple Singleton
            SimpleSingleton simpleSingleton = SimpleSingleton.GetInstance();
            simpleSingleton.DoSomeWork();


            //Multithreaded Singleton
            MultithreadSingleton multithreadedSingleton = MultithreadSingleton.GetInstance();
            multithreadedSingleton.DoSomeWork();


            Console.ReadLine();
        }
    }
}
