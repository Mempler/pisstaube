﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pisstaube.CacheDb;

namespace Pisstaube.CacheDb.Migrations
{
    [DbContext(typeof(PisstaubeCacheDbContext))]
    [Migration("20190527041827_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity("Pisstaube.CacheDb.Models.CacheBeatmapSet", b =>
                {
                    b.Property<int>("SetId")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("DownloadCount");

                    b.Property<DateTime>("LastDownload");

                    b.HasKey("SetId");

                    b.ToTable("CacheBeatmapSet");
                });
#pragma warning restore 612, 618
        }
    }
}
