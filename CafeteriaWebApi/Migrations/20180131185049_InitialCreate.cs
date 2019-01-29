using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CafeteriaWebApi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookingStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BookingId = table.Column<int>(nullable: false),
                    StatusDate = table.Column<DateTime>(nullable: true),
                    StatusDescription = table.Column<int>(nullable: false),
                    StatusId = table.Column<int>(nullable: false),
                    StatusName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    BookingDate = table.Column<DateTime>(nullable: true),
                    ContactNumber = table.Column<string>(nullable: true),
                    CustomerName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: true),
                    ReferenceId = table.Column<string>(nullable: true),
                    StatusId = table.Column<int>(nullable: true),
                    TotalPersons = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Booking_BookingStatus_StatusId",
                        column: x => x.StatusId,
                        principalTable: "BookingStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Booking_StatusId",
                table: "Booking",
                column: "StatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "BookingStatus");
        }
    }
}
