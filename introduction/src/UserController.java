import java.util.List;
import java.util.Objects;
import java.util.Scanner;

public class UserController {
    private final static Scanner SCANNER = new Scanner(System.in);

    public static Scanner getScanner() { return SCANNER; }
    public static UserAction createUser = users -> {
        User user = new User();
        user.setEmail(inputField("email", DataType.STRING));
        user.setFirstName(inputField("first name", DataType.STRING));
        user.setLastName(inputField("last name", DataType.STRING));
        user.setPassword(inputField("password", DataType.STRING));
        user.setAge(Integer.parseInt(inputField("age", DataType.INT)));

        users.add(user);
        System.out.printf("User with email %s has been successfully created\n", user.getEmail());
    };

    public static UserAction getUser = users -> {
        int id = inputId(users, "get");
        User user = users.get(id - 1);
        System.out.println(user);
    };

    public static UserAction updateUser = users -> {
        int id = inputId(users, "update");
        User user = users.get(id - 1);

        String newEmail = updateField("email", DataType.STRING);
        if(Objects.nonNull(newEmail) && !newEmail.equalsIgnoreCase("yes") && !newEmail.isBlank()) {
            user.setEmail(newEmail);
        }

        String newFirstName = updateField("first name", DataType.STRING);
        if(Objects.nonNull(newFirstName) && !newFirstName.equalsIgnoreCase("yes") && !newFirstName.isBlank()) {
            user.setFirstName(newFirstName);
        }

        String newLastName = updateField("last name", DataType.STRING);
        if(Objects.nonNull(newLastName) && !newLastName.equalsIgnoreCase("yes") && !newLastName.isBlank()) {
            user.setLastName(newLastName);
        }

        String newPassword = updateField("password", DataType.STRING);
        if(Objects.nonNull(newPassword) && !newPassword.equalsIgnoreCase("yes") && !newPassword.isBlank()) {
            user.setPassword(newPassword);
        }

        String newAge = updateField("age", DataType.INT);
        if(Objects.nonNull(newAge) && !newAge.equalsIgnoreCase("yes") && !newAge.isBlank()) {
            user.setAge(Integer.parseInt(newAge));
        }

        users.set(id - 1, user);
        System.out.printf("User with id %d has been successfully updated\n", id);
    };

    public static UserAction deleteUser = users -> {
        int id = inputId(users, "delete");
        users.remove(id - 1);
        System.out.printf("User with id %d has been successfully deleted\n", id);
    };

    public static UserAction getAllUsers = users -> {
        int id = 1;
        for (User user : users) {
            System.out.println(id + " " + user);
            ++id;
        }
    };

    private static int inputId(List<User> users, String operationType) {
        System.out.printf("Enter id of user that you want to %s: ", operationType);
        int id;
        while (!SCANNER.hasNextInt() || (id = SCANNER.nextInt()) > (users.size())) {
            System.out.println("You enter incorrect id value");
            System.out.printf("Enter id of user that you want to %s: ", operationType);
        }

        return id;
    }

    private static String inputField(String fieldName, DataType fieldDataType) {
        System.out.printf("Enter your %s: ", fieldName);

        String field = SCANNER.next();

        switch (fieldDataType) {
            case STRING -> {
                while (!Objects.nonNull(field) || field.isBlank()) {
                    System.out.printf("Field %s cannot be null or blank. Please enter again.\n", fieldName);
                    System.out.printf("Enter your %s: ", fieldName);
                    field = SCANNER.nextLine();
                }
            }
            case INT -> {
                while (!isInteger(field)) {
                    System.out.printf("Field %s must be an integer. Please enter again.\n", fieldName);
                    System.out.print("Enter " + fieldName + ": ");
                    field = SCANNER.nextLine();
                }
            }
            default -> System.out.println("Incorrect field data type");
        }

        return field;
    }

    private static String updateField(String fieldName, DataType fieldDataType) {
        System.out.printf("Enter new %s (If you want to stay previous value type 'yes'): ", fieldName);
        return SCANNER.next();
    }

    private static boolean isInteger(String str) {
        try {
            Integer.parseInt(str);
            return true;
        } catch (NumberFormatException e) {
            return false;
        }
    }

    private enum DataType {
        STRING,
        INT
    }
}
