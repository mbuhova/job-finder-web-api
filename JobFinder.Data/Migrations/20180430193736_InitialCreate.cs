using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace JobFinder.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BusinessSectors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessSectors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Towns",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Towns", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    AboutUs = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Bulstat = table.Column<string>(maxLength: 13, nullable: true),
                    CompanyName = table.Column<string>(maxLength: 60, nullable: true),
                    IsApproved = table.Column<bool>(nullable: true),
                    WebSite = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Discriminator = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobOffers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApplicationsCount = table.Column<int>(nullable: false),
                    BusinessSectorId = table.Column<int>(nullable: false),
                    CompanyId = table.Column<string>(nullable: true),
                    CompanyId1 = table.Column<int>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    IsFullTime = table.Column<bool>(nullable: true),
                    IsPermanent = table.Column<bool>(nullable: true),
                    Title = table.Column<string>(nullable: false),
                    TownId = table.Column<int>(nullable: false),
                    Views = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobOffers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobOffers_BusinessSectors_BusinessSectorId",
                        column: x => x.BusinessSectorId,
                        principalTable: "BusinessSectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobOffers_Users_CompanyId1",
                        column: x => x.CompanyId1,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JobOffers_Towns_TownId",
                        column: x => x.TownId,
                        principalTable: "Towns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SectorCompany",
                columns: table => new
                {
                    BusinessSectorId = table.Column<int>(nullable: false),
                    CompanyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectorCompany", x => new { x.BusinessSectorId, x.CompanyId });
                    table.ForeignKey(
                        name: "FK_SectorCompany_BusinessSectors_BusinessSectorId",
                        column: x => x.BusinessSectorId,
                        principalTable: "BusinessSectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SectorCompany_Users_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Applications",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContentType = table.Column<string>(nullable: true),
                    DateUploaded = table.Column<DateTime>(nullable: false),
                    FileData = table.Column<byte[]>(nullable: true),
                    FileName = table.Column<string>(nullable: false),
                    FileSize = table.Column<long>(nullable: false),
                    IsApproved = table.Column<bool>(nullable: true),
                    JobOfferId = table.Column<int>(nullable: false),
                    PersonId = table.Column<string>(nullable: false),
                    PersonId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Applications_JobOffers_JobOfferId",
                        column: x => x.JobOfferId,
                        principalTable: "JobOffers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Applications_Users_PersonId1",
                        column: x => x.PersonId1,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PersonOffer",
                columns: table => new
                {
                    PersonId = table.Column<int>(nullable: false),
                    JobOfferId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonOffer", x => new { x.PersonId, x.JobOfferId });
                    table.ForeignKey(
                        name: "FK_PersonOffer_JobOffers_JobOfferId",
                        column: x => x.JobOfferId,
                        principalTable: "JobOffers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonOffer_Users_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Applications_JobOfferId",
                table: "Applications",
                column: "JobOfferId");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_PersonId1",
                table: "Applications",
                column: "PersonId1");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessSectors_Name",
                table: "BusinessSectors",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobOffers_BusinessSectorId",
                table: "JobOffers",
                column: "BusinessSectorId");

            migrationBuilder.CreateIndex(
                name: "IX_JobOffers_CompanyId1",
                table: "JobOffers",
                column: "CompanyId1");

            migrationBuilder.CreateIndex(
                name: "IX_JobOffers_TownId",
                table: "JobOffers",
                column: "TownId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonOffer_JobOfferId",
                table: "PersonOffer",
                column: "JobOfferId");

            migrationBuilder.CreateIndex(
                name: "IX_SectorCompany_CompanyId",
                table: "SectorCompany",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Towns_Name",
                table: "Towns",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Bulstat",
                table: "Users",
                column: "Bulstat",
                unique: true,
                filter: "[Bulstat] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CompanyName",
                table: "Users",
                column: "CompanyName",
                unique: true,
                filter: "[CompanyName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Applications");

            migrationBuilder.DropTable(
                name: "PersonOffer");

            migrationBuilder.DropTable(
                name: "SectorCompany");

            migrationBuilder.DropTable(
                name: "JobOffers");

            migrationBuilder.DropTable(
                name: "BusinessSectors");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Towns");
        }
    }
}
