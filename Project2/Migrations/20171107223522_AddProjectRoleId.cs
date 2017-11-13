using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Project2.Migrations
{
    public partial class AddProjectRoleId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectRoles",
                table: "ProjectRoles");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ProjectRoles",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectRoles",
                table: "ProjectRoles",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectRoles_ProjectId",
                table: "ProjectRoles",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectRoles",
                table: "ProjectRoles");

            migrationBuilder.DropIndex(
                name: "IX_ProjectRoles_ProjectId",
                table: "ProjectRoles");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ProjectRoles");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectRoles",
                table: "ProjectRoles",
                columns: new[] { "ProjectId", "PersonId", "RoleId" });
        }
    }
}
