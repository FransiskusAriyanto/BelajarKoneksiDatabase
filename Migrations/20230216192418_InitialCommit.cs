using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BelajarKoneksiDatabase.Migrations
{
    /// <inheritdoc />
    public partial class InitialCommit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_m_employees",
                columns: table => new
                {
                    nik = table.Column<string>(type: "nchar(5)", nullable: false),
                    first_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    birth_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    gender = table.Column<int>(type: "int", nullable: false),
                    hire_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    phone_number = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_employees", x => x.nik);
                    table.UniqueConstraint("AK_tb_m_employees_email_phone_number", x => new { x.email, x.phone_number });
                });

            migrationBuilder.CreateTable(
                name: "tb_m_roles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_m_universities",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_universities", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_m_accounts",
                columns: table => new
                {
                    employee_nik = table.Column<string>(type: "nchar(5)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_accounts", x => x.employee_nik);
                    table.ForeignKey(
                        name: "FK_tb_m_accounts_tb_m_employees_employee_nik",
                        column: x => x.employee_nik,
                        principalTable: "tb_m_employees",
                        principalColumn: "nik",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_m_educations",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    major = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    degree = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    gpa = table.Column<float>(type: "real", nullable: false),
                    unversity_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_educations", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_m_educations_tb_m_universities_unversity_id",
                        column: x => x.unversity_id,
                        principalTable: "tb_m_universities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_tr_account_roles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    account_nik = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    role_id = table.Column<int>(type: "int", nullable: false),
                    AccountEmployeeNIK = table.Column<string>(type: "nchar(5)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_tr_account_roles", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_tr_account_roles_tb_m_accounts_AccountEmployeeNIK",
                        column: x => x.AccountEmployeeNIK,
                        principalTable: "tb_m_accounts",
                        principalColumn: "employee_nik");
                    table.ForeignKey(
                        name: "FK_tb_tr_account_roles_tb_m_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "tb_m_roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_tr_profilings",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    employee_nik = table.Column<string>(type: "nchar(5)", maxLength: 5, nullable: false),
                    education_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_tr_profilings", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_tr_profilings_tb_m_educations_education_id",
                        column: x => x.education_id,
                        principalTable: "tb_m_educations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_tr_profilings_tb_m_employees_employee_nik",
                        column: x => x.employee_nik,
                        principalTable: "tb_m_employees",
                        principalColumn: "nik",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_educations_unversity_id",
                table: "tb_m_educations",
                column: "unversity_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_tr_account_roles_AccountEmployeeNIK",
                table: "tb_tr_account_roles",
                column: "AccountEmployeeNIK");

            migrationBuilder.CreateIndex(
                name: "IX_tb_tr_account_roles_role_id",
                table: "tb_tr_account_roles",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_tr_profilings_education_id",
                table: "tb_tr_profilings",
                column: "education_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_tr_profilings_employee_nik",
                table: "tb_tr_profilings",
                column: "employee_nik");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_tr_account_roles");

            migrationBuilder.DropTable(
                name: "tb_tr_profilings");

            migrationBuilder.DropTable(
                name: "tb_m_accounts");

            migrationBuilder.DropTable(
                name: "tb_m_roles");

            migrationBuilder.DropTable(
                name: "tb_m_educations");

            migrationBuilder.DropTable(
                name: "tb_m_employees");

            migrationBuilder.DropTable(
                name: "tb_m_universities");
        }
    }
}
