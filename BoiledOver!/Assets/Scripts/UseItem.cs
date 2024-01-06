using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class UseItem : MonoBehaviour
{
    [SerializeField] bool isRefinery;
    [SerializeField] bool hasUranium;
    [SerializeField] bool processing;
    [SerializeField] public bool hasRefUranium;
    [SerializeField] Sprite uranium;
    [SerializeField] Sprite refinedUranium;

    [SerializeField] GameObject loader;
    [SerializeField] Image loading;

    private float timer;
    private float timerDuration = 2;

    private void OnTriggerStay(Collider other)
    {
        if (isRefinery)
        {
            if (other.GetComponent<ItemRenderer>().holdingItem == true && (other.GetComponent<ItemRenderer>().heldSprite.sprite == uranium) && !hasUranium)
                {
                    if (Input.GetKeyDown(KeyCode.E) || Gamepad.current.buttonSouth.isPressed)
                    {
                        other.GetComponent<ItemRenderer>().RemoveItem();
                        hasUranium = true;
                    }
                }
        }
        else
        {
            if (other.GetComponent<ItemRenderer>().holdingItem == true)
            {
                if (Input.GetKeyDown(KeyCode.E) || Gamepad.current.buttonSouth.isPressed)
                {
                    other.GetComponent<ItemRenderer>().RemoveItem();
                }
            }
        }

        if (other.GetComponent<ItemRenderer>().holdingItem == true)
        {
            hasRefUranium = false;
        }
    }

    private void Update()
    {
        if (hasUranium)
        {
            processing = true;
            timer += Time.deltaTime;
            if (timer >= timerDuration)
            {
                hasUranium = false;
                timer = 0;
                processing = false;
                hasRefUranium = true;
            }
        }

        if (processing || hasRefUranium)
        {
            loader.SetActive(true);
            loading.fillAmount = timer / 2;
        }
        else
        {
            loader.SetActive (false);
        }
    }
}