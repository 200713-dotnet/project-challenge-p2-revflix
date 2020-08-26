using System.Collections.Generic;

namespace RevFlix.Service.Models
{
  public class UResponseModel
  {
    // public List<UCollectionModel> Collection { get; set; }
    public List<UCollectionModel> Collection { get; set; }
    public string Id { get; set; }
    public int Status_Code { get; set; }
    public string Type { get; set; }
    public string Variant { get; set; }
  }
}