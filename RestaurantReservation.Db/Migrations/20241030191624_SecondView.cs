using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class SecondView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                    CREATE VIEW EmployeesDetails AS
	                    select CONCAT(emp.FirstName ,  ' ' , emp.LastName ) as EmpName, 
	                    emp.Position,
	                    rest.Name as RestaurantName,
	                    rest.Adress
	                    from Employees as emp
	                    join Restaurants as rest
	                    on emp.RestaurantId = rest.Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("drop view EmployeesDetails");
        }
    }
}
