import java.util.List;
import java.util.Scanner;

public class UserReadOperation implements ReadOperation{
    private List<User> users;
    public UserReadOperation(List<User> users){
        this.users=users;
    }

    @Override
    public void read() {
        Scanner sc = new Scanner(System.in);
        System.out.print("Enter user id");
        int readUserID=sc.nextInt();
        User readUser=users.stream()
                .filter(user -> user.getId()==readUserID)
                .findFirst()
                .orElse(null);
        if (readUser!=null){
            System.out.println("User found"+readUser);
        }else {
            System.out.println("User not found");
        }
    }
}
