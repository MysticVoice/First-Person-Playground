using MysticVoice;
using UnityEditor;
using UnityEngine;

//[CustomEditor(typeof(LootTable))]
public class LootTableEditor : EditorWindow
{
    private LootTable lootTable;

    [MenuItem("Window/Loot Table Editor")]
    static void ShowWindow()
    {
        LootTableEditor window = (LootTableEditor)EditorWindow.GetWindow(typeof(LootTableEditor));
        window.Show();
    }

    private void OnGUI()
    {
        if (GUILayout.Button("Create Loot Table"))
        {
            lootTable = ScriptableObject.CreateInstance<LootTable>();
            AssetDatabase.CreateAsset(lootTable, "Assets/NewLootTable.asset");
            AssetDatabase.SaveAssets();
        }

        lootTable = (LootTable)EditorGUILayout.ObjectField(lootTable, typeof(LootTable), true);

        if (lootTable == null)
            return;

        for (int i = 0; i < lootTable.GetLootTable().Count; i++)
        {
            LootTableEntry entry = lootTable.GetLootTable()[i];

            entry.item = (Item)EditorGUILayout.ObjectField("Item", entry.item, typeof(Item), false);
            entry.ammountMin = EditorGUILayout.IntField("Amount Minimum", entry.ammountMin);
            entry.ammountMax = EditorGUILayout.IntField("Amount Maximum", entry.ammountMax);
            entry.weight = EditorGUILayout.IntField("Weight", entry.weight);

            if (GUILayout.Button("Remove"))
            {
                lootTable.RemoveLootTableEntry(i);
            }
        }

        if (GUILayout.Button("Add Entry"))
        {
            lootTable.AddLootTableEntry(null, 0,1,1);
        }
    }
}