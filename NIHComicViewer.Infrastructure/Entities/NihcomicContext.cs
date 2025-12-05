using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NIHComicViewer.Infrastructure.Entities;

public partial class NihcomicContext : DbContext
{
    public NihcomicContext()
    {
    }

    public NihcomicContext(DbContextOptions<NihcomicContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Comic> Comics { get; set; }

    public virtual DbSet<ComicPage> ComicPages { get; set; }

    public virtual DbSet<ComicPageTag> ComicPageTags { get; set; }

    public virtual DbSet<ComicTag> ComicTags { get; set; }

    public virtual DbSet<Tag> Tags { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Comic>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("comic_pk");

            entity.ToTable("comic");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Author)
                .HasColumnType("character varying")
                .HasColumnName("author");
            entity.Property(e => e.Cover)
                .HasColumnType("character varying")
                .HasColumnName("cover");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_date");
            entity.Property(e => e.EndYear)
                .HasColumnType("character varying")
                .HasColumnName("end_year");
            entity.Property(e => e.Language)
                .HasColumnType("character varying")
                .HasColumnName("language");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.ModifiedDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modified_date");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.StartYear)
                .HasColumnType("character varying")
                .HasColumnName("start_year");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.ComicCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("comic_user_fk");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.ComicModifiedByNavigations)
                .HasForeignKey(d => d.ModifiedBy)
                .HasConstraintName("comic_user_fk_1");
        });

        modelBuilder.Entity<ComicPage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("comicpage_pk");

            entity.ToTable("comic_page");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("nextval('comicpage_id_seq'::regclass)")
                .HasColumnName("id");
            entity.Property(e => e.ComicId).HasColumnName("comic_id");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_date");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.ModifiedDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modified_date");
            entity.Property(e => e.PageNumber).HasColumnName("page_number");

            entity.HasOne(d => d.Comic).WithMany(p => p.ComicPages)
                .HasForeignKey(d => d.ComicId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("comic_page_comic_fk");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.ComicPageCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("comic_page_user_fk");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.ComicPageModifiedByNavigations)
                .HasForeignKey(d => d.ModifiedBy)
                .HasConstraintName("comic_page_user_fk_1");
        });

        modelBuilder.Entity<ComicPageTag>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("comic_page_tag_pk");

            entity.ToTable("comic_page_tag");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ComicPageId).HasColumnName("comic_page_id");
            entity.Property(e => e.TagId).HasColumnName("tag_id");

            entity.HasOne(d => d.ComicPage).WithMany(p => p.ComicPageTags)
                .HasForeignKey(d => d.ComicPageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("comic_page_tag_comic_page_fk");

            entity.HasOne(d => d.Tag).WithMany(p => p.ComicPageTags)
                .HasForeignKey(d => d.TagId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("comic_page_tag_tag_fk");
        });

        modelBuilder.Entity<ComicTag>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("comic_tag_pk");

            entity.ToTable("comic_tag");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ComicId).HasColumnName("comic_id");
            entity.Property(e => e.TagId).HasColumnName("tag_id");

            entity.HasOne(d => d.Comic).WithMany(p => p.ComicTags)
                .HasForeignKey(d => d.ComicId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("comic_tag_comic_fk");

            entity.HasOne(d => d.Tag).WithMany(p => p.ComicTags)
                .HasForeignKey(d => d.TagId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("comic_tag_tag_fk");
        });

        modelBuilder.Entity<Tag>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tag_pk");

            entity.ToTable("tag");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("user_pk");

            entity.ToTable("user");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_date");
            entity.Property(e => e.IsAdmin).HasColumnName("is_admin");
            entity.Property(e => e.LastSignIn)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("last_sign_in");
            entity.Property(e => e.ModifiedDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modified_date");
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(128)
                .HasColumnName("password_hash");
            entity.Property(e => e.ResetToken)
                .HasColumnType("character varying")
                .HasColumnName("reset_token");
            entity.Property(e => e.Username)
                .HasColumnType("character varying")
                .HasColumnName("username");
            entity.Property(e => e.EmailAddress)
                .HasColumnType("character varying")
                .HasColumnName("email_address");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
