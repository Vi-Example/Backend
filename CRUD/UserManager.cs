using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CRUD
{
    public class UserManager
    {
        public User CreateUser()
        {
            User user = new User();
            Random random = new Random();
            user.Id = random.Next();
            Console.WriteLine("Введите Ваше имя");
            user.Name = Console.ReadLine();
            Console.WriteLine("Введите Ваш email");
            user.Email = Console.ReadLine();
            Console.WriteLine("Введите Ваш пароль");
            user.Password = Console.ReadLine();
            Console.WriteLine();
            return user;

        }
        public void ShowDataAboutUser(List<User> users)
        {
            int i = 1;
            foreach (var user in users)
            {
                Console.WriteLine($"User{i}: ");
                Console.WriteLine($"ID пользователя: {user.Id}");
                Console.WriteLine($"Имя пользователя: {user.Name}");
                Console.WriteLine($"Email пользователя: {user.Email}");
                Console.WriteLine($"Пароль пользователя: {user.Password}");
                Console.WriteLine();
                i++;
            }

        }
        public void UpdateDataAboutUser(int index, ref List<User> users)
        {
            if (!IndexValidation(index, users)) return;
            bool StoppingTheCycle = true;
            while (StoppingTheCycle)
            {
                Console.WriteLine("Что вы хотите изменить?");
                Console.WriteLine("ID пользователя[1]");
                Console.WriteLine("Имя пользователя[2]");
                Console.WriteLine("Email пользователя[3]");
                Console.WriteLine("Пароль пользователя[4]");
                Console.WriteLine("Отмена[5]");
                int.TryParse(Console.ReadLine(), out var choise);
                switch (choise)
                {
                    case 1:
                        Console.WriteLine("Введите новый ID пользователя: ");
                        users[index].Id = int.Parse(Console.ReadLine()); ;
                        break;
                    case 2:
                        Console.WriteLine("Введите новое имя пользователя: ");
                        users[index].Name = Console.ReadLine();
                        break;
                    case 3:
                        Console.WriteLine("Введите новый email пользователя: ");
                        users[index].Email = Console.ReadLine();
                        break;
                    case 4:
                        Console.WriteLine("Введите новый пароль пользователя: ");
                        users[index].Password = Console.ReadLine();
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
        public void DeleteInformationAboutUser(int index, ref List<User> users)
        {
            if (!IndexValidation(index, users)) return;
            users.RemoveAt(index);
            Console.WriteLine("Удаление данных завершенно");
            Console.WriteLine();
        }
        public bool IndexValidation(int index, List<User> users)
        {
            if (!(index >= 0 && index < users.Count))
            {
                Console.WriteLine("Такого индекса не существует");
                return false;
            }
            return true;
        }
    }
}
