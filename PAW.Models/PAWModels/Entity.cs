﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAW.Models
{
    public interface IEntity
    {
        int? TempID { get; set; }
        bool? IsDirty { get; set; }
        string? ModifiedBy { get; set; }
        string? CreatedBy { get; set; }
        DateTime? ModifiedDate { get; set; }
        DateTime? CreatedDate { get; set; }
    }

    public class Entity : IEntity
    {
        [NotMapped]
        public int? TempID { get; set; }
        [NotMapped]
        public string? ModifiedBy { get; set; }
        [NotMapped]
        public string? CreatedBy { get; set; }
        [NotMapped]
        public DateTime? ModifiedDate { get; set; }
        [NotMapped]
        public DateTime? CreatedDate { get; set; }
        [NotMapped]
        public bool? IsDirty { get; set; }
    }
}
