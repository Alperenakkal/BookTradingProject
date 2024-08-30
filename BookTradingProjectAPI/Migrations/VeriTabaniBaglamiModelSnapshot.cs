using System;
using BookTradingProjectAPI.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookTradingProjectAPI.Migrations
{
    [DbContext(typeof(VeriTabaniBaglami))]
    partial class VeriTabaniBaglamiModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BookTradingProjectAPI.Models.KitapModel.Kitap", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Durum")
                        .HasColumnType("int");

                    b.Property<DateTime>("GuncellemeTarihi")
                        .HasColumnType("datetime2");

                    b.Property<int>("Kategori")
                        .HasColumnType("int");

                    b.Property<string>("KitapAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KitapResimUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KullaniciId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("OlusturlmaTarihi")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Takas")
                        .HasColumnType("bit");

                    b.Property<string>("Yazar")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Kitaplar");
                });

            modelBuilder.Entity("BookTradingProjectAPI.Models.UserModels.Adres", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("GuncellemeTarihi")
                        .HasColumnType("datetime2");

                    b.Property<string>("KullaniciId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Mahalle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("OlusturlmaTarihi")
                        .HasColumnType("datetime2");

                    b.Property<string>("Şehir")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("KullaniciId");

                    b.ToTable("Adres");
                });

            modelBuilder.Entity("BookTradingProjectAPI.Models.UserModels.Kullanici", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AdSoyad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("AdreslerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Cinsiyet")
                        .HasColumnType("int");

                    b.Property<DateTime>("GuncellemeTarihi")
                        .HasColumnType("datetime2");

                    b.Property<string>("KullaniciAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("OlusturlmaTarihi")
                        .HasColumnType("datetime2");

                    b.Property<string>("Sifre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SifreTekrari")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TelefonNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AdreslerId");

                    b.ToTable("Kullanicilar");
                });

            modelBuilder.Entity("BookTradingProjectAPI.Models.UserModels.Adres", b =>
                {
                    b.HasOne("BookTradingProjectAPI.Models.UserModels.Kullanici", null)
                        .WithMany("Adresler")
                        .HasForeignKey("KullaniciId");
                });

            modelBuilder.Entity("BookTradingProjectAPI.Models.UserModels.Kullanici", b =>
                {
                    b.HasOne("BookTradingProjectAPI.Models.UserModels.Adres", "Adresler")
                        .WithMany()
                        .HasForeignKey("AdreslerId");

                    b.Navigation("Adresler");
                });
#pragma warning restore 612, 618
        }
    }
}
