using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TimesheetManager.Data.Migrations
{
    public partial class DataBaseRefactor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTasks_Projects_ProjectId",
                table: "ProjectTasks");

            migrationBuilder.DropTable(
                name: "TaskHours");

            migrationBuilder.DropTable(
                name: "TimesheetProjects");

            migrationBuilder.DropTable(
                name: "TimesheetTasks");

            migrationBuilder.DropIndex(
                name: "IX_ProjectTasks_ProjectId",
                table: "ProjectTasks");

            migrationBuilder.DropColumn(
                name: "FinishDate",
                table: "Timesheets");

            migrationBuilder.DropColumn(
                name: "IsSubmitted",
                table: "Timesheets");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Timesheets");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Timesheets");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "ProjectTasks");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Timesheets",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "Timesheets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProjectTaskId",
                table: "Timesheets",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Timesheets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TaskId",
                table: "Timesheets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Weeks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimesheetId = table.Column<int>(type: "int", nullable: false),
                    MondayHours = table.Column<double>(type: "float", nullable: false),
                    TuesdayHours = table.Column<double>(type: "float", nullable: false),
                    WednesdayHours = table.Column<double>(type: "float", nullable: false),
                    ThursdayHours = table.Column<double>(type: "float", nullable: false),
                    FridayHours = table.Column<double>(type: "float", nullable: false),
                    SaturdayHours = table.Column<double>(type: "float", nullable: false),
                    SundayHours = table.Column<double>(type: "float", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weeks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Weeks_Timesheets_TimesheetId",
                        column: x => x.TimesheetId,
                        principalTable: "Timesheets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Timesheets_ApplicationUserId",
                table: "Timesheets",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Timesheets_ProjectId",
                table: "Timesheets",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Timesheets_ProjectTaskId",
                table: "Timesheets",
                column: "ProjectTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Weeks_IsDeleted",
                table: "Weeks",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Weeks_TimesheetId",
                table: "Weeks",
                column: "TimesheetId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Timesheets_AspNetUsers_ApplicationUserId",
                table: "Timesheets",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Timesheets_Projects_ProjectId",
                table: "Timesheets",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Timesheets_ProjectTasks_ProjectTaskId",
                table: "Timesheets",
                column: "ProjectTaskId",
                principalTable: "ProjectTasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Timesheets_AspNetUsers_ApplicationUserId",
                table: "Timesheets");

            migrationBuilder.DropForeignKey(
                name: "FK_Timesheets_Projects_ProjectId",
                table: "Timesheets");

            migrationBuilder.DropForeignKey(
                name: "FK_Timesheets_ProjectTasks_ProjectTaskId",
                table: "Timesheets");

            migrationBuilder.DropTable(
                name: "Weeks");

            migrationBuilder.DropIndex(
                name: "IX_Timesheets_ApplicationUserId",
                table: "Timesheets");

            migrationBuilder.DropIndex(
                name: "IX_Timesheets_ProjectId",
                table: "Timesheets");

            migrationBuilder.DropIndex(
                name: "IX_Timesheets_ProjectTaskId",
                table: "Timesheets");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Timesheets");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Timesheets");

            migrationBuilder.DropColumn(
                name: "ProjectTaskId",
                table: "Timesheets");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Timesheets");

            migrationBuilder.DropColumn(
                name: "TaskId",
                table: "Timesheets");

            migrationBuilder.AddColumn<DateTime>(
                name: "FinishDate",
                table: "Timesheets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsSubmitted",
                table: "Timesheets",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Timesheets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Timesheets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "ProjectTasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TimesheetProjects",
                columns: table => new
                {
                    TimesheetId = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimesheetProjects", x => new { x.TimesheetId, x.ProjectId });
                    table.ForeignKey(
                        name: "FK_TimesheetProjects_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TimesheetProjects_Timesheets_TimesheetId",
                        column: x => x.TimesheetId,
                        principalTable: "Timesheets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TimesheetTasks",
                columns: table => new
                {
                    TimesheetId = table.Column<int>(type: "int", nullable: false),
                    ProjectTaskId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Day = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FridayHours = table.Column<double>(type: "float", nullable: false),
                    Hours = table.Column<double>(type: "float", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MondayHours = table.Column<double>(type: "float", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SaturdayHours = table.Column<double>(type: "float", nullable: false),
                    SundayHours = table.Column<double>(type: "float", nullable: false),
                    ThursdayHours = table.Column<double>(type: "float", nullable: false),
                    TuesdayHours = table.Column<double>(type: "float", nullable: false),
                    WednesdayHours = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimesheetTasks", x => new { x.TimesheetId, x.ProjectTaskId });
                    table.ForeignKey(
                        name: "FK_TimesheetTasks_ProjectTasks_ProjectTaskId",
                        column: x => x.ProjectTaskId,
                        principalTable: "ProjectTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TimesheetTasks_Timesheets_TimesheetId",
                        column: x => x.TimesheetId,
                        principalTable: "Timesheets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TaskHours",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Day = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Hours = table.Column<double>(type: "float", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectTaskId = table.Column<int>(type: "int", nullable: false),
                    TimesheetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskHours", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskHours_ProjectTasks_ProjectTaskId",
                        column: x => x.ProjectTaskId,
                        principalTable: "ProjectTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TaskHours_Timesheets_TimesheetId",
                        column: x => x.TimesheetId,
                        principalTable: "Timesheets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TaskHours_TimesheetTasks_ProjectTaskId_TimesheetId",
                        columns: x => new { x.ProjectTaskId, x.TimesheetId },
                        principalTable: "TimesheetTasks",
                        principalColumns: new[] { "TimesheetId", "ProjectTaskId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTasks_ProjectId",
                table: "ProjectTasks",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskHours_IsDeleted",
                table: "TaskHours",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_TaskHours_ProjectTaskId_TimesheetId",
                table: "TaskHours",
                columns: new[] { "ProjectTaskId", "TimesheetId" });

            migrationBuilder.CreateIndex(
                name: "IX_TaskHours_TimesheetId",
                table: "TaskHours",
                column: "TimesheetId");

            migrationBuilder.CreateIndex(
                name: "IX_TimesheetProjects_ProjectId",
                table: "TimesheetProjects",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_TimesheetTasks_ProjectTaskId",
                table: "TimesheetTasks",
                column: "ProjectTaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTasks_Projects_ProjectId",
                table: "ProjectTasks",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
