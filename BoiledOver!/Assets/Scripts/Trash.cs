using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Trash : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<ItemRenderer>().holdingItem == true)
        {
            if (Input.GetKeyDown(KeyCode.E) || Gamepad.current.buttonSouth.isPressed)
            {
                other.GetComponent<ItemRenderer>().RemoveItem();
            }
        }
    }
}
