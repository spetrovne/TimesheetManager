using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TimesheetManager.Data.Migrations
{
    public partial class AddFieldsToTimesheetTask : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "TimesheetTasks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Day",
                table: "TimesheetTasks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "FridayHours",
                table: "TimesheetTasks",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Hours",
                table: "TimesheetTasks",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "MondayHours",
                table: "TimesheetTasks",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "TimesheetTasks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "SaturdayHours",
                table: "TimesheetTasks",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "SundayHours",
                table: "TimesheetTasks",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ThursdayHours",
                table: "TimesheetTasks",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TuesdayHours",
                table: "TimesheetTasks",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "WednesdayHours",
                table: "TimesheetTasks",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "TimesheetTasks");

            migrationBuilder.DropColumn(
                name: "Day",
                table: "TimesheetTasks");

            migrationBuilder.DropColumn(
                name: "FridayHours",
                table: "TimesheetTasks");

            migrationBuilder.DropColumn(
                name: "Hours",
                table: "TimesheetTasks");

            migrationBuilder.DropColumn(
                name: "MondayHours",
                table: "TimesheetTasks");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "TimesheetTasks");

            migrationBuilder.DropColumn(
                name: "SaturdayHours",
                table: "TimesheetTasks");

            migrationBuilder.DropColumn(
                name: "SundayHours",
                table: "TimesheetTasks");

            migrationBuilder.DropColumn(
                name: "ThursdayHours",
                table: "TimesheetTasks");

            migrationBuilder.DropColumn(
                name: "TuesdayHours",
                table: "TimesheetTasks");

            migrationBuilder.DropColumn(
                name: "WednesdayHours",
                table: "TimesheetTasks");
        }
    }
}
