﻿using Microsoft.EntityFrameworkCore;

namespace ExaminationSystem.Models
{
    [Owned]
    public class RefreshToken
    {
        public string Token { get; set; } = null!;
        public DateTime ExpiredOn { get; set; }
        public bool IsExpired => DateTime.UtcNow >= ExpiredOn;
        public DateTime CreatedOn { get; set; }
        public DateTime? RevokedOn { get; set; }
        public bool IsDeleted => RevokedOn is null || !IsExpired;
    }
}
