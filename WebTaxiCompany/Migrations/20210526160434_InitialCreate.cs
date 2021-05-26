using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebTaxiCompany.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AddService",
                columns: table => new
                {
                    AddServiceKey = table.Column<int>(type: "INT", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR (255)", nullable: false),
                    Description = table.Column<string>(type: "NVARCHAR (255)", nullable: false),
                    Cost = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddService", x => x.AddServiceKey);
                });

            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    BrandKey = table.Column<int>(type: "INT", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR (255)", nullable: false),
                    Specifications = table.Column<string>(type: "NVARCHAR (255)", nullable: false),
                    Cost = table.Column<int>(type: "INT", nullable: false),
                    Specificity = table.Column<string>(type: "NVARCHAR (255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.BrandKey);
                });

            migrationBuilder.CreateTable(
                name: "Position",
                columns: table => new
                {
                    PositionKey = table.Column<int>(type: "INT", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR (255)", nullable: false),
                    Salary = table.Column<int>(type: "INT", nullable: false),
                    Responsibility = table.Column<string>(type: "NVARCHAR (255)", nullable: false),
                    Requirement = table.Column<string>(type: "NVARCHAR (255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Position", x => x.PositionKey);
                });

            migrationBuilder.CreateTable(
                name: "Rate",
                columns: table => new
                {
                    RateKey = table.Column<int>(type: "INT", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR (255)", nullable: false),
                    Description = table.Column<string>(type: "NVARCHAR (255)", nullable: false),
                    Cost = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rate", x => x.RateKey);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeKey = table.Column<int>(type: "INT", nullable: false),
                    FullName = table.Column<string>(type: "NVARCHAR (255)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "DATE", nullable: false),
                    Gender = table.Column<string>(type: "NVARCHAR (255)", nullable: false),
                    Address = table.Column<string>(type: "NVARCHAR (255)", nullable: false),
                    Number = table.Column<int>(type: "INT", nullable: false),
                    Passport = table.Column<int>(type: "INT", nullable: false),
                    PositionKey = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeKey);
                    table.ForeignKey(
                        name: "FK_Employee_Position_PositionKey",
                        column: x => x.PositionKey,
                        principalTable: "Position",
                        principalColumn: "PositionKey",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    CarKey = table.Column<int>(type: "INT", nullable: false),
                    BrandKey = table.Column<int>(type: "INT", nullable: false),
                    RegistrationNumber = table.Column<int>(type: "INT", nullable: false),
                    BodNumber = table.Column<int>(type: "INT", nullable: false),
                    EngineNumber = table.Column<int>(type: "INT", nullable: false),
                    YearOfIssue = table.Column<DateTime>(type: "DATE", nullable: false),
                    Mileage = table.Column<int>(type: "INT", nullable: false),
                    EmployeeKey = table.Column<int>(type: "INT", nullable: false),
                    MaintenanceDate = table.Column<DateTime>(type: "DATE", nullable: false),
                    MechanicKeyEmployeeKey = table.Column<int>(type: "INT", nullable: false),
                    SpecialMarks = table.Column<string>(type: "NVARCHAR (255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.CarKey);
                    table.ForeignKey(
                        name: "FK_Car_Brand_BrandKey",
                        column: x => x.BrandKey,
                        principalTable: "Brand",
                        principalColumn: "BrandKey",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Car_Employee_EmployeeKey",
                        column: x => x.EmployeeKey,
                        principalTable: "Employee",
                        principalColumn: "EmployeeKey",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Car_Employee_MechanicKeyEmployeeKey",
                        column: x => x.MechanicKeyEmployeeKey,
                        principalTable: "Employee",
                        principalColumn: "EmployeeKey",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Call",
                columns: table => new
                {
                    NumKey = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "DATE", nullable: false),
                    Time = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Number = table.Column<int>(type: "INT", nullable: false),
                    WhereFrom = table.Column<string>(type: "NVARCHAR (255)", nullable: false),
                    WhereTo = table.Column<string>(type: "NVARCHAR (255)", nullable: false),
                    RateKey = table.Column<int>(type: "INT", nullable: false),
                    CarKey = table.Column<int>(type: "INT", nullable: false),
                    AddServiceKey = table.Column<int>(type: "INT", nullable: false),
                    EmployeeKey = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Call", x => x.NumKey);
                    table.ForeignKey(
                        name: "FK_Call_AddService_AddServiceKey",
                        column: x => x.AddServiceKey,
                        principalTable: "AddService",
                        principalColumn: "AddServiceKey",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Call_Car_CarKey",
                        column: x => x.CarKey,
                        principalTable: "Car",
                        principalColumn: "CarKey",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Call_Employee_EmployeeKey",
                        column: x => x.EmployeeKey,
                        principalTable: "Employee",
                        principalColumn: "EmployeeKey",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Call_Rate_RateKey",
                        column: x => x.RateKey,
                        principalTable: "Rate",
                        principalColumn: "RateKey",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Call_AddServiceKey",
                table: "Call",
                column: "AddServiceKey");

            migrationBuilder.CreateIndex(
                name: "IX_Call_CarKey",
                table: "Call",
                column: "CarKey");

            migrationBuilder.CreateIndex(
                name: "IX_Call_EmployeeKey",
                table: "Call",
                column: "EmployeeKey");

            migrationBuilder.CreateIndex(
                name: "IX_Call_RateKey",
                table: "Call",
                column: "RateKey");

            migrationBuilder.CreateIndex(
                name: "IX_Car_BrandKey",
                table: "Car",
                column: "BrandKey");

            migrationBuilder.CreateIndex(
                name: "IX_Car_EmployeeKey",
                table: "Car",
                column: "EmployeeKey");

            migrationBuilder.CreateIndex(
                name: "IX_Car_MechanicKeyEmployeeKey",
                table: "Car",
                column: "MechanicKeyEmployeeKey");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_PositionKey",
                table: "Employee",
                column: "PositionKey");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Call");

            migrationBuilder.DropTable(
                name: "AddService");

            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.DropTable(
                name: "Rate");

            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Position");
        }
    }
}
