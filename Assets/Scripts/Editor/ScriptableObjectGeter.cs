using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace MysticVoice
{
    public static class ScriptableObjectGeter
    {
        public static T[] GetAllInstances<T>() where T : ScriptableObject
        {
            string[] guids = AssetDatabase.FindAssets("t:" + typeof(T).Name);
            T[] instances = new T[guids.Length];
            for (int i = 0; i < guids.Length; i++)
            {
                string path = AssetDatabase.GUIDToAssetPath(guids[i]);
                instances[i] = AssetDatabase.LoadAssetAtPath<T>(path);
            }
            return instances;
        }
    }
}
