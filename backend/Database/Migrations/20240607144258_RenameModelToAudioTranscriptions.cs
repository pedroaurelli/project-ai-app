using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class RenameModelToAudioTranscriptions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "audio_texts");

            migrationBuilder.CreateTable(
                name: "audio_transcriptions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    audio_id = table.Column<Guid>(type: "uuid", nullable: false),
                    text = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_audio_transcriptions", x => x.id);
                    table.ForeignKey(
                        name: "fk_audio_transcriptions_audios_audio_id",
                        column: x => x.audio_id,
                        principalTable: "audios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_audio_transcriptions_audio_id",
                table: "audio_transcriptions",
                column: "audio_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "audio_transcriptions");

            migrationBuilder.CreateTable(
                name: "audio_texts",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    audio_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    text = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_audio_texts", x => x.id);
                    table.ForeignKey(
                        name: "fk_audio_texts_audios_audio_id",
                        column: x => x.audio_id,
                        principalTable: "audios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_audio_texts_audio_id",
                table: "audio_texts",
                column: "audio_id");
        }
    }
}
