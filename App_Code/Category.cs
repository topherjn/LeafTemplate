using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Category
/// </summary>
public class Category
{
    public string Name { get; set; }
    public string Group { get; set; }

    public Category(string name, string group)
    {
        this.Name = name;
        this.Group = group;
    }

    public override string ToString()
    {
        return Name;
    }
}