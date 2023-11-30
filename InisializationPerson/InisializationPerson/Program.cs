namespace InisializationPerson
{
    internal class Program
    {
        static List<User> users = new List<User>(); 
        static void Main(string[] args)
        {
            var userFunctionality = new UserFunctionality();

            bool continueLoop = true;
            while (continueLoop) 
            {
                Console.WriteLine("Выберете действие:\n1.Создать пользователя                         3.Обновить информацию пользователя        5.Остановить программу\n2.Просмотреть информацию о пользователе        4.Удалить информацию о пользователе");
                int choice = int.Parse(Console.ReadLine());
                switch (choice) 
                {
                    case 1:
                        var user = userFunctionality.CreateUser();
                        users.Add(user);
                        break;
                    case 2:
                        userFunctionality.ShowUserData(users);
                        break;
                    case 3:
                        Console.WriteLine("Data of which user you want to change?");
                        int.TryParse(Console.ReadLine(), out var UpdateUserData);
                        userFunctionality.UpdateUserData(UpdateUserData - 1, ref users);
                        break;
                    case 4:
                        Console.WriteLine("Data of which user you want to change?");
                        int.TryParse(Console.ReadLine(), out var DeleteUser);
                        userFunctionality.DeleteUser(DeleteUser - 1, ref users);
                        break;
                    case 5:
                        continueLoop = false;
                        break;
                    default:
                        Console.WriteLine("Unknown function! Try again.");
                        break;
                }
            }
        }
    }

}
