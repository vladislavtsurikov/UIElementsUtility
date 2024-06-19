#if !DISABLE_VISUAL_ELEMENTS
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using VladislavTsurikov.UIElementsUtility;
using VladislavTsurikov.UIElementsUtility.Runtime.Utility;

public class DialogueView : VisualElement
{
    public new class UxmlFactory : UxmlFactory<DialogueView, UxmlTraits> { }
    public new class UxmlTraits : VisualElement.UxmlTraits
    {
        private UxmlStringAttributeDescription _characterName = new UxmlStringAttributeDescription { name = "character-name", defaultValue = "Character Name" };
        private UxmlStringAttributeDescription _message = new UxmlStringAttributeDescription { name = "message", defaultValue = "Message" };

        public override IEnumerable<UxmlChildElementDescription> uxmlChildElementsDescription
        {
            get { yield break; }
        }

        public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext context)
        {
            var dialogue = (DialogueView)ve; 
            
            dialogue.CharacterName.text = _characterName.GetValueFromBag(bag, context);
            dialogue.Message.text = _message.GetValueFromBag(bag, context);
        }
    }
    
    public TemplateContainer TemplateContainer { get; }
    public Label CharacterName { get; }
    public Label Message { get; }
    public VisualElement CharacterAvatar { get; }
    
    public DialogueView()
    {
        Add(TemplateContainer = GetLayout.Samples.Dialogue.CloneTree());

        CharacterName = TemplateContainer.Q<Label>(nameof(CharacterName));
        Message = TemplateContainer.Q<Label>(nameof(Message));
        CharacterAvatar = TemplateContainer.Q<Label>(nameof(CharacterAvatar));
        
        SetSizeAsParentElement();
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

public static class DialogueViewExtensions
{
    public static void ChangeCharacterAvatar(this DialogueView dialogueView, Texture2D texture2D)
    {
        dialogueView.CharacterAvatar.SetStyleBackgroundImage(texture2D);
    }
}
#endif