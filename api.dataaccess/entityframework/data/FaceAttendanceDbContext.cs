using System;
using api.dataaccess.entityframework.model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using static Org.BouncyCastle.Math.EC.ECCurve;

#nullable disable

namespace api.dataaccess.entityframework.data
{
    public partial class FaceAttendanceDbContext : DbContext
    {
        private readonly IConfiguration _config;
        public FaceAttendanceDbContext(IConfiguration config)
        {
            _config = config;
        }


        public virtual DbSet<TblAdvertisement> TblAdvertisements { get; set; }
        public virtual DbSet<TblAttendance> TblAttendances { get; set; }
        public virtual DbSet<TblConstant> TblConstants { get; set; }
        public virtual DbSet<TblSchedule> TblSchedules { get; set; }
        public virtual DbSet<TblSubject> TblSubjects { get; set; }
        public virtual DbSet<TblUser> TblUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL(_config.GetConnectionString("MySqlConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblAdvertisement>(entity =>
            {
                entity.ToTable("tbl_advertisements");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'current_timestamp()'");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description");

                entity.Property(e => e.Img)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("img");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("title");

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasColumnName("url");
            });

            modelBuilder.Entity<TblAttendance>(entity =>
            {
                entity.ToTable("tbl_attendances");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.ClockIn)
                    .HasColumnName("clock_in")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ClockOut)
                    .HasColumnName("clock_out")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'current_timestamp()'");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.LunchEnd)
                    .HasColumnName("lunch_end")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.LunchStart)
                    .HasColumnName("lunch_start")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Overtime)
                    .HasColumnName("overtime")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.TotalHours)
                    .HasColumnName("total_hours")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Undertime)
                    .HasColumnName("undertime")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.UserId)
                    .HasColumnType("int(11)")
                    .HasColumnName("user_id");
            });

            modelBuilder.Entity<TblConstant>(entity =>
            {
                entity.ToTable("tbl_constants");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("category");

                entity.Property(e => e.SubValue)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("sub_value");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("value");
            });

            modelBuilder.Entity<TblSchedule>(entity =>
            {
                entity.HasKey(e => e.ScheduleId)
                    .HasName("PRIMARY");

                entity.ToTable("tbl_schedule");

                entity.Property(e => e.ScheduleId).HasColumnType("int(11)");

                entity.Property(e => e.SubjectId).HasColumnType("int(11)");

                entity.Property(e => e.UserId).HasColumnType("int(11)");

                entity.Property(e => e.WorkDay)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TblSubject>(entity =>
            {
                entity.HasKey(e => e.SubjectId)
                    .HasName("PRIMARY");

                entity.ToTable("tbl_subject");

                entity.Property(e => e.SubjectId).HasColumnType("int(11)");

                entity.Property(e => e.CreatedDate).HasDefaultValueSql("'NULL'");

                entity.Property(e => e.SubjectCode)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.SubjectName)
                    .HasMaxLength(100)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.UpdateDate).HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<TblUser>(entity =>
            {
                entity.ToTable("tbl_users");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("address");

                entity.Property(e => e.Age)
                    .HasColumnType("int(11)")
                    .HasColumnName("age");

                entity.Property(e => e.AttemptNo)
                    .HasColumnType("int(11)")
                    .HasColumnName("attempt_no");

                entity.Property(e => e.Bday)
                    .HasColumnType("date")
                    .HasColumnName("bday")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Contact)
                    .IsRequired()
                    .HasMaxLength(11)
                    .HasColumnName("contact");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'current_timestamp()'");

                entity.Property(e => e.Department)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("department");


                entity.Property(e => e.EmailCode)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("emailCode");

                entity.Property(e => e.Fname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("fname");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("gender");

                entity.Property(e => e.Lname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("lname");

                entity.Property(e => e.Mname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("mname");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("password");

                entity.Property(e => e.Pic)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("pic")
                    .HasDefaultValueSql("'''default.png'''");

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("role");

                entity.Property(e => e.Schedule)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("schedule");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("status");

                entity.Property(e => e.TrackFace)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("trackFace");

                entity.Property(e => e.TrainedFaces)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("username");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
