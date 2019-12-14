using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NPD.Infrastructure.Migrations
{
    public partial class InitaialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "NPD");

            migrationBuilder.EnsureSchema(
                name: "Exc");

            migrationBuilder.EnsureSchema(
                name: "Req");

            migrationBuilder.CreateTable(
                name: "UnprocessedExceptions",
                schema: "Exc",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Level = table.Column<int>(nullable: false),
                    ExceptionUuid = table.Column<Guid>(maxLength: 150, nullable: false),
                    ExceptionType = table.Column<string>(maxLength: 150, nullable: true),
                    ExceptionData = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnprocessedExceptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                schema: "NPD",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Firstname = table.Column<string>(nullable: true),
                    Lastname = table.Column<string>(nullable: true),
                    Gender = table.Column<int>(nullable: false),
                    PersonalNumber = table.Column<string>(maxLength: 11, nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: true),
                    CityId = table.Column<int>(nullable: false),
                    ImagePath = table.Column<string>(maxLength: 500, nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClientRequests",
                schema: "Req",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Time = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2019, 12, 14, 13, 39, 43, 908, DateTimeKind.Local).AddTicks(955)),
                    CommandJsonObj = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientRequests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhoneNumbers",
                schema: "NPD",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(nullable: false),
                    Value = table.Column<string>(maxLength: 50, nullable: false),
                    PersonId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneNumbers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhoneNumbers_Persons_PersonId",
                        column: x => x.PersonId,
                        principalSchema: "NPD",
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RelatedPersons",
                schema: "NPD",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(nullable: false),
                    PersonId = table.Column<int>(nullable: false),
                    RPersonId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelatedPersons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RelatedPersons_Persons_PersonId",
                        column: x => x.PersonId,
                        principalSchema: "NPD",
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Persons_PersonalNumber",
                schema: "NPD",
                table: "Persons",
                column: "PersonalNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNumbers_PersonId",
                schema: "NPD",
                table: "PhoneNumbers",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_RelatedPersons_PersonId",
                schema: "NPD",
                table: "RelatedPersons",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UnprocessedExceptions",
                schema: "Exc");

            migrationBuilder.DropTable(
                name: "PhoneNumbers",
                schema: "NPD");

            migrationBuilder.DropTable(
                name: "RelatedPersons",
                schema: "NPD");

            migrationBuilder.DropTable(
                name: "ClientRequests",
                schema: "Req");

            migrationBuilder.DropTable(
                name: "Persons",
                schema: "NPD");
        }
    }
}
