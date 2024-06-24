using System;
using UnityEngine;

namespace VladislavTsurikov.UIElementsSamples.Runtime.Inventory
{
    [Serializable]
    public class Item
    {
        public string Name = "Item";
        public Sprite Icon;
        public Color Color = Color.white;
    }
}