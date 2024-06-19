using System;
using UnityEngine.UIElements;

namespace VladislavTsurikov.UIElementsUtility.Runtime.Groups.Styles.Data
{
    [Serializable]
    public class StyleInfo
    {
        public StyleSheet UssReference;

        public StyleInfo()
        {
            UssReference = null;
        }
    }
}