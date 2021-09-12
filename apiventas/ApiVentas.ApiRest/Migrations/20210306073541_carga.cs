using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiVentas.ApiRest.Migrations
{
    public partial class carga : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "DBO");

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    IdCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCliente = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.IdCliente);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                schema: "DBO",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(150)", nullable: true),
                    Precio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    IdPedido = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaPedido = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdCliente = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.IdPedido);
                    table.ForeignKey(
                        name: "FK_Pedido_Cliente_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Cliente",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductImage",
                schema: "DBO",
                columns: table => new
                {
                    IdArticuloImagen = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdArticulo = table.Column<int>(type: "int", nullable: false),
                    NombreArchivo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NombreGenerado = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImage", x => x.IdArticuloImagen);
                    table.ForeignKey(
                        name: "FK_ProductImage_Product_IdArticulo",
                        column: x => x.IdArticulo,
                        principalSchema: "DBO",
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "DBO",
                table: "Product",
                columns: new[] { "ProductId", "Nombre", "Precio" },
                values: new object[,]
                {
                    { 1, "Articulo 1", 101 },
                    { 73, "Articulo 73", 173 },
                    { 72, "Articulo 72", 172 },
                    { 71, "Articulo 71", 171 },
                    { 70, "Articulo 70", 170 },
                    { 69, "Articulo 69", 169 },
                    { 68, "Articulo 68", 168 },
                    { 67, "Articulo 67", 167 },
                    { 66, "Articulo 66", 166 },
                    { 65, "Articulo 65", 165 },
                    { 64, "Articulo 64", 164 },
                    { 63, "Articulo 63", 163 },
                    { 62, "Articulo 62", 162 },
                    { 61, "Articulo 61", 161 },
                    { 60, "Articulo 60", 160 },
                    { 59, "Articulo 59", 159 },
                    { 58, "Articulo 58", 158 },
                    { 57, "Articulo 57", 157 },
                    { 56, "Articulo 56", 156 },
                    { 55, "Articulo 55", 155 },
                    { 54, "Articulo 54", 154 },
                    { 53, "Articulo 53", 153 },
                    { 74, "Articulo 74", 174 },
                    { 52, "Articulo 52", 152 },
                    { 75, "Articulo 75", 175 },
                    { 77, "Articulo 77", 177 },
                    { 98, "Articulo 98", 198 },
                    { 97, "Articulo 97", 197 },
                    { 96, "Articulo 96", 196 },
                    { 95, "Articulo 95", 195 },
                    { 94, "Articulo 94", 194 },
                    { 93, "Articulo 93", 193 },
                    { 92, "Articulo 92", 192 },
                    { 91, "Articulo 91", 191 },
                    { 90, "Articulo 90", 190 },
                    { 89, "Articulo 89", 189 },
                    { 88, "Articulo 88", 188 },
                    { 87, "Articulo 87", 187 },
                    { 86, "Articulo 86", 186 },
                    { 85, "Articulo 85", 185 },
                    { 84, "Articulo 84", 184 },
                    { 83, "Articulo 83", 183 }
                });

            migrationBuilder.InsertData(
                schema: "DBO",
                table: "Product",
                columns: new[] { "ProductId", "Nombre", "Precio" },
                values: new object[,]
                {
                    { 82, "Articulo 82", 182 },
                    { 81, "Articulo 81", 181 },
                    { 80, "Articulo 80", 180 },
                    { 79, "Articulo 79", 179 },
                    { 78, "Articulo 78", 178 },
                    { 76, "Articulo 76", 176 },
                    { 51, "Articulo 51", 151 },
                    { 50, "Articulo 50", 150 },
                    { 49, "Articulo 49", 149 },
                    { 22, "Articulo 22", 122 },
                    { 21, "Articulo 21", 121 },
                    { 20, "Articulo 20", 120 },
                    { 19, "Articulo 19", 119 },
                    { 18, "Articulo 18", 118 },
                    { 17, "Articulo 17", 117 },
                    { 16, "Articulo 16", 116 },
                    { 15, "Articulo 15", 115 },
                    { 14, "Articulo 14", 114 },
                    { 13, "Articulo 13", 113 },
                    { 12, "Articulo 12", 112 },
                    { 11, "Articulo 11", 111 },
                    { 10, "Articulo 10", 110 },
                    { 9, "Articulo 9", 109 },
                    { 8, "Articulo 8", 108 },
                    { 7, "Articulo 7", 107 },
                    { 6, "Articulo 6", 106 },
                    { 5, "Articulo 5", 105 },
                    { 4, "Articulo 4", 104 },
                    { 3, "Articulo 3", 103 },
                    { 2, "Articulo 2", 102 },
                    { 23, "Articulo 23", 123 },
                    { 24, "Articulo 24", 124 },
                    { 25, "Articulo 25", 125 },
                    { 26, "Articulo 26", 126 },
                    { 48, "Articulo 48", 148 },
                    { 47, "Articulo 47", 147 },
                    { 46, "Articulo 46", 146 },
                    { 45, "Articulo 45", 145 },
                    { 44, "Articulo 44", 144 },
                    { 43, "Articulo 43", 143 },
                    { 42, "Articulo 42", 142 },
                    { 41, "Articulo 41", 141 }
                });

            migrationBuilder.InsertData(
                schema: "DBO",
                table: "Product",
                columns: new[] { "ProductId", "Nombre", "Precio" },
                values: new object[,]
                {
                    { 40, "Articulo 40", 140 },
                    { 39, "Articulo 39", 139 },
                    { 99, "Articulo 99", 199 },
                    { 38, "Articulo 38", 138 },
                    { 36, "Articulo 36", 136 },
                    { 35, "Articulo 35", 135 },
                    { 34, "Articulo 34", 134 },
                    { 33, "Articulo 33", 133 },
                    { 32, "Articulo 32", 132 },
                    { 31, "Articulo 31", 131 },
                    { 30, "Articulo 30", 130 },
                    { 29, "Articulo 29", 129 },
                    { 28, "Articulo 28", 128 },
                    { 27, "Articulo 27", 127 },
                    { 37, "Articulo 37", 137 },
                    { 100, "Articulo 100", 200 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_IdCliente",
                table: "Pedido",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImage_IdArticulo",
                schema: "DBO",
                table: "ProductImage",
                column: "IdArticulo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pedido");

            migrationBuilder.DropTable(
                name: "ProductImage",
                schema: "DBO");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Product",
                schema: "DBO");
        }
    }
}
