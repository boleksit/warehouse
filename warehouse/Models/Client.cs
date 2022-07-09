namespace warehouse;

/// <summary>
/// Client model
/// </summary>
public class Client
{
    /// <summary>
    /// Id
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Name
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Email
    /// </summary>
    public string Email { get; set; }
    /// <summary>
    /// Phone
    /// </summary>
    public string Phone { get; set; }
    /// <summary>
    /// Address list
    /// </summary>
    public List<Address> Addresses { get; set; }
    
}