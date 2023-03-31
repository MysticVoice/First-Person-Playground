using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MysticVoice
{
    using UnityEngine;
    using UnityEditor;



    public class AbilityCreatorWindow : EditorWindow
    {
        private SerializedObject serializedObject;
        private SerializedProperty serializedProperty;

        protected Ability[] abilities;
        public Ability newAbility;
        
        

        private void OnGUI()
        {

            serializedObject = new SerializedObject(newAbility);
            serializedProperty = serializedObject.GetIterator();
            serializedProperty.NextVisible(true);
            PropertyDrawer.DrawProperties(serializedProperty);
            if (GUILayout.Button("save"))
            {
                abilities = ScriptableObjectGeter.GetAllInstances<Ability>();
                newAbility.name = "Ability" + (abilities.Length + 1);
                AssetDatabase.CreateAsset(newAbility, "Assets/Scripts/Abilities/ScriptableObjects/" + newAbility.name + ".asset");
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();
                Close();
            }

            Apply();
        }
        protected void Apply()
        {
            serializedObject.ApplyModifiedProperties();
        }
    }
}
