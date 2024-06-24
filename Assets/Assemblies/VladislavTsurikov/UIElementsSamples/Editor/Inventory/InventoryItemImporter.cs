#if UNITY_EDITOR
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;
using VladislavTsurikov.UIElementsSamples.Runtime.Inventory;

namespace VladislavTsurikov.UIElementsSamples.Editor.Inventory
{
    public static class InventoryItemImporter
    {
        [MenuItem("Tools/Vladislav Tsurikov/Inventory/Inventory Item Importer")]
        private static void CreateInventoryItemFromSprites()
        {
            Runtime.Inventory.Inventory inventory = GetInventory();
            if (inventory == null)
            {
                return;
            }

            string spriteFolderPath = GetSpriteFolderPath();
            if (spriteFolderPath == null)
            {
                return;
            }

            string[] texturePaths = Directory.GetFiles(spriteFolderPath, "*.png", SearchOption.AllDirectories)
                .Concat(Directory.GetFiles(spriteFolderPath, "*.jpg", SearchOption.AllDirectories))
                .ToArray();

            foreach (string texturePath  in texturePaths)
            {
                string assetPath = "Assets" + texturePath .Replace('\\', '/').Substring(Application.dataPath.Length);

                Object[] assets = AssetDatabase.LoadAllAssetsAtPath(assetPath);

                foreach (Object asset in assets)
                {
                    Sprite sprite = asset as Sprite;
                    if (sprite == null)
                    {
                        continue;
                    }

                    Item itemData = new Item
                    {
                        Name = Path.GetFileNameWithoutExtension(texturePath),
                        Icon = sprite,
                        Color = new Color(Random.value, Random.value, Random.value)
                    };

                    inventory.AddItem(itemData);
                }
            }
        }
        
        private static Runtime.Inventory.Inventory GetInventory()
        {
            Runtime.Inventory.Inventory inventory = null;
            while (inventory == null)
            {
                string path = EditorUtility.OpenFilePanel("Select Inventory", "Assets", "asset");
                if (path.Length == 0)
                {
                    Debug.Log("Canceled");
                    return null;
                }

                string assetPath = "Assets" + path.Substring(Application.dataPath.Length);
                Object assetObject = AssetDatabase.LoadAssetAtPath(assetPath, typeof(Object));
                inventory = assetObject as Runtime.Inventory.Inventory;

                if (inventory == null)
                {
                    Debug.Log("Selected file is not an Inventory. Please select another file.");
                }
            }

            Debug.Log("Selected Inventory: " + inventory.name);
            return inventory;
        }
        
        private static string GetSpriteFolderPath()
        {
            string path = "Assets";
            while (true)
            {
                path = EditorUtility.OpenFolderPanel("Select Sprite Folder", path, "");
                if (path.Length == 0)
                {
                    Debug.Log("Canceled");
                    return null;
                }

                if (Directory.GetFiles(path, "*.png").Length > 0 ||
                    Directory.GetFiles(path, "*.jpg").Length > 0)
                {
                    Debug.Log("Selected Folder: " + path);
                    return path;
                }

                Debug.Log("No sprites found in the selected folder. Please select another folder.");
            }
        }
    }
}
#endif