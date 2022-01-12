namespace TimesheetManager.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class FixTaskHoursTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskHours_ProjectTasks_ProjectTaskId",
                table: "TaskHours");

            migrationBuilder.DropIndex(
                name: "IX_TaskHours_ProjectTaskId",
                table: "TaskHours");

            migrationBuilder.RenameColumn(
                name: "ProjectTaskId",
                table: "TaskHours",
                newName: "TimesheetTaskId");

            migrationBuilder.AlterColumn<int>(
                name: "TimesheetTaskTimesheetId",
                table: "TaskHours",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TimesheetTaskProjectTaskId",
                table: "TaskHours",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TimesheetTaskId",
                table: "TaskHours",
                newName: "ProjectTaskId");

            migrationBuilder.AlterColumn<int>(
                name: "TimesheetTaskTimesheetId",
                table: "TaskHours",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "TimesheetTaskProjectTaskId",
                table: "TaskHours",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_TaskHours_ProjectTaskId",
                table: "TaskHours",
                column: "ProjectTaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskHours_ProjectTasks_ProjectTaskId",
                table: "TaskHours",
                column: "ProjectTaskId",
                principalTable: "ProjectTasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
