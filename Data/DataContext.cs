
using Microsoft.EntityFrameworkCore;

namespace IDO_Backend.Data

{
    public class DataContext : DbContext
    {


        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Task> Tasks { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);



            // Seed initial data for the Users table
            modelBuilder.Entity<User>().HasData(
             new User { userId = 1, email = "tarekhazouri@example.com", password = "tarekhazouri123" },
             new User { userId = 2, email = "houssamsabih@example.com", password = "houssamsabih123" },
             new User { userId = 3, email = "majdghoche@example.com",   password = "majdghoche123" }
  );

            modelBuilder.Entity<Task>().HasData(
                new Task { id = 1, name = "Complete project proposal", category = "Work", dueDate = "2024-02-20", estimate = "5 hours", importance = "high", status = "toDo", userId = 1 },
                new Task { id = 2, name = "Prepare presentation slides", category = "Work", dueDate = "2024-02-18", estimate = "3 hours", importance = "medium", status = "doing", userId = 1 },
                new Task { id = 3, name = "Debug issue in code", category = "Work", dueDate = "2024-02-19", estimate = "2 hours", importance = "medium", status = "toDo", userId = 1 },
                new Task { id = 4, name = "Review documentation", category = "Work", dueDate = "2024-02-21", estimate = "1.5 hours", importance = "low", status = "toDo", userId = 1 },
                new Task { id = 5, name = "Attend team meeting", category = "Work", dueDate = "2024-02-17", estimate = "1 hour", importance = "low", status = "done", userId = 1 },
                new Task { id = 6, name = "Create project plan", category = "Work", dueDate = "2024-02-23", estimate = "4 hours", importance = "high", status = "toDo", userId = 1 },
                new Task { id = 7, name = "Setup development environment", category = "Work", dueDate = "2024-02-16", estimate = "2 hours", importance = "medium", status = "done", userId = 1 },
                new Task { id = 8, name = "Research new technologies", category = "Work", dueDate = "2024-02-22", estimate = "3 hours", importance = "high", status = "doing", userId = 1 },
                new Task { id = 9, name = "Complete training module", category = "Work", dueDate = "2024-02-24", estimate = "2.5 hours", importance = "medium", status = "toDo", userId = 1 },
                new Task { id = 10, name = "Grocery shopping", category = "Personal", dueDate = "2024-02-19", estimate = "1 hour", importance = "low", status = "toDo", userId = 2 },
                new Task { id = 11, name = "Write blog post", category = "Hobby", dueDate = "2024-02-22", estimate = "2 hours", importance = "medium", status = "toDo", userId = 2 },
                new Task { id = 12, name = "Exercise session", category = "Health", dueDate = "2024-02-25", estimate = "1.5 hours", importance = "high", status = "toDo", userId = 2 },
                new Task { id = 13, name = "Read book", category = "Personal", dueDate = "2024-02-18", estimate = "1 hour", importance = "medium", status = "doing", userId = 2 },
                new Task { id = 14, name = "Attend yoga class", category = "Health", dueDate = "2024-02-20", estimate = "1.5 hours", importance = "high", status = "toDo", userId = 2 },
                new Task { id = 15, name = "Plan weekend trip", category = "Personal", dueDate = "2024-02-24", estimate = "4 hours", importance = "high", status = "doing", userId = 2 },
                new Task { id = 16, name = "Review personal finances", category = "Personal", dueDate = "2024-02-26", estimate = "2 hours", importance = "medium", status = "toDo", userId = 2 },
                new Task { id = 17, name = "Update resume", category = "Career", dueDate = "2024-02-23", estimate = "1.5 hours", importance = "medium", status = "toDo", userId = 2 },
                new Task { id = 18, name = "Research vacation destinations", category = "Personal", dueDate = "2024-02-28", estimate = "3 hours", importance = "high", status = "toDo", userId = 3 },
                new Task { id = 19, name = "Plan family outing", category = "Personal", dueDate = "2024-02-27", estimate = "2 hours", importance = "medium", status = "doing", userId = 3 },
                new Task { id = 20, name = "Attend networking event", category = "Career", dueDate = "2024-02-21", estimate = "2.5 hours", importance = "high", status = "toDo", userId = 3 },
                new Task { id = 21, name = "Complete online course", category = "Education", dueDate = "2024-02-26", estimate = "4 hours", importance = "high", status = "toDo", userId = 3 },
                new Task { id = 22, name = "Cook dinner for family", category = "Personal", dueDate = "2024-02-20", estimate = "1.5 hours", importance = "medium", status = "toDo", userId = 3 },
                new Task { id = 23, name = "Research new recipes", category = "Personal", dueDate = "2024-02-22", estimate = "2 hours", importance = "medium", status = "doing", userId = 3 },
                new Task { id = 24, name = "Organize home office", category = "Personal", dueDate = "2024-02-25", estimate = "3 hours", importance = "low", status = "toDo", userId = 3 },
                new Task { id = 25, name = "Attend parent-teacher meeting", category = "Family", dueDate = "2024-02-23", estimate = "1 hour", importance = "medium", status = "toDo", userId = 3 }
            // Add more tasks as needed
            );


        }
    }
}
