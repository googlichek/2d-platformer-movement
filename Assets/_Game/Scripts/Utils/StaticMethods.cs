using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Utils
{
    public static class StaticMethods
    {
        public static bool EnumEquals<TEnum>(TEnum first, TEnum second) where TEnum : struct
        {
            var firstValueType = first as TEnum?;
            var secondValueType = second as TEnum?;

            return EqualityComparer<TEnum>.Default.Equals(firstValueType.Value, secondValueType.Value);
        }

        public static Vector3 GetResolutionVector()
        {
            var screenWidth = Screen.width;
            var screenHeight = Screen.height;

            var height = Mathf.CeilToInt(screenHeight / 267F);
            var width = Mathf.CeilToInt(screenWidth / 440F);

            if (width > height)
            {
                height = width;
            }

            return new(height, height, 1.0f);
        }
    }
}
