#if !DISABLE_VISUAL_ELEMENTS
using UnityEngine;
using UnityEngine.UIElements;
using VladislavTsurikov.UIElementsSamples.Runtime.Content.Inventory.Scripts;
using VladislavTsurikov.UIElementsUtility.Runtime.Groups.Layouts.Data;

namespace VladislavTsurikov.UIElementsSamples.Runtime.Inventory.Controllers
{
    [ExecuteInEditMode]
    public class InventoryController : MonoBehaviour
    {
        [SerializeField] 
        private UIDocument _uiDocument;
        
        [SerializeField] 
        private Content.Inventory.Scripts.Inventory _inventory;

        private InventoryView _view;
        
        [SerializeField] 
        private LayoutGroup _layoutGroup;

        private void OnEnable()
        {
            if (!_uiDocument.isActiveAndEnabled || _uiDocument.rootVisualElement == null)
            {
                return;
            }
            
            _view ??= new InventoryView(_inventory);
            
            InstantiateView();
        }

        private void OnDisable()
        {
            if (_view == null)
            {
                return;
            }
            
            _view.RemoveFromHierarchy();
        }

        private void InstantiateView()
        {
            _uiDocument.rootVisualElement.Add(_view);
        }
    }
}
#endif