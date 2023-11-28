using Newtonsoft.Json;
class Program
{
	static List<Student> students = new List<Student>() { new Student { FirstName = "Kawazaki", LastName = "Pinguinos", Age = 69, Year = 6 } };

	static void Main()
	{
		LoadData();

		while ( true )
		{
			Console.WriteLine( "[1] - Create a student" );
			Console.WriteLine( "[2] - Open student list" );
			Console.WriteLine( "[3] - Save list" );
			Console.WriteLine( "[0] - Exit" );

			Console.Write( "Choose an option:" );
			int userChoice = int.Parse( Console.ReadLine() );

			switch ( userChoice )
			{
				case 1:
				CreateStudent();
				break;
				case 2:
				StudentList();
				break;
				case 3:
				SaveData();
				break;
				case 0:
				SaveData();
				Console.WriteLine( "Exiting..." );
				Environment.Exit( 0 );
				break;
				default:
				Console.WriteLine( "Wrong option!" );
				break;
			}
		}
	}
	static void CreateStudent()
	{
		Console.Clear();
		Console.Write( "Enter first name: " );
		string first_Name = Console.ReadLine();
		Console.Write( " Enter last name: " );
		string last_Name = Console.ReadLine();

		Console.Write( "       Enter age: " );
		int age_ = int.Parse( Console.ReadLine() );

		Console.Write( "      Enter year: " );
		int year_ = int.Parse( Console.ReadLine() );

		students.Add( new Student { FirstName = first_Name, LastName = last_Name, Age = age_, Year = year_ } );

		Console.WriteLine( "Added!" );
		Console.ReadKey();
		Console.Clear();
	}

	static void StudentList()
	{
		Console.Clear();
		if ( students.Count != 0 )
		{
			for ( int i = 0; i < students.Count; i++ )
			{
				Console.WriteLine( "Student №" + ( i + 1 ) );
				students[i].PrintInfo();
				Console.WriteLine( "_______________________________________________" );
			}

			Console.WriteLine( "Choose an option:" );
			Console.WriteLine( "[1] - Update student" );
			Console.WriteLine( "[2] - Delete student" );
			Console.WriteLine( "[0] - Back to main menu" );

			int userChoice = int.Parse( Console.ReadLine() );

			switch ( userChoice )
			{
				case 1:
				UpdateStudent();
				break;
				case 2:
				RemoveStudent();
				break;
				case 0:
				Console.Clear();
				break;
				default:
				Console.WriteLine( "Wrong option!" );
				break;
			}
		}
		else
		{
			Console.WriteLine( "No students found!" );
			Console.ReadKey();
			Console.Clear();
		}
	}
	static void UpdateStudent()
	{
		Console.WriteLine( "Choose student number:" );
		int studentNumber = int.Parse( Console.ReadLine() );

		Console.Clear();
		Console.Write( "Enter first name: " );
		string first_Name = Console.ReadLine();
		Console.Write( " Enter last name: " );
		string last_Name = Console.ReadLine();

		Console.Write( "       Enter age: " );
		int age_ = int.Parse( Console.ReadLine() );

		Console.Write( "      Enter year: " );
		int year_ = int.Parse( Console.ReadLine() );

		students[studentNumber - 1] = new Student { FirstName = first_Name, LastName = last_Name, Age = age_, Year = year_ };

		Console.WriteLine( "Updated!" );
		Console.ReadKey();
		Console.Clear();
		StudentList();
	}

	static void RemoveStudent()
	{
		Console.WriteLine( "Choose student number:" );
		int studentNumber = int.Parse( Console.ReadLine() );

		students.RemoveAt( studentNumber - 1 );

		Console.WriteLine( "Removed!" );
		Console.ReadKey();
		Console.Clear();
		StudentList();
	}

	static void SaveData()
	{
		string json = JsonConvert.SerializeObject( students, Formatting.Indented );
		File.WriteAllText( "students.json", json );
		Console.WriteLine( "Data saved!" );
	}

	static void LoadData()
	{
		Console.WriteLine( "Loading data..." );
		if ( File.Exists( "students.json" ) )
		{
			string json = File.ReadAllText( "students.json" );
			students = JsonConvert.DeserializeObject<List<Student>>( json );
			Console.WriteLine( "Data loaded successfully!" );
		}
		else
		{
			Console.WriteLine( "Load failed! Creating new file..." );
			File.WriteAllText( "students.json", "" );
			Console.WriteLine( "New file created!" );
		}
	}
}
public class Student
{
	public string FirstName { get; set; }
	public string LastName { get; set; }

	public int Age { get; set; }

	public int Year { get; set; }

	public void PrintInfo()
	{
		Console.WriteLine( "Name: " + FirstName + " " + LastName );
		Console.WriteLine( "Age: " + Age );
		Console.WriteLine( "Year " + Year );
	}
}