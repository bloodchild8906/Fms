using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fms.Persistance.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class skillsandchecklists : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckLists_Ticket_ReferencedTicketId",
                schema: "dbo",
                table: "CheckLists");

            migrationBuilder.DropIndex(
                name: "IX_CheckLists_ReferencedTicketId",
                schema: "dbo",
                table: "CheckLists");

            migrationBuilder.DropColumn(
                name: "Skillsrequired",
                schema: "dbo",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "ReferencedTicketId",
                schema: "dbo",
                table: "CheckLists");

            migrationBuilder.AddColumn<Guid>(
                name: "TicketId",
                schema: "dbo",
                table: "Skills",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TicketId1",
                schema: "dbo",
                table: "Skills",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TicketId",
                schema: "dbo",
                table: "CheckLists",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TicketId1",
                schema: "dbo",
                table: "CheckLists",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Skills_TicketId",
                schema: "dbo",
                table: "Skills",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_TicketId1",
                schema: "dbo",
                table: "Skills",
                column: "TicketId1");

            migrationBuilder.CreateIndex(
                name: "IX_CheckLists_TicketId",
                schema: "dbo",
                table: "CheckLists",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckLists_TicketId1",
                schema: "dbo",
                table: "CheckLists",
                column: "TicketId1");

            migrationBuilder.AddForeignKey(
                name: "FK_CheckLists_Ticket_TicketId",
                schema: "dbo",
                table: "CheckLists",
                column: "TicketId",
                principalSchema: "dbo",
                principalTable: "Ticket",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CheckLists_Ticket_TicketId1",
                schema: "dbo",
                table: "CheckLists",
                column: "TicketId1",
                principalSchema: "dbo",
                principalTable: "Ticket",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Ticket_TicketId",
                schema: "dbo",
                table: "Skills",
                column: "TicketId",
                principalSchema: "dbo",
                principalTable: "Ticket",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Ticket_TicketId1",
                schema: "dbo",
                table: "Skills",
                column: "TicketId1",
                principalSchema: "dbo",
                principalTable: "Ticket",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckLists_Ticket_TicketId",
                schema: "dbo",
                table: "CheckLists");

            migrationBuilder.DropForeignKey(
                name: "FK_CheckLists_Ticket_TicketId1",
                schema: "dbo",
                table: "CheckLists");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Ticket_TicketId",
                schema: "dbo",
                table: "Skills");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Ticket_TicketId1",
                schema: "dbo",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Skills_TicketId",
                schema: "dbo",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Skills_TicketId1",
                schema: "dbo",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_CheckLists_TicketId",
                schema: "dbo",
                table: "CheckLists");

            migrationBuilder.DropIndex(
                name: "IX_CheckLists_TicketId1",
                schema: "dbo",
                table: "CheckLists");

            migrationBuilder.DropColumn(
                name: "TicketId",
                schema: "dbo",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "TicketId1",
                schema: "dbo",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "TicketId",
                schema: "dbo",
                table: "CheckLists");

            migrationBuilder.DropColumn(
                name: "TicketId1",
                schema: "dbo",
                table: "CheckLists");

            migrationBuilder.AddColumn<Guid>(
                name: "Skillsrequired",
                schema: "dbo",
                table: "Ticket",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ReferencedTicketId",
                schema: "dbo",
                table: "CheckLists",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_CheckLists_ReferencedTicketId",
                schema: "dbo",
                table: "CheckLists",
                column: "ReferencedTicketId");

            migrationBuilder.AddForeignKey(
                name: "FK_CheckLists_Ticket_ReferencedTicketId",
                schema: "dbo",
                table: "CheckLists",
                column: "ReferencedTicketId",
                principalSchema: "dbo",
                principalTable: "Ticket",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
