using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Domain.Models;

namespace DataAccess.Models;

public partial class TravelTimeContext : DbContext
{
    public TravelTimeContext()
    {
    }

    public TravelTimeContext(DbContextOptions<TravelTimeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<ContactListPm> ContactListPms { get; set; }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<MessageGroup> MessageGroups { get; set; }

    public virtual DbSet<MessageListPm> MessageListPms { get; set; }

    public virtual DbSet<News> News { get; set; }

    public virtual DbSet<Point> Points { get; set; }

    public virtual DbSet<PreferencesUser> PreferencesUsers { get; set; }

    public virtual DbSet<RatingNewsUser> RatingNewsUsers { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<StoryVisitUser> StoryVisitUsers { get; set; }

    public virtual DbSet<Travel> Travels { get; set; }

    public virtual DbSet<TypePoint> TypePoints { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UsersGroup> UsersGroups { get; set; }

    public virtual DbSet<Way> Ways { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Idcategory);

            entity.ToTable("Category");

            entity.Property(e => e.Idcategory)
                .ValueGeneratedNever()
                .HasColumnName("IDCategory");
            entity.Property(e => e.CategoryName).HasMaxLength(50);
        });

        modelBuilder.Entity<ContactListPm>(entity =>
        {
            entity.HasKey(e => new { e.Idusers2, e.Idusers });

            entity.ToTable("ContactListPM");

            entity.Property(e => e.Idusers2).HasColumnName("IDUsers2");
            entity.Property(e => e.Idusers).HasColumnName("IDUsers");
            entity.Property(e => e.LastContact).HasColumnType("datetime");

            entity.HasOne(d => d.IdusersNavigation).WithMany(p => p.ContactListPmIdusersNavigations)
                .HasForeignKey(d => d.Idusers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ContactListPM_Users1");

            entity.HasOne(d => d.Idusers2Navigation).WithMany(p => p.ContactListPmIdusers2Navigations)
                .HasForeignKey(d => d.Idusers2)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ContactListPM_Users");
        });

        modelBuilder.Entity<Group>(entity =>
        {
            entity.HasKey(e => e.Idgroup).HasName("PK_Group2");

            entity.ToTable("Group");

            entity.Property(e => e.Idgroup)
                .ValueGeneratedNever()
                .HasColumnName("IDGroup");
            entity.Property(e => e.Idcreator).HasColumnName("IDCreator");
            entity.Property(e => e.Maxnumber).HasColumnName("MAXNumber");
            entity.Property(e => e.Minnumber).HasColumnName("MINNumber");
            entity.Property(e => e.NameGroup).HasMaxLength(50);
        });

        modelBuilder.Entity<MessageGroup>(entity =>
        {
            entity.HasKey(e => new { e.Idgroup, e.Idmessage });

            entity.ToTable("MessageGroup");

            entity.Property(e => e.Idgroup).HasColumnName("IDGroup");
            entity.Property(e => e.Idmessage).HasColumnName("IDMessage");
            entity.Property(e => e.Idaddressee).HasColumnName("IDAddressee");
            entity.Property(e => e.TiTleMessage).HasMaxLength(50);

            entity.HasOne(d => d.IdgroupNavigation).WithMany(p => p.MessageGroups)
                .HasForeignKey(d => d.Idgroup)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MessageGroup_Group");
        });

        modelBuilder.Entity<MessageListPm>(entity =>
        {
            entity.HasKey(e => e.Idmessage).HasName("PK_MessageListPM_1");

            entity.ToTable("MessageListPM");

            entity.Property(e => e.Idmessage)
                .ValueGeneratedNever()
                .HasColumnName("IDMessage");
            entity.Property(e => e.Idaddressee).HasColumnName("IDAddressee");
            entity.Property(e => e.Idaddresser).HasColumnName("IDAddresser");
            entity.Property(e => e.TiTle).HasMaxLength(50);

            entity.HasOne(d => d.IdaddresseeNavigation).WithMany(p => p.MessageListPmIdaddresseeNavigations)
                .HasForeignKey(d => d.Idaddressee)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MessageListPM_Users1");

            entity.HasOne(d => d.IdaddresserNavigation).WithMany(p => p.MessageListPmIdaddresserNavigations)
                .HasForeignKey(d => d.Idaddresser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MessageListPM_Users");
        });

        modelBuilder.Entity<News>(entity =>
        {
            entity.HasKey(e => e.Idnews);

            entity.ToTable("NEWS");

            entity.Property(e => e.Idnews)
                .ValueGeneratedNever()
                .HasColumnName("IDNews");
            entity.Property(e => e.ContentNews).HasMaxLength(50);
            entity.Property(e => e.Idcategory).HasColumnName("IDCategory");
            entity.Property(e => e.Idcreator).HasColumnName("IDCreator");
            entity.Property(e => e.NameNews).HasMaxLength(50);

            entity.HasOne(d => d.IdcategoryNavigation).WithMany(p => p.News)
                .HasForeignKey(d => d.Idcategory)
                .HasConstraintName("FK_NEWS_Category");

            entity.HasOne(d => d.IdnewsNavigation).WithOne(p => p.News)
                .HasForeignKey<News>(d => d.Idnews)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NEWS_RatingNewsUsers");
        });

        modelBuilder.Entity<Point>(entity =>
        {
            entity.HasKey(e => e.Idpoint);

            entity.ToTable("Point");

            entity.Property(e => e.Idpoint)
                .ValueGeneratedNever()
                .HasColumnName("IDPoint");
            entity.Property(e => e.NamePoint).HasMaxLength(50);

            entity.HasMany(d => d.IdtypePoints).WithMany(p => p.Idpoints)
                .UsingEntity<Dictionary<string, object>>(
                    "TypePointWay",
                    r => r.HasOne<TypePoint>().WithMany()
                        .HasForeignKey("IdtypePoint")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_TypePointWay_TypePoint"),
                    l => l.HasOne<Point>().WithMany()
                        .HasForeignKey("Idpoint")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_TypePointWay_Point"),
                    j =>
                    {
                        j.HasKey("Idpoint", "IdtypePoint");
                        j.ToTable("TypePointWay");
                        j.IndexerProperty<int>("Idpoint").HasColumnName("IDPoint");
                        j.IndexerProperty<int>("IdtypePoint").HasColumnName("IDTypePoint");
                    });

            entity.HasMany(d => d.Idways).WithMany(p => p.Idpoints)
                .UsingEntity<Dictionary<string, object>>(
                    "WayPoint",
                    r => r.HasOne<Way>().WithMany()
                        .HasForeignKey("Idway")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_WayPoints_Way"),
                    l => l.HasOne<Point>().WithMany()
                        .HasForeignKey("Idpoint")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_WayPoints_Point"),
                    j =>
                    {
                        j.HasKey("Idpoint", "Idway");
                        j.ToTable("WayPoints");
                        j.IndexerProperty<int>("Idpoint").HasColumnName("IDPoint");
                        j.IndexerProperty<int>("Idway").HasColumnName("IDWay");
                    });
        });

        modelBuilder.Entity<PreferencesUser>(entity =>
        {
            entity.HasKey(e => e.Idpreferences);

            entity.Property(e => e.Idpreferences)
                .ValueGeneratedNever()
                .HasColumnName("IDPreferences");
            entity.Property(e => e.Preferences).HasMaxLength(50);
        });

        modelBuilder.Entity<RatingNewsUser>(entity =>
        {
            entity.HasKey(e => e.Idnews);

            entity.Property(e => e.Idnews)
                .ValueGeneratedNever()
                .HasColumnName("IDNews");
            entity.Property(e => e.Idusers).HasColumnName("IDUsers");

            entity.HasOne(d => d.IdusersNavigation).WithMany(p => p.RatingNewsUsers)
                .HasForeignKey(d => d.Idusers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RatingNewsUsers_Users");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Idrole);

            entity.ToTable("Role");

            entity.Property(e => e.Idrole)
                .ValueGeneratedNever()
                .HasColumnName("IDRole");
            entity.Property(e => e.RoleName).HasMaxLength(50);
        });

        modelBuilder.Entity<StoryVisitUser>(entity =>
        {
            entity.HasKey(e => new { e.Idusers, e.Idpoint });

            entity.Property(e => e.Idusers).HasColumnName("IDUsers");
            entity.Property(e => e.Idpoint).HasColumnName("IDPoint");
            entity.Property(e => e.DatetimeVisit).HasColumnType("datetime");

            entity.HasOne(d => d.IdpointNavigation).WithMany(p => p.StoryVisitUsers)
                .HasForeignKey(d => d.Idpoint)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StoryVisitUsers_Point");

            entity.HasOne(d => d.IdusersNavigation).WithMany(p => p.StoryVisitUsers)
                .HasForeignKey(d => d.Idusers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StoryVisitUsers_Users");
        });

        modelBuilder.Entity<Travel>(entity =>
        {
            entity.HasKey(e => e.Idtravel);

            entity.Property(e => e.Idtravel)
                .ValueGeneratedNever()
                .HasColumnName("IDTravel");
            entity.Property(e => e.DateEnd).HasColumnType("datetime");
            entity.Property(e => e.DateStart).HasColumnType("datetime");
            entity.Property(e => e.Idgroup).HasColumnName("IDGroup");
            entity.Property(e => e.Idway).HasColumnName("IDWay");
            entity.Property(e => e.NameTravel).HasMaxLength(50);

            entity.HasOne(d => d.IdgroupNavigation).WithMany(p => p.Travels)
                .HasForeignKey(d => d.Idgroup)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Travels_Group");

            entity.HasOne(d => d.IdwayNavigation).WithMany(p => p.Travels)
                .HasForeignKey(d => d.Idway)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Travels_Way");
        });

        modelBuilder.Entity<TypePoint>(entity =>
        {
            entity.HasKey(e => e.IdtypePoint);

            entity.ToTable("TypePoint");

            entity.Property(e => e.IdtypePoint)
                .ValueGeneratedNever()
                .HasColumnName("IDTypePoint");
            entity.Property(e => e.TypePoint1)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("TypePoint");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Idusers);

            entity.Property(e => e.Idusers)
                .ValueGeneratedNever()
                .HasColumnName("IDUsers");
            entity.Property(e => e.FaterNameUou).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);

            entity.HasMany(d => d.Idpreferences).WithMany(p => p.Idusers)
                .UsingEntity<Dictionary<string, object>>(
                    "ListPreferencesUser",
                    r => r.HasOne<PreferencesUser>().WithMany()
                        .HasForeignKey("Idpreferences")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_ListPreferencesUsers_PreferencesUsers"),
                    l => l.HasOne<User>().WithMany()
                        .HasForeignKey("Idusers")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_ListPreferencesUsers_Users"),
                    j =>
                    {
                        j.HasKey("Idusers", "Idpreferences");
                        j.ToTable("ListPreferencesUsers");
                        j.IndexerProperty<int>("Idusers").HasColumnName("IDUsers");
                        j.IndexerProperty<int>("Idpreferences").HasColumnName("IDPreferences");
                    });

            entity.HasMany(d => d.Idroles).WithMany(p => p.Idusers)
                .UsingEntity<Dictionary<string, object>>(
                    "RoleUser",
                    r => r.HasOne<Role>().WithMany()
                        .HasForeignKey("Idrole")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_RoleUsers_Role"),
                    l => l.HasOne<User>().WithMany()
                        .HasForeignKey("Idusers")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_RoleUsers_Users"),
                    j =>
                    {
                        j.HasKey("Idusers", "Idrole");
                        j.ToTable("RoleUsers");
                        j.IndexerProperty<int>("Idusers").HasColumnName("IDUsers");
                        j.IndexerProperty<int>("Idrole").HasColumnName("IDRole");
                    });
        });

        modelBuilder.Entity<UsersGroup>(entity =>
        {
            entity.HasKey(e => new { e.Idgroup, e.Idusers });

            entity.ToTable("UsersGroup");

            entity.Property(e => e.Idgroup).HasColumnName("IDGroup");
            entity.Property(e => e.Idusers).HasColumnName("IDUsers");
            entity.Property(e => e.Position).HasMaxLength(50);

            entity.HasOne(d => d.IdgroupNavigation).WithMany(p => p.UsersGroups)
                .HasForeignKey(d => d.Idgroup)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UsersGroup_Group");

            entity.HasOne(d => d.IdusersNavigation).WithMany(p => p.UsersGroups)
                .HasForeignKey(d => d.Idusers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UsersGroup_Users");
        });

        modelBuilder.Entity<Way>(entity =>
        {
            entity.HasKey(e => e.Idway);

            entity.ToTable("Way");

            entity.Property(e => e.Idway)
                .ValueGeneratedNever()
                .HasColumnName("IDWay");
            entity.Property(e => e.ContentWay).HasMaxLength(50);
            entity.Property(e => e.IduserCreator).HasColumnName("IDUserCreator");
            entity.Property(e => e.WayName).HasMaxLength(50);

            entity.HasOne(d => d.IduserCreatorNavigation).WithMany(p => p.Ways)
                .HasForeignKey(d => d.IduserCreator)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Way_Users");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
