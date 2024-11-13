using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class FirstView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                    CREATE VIEW ReservationDetails AS
                    SELECT 
                        ReservationDate,
                        CONCAT(cus.FirstName, ' ', cus.LastName) AS CustomerFullName,
                        rest.Name AS RestaurantName,
                        rest.Adress
                    FROM 
                        Reservations AS res
                    JOIN 
                        Restaurants AS rest ON res.RestaurantId = rest.Id
                    JOIN 
                        Customers AS cus ON cus.Id = res.CustomerId;");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("drop view ReservationDetails");
        }
    }
}
