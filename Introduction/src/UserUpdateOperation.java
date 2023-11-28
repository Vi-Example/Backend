import java.util.List;
import java.util.Scanner;

public class UserUpdateOperation implements UpdateOperation{
    private List<User> users;
    public UserUpdateOperation(List<User> users){
        this.users=users;
    }

    @Override
    public void update() {
        Scanner sc = new Scanner(System.in);
        System.out.println("Enter user id to update");
        int updateUserID= sc.nextInt();
        User existingUser=users.stream()
                .filter(user -> user.getId()==updateUserID)
                .findFirst()
                .orElse(null);
        if (existingUser!=null){
            System.out.println("Enter new name:");
            String newName=sc.next();
            User updateUser= new User(updateUserID, newName);
            users.remove(existingUser);
            users.add(updateUser);
            System.out.println("User update" + updateUser);
        }else {
            System.out.println("User not found!");
        }
    }
}
