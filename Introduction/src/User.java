public class User {
    private String name;

    private int id;

    public User( int id,String name) {
        this.name = name;
        this.id = id;
    }

    public String getName() {
        return name;
    }

    public int getId() {
        return id;
    }

    @Override
        public String toString() {
            return "User{" +
                    "id=" + id +
                    ", name='" + name + '\'' +
                    '}';
        }
    }
interface CreateOperation {
    void create();
}

interface ReadOperation {
    void read();
}

interface UpdateOperation {
    void update();
}

interface DeleteOperation {
    void delete();
}



