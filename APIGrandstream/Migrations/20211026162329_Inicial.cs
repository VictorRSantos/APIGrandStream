using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APIGrandstream.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConfigEventos",
                columns: table => new
                {
                    IdConfigEvento = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Prioridade = table.Column<int>(type: "INTEGER", nullable: false),
                    Evento = table.Column<string>(type: "TEXT", nullable: true),
                    NomeExibicao = table.Column<string>(type: "TEXT", nullable: true),
                    CorPainel = table.Column<string>(type: "TEXT", nullable: true),
                    CorTexto = table.Column<string>(type: "TEXT", nullable: true),
                    Icone = table.Column<string>(type: "TEXT", nullable: true),
                    Som = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfigEventos", x => x.IdConfigEvento);
                });

            migrationBuilder.CreateTable(
                name: "Evento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdElise = table.Column<int>(type: "INTEGER", nullable: false),
                    HoraInicio = table.Column<DateTime>(type: "TEXT", nullable: false),
                    HoraFim = table.Column<DateTime>(type: "TEXT", nullable: false),
                    HoraInsert = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Dispositivo = table.Column<string>(type: "TEXT", nullable: true),
                    Leito = table.Column<string>(type: "TEXT", nullable: true),
                    TextoEvento = table.Column<string>(type: "TEXT", nullable: true),
                    Usuario = table.Column<string>(type: "TEXT", nullable: true),
                    MotivoFim = table.Column<string>(type: "TEXT", nullable: true),
                    Tracelogic = table.Column<string>(type: "TEXT", nullable: true),
                    Tipo = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Botao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdConfigEvento = table.Column<int>(type: "INTEGER", nullable: true),
                    Texto = table.Column<string>(type: "TEXT", nullable: true),
                    Icone = table.Column<string>(type: "TEXT", nullable: true),
                    Acao = table.Column<string>(type: "TEXT", nullable: true),
                    Complemento = table.Column<string>(type: "TEXT", nullable: true),
                    ConfigEventosIdConfigEvento = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Botao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Botao_ConfigEventos_ConfigEventosIdConfigEvento",
                        column: x => x.ConfigEventosIdConfigEvento,
                        principalTable: "ConfigEventos",
                        principalColumn: "IdConfigEvento",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    IdElise = table.Column<int>(type: "INTEGER", nullable: false),
                    IdAndar = table.Column<int>(type: "INTEGER", nullable: false),
                    Ramal = table.Column<int>(type: "INTEGER", nullable: false),
                    EventoId = table.Column<int>(type: "INTEGER", nullable: true),
                    BotaoId = table.Column<int>(type: "INTEGER", nullable: true),
                    AndaresId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locations_Botao_BotaoId",
                        column: x => x.BotaoId,
                        principalTable: "Botao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Locations_Evento_EventoId",
                        column: x => x.EventoId,
                        principalTable: "Evento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Andares",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    NomePainel = table.Column<string>(type: "TEXT", nullable: true),
                    Console = table.Column<string>(type: "TEXT", nullable: true),
                    LocationsId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Andares", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Andares_Locations_LocationsId",
                        column: x => x.LocationsId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdElise = table.Column<int>(type: "INTEGER", nullable: false),
                    HoraInicio = table.Column<DateTime>(type: "TEXT", nullable: false),
                    HoraFim = table.Column<DateTime>(type: "TEXT", nullable: false),
                    HoraInsert = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Dispositivo = table.Column<string>(type: "TEXT", nullable: true),
                    Local = table.Column<string>(type: "TEXT", nullable: true),
                    TextoEvento = table.Column<string>(type: "TEXT", nullable: true),
                    Usuario = table.Column<string>(type: "TEXT", nullable: true),
                    MotivoFim = table.Column<string>(type: "TEXT", nullable: true),
                    Tracelogid = table.Column<string>(type: "TEXT", nullable: true),
                    Tipo = table.Column<string>(type: "TEXT", nullable: true),
                    BotaoId = table.Column<int>(type: "INTEGER", nullable: true),
                    LocationsId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Eventos_Botao_BotaoId",
                        column: x => x.BotaoId,
                        principalTable: "Botao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Eventos_Locations_LocationsId",
                        column: x => x.LocationsId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Andares",
                columns: new[] { "Id", "Console", "LocationsId", "Nome", "NomePainel" },
                values: new object[] { 1, null, null, "4 Andar", "Posto 4" });

            migrationBuilder.InsertData(
                table: "Andares",
                columns: new[] { "Id", "Console", "LocationsId", "Nome", "NomePainel" },
                values: new object[] { 2, null, null, "3 Andar", "Posto 3" });

            migrationBuilder.InsertData(
                table: "Andares",
                columns: new[] { "Id", "Console", "LocationsId", "Nome", "NomePainel" },
                values: new object[] { 3, "12", null, "2 Andar", "Posto 2" });

            migrationBuilder.InsertData(
                table: "Andares",
                columns: new[] { "Id", "Console", "LocationsId", "Nome", "NomePainel" },
                values: new object[] { 4, null, null, "5 Andar", "Posto 5" });

            migrationBuilder.InsertData(
                table: "Botao",
                columns: new[] { "Id", "Acao", "Complemento", "ConfigEventosIdConfigEvento", "Icone", "IdConfigEvento", "Texto" },
                values: new object[] { 1, "Ligar", null, null, "Ligar", 1, "Ligar" });

            migrationBuilder.InsertData(
                table: "Botao",
                columns: new[] { "Id", "Acao", "Complemento", "ConfigEventosIdConfigEvento", "Icone", "IdConfigEvento", "Texto" },
                values: new object[] { 2, "Ligar", null, null, "Ligar", 2, "Ligar" });

            migrationBuilder.InsertData(
                table: "Botao",
                columns: new[] { "Id", "Acao", "Complemento", "ConfigEventosIdConfigEvento", "Icone", "IdConfigEvento", "Texto" },
                values: new object[] { 3, "Ligar", null, null, "Ligar", 3, "Ligar" });

            migrationBuilder.InsertData(
                table: "Botao",
                columns: new[] { "Id", "Acao", "Complemento", "ConfigEventosIdConfigEvento", "Icone", "IdConfigEvento", "Texto" },
                values: new object[] { 4, "Ligar", null, null, "Ligar", 4, "Ligar" });

            migrationBuilder.InsertData(
                table: "Botao",
                columns: new[] { "Id", "Acao", "Complemento", "ConfigEventosIdConfigEvento", "Icone", "IdConfigEvento", "Texto" },
                values: new object[] { 5, "Guest", null, null, "Guest", 1, "Guest" });

            migrationBuilder.InsertData(
                table: "Botao",
                columns: new[] { "Id", "Acao", "Complemento", "ConfigEventosIdConfigEvento", "Icone", "IdConfigEvento", "Texto" },
                values: new object[] { 6, "TRR", null, null, "TRR", 2, "TRR" });

            migrationBuilder.InsertData(
                table: "ConfigEventos",
                columns: new[] { "IdConfigEvento", "CorPainel", "CorTexto", "Evento", "Icone", "NomeExibicao", "Prioridade", "Som" },
                values: new object[] { 5, "rgba(0,255,0,1)", "rgba(255,255,255,1)", "Presenca", "fas fa-user-alt", "Presenca", 1, "" });

            migrationBuilder.InsertData(
                table: "ConfigEventos",
                columns: new[] { "IdConfigEvento", "CorPainel", "CorTexto", "Evento", "Icone", "NomeExibicao", "Prioridade", "Som" },
                values: new object[] { 3, "rgba(64,189,255,1)", "rgba(255,255,255,1)", "CH Azul", "fas fa-heartbeat", "Cod. Azul", 5, "" });

            migrationBuilder.InsertData(
                table: "ConfigEventos",
                columns: new[] { "IdConfigEvento", "CorPainel", "CorTexto", "Evento", "Icone", "NomeExibicao", "Prioridade", "Som" },
                values: new object[] { 4, "rgba(255,69,0,1)", "rgba(255,255,255,1)", "Ch Toilete", "fab fa-accessible-icon", "Banheiro", 1, "" });

            migrationBuilder.InsertData(
                table: "ConfigEventos",
                columns: new[] { "IdConfigEvento", "CorPainel", "CorTexto", "Evento", "Icone", "NomeExibicao", "Prioridade", "Som" },
                values: new object[] { 1, "rgba(255,41,5,1)", "rgba(255,255,255,1)", "CH Paciente", "fas fa-user-alt", "Paciente", 1, "" });

            migrationBuilder.InsertData(
                table: "ConfigEventos",
                columns: new[] { "IdConfigEvento", "CorPainel", "CorTexto", "Evento", "Icone", "NomeExibicao", "Prioridade", "Som" },
                values: new object[] { 2, "rgba(255,255,13,1)", "rgba(255,255,255,1)", "CH Auxilio", "fas fa-user-friends", "Auxilio", 2, "" });

            migrationBuilder.InsertData(
                table: "Eventos",
                columns: new[] { "Id", "BotaoId", "Dispositivo", "HoraFim", "HoraInicio", "HoraInsert", "IdElise", "Local", "LocationsId", "MotivoFim", "TextoEvento", "Tipo", "Tracelogid", "Usuario" },
                values: new object[] { 8, null, "1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 10, 22, 5, 0, 7, 387, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Leito 201", null, null, "CH Paciente", "CH Paciente", null, "Victor" });

            migrationBuilder.InsertData(
                table: "Eventos",
                columns: new[] { "Id", "BotaoId", "Dispositivo", "HoraFim", "HoraInicio", "HoraInsert", "IdElise", "Local", "LocationsId", "MotivoFim", "TextoEvento", "Tipo", "Tracelogid", "Usuario" },
                values: new object[] { 9, null, "2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 10, 22, 5, 0, 7, 387, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Leito 202", null, null, "Presenca", "CH Paciente", null, "Artur" });

            migrationBuilder.InsertData(
                table: "Eventos",
                columns: new[] { "Id", "BotaoId", "Dispositivo", "HoraFim", "HoraInicio", "HoraInsert", "IdElise", "Local", "LocationsId", "MotivoFim", "TextoEvento", "Tipo", "Tracelogid", "Usuario" },
                values: new object[] { 10, null, "2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 10, 22, 5, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Leito 202", null, null, "Presenca", "CH Paciente", null, "Andre" });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "AndaresId", "BotaoId", "EventoId", "IdAndar", "IdElise", "Nome", "Ramal" },
                values: new object[] { 12, null, null, null, 3, 1, "Leito 212", 2201 });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "AndaresId", "BotaoId", "EventoId", "IdAndar", "IdElise", "Nome", "Ramal" },
                values: new object[] { 19, null, null, null, 3, 1, "Leito 219", 2201 });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "AndaresId", "BotaoId", "EventoId", "IdAndar", "IdElise", "Nome", "Ramal" },
                values: new object[] { 18, null, null, null, 3, 1, "Leito 218", 2201 });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "AndaresId", "BotaoId", "EventoId", "IdAndar", "IdElise", "Nome", "Ramal" },
                values: new object[] { 17, null, null, null, 3, 1, "Leito 217", 2201 });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "AndaresId", "BotaoId", "EventoId", "IdAndar", "IdElise", "Nome", "Ramal" },
                values: new object[] { 16, null, null, null, 3, 1, "Leito 216", 2201 });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "AndaresId", "BotaoId", "EventoId", "IdAndar", "IdElise", "Nome", "Ramal" },
                values: new object[] { 15, null, null, null, 3, 1, "Leito 215", 2201 });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "AndaresId", "BotaoId", "EventoId", "IdAndar", "IdElise", "Nome", "Ramal" },
                values: new object[] { 14, null, null, null, 3, 1, "Leito 214", 2201 });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "AndaresId", "BotaoId", "EventoId", "IdAndar", "IdElise", "Nome", "Ramal" },
                values: new object[] { 13, null, null, null, 3, 1, "Leito 213", 2201 });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "AndaresId", "BotaoId", "EventoId", "IdAndar", "IdElise", "Nome", "Ramal" },
                values: new object[] { 11, null, null, null, 3, 1, "Leito 211", 2201 });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "AndaresId", "BotaoId", "EventoId", "IdAndar", "IdElise", "Nome", "Ramal" },
                values: new object[] { 2, null, null, null, 3, 1, "Leito 202", 2201 });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "AndaresId", "BotaoId", "EventoId", "IdAndar", "IdElise", "Nome", "Ramal" },
                values: new object[] { 9, null, null, null, 3, 1, "Leito 209", 2201 });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "AndaresId", "BotaoId", "EventoId", "IdAndar", "IdElise", "Nome", "Ramal" },
                values: new object[] { 8, null, null, null, 3, 1, "Leito 208", 2201 });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "AndaresId", "BotaoId", "EventoId", "IdAndar", "IdElise", "Nome", "Ramal" },
                values: new object[] { 7, null, null, null, 3, 1, "Leito 207", 2201 });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "AndaresId", "BotaoId", "EventoId", "IdAndar", "IdElise", "Nome", "Ramal" },
                values: new object[] { 6, null, null, null, 3, 1, "Leito 206", 2201 });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "AndaresId", "BotaoId", "EventoId", "IdAndar", "IdElise", "Nome", "Ramal" },
                values: new object[] { 5, null, null, null, 3, 1, "Leito 205", 2201 });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "AndaresId", "BotaoId", "EventoId", "IdAndar", "IdElise", "Nome", "Ramal" },
                values: new object[] { 4, null, null, null, 3, 1, "Leito 204", 2201 });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "AndaresId", "BotaoId", "EventoId", "IdAndar", "IdElise", "Nome", "Ramal" },
                values: new object[] { 3, null, null, null, 3, 1, "Leito 203", 2201 });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "AndaresId", "BotaoId", "EventoId", "IdAndar", "IdElise", "Nome", "Ramal" },
                values: new object[] { 20, null, null, null, 3, 1, "Leito 220", 2201 });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "AndaresId", "BotaoId", "EventoId", "IdAndar", "IdElise", "Nome", "Ramal" },
                values: new object[] { 1, null, null, null, 3, 1, "Leito 201", 2201 });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "AndaresId", "BotaoId", "EventoId", "IdAndar", "IdElise", "Nome", "Ramal" },
                values: new object[] { 10, null, null, null, 3, 1, "Leito 210", 2201 });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "AndaresId", "BotaoId", "EventoId", "IdAndar", "IdElise", "Nome", "Ramal" },
                values: new object[] { 21, null, null, null, 3, 1, "Leito 221", 2201 });

            migrationBuilder.CreateIndex(
                name: "IX_Andares_LocationsId",
                table: "Andares",
                column: "LocationsId");

            migrationBuilder.CreateIndex(
                name: "IX_Botao_ConfigEventosIdConfigEvento",
                table: "Botao",
                column: "ConfigEventosIdConfigEvento");

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_BotaoId",
                table: "Eventos",
                column: "BotaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_LocationsId",
                table: "Eventos",
                column: "LocationsId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_AndaresId",
                table: "Locations",
                column: "AndaresId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_BotaoId",
                table: "Locations",
                column: "BotaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_EventoId",
                table: "Locations",
                column: "EventoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Andares_AndaresId",
                table: "Locations",
                column: "AndaresId",
                principalTable: "Andares",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Andares_Locations_LocationsId",
                table: "Andares");

            migrationBuilder.DropTable(
                name: "Eventos");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Andares");

            migrationBuilder.DropTable(
                name: "Botao");

            migrationBuilder.DropTable(
                name: "Evento");

            migrationBuilder.DropTable(
                name: "ConfigEventos");
        }
    }
}
