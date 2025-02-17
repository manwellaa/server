﻿using System;
using System.ComponentModel.DataAnnotations;
using Bit.Core.Utilities;

namespace Bit.Core.Models.Table
{
    public class Installation : ITableObject<Guid>
    {
        public Guid Id { get; set; }
        [MaxLength(256)]
        public string Email { get; set; }
        [MaxLength(150)]
        public string Key { get; set; }
        public bool Enabled { get; set; }
        public DateTime CreationDate { get; internal set; } = DateTime.UtcNow;

        public void SetNewId()
        {
            Id = CoreHelpers.GenerateComb();
        }
    }
}
