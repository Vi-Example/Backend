import java.util.*;

public class Main {

    private final static List<User> users = new ArrayList<>();

    public static void main(String[] args) {
        users.add(new User("email@mail.com", "First1", "Last", "password", 20));
        users.add(new User("email@mail.com", "First2", "Last", "password", 20));
        users.add(new User("email@mail.com", "First3", "Last", "password", 20));
        users.add(new User("email@mail.com", "First4", "Last", "password", 20));
        users.add(new User("email@mail.com", "First5", "Last", "password", 20));
        users.add(new User("email@mail.com", "First6", "Last", "password", 20));
        users.add(new User("email@mail.com", "First7", "Last", "password", 20));

        Scanner scanner = UserController.getScanner();
        int action;
        Map<Integer, UserAction> userActionMap = new HashMap<>(6);
        userActionMap.put(1, UserController.createUser);
        userActionMap.put(2, UserController.getUser);
        userActionMap.put(3, UserController.updateUser);
        userActionMap.put(4, UserController.deleteUser);
        userActionMap.put(5, UserController.getAllUsers);
        userActionMap.put(6, users -> System.exit(0));

        while(true) {
            System.out.println("""
                    1 - Create user
                    2 - Get user
                    3 - Update user
                    4 - Delete user
                    5 - Get all users
                    6 - finish the program""");

            if(!scanner.hasNextInt())
            {
                System.out.println("Incorrect input type, try again");
                continue;
            }
            action = scanner.nextInt();
            UserAction userAction = userActionMap.get(action);

            if(Objects.nonNull(userAction)) {
                userAction.perform(users);
            } else {
                System.out.println("Incorrect action, try again");
            }
        }
    }
}