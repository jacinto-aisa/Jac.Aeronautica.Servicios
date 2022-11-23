﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jac.Embarque.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateAzure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Embarques",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TripulantesId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aeronave = table.Column<int>(type: "int", nullable: false),
                    NumeroPasajeros = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Embarques", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Embarques");
        }
    }
}
