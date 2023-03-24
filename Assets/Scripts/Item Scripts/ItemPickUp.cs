using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class ItemPickUp : MonoBehaviour
{
    public InventoryItemData itemData;

    public float PickUpRadius = 1f;
    private SphereCollider myCollider;

    private void Awake() {
        myCollider = GetComponent<SphereCollider>();
        myCollider.isTrigger = true;
        myCollider.radius = PickUpRadius;
    }

    void OnTriggerEnter(Collider other)
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
