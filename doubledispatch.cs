using System;
using System.Collections.Generic;
using System.Text;

namespace TerryAlgorithm.doubledispatch
{
    public interface IAnimal { }
    public class Mammals : IAnimal { }
    public class Dog : Mammals { }

    public class Survey
    {
        public void DoSurvey(IAnimal animal)
        {
            Console.WriteLine("IAnimal Type");
        }

        public void DoSurvey(Mammals animal)
        {
            Console.WriteLine("Mammals Type");
        }

        public void DoSurvey(Dog animal)
        {
            Console.WriteLine("Dog Type");
        }
    }

    static class DoubledispatchTest
    {
        public static void test()
        {
            dynamic dog = new Dog();
            dynamic mamels = new Mammals();

            Survey survey = new Survey();
            survey.DoSurvey(dog);
            survey.DoSurvey(mamels);
        }
    }
}
