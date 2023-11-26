using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace CRUD
{      
    internal class Program
    {
        static List<User> users = new List<User>();   
        static void Main(string[] args)
        {
            var userManager = new UserManager();
            bool StoppingTheCycle = true;
            while (StoppingTheCycle)
            {
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("Создать пользователя[1]");
                Console.WriteLine("Вывести данные про пользователя[2]");
                Console.WriteLine("Обновить данные про пользователя[3]");
                Console.WriteLine("Удалить данные про пользователя[4]");
                Console.WriteLine("Завершить программу[5]");
                int choise = int.Parse(Console.ReadLine());
                switch (choise)
                {
                    case 1:
                        var user = userManager.CreateUser();
                        users.Add(user);
                        break;
                    case 2:
                        userManager.ShowDataAboutUser(users);
                        break;
                    case 3:
                        Console.WriteLine("Данные о каком пользователе вы хотите изменить?");
                        int.TryParse(Console.ReadLine(), out var usersIndexUpdate);
                        userManager.UpdateDataAboutUser(usersIndexUpdate - 1, ref users);
                        break;
                    case 4:
                        Console.WriteLine("Данные о каком пользователе вы хотите изменить?");
                        int.TryParse(Console.ReadLine(), out var usersIndexDelete);
                        userManager.DeleteInformationAboutUser(usersIndexDelete - 1, ref users);

                        break;
                    case 5:
                        StoppingTheCycle = false;
                        break;
                    default:
                        Console.WriteLine("Неизвестное значение. Попробуйте ещё раз");
                        break;
                }
            }
        }
    }
}
