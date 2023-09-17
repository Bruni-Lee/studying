using System.Collections.Generic;
using System.Collections;


//옵저버 패턴 간단하게 복습!
class ObserverPattern
{

    public interface I_Observe //관찰자 interface
    {
       public abstract void  Update();
    }
    static void Main()
    {
        Subject Owner = new Subject();
        Cat cat = new Cat();
        Dog dog = new Dog();

        Owner.Add_Observe(cat);
        Owner.Add_Observe(dog);
        Owner.Notify();
    }
    public class Subject //관찰 대상자
    {
        List<I_Observe> observers = new List<I_Observe>();
       public void Add_Observe(I_Observe Observe)
        {
            observers.Add(Observe);
        }
       public void Remove_Observe(I_Observe Observe)
        {
            observers.Remove(Observe); 
        }
       public void Notify()
        {
            foreach (var Obj in observers)
                Obj.Update();
        }   
    }
    public class Cat : I_Observe // 관찰자
    {
        public void Update()
        {
            Console.WriteLine("Meow");
        }
    }
    public class Dog : I_Observe //관찰자
    {
        public void Update()
        {
            Console.WriteLine("Bark");
        }
    }
}
