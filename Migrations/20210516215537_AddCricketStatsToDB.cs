using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CricketStatsGraphQL.Migrations
{
    public partial class AddCricketStatsToDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    CountryDesc = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    LastUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dismissals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DismissalCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    DismissalDesc = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    LastUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dismissals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MatchTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MatchTypeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PlayerSurname = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    Dob = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Retired = table.Column<bool>(type: "bit", nullable: false),
                    LastUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Venues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VenueName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    VenueCity = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    LastUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Venues_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MatchNumber = table.Column<short>(type: "smallint", nullable: false),
                    HomeCountryId = table.Column<int>(type: "int", nullable: false),
                    AwayCountryId = table.Column<int>(type: "int", nullable: false),
                    VenueId = table.Column<int>(type: "int", nullable: false),
                    MatchTypeId = table.Column<int>(type: "int", nullable: false),
                    MatchStartDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    TossWinnerCountryId = table.Column<int>(type: "int", nullable: false),
                    LastUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()"),
                    CountryHomeId = table.Column<int>(type: "int", nullable: true),
                    CountryAwayId = table.Column<int>(type: "int", nullable: true),
                    CountryTossWonId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Matches_Countries_CountryAwayId",
                        column: x => x.CountryAwayId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matches_Countries_CountryHomeId",
                        column: x => x.CountryHomeId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matches_Countries_CountryTossWonId",
                        column: x => x.CountryTossWonId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matches_Countries_HomeCountryId",
                        column: x => x.HomeCountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Matches_MatchTypes_MatchTypeId",
                        column: x => x.MatchTypeId,
                        principalTable: "MatchTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Matches_Venues_VenueId",
                        column: x => x.VenueId,
                        principalTable: "Venues",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BattingInns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MatchId = table.Column<int>(type: "int", nullable: false),
                    FirstInns = table.Column<bool>(type: "bit", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    Runs = table.Column<int>(type: "int", nullable: false),
                    BallsFaced = table.Column<int>(type: "int", nullable: false),
                    Fours = table.Column<int>(type: "int", nullable: false),
                    Sixes = table.Column<int>(type: "int", nullable: false),
                    BowlerPlayerId = table.Column<int>(type: "int", nullable: true),
                    FielderPlayerId = table.Column<int>(type: "int", nullable: true),
                    DismissalId = table.Column<int>(type: "int", nullable: false),
                    LastUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BattingInns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BattingInns_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BattingInns_Dismissals_DismissalId",
                        column: x => x.DismissalId,
                        principalTable: "Dismissals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BattingInns_Matches_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Matches",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BattingInns_Players_BowlerPlayerId",
                        column: x => x.BowlerPlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BattingInns_Players_FielderPlayerId",
                        column: x => x.FielderPlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BattingInns_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BowlingInns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MatchId = table.Column<int>(type: "int", nullable: false),
                    FirstInns = table.Column<bool>(type: "bit", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    Runs = table.Column<int>(type: "int", nullable: false),
                    Wickets = table.Column<int>(type: "int", nullable: false),
                    Maidens = table.Column<int>(type: "int", nullable: false),
                    Overs = table.Column<int>(type: "int", nullable: false),
                    Extras = table.Column<int>(type: "int", nullable: false),
                    LastUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BowlingInns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BowlingInns_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BowlingInns_Matches_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Matches",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BowlingInns_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BattingInns_BowlerPlayerId",
                table: "BattingInns",
                column: "BowlerPlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_BattingInns_CountryId",
                table: "BattingInns",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_BattingInns_DismissalId",
                table: "BattingInns",
                column: "DismissalId");

            migrationBuilder.CreateIndex(
                name: "IX_BattingInns_FielderPlayerId",
                table: "BattingInns",
                column: "FielderPlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_BattingInns_MatchId",
                table: "BattingInns",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_BattingInns_PlayerId",
                table: "BattingInns",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_BowlingInns_CountryId",
                table: "BowlingInns",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_BowlingInns_MatchId",
                table: "BowlingInns",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_BowlingInns_PlayerId",
                table: "BowlingInns",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_CountryAwayId",
                table: "Matches",
                column: "CountryAwayId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_CountryHomeId",
                table: "Matches",
                column: "CountryHomeId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_CountryTossWonId",
                table: "Matches",
                column: "CountryTossWonId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_HomeCountryId",
                table: "Matches",
                column: "HomeCountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_MatchTypeId",
                table: "Matches",
                column: "MatchTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_VenueId",
                table: "Matches",
                column: "VenueId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_CountryId",
                table: "Players",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Venues_CountryId",
                table: "Venues",
                column: "CountryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BattingInns");

            migrationBuilder.DropTable(
                name: "BowlingInns");

            migrationBuilder.DropTable(
                name: "Dismissals");

            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "MatchTypes");

            migrationBuilder.DropTable(
                name: "Venues");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
