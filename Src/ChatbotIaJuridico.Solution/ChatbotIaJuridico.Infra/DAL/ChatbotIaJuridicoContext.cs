using System;
using System.Collections.Generic;
using ChatbotIaJuridico.Infra;
using Microsoft.EntityFrameworkCore;

namespace ChatbotIaJuridico.Infra.DAL;

public partial class ChatbotIaJuridicoContext : DbContext
{
    public ChatbotIaJuridicoContext()
    {
    }

    public ChatbotIaJuridicoContext(DbContextOptions<ChatbotIaJuridicoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Advogado> Advogados { get; set; }

    public virtual DbSet<Chat> Chats { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<ConfiguracaoGeral> ConfiguracaoGerals { get; set; }

    public virtual DbSet<Insumo> Insumos { get; set; }

    public virtual DbSet<PreInsumo> PreInsumos { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<Option> Options { get; set; }

    public virtual DbSet<Peticao> Peticaos { get; set; }

    public virtual DbSet<PreProcesso> PreProcessos { get; set; }

    public virtual DbSet<Prompt> Prompts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:Chinook");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Advogado>(entity =>
        {
            entity.HasKey(e => e.AdvId).HasName("PK__advogado__D4518D54BDDE5CE2");
        });

        modelBuilder.Entity<Chat>(entity =>
        {
            entity.HasKey(e => e.ChaId).HasName("PK__chat__5AF8FDEA75753377");

            entity.HasOne(d => d.Adv).WithMany(p => p.Chats)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__chat__adv_id__45F365D3");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.CliId).HasName("PK__cliente__FFEFE14F5AB0090E");

            entity.Property(e => e.CliDataCriacao).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.CliDataModificacao).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Adv).WithMany(p => p.Clientes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__cliente__adv_id__3A81B327");
        });

        modelBuilder.Entity<ConfiguracaoGeral>(entity =>
        {
            entity.HasKey(e => e.ConfgId).HasName("PK__configur__96AC3BF4901F58C0");

            entity.Property(e => e.ConfgAtiva).HasDefaultValue(true);
        });

        modelBuilder.Entity<Insumo>(entity =>
        {
            entity.HasKey(e => e.InsId).HasName("PK__insumo__9CB72D20C7DB279E");

            entity.Property(e => e.InsData).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Adv).WithMany(p => p.Insumos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__insumo__adv_id__49C3F6B7");

            entity.HasOne(d => d.Cha).WithMany(p => p.Insumos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__insumo__cha_id__4BAC3F29");

            entity.HasOne(d => d.PProc).WithMany(p => p.Insumos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__insumo__pProc_id__4AB81AF0");
        });

        modelBuilder.Entity<PreInsumo>(entity =>
        {
            entity.HasKey(e => e.pInsId);

            entity.Property(e => e.pInsData).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.pInsDataModificacao).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Adv).WithMany(p => p.PreInsumos)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Cha).WithMany(p => p.PreInsumos)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.HasKey(e => e.MenId).HasName("PK__menus__387DDE00D72BE750");

            entity.HasMany(e => e.Options)
              .WithOne(o => o.Men)
              .HasForeignKey(o => o.MenId)
              .HasConstraintName("FK_Options_Menu");
        });

        modelBuilder.Entity<Option>(entity =>
        {
            entity.HasKey(e => e.OptId).HasName("PK__options__84DB9F9B73D6FF06");

            entity.Property(e => e.OptData).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.OptFinalizar).HasDefaultValue(false);
            entity.Ignore(e => e.OptIdForMenus);

            entity.HasOne(d => d.Men).WithMany(p => p.Options)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__options__men_id__52593CB8");
        });

        modelBuilder.Entity<Peticao>(entity =>
        {
            entity.HasKey(e => e.PetId).HasName("PK__peticao__390CC5FE19ACA62F");

            entity.Property(e => e.PProcDataCriacao).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Adv).WithMany(p => p.Peticaos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__peticao__adv_id__4316F928");
        });

        modelBuilder.Entity<PreProcesso>(entity =>
        {
            entity.HasKey(e => e.PProcId).HasName("PK__preProce__51C4924F33C63072");

            entity.Property(e => e.PProcDataCriacao).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.PProcDataModificacao).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Adv).WithMany(p => p.PreProcessos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__preProces__adv_i__3E52440B");

            entity.HasOne(d => d.Cli).WithMany(p => p.PreProcessos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__preProces__cli_i__3F466844");
        });

        modelBuilder.Entity<Prompt>(entity =>
        {
            entity.HasKey(e => e.PrompId).HasName("PK__prompt__DC4E349090DCDF23");

            entity.Property(e => e.PrompAtiva).HasDefaultValue(true);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
