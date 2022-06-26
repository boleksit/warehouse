﻿namespace warehouse.Entities;

public class StatusEntity
{
    public int Id { get; set; }
    public string Name { get; set; }

    public StatusEntity(string name)
    {
        Name = name;
    }
}