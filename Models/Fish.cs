using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace dotnet_rpg.Models
{
    public class Fish
    {
        [Key] // This attribute specifies that the Id property is the primary key
        public int Id { get; set; }

        [Required] // This attribute specifies that the Name property is required
        public string Name { get; set; }

        // Other properties specific to your Fish model

        // Navigation properties, if any
    }
}
