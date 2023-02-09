using System;
using System.Collections.Generic;

namespace webapi.Models;

public partial class Todo
{
    public int TodoId { get; set; }

    public string? Subject { get; set; }

    public string? Description { get; set; }
}
