using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class MigratonName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    IDCategory = table.Column<int>(type: "int", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.IDCategory);
                });

            migrationBuilder.CreateTable(
                name: "Group",
                columns: table => new
                {
                    IDGroup = table.Column<int>(type: "int", nullable: false),
                    NameGroup = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    MAXNumber = table.Column<int>(type: "int", nullable: true),
                    MINNumber = table.Column<int>(type: "int", nullable: true),
                    IsComplected = table.Column<bool>(type: "bit", nullable: false),
                    IDCreator = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group2", x => x.IDGroup);
                });

            migrationBuilder.CreateTable(
                name: "Point",
                columns: table => new
                {
                    IDPoint = table.Column<int>(type: "int", nullable: false),
                    NamePoint = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Rating10 = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Point", x => x.IDPoint);
                });

            migrationBuilder.CreateTable(
                name: "PreferencesUsers",
                columns: table => new
                {
                    IDPreferences = table.Column<int>(type: "int", nullable: false),
                    Preferences = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreferencesUsers", x => x.IDPreferences);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    IDRole = table.Column<int>(type: "int", nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.IDRole);
                });

            migrationBuilder.CreateTable(
                name: "TypePoint",
                columns: table => new
                {
                    IDTypePoint = table.Column<int>(type: "int", nullable: false),
                    TypePoint = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypePoint", x => x.IDTypePoint);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    IDUsers = table.Column<int>(type: "int", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FaterNameUou = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.IDUsers);
                });

            migrationBuilder.CreateTable(
                name: "MessageGroup",
                columns: table => new
                {
                    IDGroup = table.Column<int>(type: "int", nullable: false),
                    IDMessage = table.Column<int>(type: "int", nullable: false),
                    TiTleMessage = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOut = table.Column<DateOnly>(type: "date", nullable: false),
                    TimeOut = table.Column<TimeOnly>(type: "time", nullable: false),
                    IDAddressee = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageGroup", x => new { x.IDGroup, x.IDMessage });
                    table.ForeignKey(
                        name: "FK_MessageGroup_Group",
                        column: x => x.IDGroup,
                        principalTable: "Group",
                        principalColumn: "IDGroup");
                });

            migrationBuilder.CreateTable(
                name: "TypePointWay",
                columns: table => new
                {
                    IDPoint = table.Column<int>(type: "int", nullable: false),
                    IDTypePoint = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypePointWay", x => new { x.IDPoint, x.IDTypePoint });
                    table.ForeignKey(
                        name: "FK_TypePointWay_Point",
                        column: x => x.IDPoint,
                        principalTable: "Point",
                        principalColumn: "IDPoint");
                    table.ForeignKey(
                        name: "FK_TypePointWay_TypePoint",
                        column: x => x.IDTypePoint,
                        principalTable: "TypePoint",
                        principalColumn: "IDTypePoint");
                });

            migrationBuilder.CreateTable(
                name: "ContactListPM",
                columns: table => new
                {
                    IDUsers2 = table.Column<int>(type: "int", nullable: false),
                    IDUsers = table.Column<int>(type: "int", nullable: false),
                    LastContact = table.Column<DateTime>(type: "datetime", nullable: true),
                    OnlineStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactListPM", x => new { x.IDUsers2, x.IDUsers });
                    table.ForeignKey(
                        name: "FK_ContactListPM_Users",
                        column: x => x.IDUsers2,
                        principalTable: "Users",
                        principalColumn: "IDUsers");
                    table.ForeignKey(
                        name: "FK_ContactListPM_Users1",
                        column: x => x.IDUsers,
                        principalTable: "Users",
                        principalColumn: "IDUsers");
                });

            migrationBuilder.CreateTable(
                name: "ListPreferencesUsers",
                columns: table => new
                {
                    IDUsers = table.Column<int>(type: "int", nullable: false),
                    IDPreferences = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListPreferencesUsers", x => new { x.IDUsers, x.IDPreferences });
                    table.ForeignKey(
                        name: "FK_ListPreferencesUsers_PreferencesUsers",
                        column: x => x.IDPreferences,
                        principalTable: "PreferencesUsers",
                        principalColumn: "IDPreferences");
                    table.ForeignKey(
                        name: "FK_ListPreferencesUsers_Users",
                        column: x => x.IDUsers,
                        principalTable: "Users",
                        principalColumn: "IDUsers");
                });

            migrationBuilder.CreateTable(
                name: "MessageListPM",
                columns: table => new
                {
                    IDMessage = table.Column<int>(type: "int", nullable: false),
                    IDAddresser = table.Column<int>(type: "int", nullable: false),
                    IDAddressee = table.Column<int>(type: "int", nullable: false),
                    TiTle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Time = table.Column<TimeOnly>(type: "time", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageListPM_1", x => x.IDMessage);
                    table.ForeignKey(
                        name: "FK_MessageListPM_Users",
                        column: x => x.IDAddresser,
                        principalTable: "Users",
                        principalColumn: "IDUsers");
                    table.ForeignKey(
                        name: "FK_MessageListPM_Users1",
                        column: x => x.IDAddressee,
                        principalTable: "Users",
                        principalColumn: "IDUsers");
                });

            migrationBuilder.CreateTable(
                name: "RatingNewsUsers",
                columns: table => new
                {
                    IDNews = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: true),
                    IDUsers = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RatingNewsUsers", x => x.IDNews);
                    table.ForeignKey(
                        name: "FK_RatingNewsUsers_Users",
                        column: x => x.IDUsers,
                        principalTable: "Users",
                        principalColumn: "IDUsers");
                });

            migrationBuilder.CreateTable(
                name: "RoleUsers",
                columns: table => new
                {
                    IDUsers = table.Column<int>(type: "int", nullable: false),
                    IDRole = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleUsers", x => new { x.IDUsers, x.IDRole });
                    table.ForeignKey(
                        name: "FK_RoleUsers_Role",
                        column: x => x.IDRole,
                        principalTable: "Role",
                        principalColumn: "IDRole");
                    table.ForeignKey(
                        name: "FK_RoleUsers_Users",
                        column: x => x.IDUsers,
                        principalTable: "Users",
                        principalColumn: "IDUsers");
                });

            migrationBuilder.CreateTable(
                name: "StoryVisitUsers",
                columns: table => new
                {
                    IDUsers = table.Column<int>(type: "int", nullable: false),
                    IDPoint = table.Column<int>(type: "int", nullable: false),
                    DatetimeVisit = table.Column<DateTime>(type: "datetime", nullable: true),
                    Rating10 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoryVisitUsers", x => new { x.IDUsers, x.IDPoint });
                    table.ForeignKey(
                        name: "FK_StoryVisitUsers_Point",
                        column: x => x.IDPoint,
                        principalTable: "Point",
                        principalColumn: "IDPoint");
                    table.ForeignKey(
                        name: "FK_StoryVisitUsers_Users",
                        column: x => x.IDUsers,
                        principalTable: "Users",
                        principalColumn: "IDUsers");
                });

            migrationBuilder.CreateTable(
                name: "UsersGroup",
                columns: table => new
                {
                    IDGroup = table.Column<int>(type: "int", nullable: false),
                    IDUsers = table.Column<int>(type: "int", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersGroup", x => new { x.IDGroup, x.IDUsers });
                    table.ForeignKey(
                        name: "FK_UsersGroup_Group",
                        column: x => x.IDGroup,
                        principalTable: "Group",
                        principalColumn: "IDGroup");
                    table.ForeignKey(
                        name: "FK_UsersGroup_Users",
                        column: x => x.IDUsers,
                        principalTable: "Users",
                        principalColumn: "IDUsers");
                });

            migrationBuilder.CreateTable(
                name: "Way",
                columns: table => new
                {
                    IDWay = table.Column<int>(type: "int", nullable: false),
                    WayName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ContentWay = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Rating = table.Column<double>(type: "float", nullable: true),
                    IDUserCreator = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Way", x => x.IDWay);
                    table.ForeignKey(
                        name: "FK_Way_Users",
                        column: x => x.IDUserCreator,
                        principalTable: "Users",
                        principalColumn: "IDUsers");
                });

            migrationBuilder.CreateTable(
                name: "NEWS",
                columns: table => new
                {
                    IDNews = table.Column<int>(type: "int", nullable: false),
                    NameNews = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ContentNews = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IDCreator = table.Column<int>(type: "int", nullable: false),
                    IDCategory = table.Column<int>(type: "int", nullable: true),
                    Rating10 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NEWS", x => x.IDNews);
                    table.ForeignKey(
                        name: "FK_NEWS_Category",
                        column: x => x.IDCategory,
                        principalTable: "Category",
                        principalColumn: "IDCategory");
                    table.ForeignKey(
                        name: "FK_NEWS_RatingNewsUsers",
                        column: x => x.IDNews,
                        principalTable: "RatingNewsUsers",
                        principalColumn: "IDNews");
                });

            migrationBuilder.CreateTable(
                name: "Travels",
                columns: table => new
                {
                    IDTravel = table.Column<int>(type: "int", nullable: false),
                    NameTravel = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateStart = table.Column<DateTime>(type: "datetime", nullable: true),
                    DateEnd = table.Column<DateTime>(type: "datetime", nullable: true),
                    IDGroup = table.Column<int>(type: "int", nullable: false),
                    IDWay = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Travels", x => x.IDTravel);
                    table.ForeignKey(
                        name: "FK_Travels_Group",
                        column: x => x.IDGroup,
                        principalTable: "Group",
                        principalColumn: "IDGroup");
                    table.ForeignKey(
                        name: "FK_Travels_Way",
                        column: x => x.IDWay,
                        principalTable: "Way",
                        principalColumn: "IDWay");
                });

            migrationBuilder.CreateTable(
                name: "WayPoints",
                columns: table => new
                {
                    IDPoint = table.Column<int>(type: "int", nullable: false),
                    IDWay = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WayPoints", x => new { x.IDPoint, x.IDWay });
                    table.ForeignKey(
                        name: "FK_WayPoints_Point",
                        column: x => x.IDPoint,
                        principalTable: "Point",
                        principalColumn: "IDPoint");
                    table.ForeignKey(
                        name: "FK_WayPoints_Way",
                        column: x => x.IDWay,
                        principalTable: "Way",
                        principalColumn: "IDWay");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContactListPM_IDUsers",
                table: "ContactListPM",
                column: "IDUsers");

            migrationBuilder.CreateIndex(
                name: "IX_ListPreferencesUsers_IDPreferences",
                table: "ListPreferencesUsers",
                column: "IDPreferences");

            migrationBuilder.CreateIndex(
                name: "IX_MessageListPM_IDAddressee",
                table: "MessageListPM",
                column: "IDAddressee");

            migrationBuilder.CreateIndex(
                name: "IX_MessageListPM_IDAddresser",
                table: "MessageListPM",
                column: "IDAddresser");

            migrationBuilder.CreateIndex(
                name: "IX_NEWS_IDCategory",
                table: "NEWS",
                column: "IDCategory");

            migrationBuilder.CreateIndex(
                name: "IX_RatingNewsUsers_IDUsers",
                table: "RatingNewsUsers",
                column: "IDUsers");

            migrationBuilder.CreateIndex(
                name: "IX_RoleUsers_IDRole",
                table: "RoleUsers",
                column: "IDRole");

            migrationBuilder.CreateIndex(
                name: "IX_StoryVisitUsers_IDPoint",
                table: "StoryVisitUsers",
                column: "IDPoint");

            migrationBuilder.CreateIndex(
                name: "IX_Travels_IDGroup",
                table: "Travels",
                column: "IDGroup");

            migrationBuilder.CreateIndex(
                name: "IX_Travels_IDWay",
                table: "Travels",
                column: "IDWay");

            migrationBuilder.CreateIndex(
                name: "IX_TypePointWay_IDTypePoint",
                table: "TypePointWay",
                column: "IDTypePoint");

            migrationBuilder.CreateIndex(
                name: "IX_UsersGroup_IDUsers",
                table: "UsersGroup",
                column: "IDUsers");

            migrationBuilder.CreateIndex(
                name: "IX_Way_IDUserCreator",
                table: "Way",
                column: "IDUserCreator");

            migrationBuilder.CreateIndex(
                name: "IX_WayPoints_IDWay",
                table: "WayPoints",
                column: "IDWay");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactListPM");

            migrationBuilder.DropTable(
                name: "ListPreferencesUsers");

            migrationBuilder.DropTable(
                name: "MessageGroup");

            migrationBuilder.DropTable(
                name: "MessageListPM");

            migrationBuilder.DropTable(
                name: "NEWS");

            migrationBuilder.DropTable(
                name: "RoleUsers");

            migrationBuilder.DropTable(
                name: "StoryVisitUsers");

            migrationBuilder.DropTable(
                name: "Travels");

            migrationBuilder.DropTable(
                name: "TypePointWay");

            migrationBuilder.DropTable(
                name: "UsersGroup");

            migrationBuilder.DropTable(
                name: "WayPoints");

            migrationBuilder.DropTable(
                name: "PreferencesUsers");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "RatingNewsUsers");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "TypePoint");

            migrationBuilder.DropTable(
                name: "Group");

            migrationBuilder.DropTable(
                name: "Point");

            migrationBuilder.DropTable(
                name: "Way");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
