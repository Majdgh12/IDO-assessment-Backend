using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IDO_Backend.Migrations
{
    public partial class CreateInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dueDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    estimate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    importance = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    userId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.userId);
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "id", "category", "dueDate", "estimate", "importance", "name", "status", "userId" },
                values: new object[,]
                {
                    { 1, "Work", "2024-02-20", "5 hours", "high", "Complete project proposal", "toDo", 1 },
                    { 2, "Work", "2024-02-18", "3 hours", "medium", "Prepare presentation slides", "doing", 1 },
                    { 3, "Work", "2024-02-19", "2 hours", "medium", "Debug issue in code", "toDo", 1 },
                    { 4, "Work", "2024-02-21", "1.5 hours", "low", "Review documentation", "toDo", 1 },
                    { 5, "Work", "2024-02-17", "1 hour", "low", "Attend team meeting", "done", 1 },
                    { 6, "Work", "2024-02-23", "4 hours", "high", "Create project plan", "toDo", 1 },
                    { 7, "Work", "2024-02-16", "2 hours", "medium", "Setup development environment", "done", 1 },
                    { 8, "Work", "2024-02-22", "3 hours", "high", "Research new technologies", "doing", 1 },
                    { 9, "Work", "2024-02-24", "2.5 hours", "medium", "Complete training module", "toDo", 1 },
                    { 10, "Personal", "2024-02-19", "1 hour", "low", "Grocery shopping", "toDo", 2 },
                    { 11, "Hobby", "2024-02-22", "2 hours", "medium", "Write blog post", "toDo", 2 },
                    { 12, "Health", "2024-02-25", "1.5 hours", "high", "Exercise session", "toDo", 2 },
                    { 13, "Personal", "2024-02-18", "1 hour", "medium", "Read book", "doing", 2 },
                    { 14, "Health", "2024-02-20", "1.5 hours", "high", "Attend yoga class", "toDo", 2 },
                    { 15, "Personal", "2024-02-24", "4 hours", "high", "Plan weekend trip", "doing", 2 },
                    { 16, "Personal", "2024-02-26", "2 hours", "medium", "Review personal finances", "toDo", 2 },
                    { 17, "Career", "2024-02-23", "1.5 hours", "medium", "Update resume", "toDo", 2 },
                    { 18, "Personal", "2024-02-28", "3 hours", "high", "Research vacation destinations", "toDo", 3 },
                    { 19, "Personal", "2024-02-27", "2 hours", "medium", "Plan family outing", "doing", 3 },
                    { 20, "Career", "2024-02-21", "2.5 hours", "high", "Attend networking event", "toDo", 3 },
                    { 21, "Education", "2024-02-26", "4 hours", "high", "Complete online course", "toDo", 3 },
                    { 22, "Personal", "2024-02-20", "1.5 hours", "medium", "Cook dinner for family", "toDo", 3 },
                    { 23, "Personal", "2024-02-22", "2 hours", "medium", "Research new recipes", "doing", 3 },
                    { 24, "Personal", "2024-02-25", "3 hours", "low", "Organize home office", "toDo", 3 },
                    { 25, "Family", "2024-02-23", "1 hour", "medium", "Attend parent-teacher meeting", "toDo", 3 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "userId", "email", "password" },
                values: new object[,]
                {
                    { 1, "tarekhazouri@example.com", "tarekhazouri123" },
                    { 2, "houssamsabih@example.com", "houssamsabih123" },
                    { 3, "majdghoche@example.com", "majdghoche123" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
