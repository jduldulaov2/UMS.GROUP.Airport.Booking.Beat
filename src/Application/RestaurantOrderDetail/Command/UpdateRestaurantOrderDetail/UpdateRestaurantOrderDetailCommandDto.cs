﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class UpdateRestaurantOrderDetailCommandDto
{
    public string? Id { get; set; }

    public DateTime UpdatedDate { get; set; }

    public int? PrimaryId { get; set; }
}

