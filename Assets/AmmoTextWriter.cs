using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
namespace MysticVoice
{
    public class AmmoTextWriter : MonoBehaviour
    {
        Weapon w;
        public TMP_Text text;

        private void OnEnable()
        {
            w = GetComponentInChildren<Weapon>();
            w.OnAmmoChanged += UpdateText;
        }

        private void OnDisable()
        {
            w.OnAmmoChanged -= UpdateText;
        }

        public void UpdateText(string text)
        {
            this.text.text = text;
        }
    }
}
