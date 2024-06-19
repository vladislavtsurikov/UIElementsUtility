//.........................
//.....Generated File......
//.........................
//.......Do not edit.......
//.........................

using VladislavTsurikov.UIElementsUtility.Runtime.Core.Utility;
using UnityEngine.UIElements;
using VladislavTsurikov.UIElementsUtility.Runtime.Groups.Layouts.Data;

namespace VladislavTsurikov.UIElementsUtility
{
    public static class GetLayout
    {
        public static class Samples
        {
            public enum LayoutName
            {
                Background,
                Dialogue,
                Inventory,
                InventoryItem,
                MainMenuDocument,
                Speedometer
            }

            private static LayoutGroup s_layoutGroup;
            private static VisualTreeAsset s_background;
            private static VisualTreeAsset s_dialogue;
            private static VisualTreeAsset s_inventory;
            private static VisualTreeAsset s_inventoryItem;
            private static VisualTreeAsset s_mainMenuDocument;
            private static VisualTreeAsset s_speedometer;

            private static LayoutGroup LayoutGroup => s_layoutGroup != null ? s_layoutGroup: s_layoutGroup = DataGroupUtility.GetGroup<LayoutGroup, LayoutInfo>("Samples");

            public static VisualTreeAsset Background => s_background ? s_background : s_background = GetVisualTreeAsset(LayoutName.Background);

            public static VisualTreeAsset Dialogue => s_dialogue ? s_dialogue : s_dialogue = GetVisualTreeAsset(LayoutName.Dialogue);

            public static VisualTreeAsset Inventory => s_inventory ? s_inventory : s_inventory = GetVisualTreeAsset(LayoutName.Inventory);

            public static VisualTreeAsset InventoryItem => s_inventoryItem ? s_inventoryItem : s_inventoryItem = GetVisualTreeAsset(LayoutName.InventoryItem);

            public static VisualTreeAsset MainMenuDocument => s_mainMenuDocument ? s_mainMenuDocument : s_mainMenuDocument = GetVisualTreeAsset(LayoutName.MainMenuDocument);

            public static VisualTreeAsset Speedometer => s_speedometer ? s_speedometer : s_speedometer = GetVisualTreeAsset(LayoutName.Speedometer);

            private static VisualTreeAsset GetVisualTreeAsset(LayoutName layoutName)
            {
                return LayoutGroup.GetVisualTreeAsset(layoutName.ToString());
            }
        }
    }
}
