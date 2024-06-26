#if !DISABLE_VISUAL_ELEMENTS
using UnityEngine;
using UnityEngine.UIElements;
using VladislavTsurikov.UIElementsUtility.Runtime.Groups.Layouts;

namespace VladislavTsurikov.UIElementsSamples.Runtime.Speedometer
{
    [ExecuteInEditMode]
    public class SpeedometerController : MonoBehaviour
    {
        [SerializeField] 
        private UIDocument _uiDocument;
        
        private SpeedometerView _view;
        
        
        [SerializeField] 
        private LayoutGroup _layoutGroup;
        
        private void OnEnable()
        {
            if (!_uiDocument.isActiveAndEnabled || _uiDocument.rootVisualElement == null)
            {
                return;
            }
            
            _view ??= new SpeedometerView();
            
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