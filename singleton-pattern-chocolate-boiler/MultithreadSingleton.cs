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

