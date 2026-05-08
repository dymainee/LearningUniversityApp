using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearningUniversityApp.Migrations
{
    /// <inheritdoc />
    public partial class added_lesson_number_to_shedule_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LessonNumber",
                table: "schedules",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LessonNumber",
                table: "schedules");
        }
    }
}
