using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FinalProjectApi.Migrations
{
    /// <inheritdoc />
    public partial class AddTeamMember : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TeamMember",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CollegeProgram = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    YearInProgram = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamMember", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TeamMember",
                columns: new[] { "Id", "BirthDate", "CollegeProgram", "FullName", "YearInProgram" },
                values: new object[,]
                {
                    { 1, new DateTime(2005, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Information Technology", "Anton Chepelev", "Junior" },
                    { 2, new DateTime(2004, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Information Technology", "Ashton Cashier", "Senior" },
                    { 3, new DateTime(2005, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Information Technology", "Opey Obute", "Junior" },
                    { 4, new DateTime(2005, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Information Technology", "Gavin Mcqueen", "Junior" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeamMember");
        }
    }
}
