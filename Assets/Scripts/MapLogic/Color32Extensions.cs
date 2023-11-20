﻿using UnityEngine;

namespace MapLogic
{
    public static class Color32Extensions
    {
        public static bool IsEquals(this Color32 firstColor, Color32 secondColor)
        {
            return firstColor.r == secondColor.r && firstColor.g == secondColor.g && firstColor.b == secondColor.b &&
                   firstColor.a == secondColor.a;
        }

        public static bool IsSolid(this Color32 color)
        {
            return !IsEquals(color, BlockColor.empty);
        }
    }
}