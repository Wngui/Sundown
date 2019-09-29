using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sundown.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    ReservationId = table.Column<string>(nullable: false),
                    BookingUser = table.Column<string>(nullable: true),
                    GuestAmount = table.Column<int>(nullable: false),
                    ReservationTime = table.Column<DateTime>(nullable: false),
                    Drink = table.Column<string>(nullable: true),
                    Menu = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.ReservationId);
                });

            migrationBuilder.CreateTable(
                name: "Tables",
                columns: table => new
                {
                    TableId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tables", x => x.TableId);
                });

            migrationBuilder.CreateTable(
                name: "TableReservation",
                columns: table => new
                {
                    ReservationId = table.Column<string>(nullable: false),
                    TableId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableReservation", x => new { x.TableId, x.ReservationId });
                    table.ForeignKey(
                        name: "FK_TableReservation_Reservations_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservations",
                        principalColumn: "ReservationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TableReservation_Tables_TableId",
                        column: x => x.TableId,
                        principalTable: "Tables",
                        principalColumn: "TableId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Tables",
                column: "TableId",
                value: "65b4eccb-8ed7-4b0f-a022-6750d8d7aaaa");

            migrationBuilder.InsertData(
                table: "Tables",
                column: "TableId",
                value: "4ac9ea47-1864-4da2-a419-78bc13fb57b7");

            migrationBuilder.InsertData(
                table: "Tables",
                column: "TableId",
                value: "22924492-4cdf-4a89-9507-caee39adca8e");

            migrationBuilder.InsertData(
                table: "Tables",
                column: "TableId",
                value: "663ac989-965d-4967-9158-3cf552746787");

            migrationBuilder.InsertData(
                table: "Tables",
                column: "TableId",
                value: "5be7799a-5873-4392-ba8f-510aebd2c076");

            migrationBuilder.InsertData(
                table: "Tables",
                column: "TableId",
                value: "c7ea795a-b513-445a-bc58-1e447a94ef89");

            migrationBuilder.InsertData(
                table: "Tables",
                column: "TableId",
                value: "00ef3607-c0d9-4d61-b418-a8c7c5757012");

            migrationBuilder.InsertData(
                table: "Tables",
                column: "TableId",
                value: "ba8c9871-2eae-4df2-a017-faaaa6669e37");

            migrationBuilder.InsertData(
                table: "Tables",
                column: "TableId",
                value: "8f842ec3-d65a-443b-bb1d-8c11c6516313");

            migrationBuilder.InsertData(
                table: "Tables",
                column: "TableId",
                value: "52a5e6f8-bee2-4a09-bf6e-c60ff21eebff");

            migrationBuilder.CreateIndex(
                name: "IX_TableReservation_ReservationId",
                table: "TableReservation",
                column: "ReservationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TableReservation");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Tables");
        }
    }
}
