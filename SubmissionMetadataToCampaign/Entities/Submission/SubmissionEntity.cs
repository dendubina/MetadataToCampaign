using System.ComponentModel.DataAnnotations;

namespace SubmissionMetadataToCampaign.Entities.Submission;

public class SubmissionEntity
{
    [Key]
    public Guid Id { get; set; }
    public SubmissionMetadataEntity Metadata { get; set; }
    public int Status { get; set; }
    public Guid SubmitterId { get; set; }
    public SubmitterEntity Submitter { get; set; }
    public DateTime CreationDate { get; set; }
}