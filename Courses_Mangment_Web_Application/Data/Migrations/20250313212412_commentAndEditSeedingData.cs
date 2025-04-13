using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Courses_Mangment_Web_Application.Data.Migrations
{
    /// <inheritdoc />
    public partial class commentAndEditSeedingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "evaluation",
                table: "StudentCourses",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "feedback",
                table: "StudentCourses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Hours",
                table: "Courses",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Computer-Science related courses", "Computer sciences" });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Hours", "Title" },
                values: new object[] { "Introduction Data Structure and algorithms by أ.فرج نجم", 3.2m, "Data Structure and algorithms I" });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CategoryId", "Description", "Hours", "Price", "Title" },
                values: new object[] { 1, "Introduction Data Structure and algorithms by أ.خيرالله الفرجاني", 3.2m, 250.00m, "Data Structure and algorithms II" });

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "Name" },
                values: new object[] { "Instructor1@example.com", "أ.فرج نجم" });

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Email", "Name" },
                values: new object[] { "Instructor2@example.com", "أ.خيرالله الفرجاني" });

            migrationBuilder.InsertData(
                table: "Instructors",
                columns: new[] { "Id", "Email", "Name" },
                values: new object[] { 3, "Instructor3@example.com", "ياسمين فوزي" });

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "evaluation", "feedback" },
                values: new object[] { 4, "it was such a nice course " });

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 2, 2 },
                columns: new[] { "evaluation", "feedback" },
                values: new object[] { 3, "good !! " });

            migrationBuilder.InsertData(
                table: "StudentCourses",
                columns: new[] { "CourseId", "StudentId", "evaluation", "feedback" },
                values: new object[] { 2, 1, 2, " no good " });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "Name" },
                values: new object[] { "Student1@example.com", "Sami Awadh" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Email", "Name" },
                values: new object[] { "Student2@example.com", "Othman Shnip" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CategoryId", "Description", "Hours", "InstructorId", "Price", "Title" },
                values: new object[] { 3, 2, "Introduction to Painting by ياسمين فوزي", 5.3m, 3, 150.00m, "Painting 101" });

            migrationBuilder.InsertData(
                table: "StudentCourses",
                columns: new[] { "CourseId", "StudentId", "evaluation", "feedback" },
                values: new object[] { 3, 2, 1, "westing money ,bad instructors no good material " });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "StudentCourses",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "StudentCourses",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "evaluation",
                table: "StudentCourses");

            migrationBuilder.DropColumn(
                name: "feedback",
                table: "StudentCourses");

            migrationBuilder.DropColumn(
                name: "Hours",
                table: "Courses");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Science related courses", "Science" });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Title" },
                values: new object[] { "Introduction to Physics", "Physics 101" });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CategoryId", "Description", "Price", "Title" },
                values: new object[] { 2, "Introduction to Painting", 150.00m, "Painting 101" });

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "Name" },
                values: new object[] { "john.doe@example.com", "John Doe" });

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Email", "Name" },
                values: new object[] { "jane.smith@example.com", "Jane Smith" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "Name" },
                values: new object[] { "alice.johnson@example.com", "Alice Johnson" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Email", "Name" },
                values: new object[] { "bob.brown@example.com", "Bob Brown" });
        }
    }
}
