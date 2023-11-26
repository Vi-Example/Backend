namespace Homework
{
    internal abstract class Program
    {
        private static List<Person> _people = new List<Person>();
        static void Main()
        {
            PersonControllers.Dict[6](ref _people);
            while (true)
            {
                Console.WriteLine("Select the desired option: ");
                Int32.TryParse(Console.ReadLine(), out var key);
                if (PersonControllers.Dict.Count <= key)
                    PersonControllers.Dict[0](ref _people);
                else
                    PersonControllers.Dict[key](ref _people);
            }
        }
    }
}
