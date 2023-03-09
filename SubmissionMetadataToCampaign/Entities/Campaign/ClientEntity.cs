using System.ComponentModel.DataAnnotations;

namespace SubmissionMetadataToCampaign.Entities.Campaign;

public class ClientEntity
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string ImageUrl { get; set; }
    public List<CampaignEntity> Campaigns { get; set; }
}