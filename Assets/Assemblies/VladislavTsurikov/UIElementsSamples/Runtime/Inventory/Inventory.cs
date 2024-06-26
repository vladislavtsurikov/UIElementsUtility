using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace VladislavTsurikov.UIElementsSamples.Runtime.Inventory
{
    [CreateAssetMenu(fileName = "Inventory", menuName = "VladislavTsurikov/UIElementsSamples/Inventory")]
    public class Inventory : ScriptableObject
    {
        [SerializeField]
        private List<Item> _items = new List<Item>();

        public IReadOnlyList<Item> Items => _items;

        public Action OnItemsChanged;

        public void AddItem(Item item)
        {
            OnItemsChanged?.Invoke();
            _items.Add(item);
            
#if UNITY_EDITOR
            EditorUtility.SetDirty(this);
#endif
        }
    }
}