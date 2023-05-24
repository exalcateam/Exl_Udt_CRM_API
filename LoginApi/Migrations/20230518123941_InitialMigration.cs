using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoginApi.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companydetails",
                columns: table => new
                {
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GstNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Photos = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companydetails", x => x.CompanyId);
                });

            migrationBuilder.CreateTable(
                name: "LoginCredential",
                columns: table => new
                {
                    Username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginCredential", x => x.Username);
                });

            migrationBuilder.CreateTable(
                name: "Bankdetails",
                columns: table => new
                {
                    AccountNo = table.Column<int>(type: "int", nullable: false),
                    Nominee = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Branch = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bankdetails", x => x.AccountNo);
                    table.ForeignKey(
                        name: "FK_Bankdetails_Companydetails_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companydetails",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanyImages",
                columns: table => new
                {
                    ImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Filename = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Filetype = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Filecontent = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Filesize = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyImages", x => x.ImageId);
                    table.ForeignKey(
                        name: "FK_CompanyImages_Companydetails_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companydetails",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Persondetails",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobileNo = table.Column<long>(type: "bigint", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persondetails", x => x.PersonId);
                    table.ForeignKey(
                        name: "FK_Persondetails_Companydetails_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companydetails",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Purchasedetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Product = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderedDate = table.Column<int>(type: "int", nullable: false),
                    DeliveredDate = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchasedetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Purchasedetails_Companydetails_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companydetails",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserImages",
                columns: table => new
                {
                    UserImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Filename = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Filetype = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Filecontent = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Filesize = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserImages", x => x.UserImageId);
                    table.ForeignKey(
                        name: "FK_UserImages_LoginCredential_UserId",
                        column: x => x.UserId,
                        principalTable: "LoginCredential",
                        principalColumn: "Username");
                });

            migrationBuilder.CreateTable(
                name: "PersonImages",
                columns: table => new
                {
                    PersonImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Filename = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Filetype = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Filecontent = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Filesize = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonImages", x => x.PersonImageId);
                    table.ForeignKey(
                        name: "FK_PersonImages_Persondetails_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persondetails",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bankdetails_CompanyId",
                table: "Bankdetails",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyImages_CompanyId",
                table: "CompanyImages",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Persondetails_CompanyId",
                table: "Persondetails",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonImages_PersonId",
                table: "PersonImages",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchasedetails_CompanyId",
                table: "Purchasedetails",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_UserImages_UserId",
                table: "UserImages",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bankdetails");

            migrationBuilder.DropTable(
                name: "CompanyImages");

            migrationBuilder.DropTable(
                name: "PersonImages");

            migrationBuilder.DropTable(
                name: "Purchasedetails");

            migrationBuilder.DropTable(
                name: "UserImages");

            migrationBuilder.DropTable(
                name: "Persondetails");

            migrationBuilder.DropTable(
                name: "LoginCredential");

            migrationBuilder.DropTable(
                name: "Companydetails");
        }
    }
}
