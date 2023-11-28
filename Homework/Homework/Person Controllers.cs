namespace Homework
{
    public static class PersonControllers
    {
        public delegate void PersonListDelegate(ref List<Person> people);

        public static readonly Dictionary<int, PersonListDelegate> Dict = new Dictionary<int, PersonListDelegate>()
        {
            { 0, (ref List<Person> _) => Console.WriteLine("You've entered unacceptable value.")},
            { 1, CreatePerson },
            { 2, ReadAllPeople},
            { 3, DeletePerson},
            { 4, UpdatePerson},
            {5, (ref List<Person> _) =>
                {
                    Console.WriteLine("Exiting the program....");
                    Environment.Exit(0);
                }
            },
            {6, (ref List<Person> _) =>
                {
                    Console.WriteLine("Press 1 if you wanna create a new Person.");
                    Console.WriteLine("Press 2 if you wanna show the content of the list.");
                    Console.WriteLine("Press 3 if you wanna delete a person.");
                    Console.WriteLine("Press 4 if you wanna update a person.");
                    Console.WriteLine("Press 5 if you wanna exit program.");
                    Console.WriteLine("Press 6 if you wanna show all available options.");
                }
            }
        };
    
        private static void CreatePerson(ref List<Person> people)
        {
            Console.WriteLine("Enter a name of new person: ");
            string? name = Console.ReadLine();
            Console.WriteLine("Enter a surname of new person: ");
            string? surname = Console.ReadLine();
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(surname))
            {
                Console.WriteLine("You've entered incorrect name or surname.");
                return;
            }

            Console.WriteLine("Enter an age of new person: ");
            Int32.TryParse(Console.ReadLine(), out var age);
            if (age <= 0)
            {
                Console.WriteLine("You've entered incorrect age!");
                return;
            }
            people.Add(new Person(name,surname,age));
            Console.WriteLine($"Person {name} {surname} of age {age} was successfully created.");
        }

        private static void ReadAllPeople(ref List<Person> people)
        {
            foreach (var person in people)
            {
                Console.WriteLine($"Name: {person.FirstName}    Surname: {person.LastName}      Age:{person.Age}");
            }
        }

        private static void DeletePerson(ref List<Person> people)
        {
            Console.WriteLine("Enter index of person you'd like to remove: ");
            Int32.TryParse(Console.ReadLine(), out var index);
            try
            {
                people.RemoveAt(index - 1);
                Console.WriteLine("Person was successfully removed.");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Probably your list doesn't contain a person with such an index.");
            }
        }

        private static void UpdatePerson(ref List<Person> people)
        {
            Console.WriteLine("Enter index of person you'd like to update: ");
            Int32.TryParse(Console.ReadLine(), out var index);
            if (index > 0 && index <= people.Count)
            {
                Console.WriteLine("Enter a new name for  chosen person, if you wanna remain the current name press \"Enter\".");
                string? newName = Console.ReadLine();
                if (StringValidation(newName))
                {
                    people[index - 1].FirstName = newName;
                    Console.WriteLine($"The name {newName} has been set successfully.");
                }
                Console.WriteLine("Enter a new name for  chosen person, if you wanna remain the current name press \"Enter\".");
                string? newSurname = Console.ReadLine();
                if (StringValidation(newSurname))
                {
                    people[index - 1].LastName = newSurname;
                    Console.WriteLine($"The surname {newSurname} has been set successfully.");
                }
                Console.WriteLine("Enter a new age for chosen person, if you wanna remain the current age press \"Enter\".");
                Int32.TryParse(Console.ReadLine(), out var newAge);
                if (newAge > 0)
                {
                    people[index - 1].Age = newAge;
                    Console.WriteLine("The age has been changed successfully.");
                }
                else
                    Console.WriteLine("The old value has been remained.");
            }

            bool StringValidation(string? stringToValidate)
            {
                bool result = string.IsNullOrEmpty(stringToValidate);
                if (result)
                    Console.WriteLine("You've pressed \"Enter\" or entered unacceptable data, the old value has been remained");
                return !result;
            }
        }
    }
}