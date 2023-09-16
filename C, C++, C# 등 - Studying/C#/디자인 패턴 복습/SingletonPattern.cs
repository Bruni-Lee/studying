using System.Collections.Generic;
using System.Collections;


//싱글톤의 개념은 사용한 적이 많아 쉽게 복습했다.
class SingletonPattern
{
    static void Main()
    {

        Singleton singleton1 = Singleton.Instance;
        Singleton singleton2 = Singleton.Instance;

        if (singleton1 == singleton2)
            Console.WriteLine("they are same, singleton"); //실행시 이 코드 나옴
        else
            Console.WriteLine("they ar not same");
    }
    public class Singleton
    {
        static Singleton instance; 

        public static Singleton Instance
        {
            get
            {
                if (null == instance)
                {
                   instance = new Singleton();
                }
                return instance;
            }
        }

    }
}
