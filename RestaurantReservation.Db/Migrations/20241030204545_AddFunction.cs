using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class AddFunction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            CREATE FUNCTION CalculateTotalRevenue(@id INT)
            RETURNS DECIMAL(18, 2)
            AS 
            BEGIN
                DECLARE @Total DECIMAL(18, 2);
                SELECT @Total = SUM(o.TotalAmount)
                FROM Restaurants AS rest
                JOIN Reservations AS res ON rest.Id = res.RestaurantId
                JOIN Orders AS o ON o.ReservationId = res.Id
                WHERE rest.Id = @id;

                RETURN @Total;
            END;");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP FUNCTION IF EXISTS dbo.CalculateTotalRevenue");
        }
    }
}
