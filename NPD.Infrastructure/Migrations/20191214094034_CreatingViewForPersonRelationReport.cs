using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NPD.Infrastructure.Migrations
{
    public partial class CreatingViewForPersonRelationReport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string createViewSql = @"CREATE VIEW [NPD].[V_PersonsRelatedPeopleReport]
                                    AS 
                                    SELECT p.PersonalNumber, p.Firstname, p.Lastname, r.Type, COUNT(r.Id) as [Count]
                                    FROM [NPD].[Persons] AS [p]
                                    LEFT JOIN [NPD].[RelatedPersons] AS [r] ON p.Id = r.PersonId
                                    GROUP BY [p].[PersonalNumber], p.Firstname, p.Lastname, r.Type
                                    GO";

            migrationBuilder.Sql(createViewSql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW [NPD].[V_PersonsRelatedPeopleReport]");
        }
    }
}
