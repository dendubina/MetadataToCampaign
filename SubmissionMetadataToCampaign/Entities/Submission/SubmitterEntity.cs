using System.ComponentModel.DataAnnotations;

namespace SubmissionMetadataToCampaign.Entities.Submission;

public class SubmitterEntity
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string ImageUrl { get; set; }
    public List<SubmissionEntity> Submissions { get; set; }
}