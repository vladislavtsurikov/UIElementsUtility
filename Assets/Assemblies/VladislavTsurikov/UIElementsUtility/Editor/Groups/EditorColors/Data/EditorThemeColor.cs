#if UNITY_EDITOR
using System;
using UnityEditor;

namespace VladislavTsurikov.UIElementsUtility.Editor.Groups.EditorColors.Data
{
    [Serializable]
    public class EditorThemeColor : ThemeColor
    {
        public override bool IsDarkTheme => EditorGUIUtility.isProSkin;
    }
}
#endif
