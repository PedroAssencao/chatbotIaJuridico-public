using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatbotIaJuridico.Infra.Migrations
{
    /// <inheritdoc />
    public partial class ScriptAtualizado_20_02_2025 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "advogado",
                columns: table => new
                {
                    adv_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    adv_senha = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    adv_waid = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    adv_nome = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    adv_cpf = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__advogado__D4518D542DBC5CDA", x => x.adv_id);
                });

            migrationBuilder.CreateTable(
                name: "cliente",
                columns: table => new
                {
                    cli_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cli_nome = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    cli_cpf = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__cliente__FFEFE14F9FCA56EF", x => x.cli_id);
                });

            migrationBuilder.CreateTable(
                name: "configuracaoGeral",
                columns: table => new
                {
                    confg_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    conf_descricao = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    confg_ativa = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    confg_valor = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__configur__96AC3BF468906048", x => x.confg_id);
                });

            migrationBuilder.CreateTable(
                name: "menus",
                columns: table => new
                {
                    men_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    men_header = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    men_footer = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    men_body = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    men_tipo = table.Column<int>(type: "int", nullable: false),
                    men_title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__menus__387DDE001B9A5F69", x => x.men_id);
                });

            migrationBuilder.CreateTable(
                name: "prompt",
                columns: table => new
                {
                    promp_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    promp_descricao = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    promp_ativa = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    promp_valor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__prompt__DC4E3490D2109AD1", x => x.promp_id);
                });

            migrationBuilder.CreateTable(
                name: "chat",
                columns: table => new
                {
                    cha_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cha_estado = table.Column<int>(type: "int", nullable: false),
                    adv_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__chat__5AF8FDEA4C906010", x => x.cha_id);
                    table.ForeignKey(
                        name: "FK__chat__adv_id__440B1D61",
                        column: x => x.adv_id,
                        principalTable: "advogado",
                        principalColumn: "adv_id");
                });

            migrationBuilder.CreateTable(
                name: "peticao",
                columns: table => new
                {
                    pet_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pProc_caminho = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    pProc_descricao = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    pProc_dataCriacao = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    pet_tipo = table.Column<int>(type: "int", nullable: false),
                    adv_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__peticao__390CC5FE5CAD68A5", x => x.pet_id);
                    table.ForeignKey(
                        name: "FK__peticao__adv_id__412EB0B6",
                        column: x => x.adv_id,
                        principalTable: "advogado",
                        principalColumn: "adv_id");
                });

            migrationBuilder.CreateTable(
                name: "preProcesso",
                columns: table => new
                {
                    pProc_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pProc_nome = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    pProc_descricao = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    pProc_dataCriacao = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    pProc_estado = table.Column<int>(type: "int", nullable: true),
                    adv_id = table.Column<int>(type: "int", nullable: false),
                    cli_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__preProce__51C4924FD8446F3A", x => x.pProc_id);
                    table.ForeignKey(
                        name: "FK__preProces__adv_i__3C69FB99",
                        column: x => x.adv_id,
                        principalTable: "advogado",
                        principalColumn: "adv_id");
                    table.ForeignKey(
                        name: "FK__preProces__cli_i__3D5E1FD2",
                        column: x => x.cli_id,
                        principalTable: "cliente",
                        principalColumn: "cli_id");
                });

            migrationBuilder.CreateTable(
                name: "options",
                columns: table => new
                {
                    opt_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    opt_data = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    opt_descricao = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    opt_finalizar = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    opt_resposta = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    opt_tipo = table.Column<int>(type: "int", nullable: false),
                    opt_title = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: true),
                    men_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__options__84DB9F9B3BF3AA01", x => x.opt_id);
                    table.ForeignKey(
                        name: "FK__options__men_id__5070F446",
                        column: x => x.men_id,
                        principalTable: "menus",
                        principalColumn: "men_id");
                });

            migrationBuilder.CreateTable(
                name: "insumo",
                columns: table => new
                {
                    ins_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ins_data = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ins_caminho = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ins_descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ins_tipo = table.Column<int>(type: "int", nullable: false),
                    adv_id = table.Column<int>(type: "int", nullable: false),
                    pProc_id = table.Column<int>(type: "int", nullable: false),
                    cha_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__insumo__9CB72D205B7BA2C0", x => x.ins_id);
                    table.ForeignKey(
                        name: "FK__insumo__adv_id__47DBAE45",
                        column: x => x.adv_id,
                        principalTable: "advogado",
                        principalColumn: "adv_id");
                    table.ForeignKey(
                        name: "FK__insumo__cha_id__49C3F6B7",
                        column: x => x.cha_id,
                        principalTable: "chat",
                        principalColumn: "cha_id");
                    table.ForeignKey(
                        name: "FK__insumo__pProc_id__48CFD27E",
                        column: x => x.pProc_id,
                        principalTable: "preProcesso",
                        principalColumn: "pProc_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_chat_adv_id",
                table: "chat",
                column: "adv_id");

            migrationBuilder.CreateIndex(
                name: "IX_insumo_adv_id",
                table: "insumo",
                column: "adv_id");

            migrationBuilder.CreateIndex(
                name: "IX_insumo_cha_id",
                table: "insumo",
                column: "cha_id");

            migrationBuilder.CreateIndex(
                name: "IX_insumo_pProc_id",
                table: "insumo",
                column: "pProc_id");

            migrationBuilder.CreateIndex(
                name: "IX_options_men_id",
                table: "options",
                column: "men_id");

            migrationBuilder.CreateIndex(
                name: "IX_peticao_adv_id",
                table: "peticao",
                column: "adv_id");

            migrationBuilder.CreateIndex(
                name: "IX_preProcesso_adv_id",
                table: "preProcesso",
                column: "adv_id");

            migrationBuilder.CreateIndex(
                name: "IX_preProcesso_cli_id",
                table: "preProcesso",
                column: "cli_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "configuracaoGeral");

            migrationBuilder.DropTable(
                name: "insumo");

            migrationBuilder.DropTable(
                name: "options");

            migrationBuilder.DropTable(
                name: "peticao");

            migrationBuilder.DropTable(
                name: "prompt");

            migrationBuilder.DropTable(
                name: "chat");

            migrationBuilder.DropTable(
                name: "preProcesso");

            migrationBuilder.DropTable(
                name: "menus");

            migrationBuilder.DropTable(
                name: "advogado");

            migrationBuilder.DropTable(
                name: "cliente");
        }
    }
}
