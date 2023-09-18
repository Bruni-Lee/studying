using System.Collections.Generic;
using System.Collections;
using System;

class FactoryPattern
{
    public enum ANIMAL_TYPE
    {
        CAT,
        DOG
    }
    static void Main()
    {
        Animal_Factory cat_factory = new Cat_Factory();
        Animal_Factory dog_factory = new Dog_Factory();
        Animal cat1 = cat_factory.Create_Animal(ANIMAL_TYPE.CAT);
        Animal cat2 = cat_factory.Create_Animal(ANIMAL_TYPE.CAT);
        Animal cat3 = cat_factory.Create_Animal(ANIMAL_TYPE.CAT);

        Animal Dog1 = dog_factory.Create_Animal(ANIMAL_TYPE.DOG);
        Animal Dog2 = dog_factory.Create_Animal(ANIMAL_TYPE.DOG);

        Console.WriteLine("Cat Count : " + Cat_Factory.Get_Cat_Count());
        Console.WriteLine("Dog Count : " + Dog_Factory.Get_dogCoung() +"\t" + "All_Dog_LegsCount : " + Dog_Factory.Get_Dogs_leg_Count());
    }
    abstract class Animal
    {
        public abstract void Speak();
    }
    abstract class Animal_Factory //모든 동물들의 공통된 속성과 생성을 하는 class
    {
        public abstract Animal Create_Animal(ANIMAL_TYPE type);
    }
    class Cat : Animal //각각의 고양이 객체 클래스
    {
        public override void Speak()
        {
            Console.WriteLine("Meow");
        }
    }
    class Dog : Animal //각각의 강아지 객체 클레스
    {
        public override void Speak()
        {
            Console.WriteLine("Bark");
        }
   }
    class EmptyAnimal : Animal // 없는 객체의 판별을 위한 클래스
    {
        public override void Speak()
        {
            Console.WriteLine("Invalid Type.");
        }
    }
    class Cat_Factory : Animal_Factory // 고양이의 객체들에 공통된 속성을 갖고 모든 고양이 객체들을 관리할 수 있는 클래스
    {
        static int Cat_Count = 0;

        public override Animal Create_Animal(ANIMAL_TYPE type)
        {
            if (type == ANIMAL_TYPE.CAT)
            {
                Cat_Count++;
                return new Cat();
            }
            else if (type == ANIMAL_TYPE.DOG)
                return new Dog();
            else
                return new EmptyAnimal();
        }
        public static int Get_Cat_Count()
        {
            return Cat_Count;
        }
    }
    class Dog_Factory : Animal_Factory // 강아지의 객체들에 공통된 속성을 갖고 모든 강아지 객체들을 관리할 수 있는 클래스
    {
        static int legs_for_all_dogs = 0;
        static int count = 0;
        public override Animal Create_Animal(ANIMAL_TYPE type)
        {
            if (type == ANIMAL_TYPE.CAT)
                return new Cat();
            else if (type == ANIMAL_TYPE.DOG)
            {
                count++;
                legs_for_all_dogs+=4;
                return new Dog();
            }
            else
                return new EmptyAnimal();
        }
        public static int Get_dogCoung()
        {
            return count;
        }
        public static int Get_Dogs_leg_Count()
        {
            return legs_for_all_dogs;
        }
    }
}
//이 패턴을 통하여 여러 몬스터들을 생설할 때 공통된 기능들은 메인Factory에 데이터를 넣고
//다른 기능들이 있다면 각각의 몬스터들의 factory를 만들어 새로운 변수 등 사용한다면 몬스터 추가, 생성, 카운트 체크등 더욱 편리하게 관리가 가능할 것같다.

//Factory Method Pattern을 이용하면 Type에 따라 필요한 추가적인 기능들을 넣어줄 때 편리할 것 같다. pattern공부에 중점을 두어 코드가 간결하지 못했다는 점이 아쉽지만 이해하는데에는 많은 도움이 됐다.