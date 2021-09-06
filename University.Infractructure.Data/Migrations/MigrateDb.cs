using Microsoft.EntityFrameworkCore.Migrations;

namespace University.Infrastructure.Data.Migrations
{
    public partial class MigrateDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "COURSES",
                table => new
                {
                    COURSE_ID = table.Column<int>("int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>("nvarchar(30)", maxLength: 30, nullable: false),
                    DESCRIPTION = table.Column<string>("nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_COURSES", x => x.COURSE_ID); });

            migrationBuilder.CreateTable(
                "GROUPS",
                table => new
                {
                    GROUP_ID = table.Column<int>("int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    COURSE_ID = table.Column<int>("int", nullable: false),
                    NAME = table.Column<string>("nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GROUPS", x => x.GROUP_ID);

                    table.ForeignKey(
                        "GROUPS_COURSE",
                        x => x.COURSE_ID,
                        "COURSES",
                        "COURSE_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "STUDENTS",
                table => new
                {
                    STUDENT_ID = table.Column<int>("int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GROUP_ID = table.Column<int>("int", nullable: false),
                    FIRST_NAME = table.Column<string>("nvarchar(50)", maxLength: 50, nullable: false),
                    LAST_NAME = table.Column<string>("nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STUDENTS", x => x.STUDENT_ID);

                    table.ForeignKey(
                        "STUDENTS_GROUP",
                        x => x.GROUP_ID,
                        "GROUPS",
                        "GROUP_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                "COURSES__INDEX",
                "COURSES",
                "NAME",
                unique: true);

            migrationBuilder.CreateIndex(
                "GROUPS_INDEX",
                "GROUPS",
                "NAME",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_GROUPS_COURSE_ID",
                "GROUPS",
                "COURSE_ID");

            migrationBuilder.CreateIndex(
                "IX_STUDENTS_GROUP_ID",
                "STUDENTS",
                "GROUP_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "STUDENTS");

            migrationBuilder.DropTable(
                "GROUPS");

            migrationBuilder.DropTable(
                "COURSES");
        }
    }
}