using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace MysticVoice
{
    public class LocalTimeToUI : MonoBehaviour
    {
        private TMP_Text text;
        // Update is called once per frame

        private void Start()
        {
            text = GetComponent<TMP_Text>();
        }

        void Update()
        {
            string time = System.DateTime.UtcNow.ToLocalTime().ToString("HH:mm");
            text.text = time;
        }
    }
}
