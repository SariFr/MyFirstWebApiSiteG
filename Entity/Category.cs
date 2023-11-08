using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Entity;

public partial class Category
{
    public int CategoryId { get; set; }

    public string Name { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<Product>? Products { get; set; } = new List<Product>();
}
