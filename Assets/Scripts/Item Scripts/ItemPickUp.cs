using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class ItemPickUp : MonoBehaviour
{
    public InventoryItemData itemData;

    [SerializeField] private CircleCollider2D myCollider;

    private void Awake() {
        myCollider = GetComponent<CircleCollider2D>();
        myCollider.isTrigger = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            var inventory = other.transform.GetComponent<InventoryHolder>();

            if (!inventory) return;

            if (!inventory.InventorySystem.addToInventory(itemData, 1))
            {
                Destroy(this.gameObject);
            }
            Destroy(this.gameObject);
        }
    }
}
