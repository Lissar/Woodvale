using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using MVCLab2.Models;

namespace MVCLab2.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("MVCLab2.Models.Reply", b =>
                {
                    b.Property<int>("ReplyID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Body")
                        .IsRequired();

                    b.Property<int?>("MessageID");

                    b.HasKey("ReplyID");

                    b.HasIndex("MessageID");

                    b.ToTable("Reply");
                });

            modelBuilder.Entity("MVCLab2.Models.Message", b =>
                {
                    b.HasOne("MVCLab2.Models.Member", "User")
                        .WithMany()
                        .HasForeignKey("UserMemberID");
                });

            modelBuilder.Entity("MVCLab2.Models.Reply", b =>
                {
                    b.HasOne("MVCLab2.Models.Message")
                        .WithMany("MessageReplies")
                        .HasForeignKey("MessageID");
                });
        }
    }
}
