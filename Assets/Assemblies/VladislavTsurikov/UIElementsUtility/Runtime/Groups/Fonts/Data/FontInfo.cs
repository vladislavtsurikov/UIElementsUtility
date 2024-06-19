using System;
using UnityEngine;
using VladislavTsurikov.UIElementsUtility.Runtime.Groups.Fonts.Enums;

namespace VladislavTsurikov.UIElementsUtility.Runtime.Groups.Fonts.Data
{
    [Serializable]
    public class FontInfo
    {
        public Font Font;
        public GenericFontWeight Weight;

        public FontInfo()
        {
            Font = null;
            Weight = GenericFontWeight.Regular;
        }
    }
}