using Microsoft.EntityFrameworkCore.Migrations;

namespace TimesheetManager.Data.Migrations
{
    public partial class FixTaskHoursKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskHours_TimesheetTasks_TimesheetTaskTimesheetId_TimesheetTaskProjectTaskId",
                table: "TaskHours");

            migrationBuilder.DropIndex(
                name: "IX_TaskHours_TimesheetTaskTimesheetId_TimesheetTaskProjectTaskId",
                table: "TaskHours");

            migrationBuilder.DropColumn(
                name: "TimesheetTaskId",
                table: "TaskHours");

            migrationBuilder.RenameColumn(
                name: "TimesheetTaskTimesheetId",
                table: "TaskHours",
                newName: "TimesheetId");

            migrationBuilder.RenameColumn(
                name: "TimesheetTaskProjectTaskId",
                table: "TaskHours",
                newName: "ProjectTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskHours_ProjectTaskId_TimesheetId",
                table: "TaskHours",
                columns: new[] { "ProjectTaskId", "TimesheetId" });

            migrationBuilder.CreateIndex(
                name: "IX_TaskHours_TimesheetId",
                table: "TaskHours",
                column: "TimesheetId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskHours_ProjectTasks_ProjectTaskId",
                table: "TaskHours",
                column: "ProjectTaskId",
                principalTable: "ProjectTasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskHours_Timesheets_TimesheetId",
                table: "TaskHours",
                column: "TimesheetId",
                principalTable: "Timesheets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskHours_TimesheetTasks_ProjectTaskId_TimesheetId",
                table: "TaskHours",
                columns: new[] { "ProjectTaskId", "TimesheetId" },
                principalTable: "TimesheetTasks",
                principalColumns: new[] { "TimesheetId", "ProjectTaskId" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskHours_ProjectTasks_ProjectTaskId",
                table: "TaskHours");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskHours_Timesheets_TimesheetId",
                table: "TaskHours");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskHours_TimesheetTasks_ProjectTaskId_TimesheetId",
                table: "TaskHours");

            migrationBuilder.DropIndex(
                name: "IX_TaskHours_ProjectTaskId_TimesheetId",
                table: "TaskHours");

            migrationBuilder.DropIndex(
                name: "IX_TaskHours_TimesheetId",
                table: "TaskHours");

            migrationBuilder.RenameColumn(
                name: "TimesheetId",
                table: "TaskHours",
                newName: "TimesheetTaskTimesheetId");

            migrationBuilder.RenameColumn(
                name: "ProjectTaskId",
                table: "TaskHours",
                newName: "TimesheetTaskProjectTaskId");

            migrationBuilder.AddColumn<int>(
                name: "TimesheetTaskId",
                table: "TaskHours",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TaskHours_TimesheetTaskTimesheetId_TimesheetTaskProjectTaskId",
                table: "TaskHours",
                columns: new[] { "TimesheetTaskTimesheetId", "TimesheetTaskProjectTaskId" });

            migrationBuilder.AddForeignKey(
                name: "FK_TaskHours_TimesheetTasks_TimesheetTaskTimesheetId_TimesheetTaskProjectTaskId",
                table: "TaskHours",
                columns: new[] { "TimesheetTaskTimesheetId", "TimesheetTaskProjectTaskId" },
                principalTable: "TimesheetTasks",
                principalColumns: new[] { "TimesheetId", "ProjectTaskId" },
                onDelete: ReferentialAction.Restrict);
        }
    }
}
