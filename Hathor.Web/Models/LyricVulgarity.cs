﻿namespace Hathor.Web.Models
{
    public enum LyricVulgarity : sbyte
    {
        Unknown = -1,
        Clean = 0,
        Dirty = sbyte.MaxValue // 127
    }
}
