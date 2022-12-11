using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace MysticVoice
{
    public static class PropertyDrawer
    {
        public static void DrawProperties(SerializedProperty p)
        {

            while (p.NextVisible(false))
            {
                EditorGUILayout.PropertyField(p, true);

            }
        }
    }
}
