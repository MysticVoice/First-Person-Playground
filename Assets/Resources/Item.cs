using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

namespace MysticVoice
{
    [CreateAssetMenu(fileName ="Item", menuName = "Scriptable Objects/Item")]
    [System.Serializable]
    public class Item : ScriptableObject
    {
        [SerializeField]
        public Sprite resource_image;
    }
}
