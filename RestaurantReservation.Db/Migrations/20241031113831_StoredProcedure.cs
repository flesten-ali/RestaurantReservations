using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class StoredProcedure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                        CREATE PROCEDURE FindCustomersWithPartySize (@size INT)
                        AS
                        BEGIN
	                        SELECT 	
	                            DISTINCT(cus.Id),
	                            CONCAT (cus.FirstName,' ',cus.LastName) AS CustomerName,
		                        cus.Email,
		                        cus.PhoneNumbers 
	                        FROM Reservations
	                        JOIN Customers AS cus ON Reservations.CustomerId = cus.Id
	                        WHERE PartySize > @size
                        END");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP PROCEDURE FindCustomersWithPartySize");
        }
    }
}
