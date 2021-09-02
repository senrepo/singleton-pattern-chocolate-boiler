using System;
using System.Collections.Generic;
using System.Text;

namespace singleton_pattern_chocolate_boiler
{
    /* With double checked locking, we first check to if an instance is created, and if not, then we  synchronize.
     * This way we only synchronize the first time as required.
     * 
     */
    public class MultithreadSingleton
    {
        /* volatile - When your program executes, the processor may cache the data and then access this data from the cache 
         * when it is requested by the executing thread. Updates and reads of this data might run against the cached version of the data, 
         * while the main memory is updated at a later point in time. This model of memory usage has consequences for multithreaded applications. 
         * When one thread is interacting with the data in the cache, and a second thread tries to read the same data concurrently,
         * the second thread might read an outdated version of the data from the main memory. 
         * This is because when the value of a non-volatile object is updated, 
         * the change is made in the cache of the executing thread and not in the main memory.
         * 
         * When you mark an object or a variable as volatile, it becomes a candidate for volatile reads and writes. 
         * It should be noted that in C# all memory writes are volatile irrespective of whether you are writing data to a volatile or a non-volatile object.
         * However, the ambiguity happens when you are reading data. When you are reading data that is non-volatile, 
         * the executing thread may or may not always get the latest value. 
         * If the object is volatile, the thread always gets the most up-to-date value.
         * 
         * You can use the volatile keyword with any reference, pointer, and enum types. 
         * You can also use the volatile modifier with byte, short, int, char, float, and bool types. 
         * It should be noted that local variables cannot be declared as volatile. 
         * 
         *  Also, a double variable cannot be volatile because it is 64 bits in size, larger than the word size on x86 systems. 
         *  If you need to make a double variable volatile, you should wrap it inside in class. 
         */
        private volatile static MultithreadSingleton uniqueInstance = null;
        private readonly static object myLocker = new object();

        private MultithreadSingleton()
        {

        }

        public static MultithreadSingleton GetInstance()
        {
            //check for an instance and if there isn't one, enter a synchronized block
            if (uniqueInstance == null)
            {
                //entering synchroized block
                lock (myLocker)
                {
                    /* once in the synchronized block, check again and if still null, create an instance
                     * But it is absolutely necessary since a thread has no idea what happened between 
                     * the time the lock statement was encountered and the time the lock is eventually acquired.
                     * This is called double checked locking.
                     */
                    if (uniqueInstance == null) 
                    {
                        uniqueInstance = new MultithreadSingleton();
                    }
                }
            }
            return uniqueInstance;
        }

        //Other useful methods here
        public void DoSomeWork()
        {
            Console.WriteLine("MultithreadSingleton is now ready to do some work.");
        }


    }
}

