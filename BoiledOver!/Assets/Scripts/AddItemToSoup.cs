using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AddItemToSoup : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<ItemRenderer>().holdingItem)
        {
            if (Input.GetKeyDown(KeyCode.E) || Gamepad.current.buttonSouth.isPressed)
            {
                GetComponent<Soup>().AddToIngredients(other.GetComponent<ItemRenderer>().heldSprite.sprite);
                other.GetComponent<ItemRenderer>().RemoveItem();
            }
        }
    }
}
