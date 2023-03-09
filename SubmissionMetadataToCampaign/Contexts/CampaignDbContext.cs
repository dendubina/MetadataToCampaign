using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SubmissionMetadataToCampaign.Entities.Campaign;

namespace SubmissionMetadataToCampaign.Contexts;

internal class CampaignDbContext : DbContext
{
    public DbSet<CampaignEntity> Campaigns { get; set; }
    public DbSet<ClientEntity> Clients { get; set; }

    public CampaignDbContext(DbContextOptions options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ClientEntity>().ToTable("clients", schema: "campaign");
        modelBuilder.Entity<ClientEntity>().Property(x => x.Id).HasColumnName("client_id");
        modelBuilder.Entity<ClientEntity>().Property(x => x.Name).HasColumnName("name");
        modelBuilder.Entity<ClientEntity>().Property(x => x.Email).HasColumnName("email");
        modelBuilder.Entity<ClientEntity>().Property(x => x.ImageUrl).HasColumnName("image_url");

        modelBuilder.Entity<CampaignEntity>().ToTable("campaigns", schema: "campaign");
        modelBuilder.Entity<CampaignEntity>().Property(x => x.ClientId).HasColumnName("client_id");
        modelBuilder.Entity<CampaignEntity>().Property(x => x.Status).HasColumnName("status");
        modelBuilder.Entity<CampaignEntity>().Property(x => x.Id).HasColumnName("campaign_id");
        modelBuilder.Entity<CampaignEntity>().Property(x => x.CreationDate).HasColumnName("creation_date");
        modelBuilder.Entity<CampaignEntity>().Property(t => t.Metadata).HasColumnName("metadata").HasColumnType("jsonb");
            
    }
}