using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CHUCVU",
                columns: table => new
                {
                    IDCV = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TENCHUCVU = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CHUCVU", x => x.IDCV);
                });

            migrationBuilder.CreateTable(
                name: "LOAICA",
                columns: table => new
                {
                    IDLOAICA = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TENLOAICA = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    HESO = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOAICA", x => x.IDLOAICA);
                });

            migrationBuilder.CreateTable(
                name: "LOAICONG",
                columns: table => new
                {
                    IDLOAICONG = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TENLOAICONG = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    HESO = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOAICONG", x => x.IDLOAICONG);
                });

            migrationBuilder.CreateTable(
                name: "PHONGBAN",
                columns: table => new
                {
                    IDPB = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TENPB = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PHONGBAN", x => x.IDPB);
                });

            migrationBuilder.CreateTable(
                name: "PHUCAP",
                columns: table => new
                {
                    IDPC = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TENPC = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SOTIEN = table.Column<double>(type: "float", nullable: true),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PHUCAP", x => x.IDPC);
                });

            migrationBuilder.CreateTable(
                name: "NHANVIEN",
                columns: table => new
                {
                    MANV = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HOTEN = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GIOITINH = table.Column<bool>(type: "bit", nullable: true),
                    NGAYSINH = table.Column<DateTime>(type: "datetime", nullable: true),
                    SDT = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CCCD = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DIACHI = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    HINHANH = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    IDPB = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IDBP = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IDCV = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NHANVIEN", x => x.MANV);
                    table.ForeignKey(
                        name: "FK_NHANVIEN_CHUCVU",
                        column: x => x.IDCV,
                        principalTable: "CHUCVU",
                        principalColumn: "IDCV");
                    table.ForeignKey(
                        name: "FK_NHANVIEN_PHONGBAN1",
                        column: x => x.IDPB,
                        principalTable: "PHONGBAN",
                        principalColumn: "IDPB");
                });

            migrationBuilder.CreateTable(
                name: "BANGCONG",
                columns: table => new
                {
                    IDBC = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NAM = table.Column<int>(type: "int", nullable: true),
                    THANG = table.Column<int>(type: "int", nullable: true),
                    NGAY = table.Column<int>(type: "int", nullable: true),
                    GIOVAO = table.Column<int>(type: "int", nullable: true),
                    GIORA = table.Column<int>(type: "int", nullable: true),
                    PHUTRA = table.Column<int>(type: "int", nullable: true),
                    MANV = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    lDLOAICONG = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BANGCONG", x => x.IDBC);
                    table.ForeignKey(
                        name: "FK_BANGCONG_LOAICONG",
                        column: x => x.lDLOAICONG,
                        principalTable: "LOAICONG",
                        principalColumn: "IDLOAICONG");
                    table.ForeignKey(
                        name: "FK_BANGCONG_NHANVIEN",
                        column: x => x.MANV,
                        principalTable: "NHANVIEN",
                        principalColumn: "MANV");
                });

            migrationBuilder.CreateTable(
                name: "BANGLUONG",
                columns: table => new
                {
                    IDBANGLUONG = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MANV = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    HOTEN = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LUONGCOBAN = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BANGLUONG", x => x.IDBANGLUONG);
                    table.ForeignKey(
                        name: "FK_BANGLUONG_NHANVIEN",
                        column: x => x.MANV,
                        principalTable: "NHANVIEN",
                        principalColumn: "MANV");
                });

            migrationBuilder.CreateTable(
                name: "BAOHIEM",
                columns: table => new
                {
                    IDBH = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SOBH = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NGAYCAP = table.Column<DateTime>(type: "datetime", nullable: true),
                    NOICAP = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    NOIDKIKHAMBENH = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MANV = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BAOHIEM", x => x.IDBH);
                    table.ForeignKey(
                        name: "FK_BAOHIEM_NHANVIEN",
                        column: x => x.MANV,
                        principalTable: "NHANVIEN",
                        principalColumn: "MANV");
                });

            migrationBuilder.CreateTable(
                name: "HOPDONG",
                columns: table => new
                {
                    SOHD = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NGAYBATDAU = table.Column<DateTime>(type: "datetime", nullable: true),
                    NGAYKETTHUC = table.Column<DateTime>(type: "datetime", nullable: true),
                    NGAYKY = table.Column<DateTime>(type: "datetime", nullable: true),
                    NOIDUNG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LANKY = table.Column<int>(type: "int", nullable: true),
                    THOIHAN = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    HESOLUONG = table.Column<double>(type: "float", nullable: true),
                    MANV = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HOPDONG", x => x.SOHD);
                    table.ForeignKey(
                        name: "FK_HOPDONG_NHANVIEN",
                        column: x => x.MANV,
                        principalTable: "NHANVIEN",
                        principalColumn: "MANV");
                });

            migrationBuilder.CreateTable(
                name: "KHENTHUONGKYLUAT",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SOKTLT = table.Column<int>(type: "int", nullable: true),
                    NOIDUNG = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NGAY = table.Column<DateTime>(type: "datetime", nullable: true),
                    MANV = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LOAI = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KHENTHUONGKYLUAT", x => x.ID);
                    table.ForeignKey(
                        name: "FK_KHENTHUONGKYLUAT_NHANVIEN",
                        column: x => x.MANV,
                        principalTable: "NHANVIEN",
                        principalColumn: "MANV");
                });

            migrationBuilder.CreateTable(
                name: "NHANVIENPHUCAP",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", fixedLength: true, maxLength: 10, nullable: false),
                    MANV = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IDPC = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NGAY = table.Column<DateTime>(type: "datetime", nullable: true),
                    NOIDUNG = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SOTIEN = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NHANVIENPHUCAP", x => x.ID);
                    table.ForeignKey(
                        name: "FK_NHANVIENPHUCAP_NHANVIEN",
                        column: x => x.MANV,
                        principalTable: "NHANVIEN",
                        principalColumn: "MANV");
                    table.ForeignKey(
                        name: "FK_NHANVIENPHUCAP_PHUCAP",
                        column: x => x.IDPC,
                        principalTable: "PHUCAP",
                        principalColumn: "IDPC");
                });

            migrationBuilder.CreateTable(
                name: "TANGCA",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NAM = table.Column<int>(type: "int", nullable: true),
                    THANG = table.Column<int>(type: "int", nullable: true),
                    NGAY = table.Column<int>(type: "int", nullable: true),
                    SOGIO = table.Column<double>(type: "float", nullable: true),
                    MANV = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IDLOAICA = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TANGCA", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TANGCA_LOAICA",
                        column: x => x.IDLOAICA,
                        principalTable: "LOAICA",
                        principalColumn: "IDLOAICA");
                    table.ForeignKey(
                        name: "FK_TANGCA_NHANVIEN",
                        column: x => x.MANV,
                        principalTable: "NHANVIEN",
                        principalColumn: "MANV");
                });

            migrationBuilder.CreateTable(
                name: "UNGLUONG",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NAM = table.Column<int>(type: "int", nullable: true),
                    THANG = table.Column<int>(type: "int", nullable: true),
                    NGAY = table.Column<int>(type: "int", nullable: true),
                    SOTIEN = table.Column<double>(type: "float", nullable: true),
                    TRANGTHAI = table.Column<int>(type: "int", nullable: true),
                    MANV = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UNGLUONG", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UNGLUONG_NHANVIEN",
                        column: x => x.MANV,
                        principalTable: "NHANVIEN",
                        principalColumn: "MANV");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BANGCONG_lDLOAICONG",
                table: "BANGCONG",
                column: "lDLOAICONG");

            migrationBuilder.CreateIndex(
                name: "IX_BANGCONG_MANV",
                table: "BANGCONG",
                column: "MANV");

            migrationBuilder.CreateIndex(
                name: "IX_BANGLUONG_MANV",
                table: "BANGLUONG",
                column: "MANV");

            migrationBuilder.CreateIndex(
                name: "IX_BAOHIEM_MANV",
                table: "BAOHIEM",
                column: "MANV");

            migrationBuilder.CreateIndex(
                name: "IX_HOPDONG_MANV",
                table: "HOPDONG",
                column: "MANV");

            migrationBuilder.CreateIndex(
                name: "IX_KHENTHUONGKYLUAT_MANV",
                table: "KHENTHUONGKYLUAT",
                column: "MANV");

            migrationBuilder.CreateIndex(
                name: "IX_NHANVIEN_IDCV",
                table: "NHANVIEN",
                column: "IDCV");

            migrationBuilder.CreateIndex(
                name: "IX_NHANVIEN_IDPB",
                table: "NHANVIEN",
                column: "IDPB");

            migrationBuilder.CreateIndex(
                name: "IX_NHANVIENPHUCAP_IDPC",
                table: "NHANVIENPHUCAP",
                column: "IDPC");

            migrationBuilder.CreateIndex(
                name: "IX_NHANVIENPHUCAP_MANV",
                table: "NHANVIENPHUCAP",
                column: "MANV");

            migrationBuilder.CreateIndex(
                name: "IX_TANGCA_IDLOAICA",
                table: "TANGCA",
                column: "IDLOAICA");

            migrationBuilder.CreateIndex(
                name: "IX_TANGCA_MANV",
                table: "TANGCA",
                column: "MANV");

            migrationBuilder.CreateIndex(
                name: "IX_UNGLUONG_MANV",
                table: "UNGLUONG",
                column: "MANV");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BANGCONG");

            migrationBuilder.DropTable(
                name: "BANGLUONG");

            migrationBuilder.DropTable(
                name: "BAOHIEM");

            migrationBuilder.DropTable(
                name: "HOPDONG");

            migrationBuilder.DropTable(
                name: "KHENTHUONGKYLUAT");

            migrationBuilder.DropTable(
                name: "NHANVIENPHUCAP");

            migrationBuilder.DropTable(
                name: "TANGCA");

            migrationBuilder.DropTable(
                name: "UNGLUONG");

            migrationBuilder.DropTable(
                name: "LOAICONG");

            migrationBuilder.DropTable(
                name: "PHUCAP");

            migrationBuilder.DropTable(
                name: "LOAICA");

            migrationBuilder.DropTable(
                name: "NHANVIEN");

            migrationBuilder.DropTable(
                name: "CHUCVU");

            migrationBuilder.DropTable(
                name: "PHONGBAN");
        }
    }
}
