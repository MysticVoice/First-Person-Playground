using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MysticVoice
{
    public class ScaleAndDieOverTime : MonoBehaviour
    {
        public  float startScale;
        
        public float scaleFactor;
        public float minScale;
        private float currentScale;
        private float moveDir;
        public float moveSpeed;
        public float spread = 3;

        private void Start()
        {
            currentScale = startScale;
            transform.localScale = Vector3.one * currentScale;
            moveDir = Random.Range(-spread, spread);
        }

        void Update()
        {
            currentScale *= scaleFactor*(1-Time.deltaTime);
            transform.localScale = Vector3.one * currentScale;
            transform.localPosition +=(transform.right * moveDir*moveSpeed)*Time.deltaTime;
            transform.position += Physics.gravity*0.1f*Time.deltaTime;
            if (currentScale<=minScale)
            {
                Destroy(gameObject);
            }
        }
    }
}
