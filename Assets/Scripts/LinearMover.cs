using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

namespace MysticVoice
{
    public class LinearMover : MonoBehaviour
    {
        public float speed;
        public UnityEvent finished;
        private Vector3 pointB;
        private Vector3 pointA;
        private float tValue;
        private bool direction;

        private void Awake()
        {
            tValue = 0;
            pointA = transform.position;
            pointB = gameObject.GetComponentInChildren<Waypoint>().transform.position;
            direction = true;
            this.enabled = false;
        }
        // Update is called once per frame
        void FixedUpdate()
        {
            CalculateTValue();
            transform.position = Vector3.Lerp(pointA, pointB, tValue);
        }

        private void CalculateTValue()
        {
            tValue += ((Convert.ToInt32(direction) - 0.5f) * 2) * speed;
            if (tValue > 1) tValue = 1;
            else if (tValue < 0) tValue = 0;
            else return;
            direction = !direction;
            this.enabled = false;
        }
    }
}
