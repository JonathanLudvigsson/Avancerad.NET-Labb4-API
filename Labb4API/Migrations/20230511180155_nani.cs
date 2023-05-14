using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Labb4API.Migrations
{
    /// <inheritdoc />
    public partial class nani : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "interests",
                columns: table => new
                {
                    InterestID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_interests", x => x.InterestID);
                });

            migrationBuilder.CreateTable(
                name: "persons",
                columns: table => new
                {
                    PersonID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_persons", x => x.PersonID);
                });

            migrationBuilder.CreateTable(
                name: "InterestPerson",
                columns: table => new
                {
                    InterestsInterestID = table.Column<int>(type: "int", nullable: false),
                    PersonsPersonID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterestPerson", x => new { x.InterestsInterestID, x.PersonsPersonID });
                    table.ForeignKey(
                        name: "FK_InterestPerson_interests_InterestsInterestID",
                        column: x => x.InterestsInterestID,
                        principalTable: "interests",
                        principalColumn: "InterestID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InterestPerson_persons_PersonsPersonID",
                        column: x => x.PersonsPersonID,
                        principalTable: "persons",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "links",
                columns: table => new
                {
                    LinkID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonID = table.Column<int>(type: "int", nullable: false),
                    InterestID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_links", x => x.LinkID);
                    table.ForeignKey(
                        name: "FK_links_interests_InterestID",
                        column: x => x.InterestID,
                        principalTable: "interests",
                        principalColumn: "InterestID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_links_persons_PersonID",
                        column: x => x.PersonID,
                        principalTable: "persons",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "interests",
                columns: new[] { "InterestID", "Description", "Title" },
                values: new object[,]
                {
                    { 1, "Programming with C#", "Programming" },
                    { 2, "Doing sick flips", "Skateboarding" },
                    { 3, "Getting gains", "Lifting" }
                });

            migrationBuilder.InsertData(
                table: "persons",
                columns: new[] { "PersonID", "Age", "DateOfBirth", "FirstName", "LastName", "Phone" },
                values: new object[,]
                {
                    { 1, 30, new DateTime(1990, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sana", "Kolq", "1234561337" },
                    { 2, 33, new DateTime(1987, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Saibot", "Kolq", "57678811" },
                    { 3, 40, new DateTime(1978, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Radier", "Qolk", "52266004" }
                });

            migrationBuilder.InsertData(
                table: "links",
                columns: new[] { "LinkID", "InterestID", "PersonID", "URL" },
                values: new object[,]
                {
                    { 1, 2, 1, "https://www.youtube.com" },
                    { 2, 2, 2, "https://www.reddit.com" },
                    { 3, 1, 3, "https://www.notion.com" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_InterestPerson_PersonsPersonID",
                table: "InterestPerson",
                column: "PersonsPersonID");

            migrationBuilder.CreateIndex(
                name: "IX_links_InterestID",
                table: "links",
                column: "InterestID");

            migrationBuilder.CreateIndex(
                name: "IX_links_PersonID",
                table: "links",
                column: "PersonID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InterestPerson");

            migrationBuilder.DropTable(
                name: "links");

            migrationBuilder.DropTable(
                name: "interests");

            migrationBuilder.DropTable(
                name: "persons");
        }
    }
}
