namespace SubmissionMetadataToCampaign.Contexts;

using Microsoft.EntityFrameworkCore;
using Entities.Submission;

public class SubmissionDbContext : DbContext
{
    public SubmissionDbContext(DbContextOptions options)
        : base(options)
    {
    }

    public DbSet<SubmissionEntity> Submissions { get; set; }
    public DbSet<SubmissionMetadataEntity> SubmissionsMetadata { get; set; }
    public DbSet<SubmitterEntity> Submitters { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region Submission

        modelBuilder.Entity<SubmissionEntity>().ToTable("submissions", schema: "submission");
        modelBuilder.Entity<SubmissionEntity>().Property(s => s.Id).HasColumnName("submission_id");
        modelBuilder.Entity<SubmissionEntity>().Property(s => s.SubmitterId).HasColumnName("submitter_id");
        modelBuilder.Entity<SubmissionEntity>().Property(s => s.Status).HasColumnName("status");
        modelBuilder.Entity<SubmissionEntity>().Property(s => s.CreationDate).HasColumnName("creation_date");

        #endregion

        modelBuilder.Entity<SubmitterEntity>().ToTable("submitters", schema: "submission");
        modelBuilder.Entity<SubmitterEntity>().Property(s => s.Id).HasColumnName("submitter_id");
        modelBuilder.Entity<SubmitterEntity>().Property(s => s.Name).HasColumnName("name");
        modelBuilder.Entity<SubmitterEntity>().Property(s => s.Email).HasColumnName("email");
        modelBuilder.Entity<SubmitterEntity>().Property(s => s.ImageUrl).HasColumnName("image_url");

        #region SubmissionMetadata

        modelBuilder.Entity<SubmissionMetadataEntity>().ToTable("submission_metadata", schema: "submission");
        modelBuilder.Entity<SubmissionMetadataEntity>().Property(m => m.Id).HasColumnName("submission_metadata_id");
        modelBuilder.Entity<SubmissionMetadataEntity>().Property(m => m.SubmissionId).HasColumnName("submission_id");
        modelBuilder.Entity<SubmissionMetadataEntity>().Property(m => m.IsExplicit).HasColumnName("is_explicit");
        modelBuilder.Entity<SubmissionMetadataEntity>().Property(m => m.GeoLocalizations)
            .HasColumnName("geo_localizations").HasColumnType("jsonb");
        modelBuilder.Entity<SubmissionMetadataEntity>().Property(m => m.MainGenre).HasColumnName("main_genre");
        modelBuilder.Entity<SubmissionMetadataEntity>().Property(m => m.Genre).HasColumnName("genre");
        modelBuilder.Entity<SubmissionMetadataEntity>().Property(m => m.SubGenres).HasColumnName("sub_genres")
            .HasColumnType("jsonb");
        modelBuilder.Entity<SubmissionMetadataEntity>().Property(m => m.SimilarArtists).HasColumnName("similar_artists")
            .HasColumnType("jsonb");
        modelBuilder.Entity<SubmissionMetadataEntity>().Property(m => m.Moods).HasColumnName("moods")
            .HasColumnType("jsonb");
        modelBuilder.Entity<SubmissionMetadataEntity>().Property(m => m.SongStyles).HasColumnName("song_styles")
            .HasColumnType("jsonb");
        modelBuilder.Entity<SubmissionMetadataEntity>().Property(m => m.LyricsLanguages)
            .HasColumnName("lyrics_languages").HasColumnType("jsonb");

        #endregion


        #region Relations

        modelBuilder.Entity<SubmissionEntity>()
            .HasOne(s => s.Metadata)
            .WithOne(sm => sm.Submission)
            .HasForeignKey<SubmissionMetadataEntity>(sm => sm.SubmissionId);

        modelBuilder.Entity<SubmissionEntity>()
            .HasOne(s => s.Submitter)
            .WithMany(s => s.Submissions)
            .HasForeignKey(s => s.SubmitterId);

        #endregion
    }
}