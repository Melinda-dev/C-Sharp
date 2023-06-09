using Microsoft.EntityFrameworkCore.Migrations;

namespace Entity_Framework.Migrations
{
    public partial class CreateDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Enrollments",
                columns: table => new
                {
                    EnrollmentID = table.Column<string>(type: "TEXT", nullable: false),
                    StudentID = table.Column<string>(type: "TEXT", nullable: true),
                    SubjectID = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollments", x => x.EnrollmentID);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentID = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentID);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    SubjectID = table.Column<string>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    NumberOfSession = table.Column<string>(type: "TEXT", nullable: true),
                    HourPerSession = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.SubjectID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enrollments");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Subjects");
        }
    }
}
