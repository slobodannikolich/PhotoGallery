using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhotoGallery.Data.Migrations
{
    public partial class AddedBusinessLogicEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    AuthorID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BirthdayDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.AuthorID)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ClientID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    BirthdayDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExternalUserID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientID);
                    table.ForeignKey(
                        name: "FK_Clients_AspNetUsers_ExternalUserID",
                        column: x => x.ExternalUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientCollections",
                columns: table => new
                {
                    ClientCollectionID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    VisibleStatus = table.Column<int>(type: "int", nullable: false),
                    ClientID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientCollections", x => x.ClientCollectionID);
                    table.ForeignKey(
                        name: "FK_ClientCollections_Clients_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Clients",
                        principalColumn: "ClientID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Paintings",
                columns: table => new
                {
                    PaintingID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaintingName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreationYear = table.Column<int>(type: "int", nullable: false),
                    PaintingTehnique = table.Column<int>(type: "int", nullable: false),
                    Documentation = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Desctiprion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    VisibleStatus = table.Column<int>(type: "int", nullable: false),
                    AuthorID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientCollectionID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paintings", x => x.PaintingID);
                    table.ForeignKey(
                        name: "FK_Paintings_Authors_AuthorID",
                        column: x => x.AuthorID,
                        principalTable: "Authors",
                        principalColumn: "AuthorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Paintings_ClientCollections_ClientCollectionID",
                        column: x => x.ClientCollectionID,
                        principalTable: "ClientCollections",
                        principalColumn: "ClientCollectionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientFavorites",
                columns: table => new
                {
                    ClientFavoriteID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaintingID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientFavorites", x => x.ClientFavoriteID);
                    table.ForeignKey(
                        name: "FK_ClientFavorites_Clients_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Clients",
                        principalColumn: "ClientID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientFavorites_Paintings_PaintingID",
                        column: x => x.PaintingID,
                        principalTable: "Paintings",
                        principalColumn: "PaintingID");
                });

            migrationBuilder.CreateTable(
                name: "PaintingCategorys",
                columns: table => new
                {
                    PaintingCategoryID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaintingID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaintingCategorys", x => x.PaintingCategoryID);
                    table.ForeignKey(
                        name: "FK_PaintingCategorys_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaintingCategorys_Paintings_PaintingID",
                        column: x => x.PaintingID,
                        principalTable: "Paintings",
                        principalColumn: "PaintingID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Authors_FirstName_LastName",
                table: "Authors",
                columns: new[] { "FirstName", "LastName" },
                unique: true)
                .Annotation("SqlServer:Clustered", true);

            migrationBuilder.CreateIndex(
                name: "IX_ClientCollections_ClientID",
                table: "ClientCollections",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_ClientFavorites_ClientID",
                table: "ClientFavorites",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_ClientFavorites_PaintingID",
                table: "ClientFavorites",
                column: "PaintingID");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_ExternalUserID",
                table: "Clients",
                column: "ExternalUserID");

            migrationBuilder.CreateIndex(
                name: "IX_PaintingCategorys_CategoryID",
                table: "PaintingCategorys",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_PaintingCategorys_PaintingID",
                table: "PaintingCategorys",
                column: "PaintingID");

            migrationBuilder.CreateIndex(
                name: "IX_Paintings_AuthorID",
                table: "Paintings",
                column: "AuthorID");

            migrationBuilder.CreateIndex(
                name: "IX_Paintings_ClientCollectionID",
                table: "Paintings",
                column: "ClientCollectionID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientFavorites");

            migrationBuilder.DropTable(
                name: "PaintingCategorys");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Paintings");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "ClientCollections");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
