using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shop : MonoBehaviour
{
    [SerializeField] GameObject player;

    [SerializeField] Sprite nuke;
    [SerializeField] Sprite popper;
    [SerializeField] Sprite death;

    [SerializeField] TextMeshProUGUI moneyCounter;

    public float money;

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<ItemRenderer>().holdingItem == true)
        {
            if (Input.GetKeyDown(KeyCode.E) || Gamepad.current.buttonSouth.isPressed)
            {
                SellSoup(other.GetComponent<ItemRenderer>().heldSprite.sprite);
            }
        }
    }

    private void SellSoup(Sprite soup)
    {
        if (soup == nuke)
        {
            money += 5;
            player.GetComponent<ItemRenderer>().RemoveItem();
        }
        else if (soup == popper)
        {
            money += 4;
            player.GetComponent<ItemRenderer>().RemoveItem();
        }
        else if (soup == death)
        {
            money += 2;
            player.GetComponent<ItemRenderer>().RemoveItem();
        }
    }

    private void Update()
    {
        moneyCounter.text = money.ToString();
    }
}
