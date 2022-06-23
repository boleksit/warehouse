﻿using System.ComponentModel.DataAnnotations;

namespace warehouse;

public class Box
{
    public int Id { get; set; }
    [Required]
    [Range(1,100)]
    public int Length { get; set; }
    [Required]
    [Range(1,100)]
    public int Width { get; set; }
    [Required]
    [Range(1,100)]
    public int Height { get; set; }
    public int ClientId { get; set; }
    public int AddressId { get; set; }
}