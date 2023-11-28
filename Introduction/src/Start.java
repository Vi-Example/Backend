import java.util.LinkedList;
import java.util.List;


public class Start {
    public static void main(String[]args){
    List<User> users = new LinkedList<>();
    CreateOperation createOperation=new UserCreateOperation(users);
    ReadOperation readOperation = new UserReadOperation(users);
    UpdateOperation updateOperation = new UserUpdateOperation(users);
    DeleteOperation deleteOperation = new UserDeleteOperation(users);
    Menu menu = new Menu(users, createOperation, readOperation, updateOperation,deleteOperation );
    menu.displayMenu();
    }

}