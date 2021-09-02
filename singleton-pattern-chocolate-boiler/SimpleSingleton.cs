using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace singleton_pattern_chocolate_boiler
{


     /* Singleton object is instantiated withtin the class only as it has private consturctor
     * getInstance() is a static function which returns the singleton object
     * private static uniqueInstance hold the object reference
     * 
     * Issues - Two threads might create overlap each other in the GetInstance() method and end ou creating two objects.
     * So need to address the multithreading issues.
     */
    public class SimpleSingleton
    {
        private static SimpleSingleton uniqueInstance = null;

        private SimpleSingleton()
        {

        }

        public static SimpleSingleton GetInstance()
        {
            if(uniqueInstance == null)
            {
                uniqueInstance = new SimpleSingleton();
            }

            return uniqueInstance;
        }

        /* By adding the Synchronized keywod in method level, we face every thread wait its turn before it can enter the method.
         * In other words, no two threads may enter the method at the same time.
         * Downside - The only time synchronization is relevant in the first time you access it,
         * In other words, once we have set the uniqueInstance variable to an instance of Singleton, we have no further need to synchronize this method.
         * After the first time through, synchronizatioin is totally unneeded overhead.
         * In Performance aspect, synchoronizing a method may decrease the performance by a factor of 100, 
         * So if a high traffic part of your code using GetInstance method, you may have to recondider this.
         */
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static SimpleSingleton GetInstance1()
        {
            if (uniqueInstance == null)
            {
                uniqueInstance = new SimpleSingleton();
            }

            return uniqueInstance;
        }



        //Other useful methods here
        public void DoSomeWork()
        {
            Console.WriteLine("SimpleSingleton is now ready to do some work.");
        }
    }
}
