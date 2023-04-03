using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;


public abstract class InventoryDisplay : MonoBehaviour
{  
    [SerializeField] MouseItemData mouseInventoryItem;

    protected InventorySystem inventorySystem;
    protected Dictionary<InventorySlot_UI, InventorySlot> slotDictionary;
    
    public InventorySystem InventorySystem => inventorySystem;
    public Dictionary<InventorySlot_UI, InventorySlot> SlotDictionary => slotDictionary;

    protected virtual void Start()
    {

    }

    public abstract void AssignSlot(InventorySystem invToDisplay);

    protected virtual void UpdateSlot(InventorySlot updateSlot)
    {
        foreach (var slot in slotDictionary)
        {
            if (slot.Value == updateSlot) // Slot value
            {
                slot.Key.UpdateUISlot(updateSlot); // slot key
            }
        }
    }

    public void SlotClicked(InventorySlot_UI clickedUISlot)
    {
        bool isALTPressed = Keyboard.current.leftAltKey.isPressed;

        // Clicked slot possui item - Mouse não tem item - pegue o item
        if (clickedUISlot.AssignedInventorySlot.ItemData != null && mouseInventoryItem.assignedInventorySlot.ItemData == null)
        {
            //se o player estiver segurando ALT key, divida o stack
            if (isALTPressed && clickedUISlot.AssignedInventorySlot.SplitStack(out InventorySlot halfStackSlot)) // divide o stack
            {
                mouseInventoryItem.UpdateMouseSlot(halfStackSlot);
                clickedUISlot.UpdateUISlot();
                return;
            }
            else
            {
                mouseInventoryItem.UpdateMouseSlot(clickedUISlot.AssignedInventorySlot);
                clickedUISlot.ClearSlot();
                return;
            }
        
            
        }

        // Clicked slot não possui item - Mouse possui item - coloca o item do mouse no slot vazio
        if (clickedUISlot.AssignedInventorySlot.ItemData == null && mouseInventoryItem.assignedInventorySlot.ItemData != null)
        {
            clickedUISlot.AssignedInventorySlot.AssignItem(mouseInventoryItem.assignedInventorySlot);
            clickedUISlot.UpdateUISlot();

            mouseInventoryItem.ClearSlot();
        }

        //Slot e mouse possuem item
        if (clickedUISlot.AssignedInventorySlot.ItemData != null && mouseInventoryItem.assignedInventorySlot.ItemData != null)
        {   
            bool isSameItem = clickedUISlot.AssignedInventorySlot.ItemData == mouseInventoryItem.assignedInventorySlot.ItemData;
        
            if (isSameItem && clickedUISlot.AssignedInventorySlot.RoomLeftInStack(mouseInventoryItem.assignedInventorySlot.StackSize))
            {
                clickedUISlot.AssignedInventorySlot.AssignItem(mouseInventoryItem.assignedInventorySlot);
                clickedUISlot.UpdateUISlot();

                mouseInventoryItem.ClearSlot();
                return;
            }
            else if (isSameItem && 
            !clickedUISlot.AssignedInventorySlot.RoomLeftInStack(mouseInventoryItem.assignedInventorySlot.StackSize, out int leftInStack))
            {
                if (leftInStack < 1) SwapSlots(clickedUISlot); // Stack está cheio então troca os itens
                else // slot não ta no maximo, então pega oq precisa do inventario do mouse
                {
                    int remainingOnMouse = mouseInventoryItem.assignedInventorySlot.StackSize - leftInStack;
                    clickedUISlot.AssignedInventorySlot.AddToStack(leftInStack);
                    clickedUISlot.UpdateUISlot();

                    var newItem = new InventorySlot(mouseInventoryItem.assignedInventorySlot.ItemData, remainingOnMouse);
                    mouseInventoryItem.ClearSlot();
                    mouseInventoryItem.UpdateMouseSlot(newItem);
                    return;

                }
            }

            else if (!isSameItem)
            {
                SwapSlots(clickedUISlot);
                return;
            }
        }
    }

    private void SwapSlots(InventorySlot_UI clickedUISlot)
    {
        var clonedSlot = new InventorySlot(mouseInventoryItem.assignedInventorySlot.ItemData, mouseInventoryItem.assignedInventorySlot.StackSize);
        mouseInventoryItem.ClearSlot();

        mouseInventoryItem.UpdateMouseSlot(clickedUISlot.AssignedInventorySlot);

        clickedUISlot.ClearSlot();
        clickedUISlot.AssignedInventorySlot.AssignItem(clonedSlot);
        clickedUISlot.UpdateUISlot();
    }

}
