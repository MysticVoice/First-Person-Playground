using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MysticVoice
{
    public class DoorControler : MonoBehaviour
    {
        public GameObject center;
        public GameObject left;
        public GameObject right;

        public float rotationAmmount = 90;
        public float displacementAmmount = 3;
        public float animationLength = 3;

        private bool animationRunning;
        private bool animationDirection;
        private float animatorValue = 0;

        // Start is called before the first frame update
        void Start()
        {
            animationDirection = false;
        }

        public void StartAnimation()
        {
            animationDirection = !animationDirection;
            animationRunning = true;
        }

        // Update is called once per frame
        void Update()
        {
            if (!animationRunning) return;
            UpdateAnimatorValue();
            float remap1 = Mathf.Clamp01(animatorValue.Remap(0f,0.5f,0,1f));
            float remap2 = Mathf.Clamp01(animatorValue.Remap(0.5f,1f,0,1f));
            center.transform.localRotation = Quaternion.Euler(0, 0, remap1 * rotationAmmount);
            left.transform.localPosition = -Vector3.right * displacementAmmount*remap2;
            right.transform.localPosition = Vector3.right * displacementAmmount*remap2;
        }

        private void UpdateAnimatorValue()
        {
            float dir;
            if (animationDirection) dir = 1;
            else dir = -1;
            animatorValue += (Time.deltaTime*dir) / animationLength;
            if (!(animatorValue >= 1) && !(animatorValue <= 0)) return;
            if (animatorValue >= 1) animatorValue = 1;
            if(animatorValue <= 0) animatorValue = 0;
            animationRunning = false;
            //animationDirection = !animationDirection;
        }
    }
}
