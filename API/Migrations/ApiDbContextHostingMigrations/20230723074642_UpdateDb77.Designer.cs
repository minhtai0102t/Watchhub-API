﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Ecom_API.DBHelpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Ecom_API.Migrations.ApiDbContextHostingMigrations
{
    [DbContext(typeof(ApiDbContextHosting))]
    [Migration("20230723074642_UpdateDb77")]
    partial class UpdateDb77
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.HasSequence("BrandSequence");

            modelBuilder.HasSequence("ProductAlbertSequence");

            modelBuilder.HasSequence("ProductCoreSequence");

            modelBuilder.HasSequence("ProductGlassSequence");

            modelBuilder.HasSequence("ProductTypeSequence");

            modelBuilder.HasSequence("SubCategorySequence");

            modelBuilder.Entity("Ecom_API.DTO.Entities.Brand", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValueSql("nextval('\"BrandSequence\"')");

                    NpgsqlPropertyBuilderExtensions.UseSequence(b.Property<int>("id"));

                    b.Property<string>("brand_logo")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<string>("brand_name")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<DateTime>("created_date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("created_user")
                        .HasColumnType("integer");

                    b.Property<bool>("is_deleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("updated_date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("updated_user")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.ToTable("brands");

                    b.UseTpcMappingStrategy();
                });

            modelBuilder.Entity("Ecom_API.DTO.Entities.Category", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("category_name")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<DateTime>("created_date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("created_user")
                        .HasColumnType("integer");

                    b.Property<bool>("is_deleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("updated_date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("updated_user")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.ToTable("categories");
                });

            modelBuilder.Entity("Ecom_API.DTO.Entities.Order", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("cancel_reason")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("created_date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("created_user")
                        .HasColumnType("integer");

                    b.Property<string>("district")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("isPaid")
                        .HasColumnType("boolean");

                    b.Property<bool>("is_deleted")
                        .HasColumnType("boolean");

                    b.Property<string>("order_info")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("order_status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("payment_method_id")
                        .HasColumnType("integer");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<List<string>>("product_image_uuid")
                        .HasColumnType("text[]");

                    b.Property<List<int>>("product_type_ids")
                        .IsRequired()
                        .HasColumnType("integer[]");

                    b.Property<string>("province")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("street")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("total_amount")
                        .HasColumnType("integer");

                    b.Property<DateTime>("updated_date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("updated_user")
                        .HasColumnType("integer");

                    b.Property<int>("user_id")
                        .HasColumnType("integer");

                    b.Property<string>("ward")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("orders");
                });

            modelBuilder.Entity("Ecom_API.DTO.Entities.Payment", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<DateTime>("created_date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("created_user")
                        .HasColumnType("integer");

                    b.Property<bool>("isPaid")
                        .HasColumnType("boolean");

                    b.Property<bool>("is_deleted")
                        .HasColumnType("boolean");

                    b.Property<int>("order_id")
                        .HasColumnType("integer");

                    b.Property<int>("payment_method_id")
                        .HasColumnType("integer");

                    b.Property<DateTime>("updated_date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("updated_user")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.ToTable("payments");
                });

            modelBuilder.Entity("Ecom_API.DTO.Entities.PaymentMethod", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<DateTime>("created_date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("created_user")
                        .HasColumnType("integer");

                    b.Property<bool>("is_deleted")
                        .HasColumnType("boolean");

                    b.Property<string>("payment_method_name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<DateTime>("updated_date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("updated_user")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.ToTable("payment_methods");
                });

            modelBuilder.Entity("Ecom_API.DTO.Entities.Product", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<DateTime>("created_date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("created_user")
                        .HasColumnType("integer");

                    b.Property<bool>("is_deleted")
                        .HasColumnType("boolean");

                    b.Property<bool>("is_on_sale")
                        .HasColumnType("boolean");

                    b.Property<string>("product_code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("product_type_id")
                        .HasColumnType("integer");

                    b.Property<DateTime>("updated_date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("updated_user")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.HasIndex("product_type_id");

                    b.ToTable("products");
                });

            modelBuilder.Entity("Ecom_API.DTO.Entities.ProductAlbert", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValueSql("nextval('\"ProductAlbertSequence\"')");

                    NpgsqlPropertyBuilderExtensions.UseSequence(b.Property<int>("id"));

                    b.Property<string>("albert_name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("created_date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("created_user")
                        .HasColumnType("integer");

                    b.Property<bool>("is_deleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("updated_date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("updated_user")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.ToTable("product_alberts");

                    b.UseTpcMappingStrategy();
                });

            modelBuilder.Entity("Ecom_API.DTO.Entities.ProductCore", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValueSql("nextval('\"ProductCoreSequence\"')");

                    NpgsqlPropertyBuilderExtensions.UseSequence(b.Property<int>("id"));

                    b.Property<string>("core_name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("created_date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("created_user")
                        .HasColumnType("integer");

                    b.Property<bool>("is_deleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("updated_date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("updated_user")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.ToTable("product_cores");

                    b.UseTpcMappingStrategy();
                });

            modelBuilder.Entity("Ecom_API.DTO.Entities.ProductFeedback", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<DateTime>("created_date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("created_user")
                        .HasColumnType("integer");

                    b.Property<List<string>>("feedback_images")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.Property<string>("feedback_message")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("is_deleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("updated_date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("updated_user")
                        .HasColumnType("integer");

                    b.Property<int>("user_id")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.ToTable("product_feedbacks");
                });

            modelBuilder.Entity("Ecom_API.DTO.Entities.ProductGlass", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValueSql("nextval('\"ProductGlassSequence\"')");

                    NpgsqlPropertyBuilderExtensions.UseSequence(b.Property<int>("id"));

                    b.Property<DateTime>("created_date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("created_user")
                        .HasColumnType("integer");

                    b.Property<string>("glass_name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("is_deleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("updated_date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("updated_user")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.ToTable("product_glasses");

                    b.UseTpcMappingStrategy();
                });

            modelBuilder.Entity("Ecom_API.DTO.Entities.ProductSubCategory", b =>
                {
                    b.Property<int>("product_type_id")
                        .HasColumnType("integer");

                    b.Property<int>("sub_category_id")
                        .HasColumnType("integer");

                    b.Property<DateTime>("created_date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("created_user")
                        .HasColumnType("integer");

                    b.Property<bool>("is_deleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("updated_date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("updated_user")
                        .HasColumnType("integer");

                    b.HasKey("product_type_id", "sub_category_id");

                    b.HasIndex("sub_category_id");

                    b.ToTable("products_sub_categories");
                });

            modelBuilder.Entity("Ecom_API.DTO.Entities.ProductType", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValueSql("nextval('\"ProductTypeSequence\"')");

                    NpgsqlPropertyBuilderExtensions.UseSequence(b.Property<int>("id"));

                    b.Property<int>("brand_id")
                        .HasColumnType("integer");

                    b.Property<DateTime>("created_date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("created_user")
                        .HasColumnType("integer");

                    b.Property<string>("gender")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("is_deleted")
                        .HasColumnType("boolean");

                    b.Property<int>("price")
                        .HasColumnType("integer");

                    b.Property<string>("product_additional_information")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("product_albert_id")
                        .HasColumnType("integer");

                    b.Property<int>("product_core_id")
                        .HasColumnType("integer");

                    b.Property<string>("product_dial_color")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("product_dial_height")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("product_dial_width")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("product_features")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<List<int>>("product_feedback_ids")
                        .HasColumnType("integer[]");

                    b.Property<int>("product_glass_id")
                        .HasColumnType("integer");

                    b.Property<string>("product_guarantee")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<List<string>>("product_image_uuid")
                        .HasColumnType("text[]");

                    b.Property<string>("product_source")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("product_type_code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("product_type_id")
                        .HasColumnType("integer");

                    b.Property<string>("product_type_name")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<string>("product_waterproof")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("quantity")
                        .HasColumnType("integer");

                    b.Property<int>("sold_quantity")
                        .HasColumnType("integer");

                    b.Property<DateTime>("updated_date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("updated_user")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.HasIndex("brand_id");

                    b.HasIndex("product_albert_id");

                    b.HasIndex("product_core_id");

                    b.HasIndex("product_glass_id");

                    b.ToTable("product_types");

                    b.UseTpcMappingStrategy();
                });

            modelBuilder.Entity("Ecom_API.DTO.Entities.SubCategory", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValueSql("nextval('\"SubCategorySequence\"')");

                    NpgsqlPropertyBuilderExtensions.UseSequence(b.Property<int>("id"));

                    b.Property<int>("category_id")
                        .HasColumnType("integer");

                    b.Property<DateTime>("created_date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("created_user")
                        .HasColumnType("integer");

                    b.Property<bool>("is_deleted")
                        .HasColumnType("boolean");

                    b.Property<string>("sub_category_name")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<DateTime>("updated_date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("updated_user")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.HasIndex("category_id");

                    b.ToTable("sub_categories");

                    b.UseTpcMappingStrategy();
                });

            modelBuilder.Entity("Ecom_API.DTO.Entities.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("addresses")
                        .HasColumnType("text");

                    b.Property<string>("avatar")
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<DateTime>("created_date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("created_user")
                        .HasColumnType("integer");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("fullname")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<bool>("is_admin")
                        .HasMaxLength(2000)
                        .HasColumnType("boolean");

                    b.Property<bool>("is_deleted")
                        .HasColumnType("boolean");

                    b.Property<bool>("is_verified")
                        .HasColumnType("boolean");

                    b.Property<List<int>>("order_ids")
                        .HasColumnType("integer[]");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.Property<string>("phone")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<DateTime>("updated_date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("updated_user")
                        .HasColumnType("integer");

                    b.Property<string>("username")
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.HasKey("id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("Ecom_API.DTO.Entities.VNPay", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("Amount")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("BankCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("BankTranNo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CardType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("OrderID")
                        .HasColumnType("integer");

                    b.Property<string>("OrderInfo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PayDate")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ResponseCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SecureHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("TmnCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("TransactionNo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("TransactionStatus")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("TxnRef")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UserID")
                        .HasColumnType("integer");

                    b.Property<DateTime>("created_date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("created_user")
                        .HasColumnType("integer");

                    b.Property<bool>("is_deleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("updated_date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("updated_user")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.ToTable("vnpay_payment");
                });

            modelBuilder.Entity("Ecom_API.DTO.Entities.Product", b =>
                {
                    b.HasOne("Ecom_API.DTO.Entities.ProductType", "productType")
                        .WithMany("products")
                        .HasForeignKey("product_type_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("productType");
                });

            modelBuilder.Entity("Ecom_API.DTO.Entities.ProductSubCategory", b =>
                {
                    b.HasOne("Ecom_API.DTO.Entities.ProductType", "productType")
                        .WithMany("productSubCategories")
                        .HasForeignKey("product_type_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ecom_API.DTO.Entities.SubCategory", "subCategory")
                        .WithMany("productSubCategories")
                        .HasForeignKey("sub_category_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("productType");

                    b.Navigation("subCategory");
                });

            modelBuilder.Entity("Ecom_API.DTO.Entities.ProductType", b =>
                {
                    b.HasOne("Ecom_API.DTO.Entities.Brand", "brand")
                        .WithMany("productTypes")
                        .HasForeignKey("brand_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ecom_API.DTO.Entities.ProductAlbert", "albert")
                        .WithMany("productTypes")
                        .HasForeignKey("product_albert_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ecom_API.DTO.Entities.ProductCore", "core")
                        .WithMany("productTypes")
                        .HasForeignKey("product_core_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ecom_API.DTO.Entities.ProductGlass", "glass")
                        .WithMany("productTypes")
                        .HasForeignKey("product_glass_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("albert");

                    b.Navigation("brand");

                    b.Navigation("core");

                    b.Navigation("glass");
                });

            modelBuilder.Entity("Ecom_API.DTO.Entities.SubCategory", b =>
                {
                    b.HasOne("Ecom_API.DTO.Entities.Category", "category")
                        .WithMany("subCategories")
                        .HasForeignKey("category_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("category");
                });

            modelBuilder.Entity("Ecom_API.DTO.Entities.Brand", b =>
                {
                    b.Navigation("productTypes");
                });

            modelBuilder.Entity("Ecom_API.DTO.Entities.Category", b =>
                {
                    b.Navigation("subCategories");
                });

            modelBuilder.Entity("Ecom_API.DTO.Entities.ProductAlbert", b =>
                {
                    b.Navigation("productTypes");
                });

            modelBuilder.Entity("Ecom_API.DTO.Entities.ProductCore", b =>
                {
                    b.Navigation("productTypes");
                });

            modelBuilder.Entity("Ecom_API.DTO.Entities.ProductGlass", b =>
                {
                    b.Navigation("productTypes");
                });

            modelBuilder.Entity("Ecom_API.DTO.Entities.ProductType", b =>
                {
                    b.Navigation("productSubCategories");

                    b.Navigation("products");
                });

            modelBuilder.Entity("Ecom_API.DTO.Entities.SubCategory", b =>
                {
                    b.Navigation("productSubCategories");
                });
#pragma warning restore 612, 618
        }
    }
}
