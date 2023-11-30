using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InisializationPerson
{
    internal class UserFunctionality
    {
        public User CreateUser() 
        {
            User user = new User();
            Random random = new Random();
            user.Id = random.Next();
            Console.WriteLine("Enter your name:");
            user.Name = Console.ReadLine();
            Console.WriteLine("Enter your email:");
            user.Email = Console.ReadLine();
            Console.WriteLine("Enter your password:");
            user.Password = Console.ReadLine();
            Console.WriteLine("\n");
            return user;
        }

        public void ShowUserData(List <User> users) 
        {
            int i = 1;
            foreach (var user in users) 
            {
                Console.WriteLine($"User #{i}");
                Console.WriteLine(user.Id); 
                Console.WriteLine(user.Name);
                Console.WriteLine(user.Email);
                Console.WriteLine(user.Password);
                Console.WriteLine("\n");
                i++;
            }
        }

        public void UpdateUserData(int index, ref List<User> users)
        {
            if(!IndexChecker(index, users)) return;
            bool continueLoop = true;
            while (continueLoop) 
            {
                Console.WriteLine("What do you want to change?\n1.User ID       3.User Email        5.Cancel\n2.User Name       4.User Password");
                int.TryParse(Console.ReadLine(), out var choice);
                switch (choice) 
                {
                    case 1:
                        Console.WriteLine("Enter new Id:");
                        users[index].Id = int.Parse(Console.ReadLine());
                        break;
                    case 2: 
                        Console.WriteLine("Enter new Name:");
                        users[index].Name = Console.ReadLine();
                        break;
                    case 3:
                        Console.WriteLine("Enter new Email:");
                        users[index].Email = Console.ReadLine();
                        break;
                    case 4:
                        Console.WriteLine("Enter new Password:");
                        users[index].Password = Console.ReadLine();
                        break;
                    case 5:
                        continueLoop = false;
                        break;
                    default:
                        Console.WriteLine("Unknown command! Try again.");
                        break;
                }
            }
        }

        public void DeleteUser(int index, ref List<User> users) 
        {
            if (!IndexChecker(index, users)) return;
            users.RemoveAt(index);
            Console.WriteLine("Data deleted!");
            Console.WriteLine("\n");
        }

        public bool IndexChecker(int index, List<User> users) 
        {
            if (!(index >= 0 && index < users.Count)) 
            {
                Console.WriteLine("Unknown index");
                return false;
            }
            return true;
        }
    }
}
