using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hathor.Web.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    SourceAsUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SourcedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RekordboxCollections",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Entries = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RekordboxCollections", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RekordboxPlaylistNodes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KeyType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Entries = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlaylistNodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RekordboxPlaylistNodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RekordboxPlaylistNodes_RekordboxPlaylistNodes_PlaylistNodeId",
                        column: x => x.PlaylistNodeId,
                        principalTable: "RekordboxPlaylistNodes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RekordboxProducts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Version = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Company = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RekordboxProducts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RekordboxTempos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Inizio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bpm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Metro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Battito = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RekordboxTempos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RekordboxPlaylistNodeTracks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TrackID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PlaylistNodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RekordboxPlaylistNodeTracks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RekordboxPlaylistNodeTracks_RekordboxPlaylistNodes_PlaylistNodeId",
                        column: x => x.PlaylistNodeId,
                        principalTable: "RekordboxPlaylistNodes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RekordboxPlaylists",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlaylistNodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RekordboxPlaylists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RekordboxPlaylists_RekordboxPlaylistNodes_PlaylistNodeId",
                        column: x => x.PlaylistNodeId,
                        principalTable: "RekordboxPlaylistNodes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RekordboxTracks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TEMPOId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TrackID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Artist = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Composer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Album = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Grouping = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Genre = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Kind = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiscNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrackNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AverageBpm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateAdded = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BitRate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SampleRate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlayCount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remixer = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Tonality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mix = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CollectionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RekordboxTracks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RekordboxTracks_RekordboxCollections_CollectionId",
                        column: x => x.CollectionId,
                        principalTable: "RekordboxCollections",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RekordboxTracks_RekordboxTempos_TEMPOId",
                        column: x => x.TEMPOId,
                        principalTable: "RekordboxTempos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RekordboxLibraries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Version = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CollectionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlaylistsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UploadDateTimeOffset = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RekordboxLibraries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RekordboxLibraries_RekordboxCollections_CollectionId",
                        column: x => x.CollectionId,
                        principalTable: "RekordboxCollections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RekordboxLibraries_RekordboxPlaylists_PlaylistsId",
                        column: x => x.PlaylistsId,
                        principalTable: "RekordboxPlaylists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RekordboxLibraries_RekordboxProducts_ProductId",
                        column: x => x.ProductId,
                        principalTable: "RekordboxProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RekordboxPositionMarks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Start = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Num = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Red = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Green = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Blue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrackId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RekordboxPositionMarks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RekordboxPositionMarks_RekordboxTracks_TrackId",
                        column: x => x.TrackId,
                        principalTable: "RekordboxTracks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_RekordboxLibraries_CollectionId",
                table: "RekordboxLibraries",
                column: "CollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_RekordboxLibraries_PlaylistsId",
                table: "RekordboxLibraries",
                column: "PlaylistsId");

            migrationBuilder.CreateIndex(
                name: "IX_RekordboxLibraries_ProductId",
                table: "RekordboxLibraries",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_RekordboxLibraries_UploadDateTimeOffset",
                table: "RekordboxLibraries",
                column: "UploadDateTimeOffset");

            migrationBuilder.CreateIndex(
                name: "IX_RekordboxPlaylistNodes_PlaylistNodeId",
                table: "RekordboxPlaylistNodes",
                column: "PlaylistNodeId");

            migrationBuilder.CreateIndex(
                name: "IX_RekordboxPlaylistNodeTracks_PlaylistNodeId",
                table: "RekordboxPlaylistNodeTracks",
                column: "PlaylistNodeId");

            migrationBuilder.CreateIndex(
                name: "IX_RekordboxPlaylistNodeTracks_TrackID",
                table: "RekordboxPlaylistNodeTracks",
                column: "TrackID");

            migrationBuilder.CreateIndex(
                name: "IX_RekordboxPlaylists_PlaylistNodeId",
                table: "RekordboxPlaylists",
                column: "PlaylistNodeId");

            migrationBuilder.CreateIndex(
                name: "IX_RekordboxPositionMarks_TrackId",
                table: "RekordboxPositionMarks",
                column: "TrackId");

            migrationBuilder.CreateIndex(
                name: "IX_RekordboxTracks_CollectionId",
                table: "RekordboxTracks",
                column: "CollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_RekordboxTracks_TEMPOId",
                table: "RekordboxTracks",
                column: "TEMPOId");

            migrationBuilder.CreateIndex(
                name: "IX_RekordboxTracks_TrackID_Artist_Name_Remixer_Genre",
                table: "RekordboxTracks",
                columns: new[] { "TrackID", "Artist", "Name", "Remixer", "Genre" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "RekordboxLibraries");

            migrationBuilder.DropTable(
                name: "RekordboxPlaylistNodeTracks");

            migrationBuilder.DropTable(
                name: "RekordboxPositionMarks");

            migrationBuilder.DropTable(
                name: "RekordboxPlaylists");

            migrationBuilder.DropTable(
                name: "RekordboxProducts");

            migrationBuilder.DropTable(
                name: "RekordboxTracks");

            migrationBuilder.DropTable(
                name: "RekordboxPlaylistNodes");

            migrationBuilder.DropTable(
                name: "RekordboxCollections");

            migrationBuilder.DropTable(
                name: "RekordboxTempos");
        }
    }
}
