using System;
using UnityEngine;
using VladislavTsurikov.Utility.Runtime.Extensions;

namespace VladislavTsurikov.UIElementsUtility.Runtime.Groups.Textures.Data
{
    [Serializable]
    public class TextureInfo
    {
        public string TextureName;
        public Texture2D TextureReference;

        public void ValidateName()
        {
            TextureName = TextureName.RemoveWhitespaces().RemoveAllSpecialCharacters();
        }
    }
}