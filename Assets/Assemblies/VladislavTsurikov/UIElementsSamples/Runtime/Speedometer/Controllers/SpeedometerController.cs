#if !DISABLE_VISUAL_ELEMENTS
using UnityEngine;
using UnityEngine.UIElements;
using VladislavTsurikov.UIElementsSamples.Runtime.Speedometer.Views;

namespace VladislavTsurikov.UIElementsSamples.Runtime.Speedometer.Controllers
{
    [ExecuteInEditMode]
    public class SpeedometerController : MonoBehaviour
    {
        [SerializeField] 
        private UIDocument _uiDocument;
        
        private SpeedometerView _view;

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