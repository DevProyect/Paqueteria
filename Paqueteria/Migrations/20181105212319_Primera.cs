﻿using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Paqueteria.Migrations
{
    public partial class Primera : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dependencia",
                columns: table => new
                {
                    DependenciaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NombreDpd = table.Column<string>(nullable: false),
                    DescripcionDpd = table.Column<string>(maxLength: 100, nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    FinaltDate = table.Column<DateTime>(nullable: false),
                    EstatusID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dependencia", x => x.DependenciaID);
                });

            migrationBuilder.CreateTable(
                name: "Estatus",
                columns: table => new
                {
                    EstatusID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NombreSts = table.Column<string>(nullable: true),
                    DescripcionSts = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estatus", x => x.EstatusID);
                });

            migrationBuilder.CreateTable(
                name: "Paquete",
                columns: table => new
                {
                    PaqueteID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NombrePck = table.Column<string>(maxLength: 50, nullable: false),
                    DescripcionPck = table.Column<string>(maxLength: 100, nullable: true),
                    DetallePck = table.Column<string>(maxLength: 100, nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    FinalDate = table.Column<DateTime>(nullable: false),
                    EstatusID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paquete", x => x.PaqueteID);
                });

            migrationBuilder.CreateTable(
                name: "Aplicacion",
                columns: table => new
                {
                    AplicacionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NombreApp = table.Column<string>(maxLength: 50, nullable: false),
                    DescripcionApp = table.Column<string>(maxLength: 100, nullable: true),
                    DetalleApp = table.Column<string>(maxLength: 100, nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    FinalDate = table.Column<DateTime>(nullable: false),
                    EstatusID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aplicacion", x => x.AplicacionID);
                    table.ForeignKey(
                        name: "FK_Aplicacion_Estatus_EstatusID",
                        column: x => x.EstatusID,
                        principalTable: "Estatus",
                        principalColumn: "EstatusID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Incidecia",
                columns: table => new
                {
                    IncidenciaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NombreIc = table.Column<string>(maxLength: 50, nullable: false),
                    DescripcionIc = table.Column<string>(nullable: false),
                    PaqueteID = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    FinaltDate = table.Column<DateTime>(nullable: false),
                    EstatusID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incidecia", x => x.IncidenciaID);
                    table.ForeignKey(
                        name: "FK_Incidecia_Paquete_PaqueteID",
                        column: x => x.PaqueteID,
                        principalTable: "Paquete",
                        principalColumn: "PaqueteID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Relacion",
                columns: table => new
                {
                    PaqueteID = table.Column<int>(nullable: false),
                    DependenciaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relacion", x => new { x.PaqueteID, x.DependenciaID });
                    table.ForeignKey(
                        name: "FK_Relacion_Dependencia_DependenciaID",
                        column: x => x.DependenciaID,
                        principalTable: "Dependencia",
                        principalColumn: "DependenciaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Relacion_Paquete_PaqueteID",
                        column: x => x.PaqueteID,
                        principalTable: "Paquete",
                        principalColumn: "PaqueteID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AplicacionPaquete",
                columns: table => new
                {
                    PaqueteID = table.Column<int>(nullable: false),
                    AplicacionID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AplicacionPaquete", x => new { x.AplicacionID, x.PaqueteID });
                    table.ForeignKey(
                        name: "FK_AplicacionPaquete_Aplicacion_AplicacionID",
                        column: x => x.AplicacionID,
                        principalTable: "Aplicacion",
                        principalColumn: "AplicacionID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AplicacionPaquete_Paquete_PaqueteID",
                        column: x => x.PaqueteID,
                        principalTable: "Paquete",
                        principalColumn: "PaqueteID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aplicacion_EstatusID",
                table: "Aplicacion",
                column: "EstatusID");

            migrationBuilder.CreateIndex(
                name: "IX_AplicacionPaquete_PaqueteID",
                table: "AplicacionPaquete",
                column: "PaqueteID");

            migrationBuilder.CreateIndex(
                name: "IX_Incidecia_PaqueteID",
                table: "Incidecia",
                column: "PaqueteID");

            migrationBuilder.CreateIndex(
                name: "IX_Relacion_DependenciaID",
                table: "Relacion",
                column: "DependenciaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AplicacionPaquete");

            migrationBuilder.DropTable(
                name: "Incidecia");

            migrationBuilder.DropTable(
                name: "Relacion");

            migrationBuilder.DropTable(
                name: "Aplicacion");

            migrationBuilder.DropTable(
                name: "Dependencia");

            migrationBuilder.DropTable(
                name: "Paquete");

            migrationBuilder.DropTable(
                name: "Estatus");
        }
    }
}
