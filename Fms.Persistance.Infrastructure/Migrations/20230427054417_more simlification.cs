using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fms.Persistance.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class moresimlification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActivityList",
                schema: "dbo",
                table: "CheckLists");

            migrationBuilder.DropColumn(
                name: "RelatedDocuments",
                schema: "dbo",
                table: "CheckLists");

            migrationBuilder.DropColumn(
                name: "Attachments",
                schema: "dbo",
                table: "ActivityLog");

            migrationBuilder.DropColumn(
                name: "RelatedDocuments",
                schema: "dbo",
                table: "Activity");

            migrationBuilder.DropColumn(
                name: "Skillsrequired",
                schema: "dbo",
                table: "Activity");

            migrationBuilder.RenameColumn(
                name: "TaskLog",
                schema: "dbo",
                table: "Activity",
                newName: "CheckListsId");

            migrationBuilder.AddColumn<Guid>(
                name: "ActivityId",
                schema: "dbo",
                table: "Skills",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ActivityId",
                schema: "dbo",
                table: "Documents",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ActivityLogId",
                schema: "dbo",
                table: "Documents",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CheckListsId",
                schema: "dbo",
                table: "Documents",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ActivityId",
                schema: "dbo",
                table: "ActivityLog",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Skills_ActivityId",
                schema: "dbo",
                table: "Skills",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_ActivityId",
                schema: "dbo",
                table: "Documents",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_ActivityLogId",
                schema: "dbo",
                table: "Documents",
                column: "ActivityLogId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_CheckListsId",
                schema: "dbo",
                table: "Documents",
                column: "CheckListsId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityLog_ActivityId",
                schema: "dbo",
                table: "ActivityLog",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_Activity_CheckListsId",
                schema: "dbo",
                table: "Activity",
                column: "CheckListsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activity_CheckLists_CheckListsId",
                schema: "dbo",
                table: "Activity",
                column: "CheckListsId",
                principalSchema: "dbo",
                principalTable: "CheckLists",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityLog_Activity_ActivityId",
                schema: "dbo",
                table: "ActivityLog",
                column: "ActivityId",
                principalSchema: "dbo",
                principalTable: "Activity",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_ActivityLog_ActivityLogId",
                schema: "dbo",
                table: "Documents",
                column: "ActivityLogId",
                principalSchema: "dbo",
                principalTable: "ActivityLog",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Activity_ActivityId",
                schema: "dbo",
                table: "Documents",
                column: "ActivityId",
                principalSchema: "dbo",
                principalTable: "Activity",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_CheckLists_CheckListsId",
                schema: "dbo",
                table: "Documents",
                column: "CheckListsId",
                principalSchema: "dbo",
                principalTable: "CheckLists",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Activity_ActivityId",
                schema: "dbo",
                table: "Skills",
                column: "ActivityId",
                principalSchema: "dbo",
                principalTable: "Activity",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activity_CheckLists_CheckListsId",
                schema: "dbo",
                table: "Activity");

            migrationBuilder.DropForeignKey(
                name: "FK_ActivityLog_Activity_ActivityId",
                schema: "dbo",
                table: "ActivityLog");

            migrationBuilder.DropForeignKey(
                name: "FK_Documents_ActivityLog_ActivityLogId",
                schema: "dbo",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Activity_ActivityId",
                schema: "dbo",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Documents_CheckLists_CheckListsId",
                schema: "dbo",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Activity_ActivityId",
                schema: "dbo",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Skills_ActivityId",
                schema: "dbo",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Documents_ActivityId",
                schema: "dbo",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Documents_ActivityLogId",
                schema: "dbo",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Documents_CheckListsId",
                schema: "dbo",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_ActivityLog_ActivityId",
                schema: "dbo",
                table: "ActivityLog");

            migrationBuilder.DropIndex(
                name: "IX_Activity_CheckListsId",
                schema: "dbo",
                table: "Activity");

            migrationBuilder.DropColumn(
                name: "ActivityId",
                schema: "dbo",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "ActivityId",
                schema: "dbo",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "ActivityLogId",
                schema: "dbo",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "CheckListsId",
                schema: "dbo",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "ActivityId",
                schema: "dbo",
                table: "ActivityLog");

            migrationBuilder.RenameColumn(
                name: "CheckListsId",
                schema: "dbo",
                table: "Activity",
                newName: "TaskLog");

            migrationBuilder.AddColumn<Guid>(
                name: "ActivityList",
                schema: "dbo",
                table: "CheckLists",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RelatedDocuments",
                schema: "dbo",
                table: "CheckLists",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Attachments",
                schema: "dbo",
                table: "ActivityLog",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "RelatedDocuments",
                schema: "dbo",
                table: "Activity",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Skillsrequired",
                schema: "dbo",
                table: "Activity",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
