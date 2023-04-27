using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fms.Persistance.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Activity",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Skillsrequired = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartedOn = table.Column<DateTime>(type: "date", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    RelatedDocuments = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsComplete = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))"),
                    completedOn = table.Column<DateTime>(type: "date", nullable: true),
                    TaskLog = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ActivityLog",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "date", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false, defaultValueSql: "((0))"),
                    Attachments = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    file = table.Column<string>(type: "varchar(max)", nullable: false),
                    FileType = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false, defaultValueSql: "((0))"),
                    RequiresAction = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))"),
                    TimeSensitive = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))"),
                    IsComplete = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))"),
                    ActionType = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false, defaultValueSql: "((0))"),
                    DueOn = table.Column<DateTime>(type: "date", nullable: true),
                    SentOn = table.Column<DateTime>(type: "date", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GeneralDetails",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "varchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "varchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "date", nullable: false),
                    EmailAddress = table.Column<string>(type: "varchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(max)", nullable: false),
                    Address = table.Column<string>(type: "varchar(max)", nullable: false),
                    EmergencyContactName = table.Column<string>(type: "varchar(max)", nullable: false),
                    EmergencyContactNumber = table.Column<string>(type: "varchar(max)", nullable: false),
                    EmergencyContactRelation = table.Column<string>(type: "varchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleGroup",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Domain = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactDomainRoles",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Domain = table.Column<string>(type: "varchar(1)", maxLength: 1, nullable: false),
                    RoleGroup = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerAccount = table.Column<string>(type: "varchar(1)", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactDomainRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK__ContactDo__RoleG__5FB337D6",
                        column: x => x.RoleGroup,
                        principalSchema: "dbo",
                        principalTable: "RoleGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(max)", nullable: false),
                    RoleGroup = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PermissionMatrix = table.Column<string>(type: "varchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Role__RoleGroup__60A75C0F",
                        column: x => x.RoleGroup,
                        principalSchema: "dbo",
                        principalTable: "RoleGroup",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RoleObject",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Role = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ObjectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Group = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleObject", x => x.Id);
                    table.ForeignKey(
                        name: "FK__RoleObjec__Group__628FA481",
                        column: x => x.Group,
                        principalSchema: "dbo",
                        principalTable: "RoleGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CheckLists",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    RelatedDocuments = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsComplete = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))"),
                    CompletedOn = table.Column<DateTime>(type: "date", nullable: true),
                    ActivityList = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ReferencedTicketId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckLists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmploymentDetails",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "date", nullable: false),
                    JobTitle = table.Column<string>(type: "varchar(max)", nullable: false),
                    EmploymentStatus = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false, defaultValueSql: "((0))"),
                    Documentation = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Skills = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TicketAssignments = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ActiveTicket = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TravelRangeLimit = table.Column<double>(type: "float", nullable: true, defaultValueSql: "((0))"),
                    ReportsTo = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmploymentDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "varchar(max)", nullable: false),
                    Password = table.Column<string>(type: "varchar(max)", nullable: false),
                    PersonalDetails = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmploymentDetails = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Role = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserType = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_EmploymentDetails_EmploymentDetails",
                        column: x => x.EmploymentDetails,
                        principalSchema: "dbo",
                        principalTable: "EmploymentDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__User__PersonalDe__5CD6CB2B",
                        column: x => x.PersonalDetails,
                        principalSchema: "dbo",
                        principalTable: "GeneralDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__User__Role__5EBF139D",
                        column: x => x.Role,
                        principalSchema: "dbo",
                        principalTable: "Role",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Referencenumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Skillsrequired = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Client = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Approvedon = table.Column<DateTime>(type: "date", nullable: true),
                    CanBeApprovedByRoles = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ApprovedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "date", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Requestedon = table.Column<DateTime>(type: "date", nullable: true),
                    RequestedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Ticket__Approved__5441852A",
                        column: x => x.ApprovedBy,
                        principalSchema: "dbo",
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Ticket__CanBeApp__534D60F1",
                        column: x => x.CanBeApprovedByRoles,
                        principalSchema: "dbo",
                        principalTable: "Role",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Ticket__CreatedB__5535A963",
                        column: x => x.CreatedBy,
                        principalSchema: "dbo",
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Ticket__Requeste__5629CD9C",
                        column: x => x.RequestedBy,
                        principalSchema: "dbo",
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CheckLists_ReferencedTicketId",
                schema: "dbo",
                table: "CheckLists",
                column: "ReferencedTicketId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactDomainRoles_RoleGroup",
                schema: "dbo",
                table: "ContactDomainRoles",
                column: "RoleGroup");

            migrationBuilder.CreateIndex(
                name: "IX_EmploymentDetails_ActiveTicket",
                schema: "dbo",
                table: "EmploymentDetails",
                column: "ActiveTicket");

            migrationBuilder.CreateIndex(
                name: "IX_Role_RoleGroup",
                schema: "dbo",
                table: "Role",
                column: "RoleGroup");

            migrationBuilder.CreateIndex(
                name: "IX_RoleObject_Group",
                schema: "dbo",
                table: "RoleObject",
                column: "Group");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_ApprovedBy",
                schema: "dbo",
                table: "Ticket",
                column: "ApprovedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_CanBeApprovedByRoles",
                schema: "dbo",
                table: "Ticket",
                column: "CanBeApprovedByRoles");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_CreatedBy",
                schema: "dbo",
                table: "Ticket",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_RequestedBy",
                schema: "dbo",
                table: "Ticket",
                column: "RequestedBy");

            migrationBuilder.CreateIndex(
                name: "IX_User_EmploymentDetails",
                schema: "dbo",
                table: "User",
                column: "EmploymentDetails",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_PersonalDetails",
                schema: "dbo",
                table: "User",
                column: "PersonalDetails",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_Role",
                schema: "dbo",
                table: "User",
                column: "Role");

            migrationBuilder.AddForeignKey(
                name: "FK_CheckLists_Ticket_ReferencedTicketId",
                schema: "dbo",
                table: "CheckLists",
                column: "ReferencedTicketId",
                principalSchema: "dbo",
                principalTable: "Ticket",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmploymentDetails_Ticket_ActiveTicket",
                schema: "dbo",
                table: "EmploymentDetails",
                column: "ActiveTicket",
                principalSchema: "dbo",
                principalTable: "Ticket",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmploymentDetails_Ticket_ActiveTicket",
                schema: "dbo",
                table: "EmploymentDetails");

            migrationBuilder.DropTable(
                name: "Activity",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ActivityLog",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CheckLists",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ContactDomainRoles",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Documents",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "RoleObject",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Skills",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Ticket",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "User",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "EmploymentDetails",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "GeneralDetails",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Role",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "RoleGroup",
                schema: "dbo");
        }
    }
}
