using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SubmissionMetadataToCampaign.Entities.Campaign;

public class CampaignEntity
{
    [Key]
    public Guid Id { get; set; }
    public Guid ClientId { get; set; }
    public int Status { get; set; }
    public DateTime CreationDate { get; set; }
    public CampaignMetadata? Metadata { get; set; }
    public ClientEntity Client { get; set; }
}