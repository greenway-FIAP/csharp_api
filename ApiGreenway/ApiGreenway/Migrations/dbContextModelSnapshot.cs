﻿// <auto-generated />
using System;
using ApiGreenway.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;

#nullable disable

namespace ApiGreenway.Migrations
{
    [DbContext(typeof(dbContext))]
    partial class dbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ApiGreenway.Models.Address", b =>
                {
                    b.Property<int>("id_address")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_address"));

                    b.Property<string>("ds_city")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("ds_neighborhood")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("ds_number")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("ds_street")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("ds_uf")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("NVARCHAR2(2)");

                    b.Property<string>("ds_zip_code")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("NVARCHAR2(8)");

                    b.Property<DateTimeOffset>("dt_created_at")
                        .HasColumnType("TIMESTAMP(7) WITH TIME ZONE");

                    b.Property<DateTimeOffset?>("dt_finished_at")
                        .HasColumnType("TIMESTAMP(7) WITH TIME ZONE");

                    b.Property<DateTimeOffset?>("dt_updated_at")
                        .HasColumnType("TIMESTAMP(7) WITH TIME ZONE");

                    b.Property<int?>("id_company")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("id_address");

                    b.ToTable("T_GRW_ADDRESS");
                });

            modelBuilder.Entity("ApiGreenway.Models.Badge", b =>
                {
                    b.Property<int>("id_badge")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_badge"));

                    b.Property<string>("ds_criteria")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("ds_name")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<DateTimeOffset>("dt_created_at")
                        .HasColumnType("TIMESTAMP(7) WITH TIME ZONE");

                    b.Property<DateTimeOffset?>("dt_finished_at")
                        .HasColumnType("TIMESTAMP(7) WITH TIME ZONE");

                    b.Property<DateTimeOffset?>("dt_updated_at")
                        .HasColumnType("TIMESTAMP(7) WITH TIME ZONE");

                    b.Property<int?>("id_badge_level")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int?>("id_sustainable_goal")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("st_badge")
                        .HasMaxLength(1)
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("tx_description")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("url_image")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("id_badge");

                    b.ToTable("T_GRW_BADGE");
                });

            modelBuilder.Entity("ApiGreenway.Models.BadgeLevel", b =>
                {
                    b.Property<int>("id_badge_level")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_badge_level"));

                    b.Property<string>("ds_name")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<DateTimeOffset>("dt_created_at")
                        .HasColumnType("TIMESTAMP(7) WITH TIME ZONE");

                    b.Property<DateTimeOffset?>("dt_finished_at")
                        .HasColumnType("TIMESTAMP(7) WITH TIME ZONE");

                    b.Property<DateTimeOffset?>("dt_updated_at")
                        .HasColumnType("TIMESTAMP(7) WITH TIME ZONE");

                    b.Property<string>("tx_description")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("id_badge_level");

                    b.ToTable("T_GRW_BADGE_LEVEL");
                });

            modelBuilder.Entity("ApiGreenway.Models.Company", b =>
                {
                    b.Property<int>("id_company")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_company"));

                    b.Property<string>("ds_name")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<DateTimeOffset>("dt_created_at")
                        .HasColumnType("TIMESTAMP(7) WITH TIME ZONE");

                    b.Property<DateTimeOffset?>("dt_finished_at")
                        .HasColumnType("TIMESTAMP(7) WITH TIME ZONE");

                    b.Property<DateTimeOffset?>("dt_updated_at")
                        .HasColumnType("TIMESTAMP(7) WITH TIME ZONE");

                    b.Property<int?>("id_address")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int?>("id_sector")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("nr_cnpj")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("NVARCHAR2(14)");

                    b.Property<int>("nr_size")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("tx_description")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<double>("vl_current_revenue")
                        .HasColumnType("BINARY_DOUBLE");

                    b.HasKey("id_company");

                    b.ToTable("T_GRW_COMPANY");
                });

            modelBuilder.Entity("ApiGreenway.Models.CompanyRepresentative", b =>
                {
                    b.Property<int>("id_company_representative")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_company_representative"));

                    b.Property<string>("ds_name")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("ds_role")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<DateTimeOffset>("dt_created_at")
                        .HasColumnType("TIMESTAMP(7) WITH TIME ZONE");

                    b.Property<DateTimeOffset?>("dt_finished_at")
                        .HasColumnType("TIMESTAMP(7) WITH TIME ZONE");

                    b.Property<DateTimeOffset?>("dt_updated_at")
                        .HasColumnType("TIMESTAMP(7) WITH TIME ZONE");

                    b.Property<int?>("id_company")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int?>("id_user")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("nr_phone")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("NVARCHAR2(11)");

                    b.HasKey("id_company_representative");

                    b.ToTable("T_GRW_COMPANY_REPRESENTATIVE");
                });

            modelBuilder.Entity("ApiGreenway.Models.ImprovementMeasurement", b =>
                {
                    b.Property<int>("id_improvement_measurement")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_improvement_measurement"));

                    b.Property<DateTimeOffset>("dt_created_at")
                        .HasColumnType("TIMESTAMP(7) WITH TIME ZONE");

                    b.Property<DateTimeOffset?>("dt_finished_at")
                        .HasColumnType("TIMESTAMP(7) WITH TIME ZONE");

                    b.Property<DateTimeOffset?>("dt_updated_at")
                        .HasColumnType("TIMESTAMP(7) WITH TIME ZONE");

                    b.Property<int?>("id_sustainable_improvement_actions")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("id_improvement_measurement");

                    b.ToTable("T_GRW_IMPROVEMENT_MEASUREMENT");
                });

            modelBuilder.Entity("ApiGreenway.Models.Measurement", b =>
                {
                    b.Property<int>("id_measurement")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_measurement"));

                    b.Property<string>("ds_name")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<DateTimeOffset>("dt_created_at")
                        .HasColumnType("TIMESTAMP(7) WITH TIME ZONE");

                    b.Property<DateTimeOffset?>("dt_finished_at")
                        .HasColumnType("TIMESTAMP(7) WITH TIME ZONE");

                    b.Property<DateTimeOffset?>("dt_updated_at")
                        .HasColumnType("TIMESTAMP(7) WITH TIME ZONE");

                    b.Property<int?>("id_improvement_measurement")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int?>("id_measurement_type")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int?>("id_sustainable_goal")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("tx_description")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("id_measurement");

                    b.ToTable("T_GRW_MEASUREMENT");
                });

            modelBuilder.Entity("ApiGreenway.Models.MeasurementProcessStep", b =>
                {
                    b.Property<int>("id_measurement_process_step")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_measurement_process_step"));

                    b.Property<DateTimeOffset>("dt_created_at")
                        .HasColumnType("TIMESTAMP(7) WITH TIME ZONE");

                    b.Property<DateTimeOffset?>("dt_finished_at")
                        .HasColumnType("TIMESTAMP(7) WITH TIME ZONE");

                    b.Property<DateTimeOffset?>("dt_updated_at")
                        .HasColumnType("TIMESTAMP(7) WITH TIME ZONE");

                    b.Property<int?>("id_measurement")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int?>("id_process_step")
                        .HasColumnType("NUMBER(10)");

                    b.Property<double>("nr_result")
                        .HasColumnType("BINARY_DOUBLE");

                    b.HasKey("id_measurement_process_step");

                    b.ToTable("T_GRW_MEASUREMENT_PROCESS_STEP");
                });

            modelBuilder.Entity("ApiGreenway.Models.MeasurementType", b =>
                {
                    b.Property<int>("id_measurement_type")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_measurement_type"));

                    b.Property<int>("ds_name")
                        .HasColumnType("NUMBER(10)");

                    b.Property<DateTimeOffset>("dt_created_at")
                        .HasColumnType("TIMESTAMP(7) WITH TIME ZONE");

                    b.Property<DateTimeOffset?>("dt_finished_at")
                        .HasColumnType("TIMESTAMP(7) WITH TIME ZONE");

                    b.Property<DateTimeOffset?>("dt_updated_at")
                        .HasColumnType("TIMESTAMP(7) WITH TIME ZONE");

                    b.Property<string>("tx_description")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("id_measurement_type");

                    b.ToTable("T_GRW_MEASUREMENT_TYPE");
                });

            modelBuilder.Entity("ApiGreenway.Models.Process", b =>
                {
                    b.Property<int>("id_process")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_process"));

                    b.Property<string>("ds_name")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<DateTimeOffset>("dt_created_at")
                        .HasColumnType("TIMESTAMP(7) WITH TIME ZONE");

                    b.Property<string>("dt_end")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(10)");

                    b.Property<DateTimeOffset?>("dt_finished_at")
                        .HasColumnType("TIMESTAMP(7) WITH TIME ZONE");

                    b.Property<string>("dt_start")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(10)");

                    b.Property<DateTimeOffset?>("dt_updated_at")
                        .HasColumnType("TIMESTAMP(7) WITH TIME ZONE");

                    b.Property<int?>("id_company")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int?>("id_company_representative")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("nr_priority")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("st_process")
                        .HasMaxLength(1)
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("tx_comments")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("tx_description")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("id_process");

                    b.ToTable("T_GRW_PROCESS");
                });

            modelBuilder.Entity("ApiGreenway.Models.ProcessBadge", b =>
                {
                    b.Property<int>("id_process_badge")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_process_badge"));

                    b.Property<DateTimeOffset>("dt_created_at")
                        .HasColumnType("TIMESTAMP(7) WITH TIME ZONE");

                    b.Property<string>("dt_expiration_date")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(10)");

                    b.Property<DateTimeOffset?>("dt_finished_at")
                        .HasColumnType("TIMESTAMP(7) WITH TIME ZONE");

                    b.Property<DateTimeOffset?>("dt_updated_at")
                        .HasColumnType("TIMESTAMP(7) WITH TIME ZONE");

                    b.Property<int?>("id_badge")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int?>("id_process")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("url_badge")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("id_process_badge");

                    b.ToTable("T_GRW_PROCESS_BADGE");
                });

            modelBuilder.Entity("ApiGreenway.Models.ProcessResource", b =>
                {
                    b.Property<int>("id_process_resource")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_process_resource"));

                    b.Property<DateTimeOffset>("dt_created_at")
                        .HasColumnType("TIMESTAMP(7) WITH TIME ZONE");

                    b.Property<DateTimeOffset?>("dt_finished_at")
                        .HasColumnType("TIMESTAMP(7) WITH TIME ZONE");

                    b.Property<DateTimeOffset?>("dt_updated_at")
                        .HasColumnType("TIMESTAMP(7) WITH TIME ZONE");

                    b.Property<int?>("id_process")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int?>("id_resource")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("id_process_resource");

                    b.ToTable("T_GRW_PROCESS_RESOURCE");
                });

            modelBuilder.Entity("ApiGreenway.Models.ProcessStep", b =>
                {
                    b.Property<int>("id_process_step")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_process_step"));

                    b.Property<DateTimeOffset>("dt_created_at")
                        .HasColumnType("TIMESTAMP(7) WITH TIME ZONE");

                    b.Property<DateTimeOffset?>("dt_finished_at")
                        .HasColumnType("TIMESTAMP(7) WITH TIME ZONE");

                    b.Property<DateTimeOffset?>("dt_updated_at")
                        .HasColumnType("TIMESTAMP(7) WITH TIME ZONE");

                    b.Property<int?>("id_process")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int?>("id_step")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("id_process_step");

                    b.ToTable("T_GRW_PROCESS_STEP");
                });

            modelBuilder.Entity("ApiGreenway.Models.Product", b =>
                {
                    b.Property<int>("id_product")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_product"));

                    b.Property<string>("ds_name")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<DateTimeOffset>("dt_created_at")
                        .HasColumnType("TIMESTAMP(7) WITH TIME ZONE");

                    b.Property<DateTimeOffset?>("dt_finished_at")
                        .HasColumnType("TIMESTAMP(7) WITH TIME ZONE");

                    b.Property<DateTimeOffset?>("dt_updated_at")
                        .HasColumnType("TIMESTAMP(7) WITH TIME ZONE");

                    b.Property<int?>("id_product_type")
                        .HasColumnType("NUMBER(10)");

                    b.Property<double>("nr_weight")
                        .HasColumnType("BINARY_DOUBLE");

                    b.Property<string>("tx_description")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<double>("vl_cost_price")
                        .HasColumnType("BINARY_DOUBLE");

                    b.Property<double>("vl_sale_price")
                        .HasColumnType("BINARY_DOUBLE");

                    b.HasKey("id_product");

                    b.ToTable("T_GRW_PRODUCT");
                });

            modelBuilder.Entity("ApiGreenway.Models.ProductType", b =>
                {
                    b.Property<int>("id_product_type")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_product_type"));

                    b.Property<string>("ds_name")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<DateTimeOffset>("dt_created_at")
                        .HasColumnType("TIMESTAMP(7) WITH TIME ZONE");

                    b.Property<DateTimeOffset?>("dt_finished_at")
                        .HasColumnType("TIMESTAMP(7) WITH TIME ZONE");

                    b.Property<DateTimeOffset?>("dt_updated_at")
                        .HasColumnType("TIMESTAMP(7) WITH TIME ZONE");

                    b.Property<string>("tx_description")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("id_product_type");

                    b.ToTable("T_GRW_PRODUCT_TYPE");
                });

            modelBuilder.Entity("ApiGreenway.Models.Resource", b =>
                {
                    b.Property<int>("id_resource")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_resource"));

                    b.Property<string>("ds_name")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("ds_unit_of_measurement")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<DateTimeOffset>("dt_created_at")
                        .HasColumnType("TIMESTAMP(7) WITH TIME ZONE");

                    b.Property<DateTimeOffset?>("dt_finished_at")
                        .HasColumnType("TIMESTAMP(7) WITH TIME ZONE");

                    b.Property<DateTimeOffset?>("dt_updated_at")
                        .HasColumnType("TIMESTAMP(7) WITH TIME ZONE");

                    b.Property<int?>("id_resource_type")
                        .HasColumnType("NUMBER(10)");

                    b.Property<double>("nr_availability")
                        .HasColumnType("BINARY_DOUBLE");

                    b.Property<string>("tx_description")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<double>("vl_cost_per_unity")
                        .HasColumnType("BINARY_DOUBLE");

                    b.HasKey("id_resource");

                    b.ToTable("T_GRW_RESOURCE");
                });

            modelBuilder.Entity("ApiGreenway.Models.ResourceType", b =>
                {
                    b.Property<int>("id_resource_type")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_resource_type"));

                    b.Property<string>("ds_name")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<DateTimeOffset>("dt_created_at")
                        .HasColumnType("TIMESTAMP(7) WITH TIME ZONE");

                    b.Property<DateTimeOffset?>("dt_finished_at")
                        .HasColumnType("TIMESTAMP(7) WITH TIME ZONE");

                    b.Property<DateTimeOffset?>("dt_updated_at")
                        .HasColumnType("TIMESTAMP(7) WITH TIME ZONE");

                    b.Property<string>("tx_description")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("id_resource_type");

                    b.ToTable("T_GRW_RESOURCE_TYPE");
                });

            modelBuilder.Entity("ApiGreenway.Models.Sector", b =>
                {
                    b.Property<int>("id_sector")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_sector"));

                    b.Property<string>("ds_name")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<DateTimeOffset>("dt_created_at")
                        .HasColumnType("TIMESTAMP(7) WITH TIME ZONE");

                    b.Property<DateTimeOffset?>("dt_finished_at")
                        .HasColumnType("TIMESTAMP(7) WITH TIME ZONE");

                    b.Property<DateTimeOffset?>("dt_updated_at")
                        .HasColumnType("TIMESTAMP(7) WITH TIME ZONE");

                    b.Property<string>("tx_description")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("id_sector");

                    b.ToTable("T_GRW_SECTOR");
                });

            modelBuilder.Entity("ApiGreenway.Models.Step", b =>
                {
                    b.Property<int>("id_step")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_step"));

                    b.Property<string>("ds_name")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<DateTimeOffset>("dt_created_at")
                        .HasColumnType("TIMESTAMP(7) WITH TIME ZONE");

                    b.Property<string>("dt_end")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(10)");

                    b.Property<DateTimeOffset?>("dt_finished_at")
                        .HasColumnType("TIMESTAMP(7) WITH TIME ZONE");

                    b.Property<string>("dt_start")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(10)");

                    b.Property<DateTimeOffset?>("dt_updated_at")
                        .HasColumnType("TIMESTAMP(7) WITH TIME ZONE");

                    b.Property<double>("nr_estimated_time")
                        .HasColumnType("BINARY_DOUBLE");

                    b.Property<int>("st_step")
                        .HasMaxLength(1)
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("tx_description")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("id_step");

                    b.ToTable("T_GRW_STEP");
                });

            modelBuilder.Entity("ApiGreenway.Models.SustainableGoal", b =>
                {
                    b.Property<int>("id_sustainable_goal")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_sustainable_goal"));

                    b.Property<string>("ds_name")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<DateTimeOffset>("dt_created_at")
                        .HasColumnType("TIMESTAMP(7) WITH TIME ZONE");

                    b.Property<DateTimeOffset?>("dt_finished_at")
                        .HasColumnType("TIMESTAMP(7) WITH TIME ZONE");

                    b.Property<DateTimeOffset?>("dt_updated_at")
                        .HasColumnType("TIMESTAMP(7) WITH TIME ZONE");

                    b.Property<int?>("id_badge")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("tx_description")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<double>("vl_target")
                        .HasColumnType("BINARY_DOUBLE");

                    b.HasKey("id_sustainable_goal");

                    b.ToTable("T_GRW_SUSTAINABLE_GOAL");
                });

            modelBuilder.Entity("ApiGreenway.Models.SustainableImprovementActions", b =>
                {
                    b.Property<int>("id_sustainable_improvement_action")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_sustainable_improvement_action"));

                    b.Property<string>("ds_name")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<DateTimeOffset>("dt_created_at")
                        .HasColumnType("TIMESTAMP(7) WITH TIME ZONE");

                    b.Property<DateTimeOffset?>("dt_finished_at")
                        .HasColumnType("TIMESTAMP(7) WITH TIME ZONE");

                    b.Property<DateTimeOffset?>("dt_updated_at")
                        .HasColumnType("TIMESTAMP(7) WITH TIME ZONE");

                    b.Property<int?>("id_sustainable_goal")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("nr_priority")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("st_sustainable_action")
                        .HasMaxLength(1)
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("tx_instruction")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("id_sustainable_improvement_action");

                    b.ToTable("T_GRW_SUSTAINABLE_IMPROVEMENT_ACTIONS");
                });

            modelBuilder.Entity("ApiGreenway.Models.User", b =>
                {
                    b.Property<int>("id_user")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_user"));

                    b.Property<string>("ds_email")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("ds_password")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("ds_uid_fb")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<DateTimeOffset>("dt_created_at")
                        .HasColumnType("TIMESTAMP(7) WITH TIME ZONE");

                    b.Property<DateTimeOffset?>("dt_finished_at")
                        .HasColumnType("TIMESTAMP(7) WITH TIME ZONE");

                    b.Property<DateTimeOffset?>("dt_updated_at")
                        .HasColumnType("TIMESTAMP(7) WITH TIME ZONE");

                    b.Property<int?>("id_company_representative")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int?>("id_user_type")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("id_user");

                    b.ToTable("T_GRW_USER");
                });

            modelBuilder.Entity("ApiGreenway.Models.UserType", b =>
                {
                    b.Property<int>("id_user_type")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_user_type"));

                    b.Property<string>("ds_title")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<DateTimeOffset>("dt_created_at")
                        .HasColumnType("TIMESTAMP(7) WITH TIME ZONE");

                    b.Property<DateTimeOffset?>("dt_finished_at")
                        .HasColumnType("TIMESTAMP(7) WITH TIME ZONE");

                    b.Property<DateTimeOffset?>("dt_updated_at")
                        .HasColumnType("TIMESTAMP(7) WITH TIME ZONE");

                    b.HasKey("id_user_type");

                    b.ToTable("T_GRW_USER_TYPE");
                });
#pragma warning restore 612, 618
        }
    }
}
