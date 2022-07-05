using System.Collections.Generic;

namespace WPF_App.Models;

public class Client
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public List<Address> Addresses { get; set; }
    
}