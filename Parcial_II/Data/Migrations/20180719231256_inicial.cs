using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Parcial_II.Data.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.CreateTable(
                name: "Categoria_Laboral",
                columns: table => new
                {
                    Categoria_LaboralId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria_Laboral", x => x.Categoria_LaboralId);
                });

            migrationBuilder.CreateTable(
                name: "Ciudad",
                columns: table => new
                {
                    CiudadId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ciudad", x => x.CiudadId);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    ClienteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Cedula = table.Column<int>(maxLength: 10, nullable: false),
                    Correo = table.Column<string>(nullable: false),
                    Fecha_registro = table.Column<DateTime>(nullable: false),
                    Importe_maximo = table.Column<int>(nullable: false),
                    Primerapellido = table.Column<string>(nullable: false),
                    Primernombre = table.Column<string>(nullable: false),
                    Segundoapellido = table.Column<string>(nullable: false),
                    Segundonombre = table.Column<string>(nullable: false),
                    Telefono = table.Column<int>(nullable: false),
                    Tipo_prefe_inmueble = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "Propietario",
                columns: table => new
                {
                    PropietarioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Apellido1 = table.Column<string>(maxLength: 220, nullable: false),
                    Apellido2 = table.Column<string>(maxLength: 220, nullable: false),
                    Correo = table.Column<string>(maxLength: 220, nullable: false),
                    Direccion = table.Column<string>(maxLength: 220, nullable: false),
                    Nombre1 = table.Column<string>(maxLength: 220, nullable: false),
                    Nombre2 = table.Column<string>(maxLength: 220, nullable: false),
                    Telefono = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Propietario", x => x.PropietarioId);
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    RolId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.RolId);
                });

            migrationBuilder.CreateTable(
                name: "Tipopago",
                columns: table => new
                {
                    TipopagoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre_tipopago = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipopago", x => x.TipopagoId);
                });

            migrationBuilder.CreateTable(
                name: "Tipos_inmu",
                columns: table => new
                {
                    Tipos_inmuId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(maxLength: 220, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipos_inmu", x => x.Tipos_inmuId);
                });

            migrationBuilder.CreateTable(
                name: "Parroquia",
                columns: table => new
                {
                    ParroquiaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CiudadId = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parroquia", x => x.ParroquiaId);
                    table.ForeignKey(
                        name: "FK_Parroquia_Ciudad_CiudadId",
                        column: x => x.CiudadId,
                        principalTable: "Ciudad",
                        principalColumn: "CiudadId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Clave = table.Column<string>(nullable: false),
                    RolId = table.Column<int>(nullable: false),
                    Usuarios = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.UsuarioId);
                    table.ForeignKey(
                        name: "FK_Usuario_Rol_RolId",
                        column: x => x.RolId,
                        principalTable: "Rol",
                        principalColumn: "RolId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inmuebles",
                columns: table => new
                {
                    InmueblesId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Costo = table.Column<int>(nullable: false),
                    N_habitaciones = table.Column<string>(nullable: false),
                    ParroquiaId = table.Column<int>(nullable: false),
                    PropietarioId = table.Column<int>(nullable: false),
                    Tipos_inmuid = table.Column<int>(nullable: false),
                    activo = table.Column<bool>(nullable: false),
                    direccion = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inmuebles", x => x.InmueblesId);
                    table.ForeignKey(
                        name: "FK_Inmuebles_Parroquia_ParroquiaId",
                        column: x => x.ParroquiaId,
                        principalTable: "Parroquia",
                        principalColumn: "ParroquiaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inmuebles_Propietario_PropietarioId",
                        column: x => x.PropietarioId,
                        principalTable: "Propietario",
                        principalColumn: "PropietarioId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inmuebles_Tipos_inmu_Tipos_inmuid",
                        column: x => x.Tipos_inmuid,
                        principalTable: "Tipos_inmu",
                        principalColumn: "Tipos_inmuId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sucursal",
                columns: table => new
                {
                    SucursalId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Direccion = table.Column<string>(nullable: false),
                    ParroquiaId = table.Column<int>(nullable: false),
                    Telefono = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sucursal", x => x.SucursalId);
                    table.ForeignKey(
                        name: "FK_Sucursal_Parroquia_ParroquiaId",
                        column: x => x.ParroquiaId,
                        principalTable: "Parroquia",
                        principalColumn: "ParroquiaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Empleado",
                columns: table => new
                {
                    EmpleadoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoriaLaboralId = table.Column<int>(nullable: false),
                    Categoria_LaboralId = table.Column<int>(nullable: true),
                    Correo = table.Column<string>(nullable: false),
                    Direccion = table.Column<string>(nullable: false),
                    Edad = table.Column<int>(nullable: false),
                    Fecha_nacimiento = table.Column<DateTime>(nullable: false),
                    PrimerApellido = table.Column<string>(nullable: false),
                    PrimerNombre = table.Column<string>(nullable: false),
                    Salario = table.Column<string>(nullable: false),
                    SegundoApellido = table.Column<string>(nullable: false),
                    SegundoNombre = table.Column<string>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleado", x => x.EmpleadoId);
                    table.ForeignKey(
                        name: "FK_Empleado_Categoria_Laboral_Categoria_LaboralId",
                        column: x => x.Categoria_LaboralId,
                        principalTable: "Categoria_Laboral",
                        principalColumn: "Categoria_LaboralId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Empleado_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contrato",
                columns: table => new
                {
                    ContratoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClienteId = table.Column<int>(nullable: false),
                    Duracion = table.Column<string>(maxLength: 220, nullable: false),
                    SucursalId = table.Column<int>(nullable: false),
                    TipopagoId = table.Column<int>(nullable: true),
                    TipopagosId = table.Column<int>(nullable: false),
                    deposito = table.Column<int>(nullable: false),
                    fecha_ini = table.Column<DateTime>(nullable: false),
                    fecha_vence = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contrato", x => x.ContratoId);
                    table.ForeignKey(
                        name: "FK_Contrato_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contrato_Sucursal_SucursalId",
                        column: x => x.SucursalId,
                        principalTable: "Sucursal",
                        principalColumn: "SucursalId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contrato_Tipopago_TipopagoId",
                        column: x => x.TipopagoId,
                        principalTable: "Tipopago",
                        principalColumn: "TipopagoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sucur_emple",
                columns: table => new
                {
                    Sucur_empleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmpleadoId = table.Column<int>(nullable: false),
                    SucursalId = table.Column<int>(nullable: true),
                    SucursualesId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sucur_emple", x => x.Sucur_empleId);
                    table.ForeignKey(
                        name: "FK_Sucur_emple_Empleado_EmpleadoId",
                        column: x => x.EmpleadoId,
                        principalTable: "Empleado",
                        principalColumn: "EmpleadoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sucur_emple_Sucursal_SucursalId",
                        column: x => x.SucursalId,
                        principalTable: "Sucursal",
                        principalColumn: "SucursalId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Contrato_ClienteId",
                table: "Contrato",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Contrato_SucursalId",
                table: "Contrato",
                column: "SucursalId");

            migrationBuilder.CreateIndex(
                name: "IX_Contrato_TipopagoId",
                table: "Contrato",
                column: "TipopagoId");

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_Categoria_LaboralId",
                table: "Empleado",
                column: "Categoria_LaboralId");

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_UsuarioId",
                table: "Empleado",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Inmuebles_ParroquiaId",
                table: "Inmuebles",
                column: "ParroquiaId");

            migrationBuilder.CreateIndex(
                name: "IX_Inmuebles_PropietarioId",
                table: "Inmuebles",
                column: "PropietarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Inmuebles_Tipos_inmuid",
                table: "Inmuebles",
                column: "Tipos_inmuid");

            migrationBuilder.CreateIndex(
                name: "IX_Parroquia_CiudadId",
                table: "Parroquia",
                column: "CiudadId");

            migrationBuilder.CreateIndex(
                name: "IX_Sucur_emple_EmpleadoId",
                table: "Sucur_emple",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Sucur_emple_SucursalId",
                table: "Sucur_emple",
                column: "SucursalId");

            migrationBuilder.CreateIndex(
                name: "IX_Sucursal_ParroquiaId",
                table: "Sucursal",
                column: "ParroquiaId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_RolId",
                table: "Usuario",
                column: "RolId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Contrato");

            migrationBuilder.DropTable(
                name: "Inmuebles");

            migrationBuilder.DropTable(
                name: "Sucur_emple");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Tipopago");

            migrationBuilder.DropTable(
                name: "Propietario");

            migrationBuilder.DropTable(
                name: "Tipos_inmu");

            migrationBuilder.DropTable(
                name: "Empleado");

            migrationBuilder.DropTable(
                name: "Sucursal");

            migrationBuilder.DropTable(
                name: "Categoria_Laboral");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Parroquia");

            migrationBuilder.DropTable(
                name: "Rol");

            migrationBuilder.DropTable(
                name: "Ciudad");

            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName");
        }
    }
}
