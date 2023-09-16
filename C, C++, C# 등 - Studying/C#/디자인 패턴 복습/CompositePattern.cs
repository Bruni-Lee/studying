using System.Collections.Generic;
using System.Collections;
class CompositePattern
{
    public interface I_Animal // Component
    {
        void Speak();
    }
    static void Main()
    {
        Animal_Group Cat_Group = new Animal_Group();  //Cat_Group Composite.
        for(int i =0; i < 3;i++)
        Cat_Group.Add(new Cat()); //Cat 3마리 추가

        Animal_Group Dog_Group = new Animal_Group();  //Dog_Group Composite.
        Dog_Group.Add(new Dog()); //Dog 3마리 추가
        Dog_Group.Add(new Dog());
        Dog_Group.Add(new Dog());

        Animal_Group Zoo = new Animal_Group(); //Composite 여기에서 Cat과 Dog의 Group (Composite)을 추가함.
        Zoo.Add(Cat_Group);
        Zoo.Add(Dog_Group);
        Zoo.Speak();
    }
    class Cat : I_Animal //Leaf
    {
        public void Speak()
        {
            Console.WriteLine("Meow");
        }
    }
    class Dog : I_Animal //Leaf
    {
        public void Speak()
        {
            Console.WriteLine("Bark");
        }
    }
    class Animal_Group : I_Animal // Composite
    {
        public List<I_Animal> Components = new List<I_Animal>();
        public void Add(I_Animal obj)
        {
            Components.Add(obj);
        }
        public void Speak()
        {
            Console.WriteLine("Group Speaking");
            foreach (var component in Components)
            {
                component.Speak();
            }
        }
    }
}

//예를들어 Cat,Dog가 있으면 I_Animal이라는 인터페이스를 가지는 것을 컴포넌트라 부름 leaf와 composite는 Component의 함수(I_Animal.Speak())를 갖고 있어야함

//Component를 상속받은 객체를 leaf라 부름 leaf는 dog, cat이 될 수 있고 Component는 I_Animal이라고 생각

//Component를 상속받는 "그룹"을 Composite라 부름 Composite는 객체의 리스트(Component)가 들어가는데 이 안에는 leaf가 아닌 Comeponent가 들어감 그렇게 하면 leaf의 객체도 들어갈 수 있고
//그룹 형태인 Composite도 들어갈 수 있다.