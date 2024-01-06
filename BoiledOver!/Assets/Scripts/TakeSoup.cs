using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TakeSoup : MonoBehaviour
{
    [SerializeField] Sprite nuke;
    [SerializeField] Sprite popper;
    [SerializeField] Sprite death;
    [SerializeField] Sprite nothing;

    private Sprite soup;

    [SerializeField] bool player1CannotHold;
    [SerializeField] bool player2CannotHold;

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
        if (!player1CannotHold && Input.GetKeyDown(KeyCode.E))
        {
            GiveSoup();
            other.GetComponent<ItemRenderer>().HoldItem(soup);
        }

        if (!player2CannotHold && Gamepad.current.buttonSouth.isPressed)
        {
            GiveSoup();
            other.GetComponent<ItemRenderer>().HoldItem(soup);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        player1CannotHold = false;
        player2CannotHold = false;
    }

    private void GiveSoup()
    {
        if (GetComponent<Soup>().readyForNuke)
        {
            soup = nuke;
        }
        else if (GetComponent<Soup>().readyForPopper)
        {
            soup = popper;
        }
        else if (GetComponent<Soup>().readyForDeath)
        {
            soup = death;
        }
        else if (GetComponent<Soup>().readyForNothing)
        {
            soup = nothing;
        }

        GetComponent<Soup>().EmptyCouldron();
    }
}

