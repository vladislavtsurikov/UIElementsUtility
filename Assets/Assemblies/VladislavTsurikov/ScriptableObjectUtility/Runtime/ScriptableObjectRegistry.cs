using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using VladislavTsurikov.ScriptableObjectUtility.Editor;
using UnityEditor;
#endif

namespace VladislavTsurikov.ScriptableObjectUtility.Runtime
{
    public class ScriptableObjectRegistry<T> : ScriptableObject
#if UNITY_EDITOR
        , IOnEditorDestroy 
#endif
        where T : ScriptableObject
    {
        private static List<T> _allInstances;
        public static List<T> AllInstances
        {
            get
            {
                if (_allInstances == null)
                {
#if UNITY_EDITOR
                    FindAllScriptableObject();
#endif
                }
                
                return _allInstances;
            }
        } 
        

        private static HashSet<int> _addedInstanceIDs = new HashSet<int>(); 
        
#if UNITY_EDITOR
        void IOnEditorDestroy.OnEditorDestroy()
        {
            OnDisable();
        }
        
        private static void FindAllScriptableObject()
        {
            _allInstances = new List<T>(); 
            
            var guids = AssetDatabase.FindAssets($"t:{typeof(T).Name}");

            foreach (var guid in guids)
            {
                var path = AssetDatabase.GUIDToAssetPath(guid);
                var instance = AssetDatabase.LoadAssetAtPath<T>(path);
                AddInstance(instance);
            }
        }
#endif

        private void OnEnable()
        {
            if (_allInstances == null)
            {
#if UNITY_EDITOR
                FindAllScriptableObject();
#endif
            }
            
            AddInstance(this as T);
        }

        private void OnDisable()
        {
            AllInstances.Remove(this as T);

            var instanceID = GetInstanceID();
            if (_addedInstanceIDs.Contains(instanceID))
            {
                _addedInstanceIDs.Remove(instanceID);
            }
        }
        
        private static void AddInstance(T instance)
        {
            if (instance == null)
            {
                return;
            }

            var instanceID = instance.GetInstanceID();
            if (!_addedInstanceIDs.Contains(instanceID))
            {
                _addedInstanceIDs.Add(instanceID);
                _allInstances.Add(instance);
            }
        }
    }
}