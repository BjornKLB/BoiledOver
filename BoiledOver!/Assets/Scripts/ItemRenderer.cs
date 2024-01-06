using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRenderer : MonoBehaviour
{
    [SerializeField] Rigidbody player;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] bool flipped;

    [SerializeField] GameObject heldItem;
    [SerializeField] public SpriteRenderer heldSprite;
    [SerializeField] public bool holdingItem;

    void Start()
    {
        RemoveItem();
    }

    void Update()
    {
        // player sprite orientation
        CheckOrientation();
        FlipSprite();

        // orientate held item
        if (holdingItem)
        {
            OrientateItem();
        }
    }

    private void CheckOrientation()
    {
        if (player.velocity.x > 0)
        {
            flipped = true;
        }
        else if (player.velocity.x < 0)
        {
            flipped = false;
        }
    }

    private void FlipSprite()
    {
        if (flipped)
        {
            spriteRenderer.flipX = true;
        }
        else spriteRenderer.flipX = false; 
    }

    public void HoldItem(Sprite newItem)
    {
        heldItem.SetActive(true);
        heldSprite.sprite = newItem;
        holdingItem = true;
    }

    public void RemoveItem()
    {
        heldItem.SetActive(false);
        holdingItem = false;
    }

    private void OrientateItem()
    {
        if (flipped)
        {
            heldSprite.flipX = true;
        }
        else heldSprite.flipX = false;
    }
}
