using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CafeteriaWebApi.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookingId",
                table: "BookingStatus");

            migrationBuilder.AlterColumn<string>(
                name: "StatusDescription",
                table: "BookingStatus",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "StatusDescription",
                table: "BookingStatus",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BookingId",
                table: "BookingStatus",
                nullable: false,
                defaultValue: 0);
        }
    }
}
