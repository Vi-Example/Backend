import java.util.List;
import java.util.Scanner;

public class UserCreateOperation implements CreateOperation{
    private List<User> users;
    public UserCreateOperation(List<User> users){
        this.users=users;
    }

    @Override
    public void create() {
        Scanner sc = new Scanner(System.in);
        System.out.println("Enter user name:");
        String userName=sc.next();
        User newUser = new User(users.size()+1, userName);
        users.add(newUser);
        System.out.println("User created:" + newUser);
    }
}
