#if !DISABLE_VISUAL_ELEMENTS
using UnityEngine;
using UnityEngine.UIElements;
using VladislavTsurikov.UIElementsUtility;
using VladislavTsurikov.UIElementsUtility.Runtime;

namespace VladislavTsurikov.UIElementsSamples.Runtime.Inventory
{
    public class InventoryView : VisualElement
    {
        public new class UxmlFactory : UxmlFactory<InventoryView, UxmlTraits> { }
        public new class UxmlTraits : VisualElement.UxmlTraits { }

        private Inventory _model;
        public Inventory Model 
        {
            get => _model;
            set
            {
                if (_model != value)
                {
                    _model = value;
                    _model.OnItemsChanged += OnItemsChanged;
                    UpdateItemsGrid();
                }
            }
        }

        public TemplateContainer TemplateContainer { get; }
        public VisualElement ItemsGrid { get; }

        public InventoryView()
        {
            Add(TemplateContainer = GetLayout.Samples.Inventory.CloneTree());

            ItemsGrid = TemplateContainer.Q<VisualElement>(nameof(ItemsGrid));
            
            SetSizeAsParentElement(); 
        }

        public InventoryView(Inventory model) : this()
        {
            Model = model;
            Model.OnItemsChanged += OnItemsChanged;
            UpdateItemsGrid();
        }

        private void OnItemsChanged()
        {
            UpdateItemsGrid();
        }

        private void UpdateItemsGrid()
        {
            ItemsGrid.Clear();

            foreach (var item in Model.Items)
            {
                InventoryItemView inventoryItemView = new InventoryItemView()
                    .ChangeImage(item.Icon)
                    .ChangeImageTintColor(item.Color);
                
                inventoryItemView.Button.clicked += () => Debug.Log($"Item {item.Name} clicked");
                
                ItemsGrid.Add(inventoryItemView);
            }
        }

        private void SetSizeAsParentElement()
        {
            Length length = new Length(100, LengthUnit.Percent);
        
            style.minHeight = length;
            style.maxHeight = length;
        
            style.maxWidth = length;
            style.minWidth = length;
        
            TemplateContainer.style.minHeight = length;
            TemplateContainer.style.maxHeight = length;
        
            TemplateContainer.style.maxWidth = length;
            TemplateContainer.style.minWidth = length;
        }
    }
}
#endif