#if !DISABLE_VISUAL_ELEMENTS
using UnityEngine;
using UnityEngine.UIElements;
using VladislavTsurikov.UIElementsUtility;
using VladislavTsurikov.UIElementsUtility.Runtime;

namespace VladislavTsurikov.UIElementsSamples.Runtime.Inventory
{
    public class InventoryItemView : VisualElement
    {
        public new class UxmlFactory : UxmlFactory<InventoryItemView, UxmlTraits> { }
        public new class UxmlTraits : VisualElement.UxmlTraits { }
    
        public TemplateContainer TemplateContainer { get; }
        public Button Button { get; }
        public VisualElement Icon { get; }
    
        public InventoryItemView()
        {
            Add(TemplateContainer = GetLayout.Samples.InventoryItem.CloneTree());
        
            Button = TemplateContainer.Q<Button>();
            Icon = TemplateContainer.Q<VisualElement>(nameof(Icon));
        }
    }

    public static class InventoryItemExtensions
    {
        public static InventoryItemView ChangeImage(this InventoryItemView target, Sprite icon)
        {
            target.Icon.style.backgroundImage = new StyleBackground(icon);
            return target;
        }

        public static InventoryItemView ChangeImageTintColor(this InventoryItemView target, Color color)
        {
            target.Icon.style.unityBackgroundImageTintColor = color;
            return target;
        }
    }
#endif
}