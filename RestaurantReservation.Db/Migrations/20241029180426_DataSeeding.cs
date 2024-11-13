using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class DataSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "PhoneNumbers" },
                values: new object[,]
                {
                    { 1, "example1@gmail.com", "Cus1", "A", "059900293" },
                    { 2, "example2@gmail.com", "Cus2", "A", "059900293" },
                    { 3, "example3@gmail.com", "Cus3", "B", "059900293" },
                    { 4, "example4@gmail.com", "Cus4", "C", "059900293" },
                    { 5, "example5@gmail.com", "Cus5", "D", "059900293" }
                });

            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "Id", "Adress", "Name", "OpeningHours", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "A", "Res1", 12, "9039741" },
                    { 2, "B", "Res2", 10, "9039741" },
                    { 3, "D", "Res3", 6, "9039741" },
                    { 4, "C", "Res4", 9, "9039741" },
                    { 5, "A", "Res5", 12, "9039741" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "FirstName", "LastName", "Position", "RestaurantId" },
                values: new object[,]
                {
                    { 1, "Emp1", "F", "A", 1 },
                    { 2, "Emp2", "B", "A", 1 },
                    { 3, "Emp3", "G", "B", 2 },
                    { 4, "Emp4", "T", "C", 4 },
                    { 5, "Emp5", "B", "A", 5 }
                });

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "Id", "Description", "Name", "Price", "RestaurantId" },
                values: new object[,]
                {
                    { 1, null, "Item1", 140.0, 1 },
                    { 2, null, "Item2", 120.0, 2 },
                    { 3, null, "Item3", 130.0, 3 },
                    { 4, null, "Item4", 10.0, 4 },
                    { 5, null, "Item5", 60.0, 5 }
                });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "Id", "Capacity", "RestaurantId" },
                values: new object[,]
                {
                    { 1, 2, 1 },
                    { 2, 4, 2 },
                    { 3, 3, 1 },
                    { 4, 5, 3 },
                    { 5, 6, 4 },
                    { 6, 4, 5 }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "CustomerId", "PartySize", "ReservationDate", "RestaurantId", "TableId" },
                values: new object[,]
                {
                    { 1, 1, 2, new DateTime(2024, 10, 29, 20, 4, 25, 948, DateTimeKind.Local).AddTicks(7434), 1, 1 },
                    { 2, 1, 2, new DateTime(2024, 10, 29, 20, 4, 25, 948, DateTimeKind.Local).AddTicks(7501), 1, 2 },
                    { 3, 1, 2, new DateTime(2024, 10, 29, 20, 4, 25, 948, DateTimeKind.Local).AddTicks(7507), 2, 1 },
                    { 4, 1, 2, new DateTime(2024, 10, 29, 20, 4, 25, 948, DateTimeKind.Local).AddTicks(7512), 3, 1 },
                    { 5, 1, 2, new DateTime(2024, 10, 29, 20, 4, 25, 948, DateTimeKind.Local).AddTicks(7517), 5, 1 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "EmployeeId", "OrderDate", "ReservationId", "TotalAmount" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 10, 29, 20, 4, 25, 948, DateTimeKind.Local).AddTicks(7569), 1, 2 },
                    { 2, 2, new DateTime(2024, 10, 29, 20, 4, 25, 948, DateTimeKind.Local).AddTicks(7577), 2, 12 },
                    { 3, 3, new DateTime(2024, 10, 29, 20, 4, 25, 948, DateTimeKind.Local).AddTicks(7582), 3, 10 },
                    { 4, 4, new DateTime(2024, 10, 29, 20, 4, 25, 948, DateTimeKind.Local).AddTicks(7586), 4, 11 },
                    { 5, 5, new DateTime(2024, 10, 29, 20, 4, 25, 948, DateTimeKind.Local).AddTicks(7590), 5, 120 }
                });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "MenuItemId", "OrderId", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 1, 2 },
                    { 2, 2, 2, 2 },
                    { 3, 3, 3, 2 },
                    { 4, 4, 4, 2 },
                    { 5, 5, 5, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
