using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CafeteriaWebApi.Migrations
{
    public partial class init_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_BookingStatus_StatusId",
                table: "Booking");

            migrationBuilder.DropIndex(
                name: "IX_Booking_StatusId",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "BookingStatus");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Booking");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StatusDate",
                table: "BookingStatus",
                nullable: true,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BookingId",
                table: "BookingStatus",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookingStatus_BookingId",
                table: "BookingStatus",
                column: "BookingId",
                unique: true,
                filter: "[BookingId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingStatus_Booking_BookingId",
                table: "BookingStatus",
                column: "BookingId",
                principalTable: "Booking",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingStatus_Booking_BookingId",
                table: "BookingStatus");

            migrationBuilder.DropIndex(
                name: "IX_BookingStatus_BookingId",
                table: "BookingStatus");

            migrationBuilder.DropColumn(
                name: "BookingId",
                table: "BookingStatus");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StatusDate",
                table: "BookingStatus",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "BookingStatus",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Booking",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Booking_StatusId",
                table: "Booking",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_BookingStatus_StatusId",
                table: "Booking",
                column: "StatusId",
                principalTable: "BookingStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
