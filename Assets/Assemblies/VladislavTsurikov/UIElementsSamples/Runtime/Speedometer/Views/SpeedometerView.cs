#if !DISABLE_VISUAL_ELEMENTS
using System.Collections.Generic;
using UnityEngine.UIElements;
using VladislavTsurikov.UIElementsUtility;
using VladislavTsurikov.UIElementsUtility.Runtime;

namespace VladislavTsurikov.UIElementsSamples.Runtime.Speedometer
{
    public class SpeedometerView : VisualElement
    {
        public new class UxmlFactory : UxmlFactory<SpeedometerView, UxmlTraits> { }
        public new class UxmlTraits : VisualElement.UxmlTraits
        {
            private UxmlIntAttributeDescription _speed = new UxmlIntAttributeDescription { name = "Speed", defaultValue = 132 };

            public override IEnumerable<UxmlChildElementDescription> uxmlChildElementsDescription
            {
                get { yield break; }
            }

            public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext context)
            {
                var target = (SpeedometerView)ve; 
            
                target.Speed.text = _speed.GetValueFromBag(bag, context).ToString();
            }
        }
    
        public TemplateContainer TemplateContainer { get; }
        public Label Speed { get; }
        public VisualElement Background { get; }
    
        public SpeedometerView()
        {
            Add(TemplateContainer = GetLayout.Samples.Speedometer.CloneTree());

            Speed = TemplateContainer.Q<Label>(nameof(Speed));
            Background = TemplateContainer.Q<VisualElement>(nameof(Background));

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
}
#endif