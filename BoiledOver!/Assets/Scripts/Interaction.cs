using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interaction : MonoBehaviour
{
    [SerializeField] Sprite item;
    
    [SerializeField] bool player1CannotHold;
    [SerializeField] bool player2CannotHold;
    [SerializeField] bool isRefinery;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player1"))
        {
            if (other.GetComponent<ItemRenderer>().holdingItem == true)
            {
                player1CannotHold = true;
            }
        }
        else if (other.CompareTag("Player2"))
        {
            if (other.GetComponent<ItemRenderer>().holdingItem == true)
            {
                player2CannotHold = true;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (isRefinery)
        {
            if (GetComponent<UseItem>().hasRefUranium)
            {
                if (!player1CannotHold && Input.GetKeyDown(KeyCode.E))
                {
                    other.GetComponent<ItemRenderer>().HoldItem(item);
                }

                if (!player2CannotHold && Gamepad.current.buttonSouth.isPressed)
                {
                    other.GetComponent<ItemRenderer>().HoldItem(item);
                }
            }
        }
        else
        {
            if (!player1CannotHold && Input.GetKeyDown(KeyCode.E))
            {
                other.GetComponent<ItemRenderer>().HoldItem(item);
            }

            if (!player2CannotHold && Gamepad.current.buttonSouth.isPressed)
            {
                other.GetComponent<ItemRenderer>().HoldItem(item);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        player1CannotHold = false;
        player2CannotHold = false;
    }
}
