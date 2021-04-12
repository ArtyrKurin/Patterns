using Strategy.Strategys;
using System;

namespace Strategy
{
    // Контекст определяет интерфейс, представляющий интерес для клиентов.

    // Интерфейс Стратегии объявляет операции, общие для всех поддерживаемых
    // версий некоторого алгоритма.
    //
    // Контекст использует этот интерфейс для вызова алгоритма, определённого
    // Конкретными Стратегиями. 

    // Конкретные Стратегии реализуют алгоритм, следуя базовому интерфейсу
    // Стратегии. Этот интерфейс делает их взаимозаменяемыми в Контексте.  

    class Program
    {
        static void Main(string[] args)
        {
            // Клиентский код выбирает конкретную стратегию и передаёт её в
            // контекст. Клиент должен знать о различиях между стратегиями,
            // чтобы сделать правильный выбор.
            var context = new Context();

            Console.WriteLine("Client: Strategy is set to normal sorting.");
            context.SetStrategy(new SortConcrete());
            context.DoSomeBusinessLogic();

            Console.WriteLine();

            Console.WriteLine("Client: Strategy is set to reverse sorting.");
            context.SetStrategy(new SortReverseStrategy());
            context.DoSomeBusinessLogic();

            Console.WriteLine();

            Console.WriteLine("Client: Remove is 1.");
            context.SetStrategy(new PopStrategy());
            context.DoSomeBusinessLogic();
        }
    }
}
