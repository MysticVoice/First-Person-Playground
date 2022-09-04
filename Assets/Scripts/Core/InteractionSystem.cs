using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Linq;
using TMPro;
using System;

namespace MysticVoice.Core
{
    public class InteractionSystem : MonoBehaviour
    {
        public InputActionReference interactionInput;
        public float interactionRange = 3;
        private Transform player;
        public Transform world;
        private IInteractible currentInteractible;
        public TMP_Text interactionText;

        //WARNING Only IInteractibles in this list or it breaks
        public List<MonoBehaviour> interactibles;

        private bool interactNextFrame;
        public static InteractionSystem instance { get; private set; }
        private void Awake()
        {
            if (instance != null && instance != this)
            {
                Destroy(this);
            }
            else
            {
                instance = this;
                SetupInteractibles();
                interactionInput.action.Enable();
                player = GameObject.FindGameObjectWithTag("Player").transform;
            }
        }

        public void SetupInteractibles()
        {
            interactibles = world.GetComponentsInChildren<IInteractible>().ToList().Cast<MonoBehaviour>().ToList();
            interactNextFrame = false;
        }

        public bool GetInteractionInput()
        {
            if (interactionInput.action.triggered) return interactionInput.action.ReadValue<float>() > 0;
            else return false;
        }

        public bool GetInteractionHeld()
        {
            return interactionInput.action.ReadValue<float>() > 0;
        }

        public IInteractible GetNearestInteractibleInRange()
        {
            MonoBehaviour result = null;
            float shortestDistance = 10000000;
            foreach (MonoBehaviour interactible in interactibles)
            {
                float distance = DistanceFromPlayer(interactible);
                if (distance <= interactionRange && distance < shortestDistance)
                {
                    //print("Detected!");
                    shortestDistance = distance;
                    result = interactible;
                }
            }
            return (IInteractible)result;
        }

        private bool InteractibleInRange(IInteractible interactible)
        {
            float distance = DistanceFromPlayer(interactible);
            return distance <= interactionRange;
        }

        private float DistanceFromPlayer(MonoBehaviour interactible)
        {
            return Vector3.Distance(interactible.transform.position, player.position);
        }
        private float DistanceFromPlayer(IInteractible interactible)
        {
            return DistanceFromPlayer((MonoBehaviour)interactible);
        }
        public void AddInteractible(IInteractible interactible)
        {
            AddInteractible((MonoBehaviour)interactible);
        }

        public void AddInteractible(MonoBehaviour interactible)
        {
            interactibles.Add(interactible);
        }

        private void Update()
        {
            if (GetInteractionInput()) interactNextFrame = true;
        }

        private void FixedUpdate()
        {
            TriggerInteraction();
        }

        private void TriggerInteraction()
        {
            IInteractible interactible = GetNearestInteractibleInRange();
            if (interactible != currentInteractible)
            {
                if (currentInteractible != null) currentInteractible.SetInteractionRangeState(false);
                currentInteractible = interactible;
                if (currentInteractible != null)
                {
                    currentInteractible.SetInteractionRangeState(true);
                    interactionText.text = currentInteractible.GetInteractionText();
                }
                else interactionText.text = "";
            }
            if (interactNextFrame && currentInteractible != null)
            {
                currentInteractible.Interact();
            }
            interactNextFrame = false;
        }
    }
}
