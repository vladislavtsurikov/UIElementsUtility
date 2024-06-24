# **UIElements Utility**

UIElements Utility - a package that makes it easier to retrieve data for the UI, which also caches previously retrieved data. This works by generating a static class for a specific ScriptableObject with data. You can get textures, colors, fonts, styles, etc. this way, this allows you to simplify programming and not have to keep references to these files in components with logic, how your interface is drawn. This framework is especially useful for programming complex interfaces for Editor. Works both Runtime and Editor

## **Getting Started**
1. Go to the folder "Assets/Assemblies/VladislavTsurikov/UIElementsSamples/Content".
2. Create a LayoutGroup, click Create/VladislavTsurikov/UIElementsUtility/Layout Group (UXML).
3. In the Inspector of this LayoutGroup, select a name for the GroupName, any one.
4. Also in the Inspector, find the Setup button, clicking this button finds all the files in the folder where this ScriptableObject is located, as well as in subfolders. This will also rename the LayoutGroup, adding a word from GroupName.
5. Сlick on "Tools/Vladislav Tsurikov/UIElementsUtility/Generate API". This will generate you a static class for the created LayoutGroup. Finding the generated class: Assets\Assemblies\VladislavTsurikov\UIElementsUtility\Runtime\API\GetLayout.cs.

The following file will be generated:
  
```csharp
    public static class GetLayout
    {
        public static class Samples
        {
            public enum LayoutName
            {
                Inventory,
                InventoryItem,
                Speedometer
            }

            private static LayoutGroup s_layoutGroup;
            private static VisualTreeAsset s_inventory;
            private static VisualTreeAsset s_inventoryItem;
            private static VisualTreeAsset s_speedometer;

            private static LayoutGroup LayoutGroup => s_layoutGroup != null ? s_layoutGroup: s_layoutGroup = DataGroupUtility.GetGroup<LayoutGroup, LayoutInfo>("Samples");

            public static VisualTreeAsset Inventory => s_inventory ? s_inventory : s_inventory = GetVisualTreeAsset(LayoutName.Inventory);

            public static VisualTreeAsset InventoryItem => s_inventoryItem ? s_inventoryItem : s_inventoryItem = GetVisualTreeAsset(LayoutName.InventoryItem);

            public static VisualTreeAsset Speedometer => s_speedometer ? s_speedometer : s_speedometer = GetVisualTreeAsset(LayoutName.Speedometer);

            private static VisualTreeAsset GetVisualTreeAsset(LayoutName layoutName)
            {
                return LayoutGroup.GetVisualTreeAsset(layoutName.ToString());
            }
        }
    }
```

You can use the generated class to draw an Inventory without writing additional code where you would have to call the loading of a resource from a specific folder, and also write support for caching the file so as not to load it again:
  
<details>
  <summary>Click to view the code</summary>

  ```csharp
  public class InventoryView : VisualElement
    {
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
    }
```
</details> 

## Support groups

* EditorColors
* Fonts
* Layouts
* Styles
* Textures

# Editor examples

<div style="display: flex;">
  <img src="https://github.com/vladislavtsurikov/UIElementsUtility/assets/76901538/5dd7da87-6517-4a7b-a37b-ba920e4bc68a" width="400">
  <img src="https://github.com/vladislavtsurikov/UIElementsUtility/assets/76901538/cf66b25f-f8b1-4368-af78-c0a01a374bb1" width="400">
</div>

# Runtime examples

You can find these examples in Assets/Assemblies/VladislavTsurikov/UIElementsSamples/Scenes

### Main Menu Scene
 Features buttons with mouse interactions (hover, selected, highlighted). In this example, you can also see how to determine which button the player pressed

![Main Menu Scene](https://github.com/vladislavtsurikov/UIElementsUtility/assets/76901538/28bb6122-1b8f-445e-882d-b453d5415f67)


### Inventory Scene
 Features codes to instantiate items slots dynamically using a list of scriptable objects. This example also shows how you can use the MVC pattern for UIElements

![Inventory Scene](https://github.com/vladislavtsurikov/UIElementsUtility/assets/76901538/b297ede7-ecc9-439f-9394-8df5f3d0bc0b)


### Dialogue Scene
 Features world space UIDocument created in UIElementsUtility

![Dialogue Scene](https://github.com/vladislavtsurikov/UIElementsUtility/assets/76901538/c28e0206-a888-4c74-906b-022750c242f7)


### Speedometer Scene
 Features a circular speed bar made with a custom shader

![Image Sequence_004_0000](https://github.com/vladislavtsurikov/UIElementsUtility/assets/76901538/003d4d14-f855-42ec-b4bf-ad93677d07f1)
