﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatingApp.API.Data.Migrations
{
    public partial class AddMemberInfoToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Avatar",
                table: "AppUsers",
                type: "varchar(256)",
                maxLength: 256,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "AppUsers",
                type: "varchar(32)",
                maxLength: 32,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "AppUsers",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "AppUsers",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "AppUsers",
                type: "varchar(6)",
                maxLength: 6,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Introduction",
                table: "AppUsers",
                type: "varchar(512)",
                maxLength: 512,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "KnownAs",
                table: "AppUsers",
                type: "varchar(32)",
                maxLength: 32,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "AppUsers",
                type: "datetime(6)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Avatar",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "City",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "Introduction",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "KnownAs",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "AppUsers");
        }
    }
}
