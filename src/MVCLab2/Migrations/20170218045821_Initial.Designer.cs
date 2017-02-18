using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using MVCLab2.Models;

namespace MVCLab2.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20170218045821_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MVCLab2.Models.Member", b =>
                {
                    b.Property<int>("MemberID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DisplayName");

                    b.Property<string>("Email");

                    b.Property<string>("UserName");

                    b.HasKey("MemberID");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("MVCLab2.Models.Message", b =>
                {
                    b.Property<int>("MessageID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Body");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Title");

                    b.Property<string>("Topic");

                    b.Property<int?>("UserMemberID");

                    b.HasKey("MessageID");

                    b.HasIndex("UserMemberID");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("MVCLab2.Models.Message", b =>
                {
                    b.HasOne("MVCLab2.Models.Member", "User")
                        .WithMany()
                        .HasForeignKey("UserMemberID");
                });
        }
    }
}
