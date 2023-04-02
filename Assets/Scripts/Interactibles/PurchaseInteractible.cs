using MysticVoice.Core;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace MysticVoice
{
    public class PurchaseInteractible : BaseInteractible
    {
        public UnityEvent purchaseEvent;
        public UnityAction<bool> heldEvent;
        public Item costItem;
        public int costAmmount;
        public bool oneTimeUse;
        private bool used;
        public bool hasCooldown;
        public float cooldownTime;
        public void Awake()
        {
            SetInteractionRangeState(false);
            used = false;
            
        }
        public override void Interact()
        {
            if ((oneTimeUse && used) || (hasCooldown && used)) return;
            
            GameObject player = InteractionSystem.Player;
            Inventory playerInventory = player.GetComponent<InventoryHolder>().GetInventory();
            if (playerInventory.GetItemAmmount(costItem) < costAmmount) return;
            used = true;
            purchaseEvent?.Invoke();
            playerInventory.RemoveItem(costItem,costAmmount);

            if (oneTimeUse) RemoveFromInteractionSystem();
            if (hasCooldown) StartCoroutine(Cooldown());
        }

        private IEnumerator Cooldown()
        {
            yield return new WaitForSeconds(cooldownTime);
            used = false;
        }


        public override void SetInteractionRangeState(bool state)
        {
            text = costAmmount + " " + costItem.name;
            foreach (TextMeshPro t in GetComponentsInChildren<TextMeshPro>(includeInactive: true))
            {
                t.gameObject.SetActive(state);
            }
        }
    }
}
