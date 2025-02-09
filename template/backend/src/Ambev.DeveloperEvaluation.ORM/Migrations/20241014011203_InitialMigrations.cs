using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ambev.DeveloperEvaluation.ORM.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Username = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Status = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Role = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });


            migrationBuilder.CreateTable(
               name: "Sales",
               columns: table => new
               {
                   Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                   NumberSale = table.Column<long>(type: "long", maxLength: 100, nullable: false),
                   CreatedSale = table.Column<DateTime>(type: "date", nullable: false),
                   Customer = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                   TotalValue = table.Column<decimal>(type: "decimal(10, 2)",  nullable: false),
                   Agency = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                   UpdatedAt = table.Column<DateTime>(type: "date", nullable: false),
                   Status = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Sales", x => x.Id);                   
               });


            migrationBuilder.CreateTable(
               name: "Products",
               columns: table => new
               {
                   Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                   Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                   Description = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                   UnitPrice = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                   Discount = table.Column<int>(type: "integer", nullable: false),
                   SaleId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                   Status = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Product", x => x.Id);
                   table.ForeignKey(name:"FK_Product_Sale",
                                   column: x => x.SaleId,
                                   principalTable: "Sales",
                                   principalColumn: "Id",
                                   onDelete: ReferentialAction.Cascade);
               });



        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "`Products");
        }
    }
}
