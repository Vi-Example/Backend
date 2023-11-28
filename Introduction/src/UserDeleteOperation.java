import java.util.List;
import java.util.Scanner;

public class UserDeleteOperation implements DeleteOperation{
    private List<User> users;
    public UserDeleteOperation(List<User> users){
        this.users=users;
    }
    @Override
    public void delete() {
        Scanner sc= new Scanner(System.in);
        System.out.println("Enter user id to delete");
        int deleteUserID = sc.nextInt();
        users.removeIf(user -> user.getId()==deleteUserID);
        System.out.println("User delete with id:" + deleteUserID);
    }
}
