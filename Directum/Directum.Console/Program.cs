using Directum.BusinessLogic.Services;
using Directum.BusinessLogic.Utils;

namespace Directum.ConsoleInterface
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Приветствую в программе DirectumProject");

            var meetService = new MeetService();
            
            while (true)
            {
                Console.WriteLine("Что вы хотите сделать?");
                Console.WriteLine("Е - создать новую встречу");
                Console.WriteLine("А - посмотреть все встречи");
                Console.WriteLine("Q - выйти из приложения");

                var key = Console.ReadKey();
                Console.WriteLine();
                string text = string.Empty;

                switch (key.Key)
                {
                    case ConsoleKey.E:
                        Console.Write("Введите название встречи: ");
                        string name = Console.ReadLine();

                        Console.Write("Введите дату и время начала встречи (дд.мм.гггг чч.мм): ");
                        DateTime dateStart = Utils.ParseDate();

                        Console.Write("Введите дату и время конца встречи (дд.мм.гггг чч.мм): ");
                        DateTime dateEnd = Utils.ParseDate();

                        Console.Write("Введите время за сколько минут нужно предупредить вас: ");
                        uint notifyTime = Convert.ToUInt32(Console.ReadLine());

                        Console.Write("Введите описание встречи: ");
                        string description = Console.ReadLine();

                        meetService.CreateMeet(name, dateStart, dateEnd, notifyTime, description);
                        break;
                    case ConsoleKey.A:
                        Console.WriteLine(meetService.GetMeets());
                        break;
                    case ConsoleKey.Q:
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}