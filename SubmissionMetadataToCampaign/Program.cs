using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SubmissionMetadataToCampaign.Contexts;
using SubmissionMetadataToCampaign.Entities.Campaign;

namespace SubmissionMetadataToCampaign;

internal class Program
{
    static async Task Main(string[] args)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("config.json", optional: false, reloadOnChange: false)
            .Build();

        var campaignOptions = new DbContextOptionsBuilder()
            .UseNpgsql(config.GetConnectionString("Campaign")).Options;
        var submissionOptions = new DbContextOptionsBuilder()
            .UseNpgsql(config.GetConnectionString("Submission")).Options;

        var campaignContext = new CampaignDbContext(campaignOptions);
        var submissionContext = new SubmissionDbContext(submissionOptions);

        var submissions = submissionContext.Submissions
            .Include(x => x.Metadata)
            .Where(x => x.Metadata != null)
            .ToList();

        var campaigns = campaignContext.Campaigns
            .Where(x => submissions.Select(s => s.Id).Any(f => f == x.Id))
            .ToList();

        foreach (var campaignEntity in campaigns)
        {
            var submission = submissions.First(x => x.Id == campaignEntity.Id);

            campaignEntity.Metadata = new CampaignMetadataEntity
            {
                Id = submission.Metadata.Id,
                Genre = submission.Metadata.Genre,
                MainGenre = submission.Metadata.MainGenre,
                LyricsLanguages = submission.Metadata.LyricsLanguages,
                Moods = submission.Metadata.Moods,
                SimilarArtists = submission.Metadata.SimilarArtists,
                SongStyles = submission.Metadata.SongStyles,
                SubGenres = submission.Metadata.SubGenres,
            };
        }

        await campaignContext.SaveChangesAsync();
        Console.WriteLine($"Updated {campaigns.Count} campaigns");
    }
}