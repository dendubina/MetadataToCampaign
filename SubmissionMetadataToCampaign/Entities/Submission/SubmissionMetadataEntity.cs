using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace SubmissionMetadataToCampaign.Entities.Submission;

public class SubmissionMetadataEntity
{
    [Key]
    public Guid Id { get; set; }
    public string MainGenre { get; set; }
    public int? Genre { get; set; }
    public bool IsExplicit { get; set; }
    public List<SubGenreEntity> SubGenres { get; set; }
    public List<SimilarArtistEntity> SimilarArtists { get; set; }
    public List<MoodEntity> Moods { get; set; }
    public List<SongStyleEntity> SongStyles { get; set; }
    public List<LyricsLanguageEntity> LyricsLanguages { get; set; }
    public IEnumerable<int> GeoLocalizations { get; set; }
    public Guid SubmissionId { get; set; }
    public SubmissionEntity Submission { get; set; }
}