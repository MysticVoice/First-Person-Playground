using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Unity.VisualScripting;

namespace MysticVoice
{
    public class AbilityEditorWindow : EditorWindow
    {
        protected ScriptableObject[] abilities;
        protected SerializedObject serializedObject;
        protected SerializedProperty serializedProperty;

        protected ScriptableObject selectedPropertyTemp;
        protected ScriptableObject selectedProperty;

        [MenuItem("Window/GameData/AbilityCreator")]
        protected static void ShowWindow()
        {
            GetWindow<AbilityEditorWindow>("Abilities");
        }

        private void OnGUI()
        {
            abilities = ScriptableObjectGeter.GetAllInstances<Ability>();
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.BeginVertical("box", GUILayout.MinWidth(50),GUILayout.MaxWidth(150), GUILayout.ExpandHeight(true));
            DrawSliderBar(abilities);
            
            EditorGUILayout.EndVertical();
            EditorGUILayout.BeginVertical("box",GUILayout.ExpandHeight(true));
            if (selectedProperty != null)
            {
                for (int i = 0; i < abilities.Length; i++)
                {
                    if (abilities[i] == selectedProperty)
                    {
                        abilities[i].name = EditorGUILayout.TextField(abilities[i].name);
                        serializedObject = new SerializedObject(abilities[i]);
                        
                        serializedProperty = serializedObject.GetIterator();
                        serializedProperty.NextVisible(true);
                        PropertyDrawer.DrawProperties(serializedProperty);
                    }
                }
            }
            else 
            {
                EditorGUILayout.LabelField("select an item from list");
            }
            EditorGUILayout.EndVertical();
            EditorGUILayout.EndHorizontal();
            Apply();
        }

        protected void DrawSliderBar(ScriptableObject[] scriptableObjects)
        {
            foreach (ScriptableObject scriptableObject in scriptableObjects)
            {
                if (GUILayout.Button(scriptableObject.name))
                {
                    selectedPropertyTemp = scriptableObject;
                }
            }
            if (selectedPropertyTemp != null)
            {
                selectedProperty = selectedPropertyTemp;
            }
            if(GUILayout.Button("New Ability"))
            {
                Ability newAbility = ScriptableObject.CreateInstance<SpawnObject>();
                AbilityCreatorWindow newAbilityCreator = GetWindow<AbilityCreatorWindow>("New Ability");
                newAbilityCreator.newAbility = newAbility;
            }
        }

        protected void Apply()
        {
            serializedObject.ApplyModifiedProperties();
        }
    }
}
