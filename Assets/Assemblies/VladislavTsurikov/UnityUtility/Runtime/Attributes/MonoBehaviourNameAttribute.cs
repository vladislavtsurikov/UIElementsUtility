using System;

namespace VladislavTsurikov.UnityUtility.Runtime.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class MonoBehaviourNameAttribute : Attribute
    {
        public readonly string Name;

        public MonoBehaviourNameAttribute(string name)
        {
            Name = name;
        }
    }
}