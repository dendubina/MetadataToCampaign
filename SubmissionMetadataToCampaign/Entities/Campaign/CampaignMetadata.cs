using System.ComponentModel.DataAnnotations;

namespace SubmissionMetadataToCampaign.Entities.Campaign;

public class CampaignMetadata
{
    [Key]
    public Guid? Id { get; set; }
    public string MainGenre { get; set; }
    public int? Genre { get; set; }
    public List<SubGenreEntity> SubGenres { get; set; }
    public List<SimilarArtistEntity> SimilarArtists { get; set; }
    public List<MoodEntity> Moods { get; set; }
    public List<SongStyleEntity> SongStyles { get; set; }
    public List<LyricsLanguageEntity> LyricsLanguages { get; set; }
}