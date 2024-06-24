#if !DISABLE_VISUAL_ELEMENTS
using UnityEngine;
using UnityEngine.UIElements;
using VladislavTsurikov.UIElementsUtility.Runtime.Groups.Layouts;

namespace VladislavTsurikov.UIElementsSamples.Runtime.Dialogue
{
    [ExecuteInEditMode]
    public class DialogueController : MonoBehaviour
    {
        [SerializeField] 
        private UIDocument _uiDocument;

        private DialogueView _dialogueView;
        
        [SerializeField] 
        private LayoutGroup _layoutGroup;

        private void OnEnable()
        {
            if (!_uiDocument.isActiveAndEnabled || _uiDocument.rootVisualElement == null)
            {
                return;
            }
            
            _dialogueView ??= new DialogueView();
            
            InstantiateView();
        }

        private void OnDisable()
        {
            if (_dialogueView == null)
            {
                return;
            }
            
            _dialogueView.RemoveFromHierarchy();
        }

        private void InstantiateView()
        {
            _uiDocument.rootVisualElement.Add(_dialogueView);
        }
    }
}
#endif