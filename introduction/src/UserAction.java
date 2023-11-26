import java.util.List;

@FunctionalInterface
public interface UserAction {
    void perform(List<User> users);
}
