using System.Collections;
using System.Collections.Generic;

public class Item
{
    public string Value { get; set; }
    public Item NextItem { get; set; }

    public Item() 
    {

    }
    public Item(string value)
    {
        Value = value;
    }
}
