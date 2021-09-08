﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DatabseFirst.Models
{
    public partial class pubsContext : DbContext
    {
        public pubsContext()
        {
        }

        public pubsContext(DbContextOptions<pubsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AnotherEmpl> AnotherEmpls { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Cust> Custs { get; set; }
        public virtual DbSet<Discount> Discounts { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Employeesalary> Employeesalaries { get; set; }
        public virtual DbSet<Emplsal> Emplsals { get; set; }
        public virtual DbSet<Job> Jobs { get; set; }
        public virtual DbSet<PubInfo> PubInfos { get; set; }
        public virtual DbSet<Publisher> Publishers { get; set; }
        public virtual DbSet<Roysched> Royscheds { get; set; }
        public virtual DbSet<Salary> Salaries { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
        public virtual DbSet<TbTriggerCheck> TbTriggerChecks { get; set; }
        public virtual DbSet<Tblemp> Tblemps { get; set; }
        public virtual DbSet<Tblemp1> Tblemp1s { get; set; }
        public virtual DbSet<Title> Titles { get; set; }
        public virtual DbSet<Titleauthor> Titleauthors { get; set; }
        public virtual DbSet<Titleview> Titleviews { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=KANINI-LTP-471\\SQLSERVER2019G3;user id=sa;password=Admin@123;Initial catalog=pubs");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AnotherEmpl>(entity =>
            {
                entity.ToTable("anotherEmpl");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Author>(entity =>
            {
                entity.HasKey(e => e.AuId)
                    .HasName("UPKCL_auidind");

                entity.ToTable("authors");

                entity.HasIndex(e => new { e.AuLname, e.AuFname }, "aunmind");

                entity.Property(e => e.AuId)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("au_id");

                entity.Property(e => e.Address)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.AuFname)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("au_fname");

                entity.Property(e => e.AuLname)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("au_lname");

                entity.Property(e => e.City)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("city");

                entity.Property(e => e.Contract).HasColumnName("contract");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("phone")
                    .HasDefaultValueSql("('UNKNOWN')")
                    .IsFixedLength(true);

                entity.Property(e => e.State)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("state")
                    .IsFixedLength(true);

                entity.Property(e => e.Zip)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("zip")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Cust>(entity =>
            {
                entity.ToTable("Cust");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.ReffBy).HasColumnName("reffBy");

                entity.HasOne(d => d.ReffByNavigation)
                    .WithMany(p => p.InverseReffByNavigation)
                    .HasForeignKey(d => d.ReffBy)
                    .HasConstraintName("fk_reff");
            });

            modelBuilder.Entity<Discount>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("discounts");

                entity.Property(e => e.Discount1)
                    .HasColumnType("decimal(4, 2)")
                    .HasColumnName("discount");

                entity.Property(e => e.Discounttype)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("discounttype");

                entity.Property(e => e.Highqty).HasColumnName("highqty");

                entity.Property(e => e.Lowqty).HasColumnName("lowqty");

                entity.Property(e => e.StorId)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("stor_id")
                    .IsFixedLength(true);

                entity.HasOne(d => d.Stor)
                    .WithMany()
                    .HasForeignKey(d => d.StorId)
                    .HasConstraintName("FK__discounts__stor___3C69FB99");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmpId)
                    .HasName("PK_emp_id")
                    .IsClustered(false);

                entity.ToTable("employee");

                entity.HasIndex(e => new { e.Lname, e.Fname, e.Minit }, "employee_ind")
                    .IsClustered();

                entity.Property(e => e.EmpId)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("emp_id")
                    .IsFixedLength(true);

                entity.Property(e => e.Fname)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("fname");

                entity.Property(e => e.HireDate)
                    .HasColumnType("datetime")
                    .HasColumnName("hire_date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.JobId)
                    .HasColumnName("job_id")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.JobLvl)
                    .HasColumnName("job_lvl")
                    .HasDefaultValueSql("((10))");

                entity.Property(e => e.Lname)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("lname");

                entity.Property(e => e.Minit)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("minit")
                    .IsFixedLength(true);

                entity.Property(e => e.PubId)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("pub_id")
                    .HasDefaultValueSql("('9952')")
                    .IsFixedLength(true);

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.JobId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__employee__job_id__48CFD27E");

                entity.HasOne(d => d.Pub)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.PubId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__employee__pub_id__4BAC3F29");
            });

            modelBuilder.Entity<Employeesalary>(entity =>
            {
                entity.HasKey(e => e.EmpId)
                    .HasName("PK__employee__AFB3EC6DA0AC63B5");

                entity.ToTable("employeesalary");

                entity.Property(e => e.EmpId).HasColumnName("empID");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.Extra).HasColumnName("extra");

                entity.Property(e => e.SalId).HasColumnName("salId");

                entity.Property(e => e.Saldate)
                    .HasColumnType("date")
                    .HasColumnName("saldate");

                entity.HasOne(d => d.Sal)
                    .WithMany(p => p.Employeesalaries)
                    .HasForeignKey(d => d.SalId)
                    .HasConstraintName("FK__employees__salId__32AB8735");
            });

            modelBuilder.Entity<Emplsal>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("emplsal");

                entity.Property(e => e.Empid).HasColumnName("empid");

                entity.Property(e => e.SalDate)
                    .HasColumnType("date")
                    .HasColumnName("salDate");

                entity.Property(e => e.SalId).HasColumnName("salId");

                entity.Property(e => e.TotalSal).HasColumnName("totalSal");

                entity.HasOne(d => d.Emp)
                    .WithMany()
                    .HasForeignKey(d => d.Empid)
                    .HasConstraintName("FK__emplsal__empid__42E1EEFE");

                entity.HasOne(d => d.Sal)
                    .WithMany()
                    .HasForeignKey(d => d.SalId)
                    .HasConstraintName("FK__emplsal__salId__43D61337");
            });

            modelBuilder.Entity<Job>(entity =>
            {
                entity.ToTable("jobs");

                entity.Property(e => e.JobId).HasColumnName("job_id");

                entity.Property(e => e.JobDesc)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("job_desc")
                    .HasDefaultValueSql("('New Position - title not formalized yet')");

                entity.Property(e => e.MaxLvl).HasColumnName("max_lvl");

                entity.Property(e => e.MinLvl).HasColumnName("min_lvl");
            });

            modelBuilder.Entity<PubInfo>(entity =>
            {
                entity.HasKey(e => e.PubId)
                    .HasName("UPKCL_pubinfo");

                entity.ToTable("pub_info");

                entity.Property(e => e.PubId)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("pub_id")
                    .IsFixedLength(true);

                entity.Property(e => e.Logo)
                    .HasColumnType("image")
                    .HasColumnName("logo");

                entity.Property(e => e.PrInfo)
                    .HasColumnType("text")
                    .HasColumnName("pr_info");

                entity.HasOne(d => d.Pub)
                    .WithOne(p => p.PubInfo)
                    .HasForeignKey<PubInfo>(d => d.PubId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__pub_info__pub_id__440B1D61");
            });

            modelBuilder.Entity<Publisher>(entity =>
            {
                entity.HasKey(e => e.PubId)
                    .HasName("UPKCL_pubind");

                entity.ToTable("publishers");

                entity.Property(e => e.PubId)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("pub_id")
                    .IsFixedLength(true);

                entity.Property(e => e.City)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("city");

                entity.Property(e => e.Country)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("country")
                    .HasDefaultValueSql("('USA')");

                entity.Property(e => e.PubName)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("pub_name");

                entity.Property(e => e.State)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("state")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Roysched>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("roysched");

                entity.HasIndex(e => e.TitleId, "titleidind");

                entity.Property(e => e.Hirange).HasColumnName("hirange");

                entity.Property(e => e.Lorange).HasColumnName("lorange");

                entity.Property(e => e.Royalty).HasColumnName("royalty");

                entity.Property(e => e.TitleId)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("title_id");

                entity.HasOne(d => d.Title)
                    .WithMany()
                    .HasForeignKey(d => d.TitleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__roysched__title___3A81B327");
            });

            modelBuilder.Entity<Salary>(entity =>
            {
                entity.HasKey(e => e.SalId)
                    .HasName("PK__salary__E3E8929631C6152B");

                entity.ToTable("salary");

                entity.Property(e => e.SalId).HasColumnName("salId");

                entity.Property(e => e.Basic).HasColumnName("basic");

                entity.Property(e => e.Da).HasColumnName("da");

                entity.Property(e => e.Deductions).HasColumnName("deductions");

                entity.Property(e => e.Hra).HasColumnName("hra");
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.HasKey(e => new { e.StorId, e.OrdNum, e.TitleId })
                    .HasName("UPKCL_sales");

                entity.ToTable("sales");

                entity.HasIndex(e => e.TitleId, "titleidind");

                entity.Property(e => e.StorId)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("stor_id")
                    .IsFixedLength(true);

                entity.Property(e => e.OrdNum)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ord_num");

                entity.Property(e => e.TitleId)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("title_id");

                entity.Property(e => e.OrdDate)
                    .HasColumnType("datetime")
                    .HasColumnName("ord_date");

                entity.Property(e => e.Payterms)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("payterms");

                entity.Property(e => e.Qty).HasColumnName("qty");

                entity.HasOne(d => d.Stor)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.StorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__sales__stor_id__37A5467C");

                entity.HasOne(d => d.Title)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.TitleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__sales__title_id__38996AB5");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.HasKey(e => e.StorId)
                    .HasName("UPK_storeid");

                entity.ToTable("stores");

                entity.Property(e => e.StorId)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("stor_id")
                    .IsFixedLength(true);

                entity.Property(e => e.City)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("city");

                entity.Property(e => e.State)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("state")
                    .IsFixedLength(true);

                entity.Property(e => e.StorAddress)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("stor_address");

                entity.Property(e => e.StorName)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("stor_name");

                entity.Property(e => e.Zip)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("zip")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<TbTriggerCheck>(entity =>
            {
                entity.HasKey(e => e.F1)
                    .HasName("PK__tbTrigge__32139E5835656047");

                entity.ToTable("tbTriggerCheck");

                entity.Property(e => e.F1).HasColumnName("f1");

                entity.Property(e => e.F2)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("f2");
            });

            modelBuilder.Entity<Tblemp>(entity =>
            {
                entity.ToTable("tblemp");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Tblemp1>(entity =>
            {
                entity.ToTable("tblemp1");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Title>(entity =>
            {
                entity.ToTable("titles");

                entity.HasIndex(e => e.Title1, "titleind");

                entity.Property(e => e.TitleId)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("title_id");

                entity.Property(e => e.Advance)
                    .HasColumnType("money")
                    .HasColumnName("advance");

                entity.Property(e => e.Notes)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("notes");

                entity.Property(e => e.Price)
                    .HasColumnType("money")
                    .HasColumnName("price");

                entity.Property(e => e.PubId)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("pub_id")
                    .IsFixedLength(true);

                entity.Property(e => e.Pubdate)
                    .HasColumnType("datetime")
                    .HasColumnName("pubdate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Royalty).HasColumnName("royalty");

                entity.Property(e => e.Title1)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("title");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("type")
                    .HasDefaultValueSql("('UNDECIDED')")
                    .IsFixedLength(true);

                entity.Property(e => e.YtdSales).HasColumnName("ytd_sales");

                entity.HasOne(d => d.Pub)
                    .WithMany(p => p.Titles)
                    .HasForeignKey(d => d.PubId)
                    .HasConstraintName("FK__titles__pub_id__2E1BDC42");
            });

            modelBuilder.Entity<Titleauthor>(entity =>
            {
                entity.HasKey(e => new { e.AuId, e.TitleId })
                    .HasName("UPKCL_taind");

                entity.ToTable("titleauthor");

                entity.HasIndex(e => e.AuId, "auidind");

                entity.HasIndex(e => e.TitleId, "titleidind");

                entity.Property(e => e.AuId)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("au_id");

                entity.Property(e => e.TitleId)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("title_id");

                entity.Property(e => e.AuOrd).HasColumnName("au_ord");

                entity.Property(e => e.Royaltyper).HasColumnName("royaltyper");

                entity.HasOne(d => d.Au)
                    .WithMany(p => p.Titleauthors)
                    .HasForeignKey(d => d.AuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__titleauth__au_id__31EC6D26");

                entity.HasOne(d => d.Title)
                    .WithMany(p => p.Titleauthors)
                    .HasForeignKey(d => d.TitleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__titleauth__title__32E0915F");
            });

            modelBuilder.Entity<Titleview>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("titleview");

                entity.Property(e => e.AuLname)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("au_lname");

                entity.Property(e => e.AuOrd).HasColumnName("au_ord");

                entity.Property(e => e.Price)
                    .HasColumnType("money")
                    .HasColumnName("price");

                entity.Property(e => e.PubId)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("pub_id")
                    .IsFixedLength(true);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("title");

                entity.Property(e => e.YtdSales).HasColumnName("ytd_sales");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
