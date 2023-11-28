import java.util.List;
import java.util.Scanner;

public class Menu {
    private List<User> users;
    private CreateOperation createOperation;
    private ReadOperation readOperation;
    private UpdateOperation updateOperation;
    private DeleteOperation deleteOperation;

    public Menu(List<User> users,
                CreateOperation createOperation,
                ReadOperation readOperation,
                UpdateOperation updateOperation,
                DeleteOperation deleteOperation) {
        this.users = users;
        this.createOperation = createOperation;
        this.readOperation = readOperation;
        this.updateOperation = updateOperation;
        this.deleteOperation = deleteOperation;
    }
    public void displayMenu(){
        Scanner sc= new Scanner(System.in);
        while (true){
            System.out.println("1. Create user");
            System.out.println("2. Read user");
            System.out.println("3. Update user");
            System.out.println("4. Delete user");
            System.out.println("0. Exit");
            System.out.print("Enter your choice: ");
            int choice=sc.nextInt();
            switch (choice){
                case 1:
                    createOperation.create();
                    break;

                case 2:
                    readOperation.read();
                    break;

                case 3:
                    updateOperation.update();
                    break;

                case 4:
                    deleteOperation.delete();
                    break;

                case 0:
                    System.out.println("Exiting application. Goodbye!");
                    System.exit(0);
                    break;

                default:
                    System.out.println("Invalid choice. Please enter a valid option.");
                    break;
            }
        }
    }
}
