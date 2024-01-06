using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soup : MonoBehaviour
{
    [SerializeField] float numberOfIngredients;

    [SerializeField] Sprite refUranium;
    [SerializeField] Sprite eyes;
    [SerializeField] Sprite mushrooms;
    [SerializeField] Sprite bones;
    [SerializeField] Sprite glitter;

    [SerializeField] bool containsUranium;
    [SerializeField] bool containsEyes;
    [SerializeField] bool containsMushrooms;
    [SerializeField] bool containsBones;
    [SerializeField] bool containsGlitter;

    [SerializeField] public bool readyForNuke;
    [SerializeField] public bool readyForPopper;
    [SerializeField] public bool readyForDeath;
    [SerializeField] public bool readyForNothing;

    [SerializeField] ParticleSystem boiling1;
    [SerializeField] ParticleSystem boiling2;

    [SerializeField] Color nuke;
    [SerializeField] Color popper;
    [SerializeField] Color death;
    [SerializeField] Color nothing;

    [System.Obsolete]
    void Start()
    {
        boiling1.startColor = Color.gray;
        boiling2.startColor = Color.gray;


    }

    [System.Obsolete]
    void Update()
    {
        CheckBombPotion();
        CheckGlitterBomb();
        CheckDeathPotion();
        NoPotion();

        SetColor();
    }

    private void CheckBombPotion()
    {
        if (numberOfIngredients == 2)
        {
            if (containsUranium && containsMushrooms)
            {
                readyForNuke = true;
            }
        }
    }

    private void CheckGlitterBomb()
    {
        if (numberOfIngredients == 2)
        {
            if (containsUranium && containsGlitter)
            {
                readyForPopper = true;
            }
        }
    }

    private void CheckDeathPotion()
    {
        if (numberOfIngredients == 2)
        {
            if (containsEyes && containsBones)
            {
                readyForDeath = true;
            }
        }
    }

    private void NoPotion()
    {
        if (numberOfIngredients == 2)
        {
            if (!readyForNuke && !readyForPopper && !readyForDeath)
            {
                readyForNothing = true;
            }
        }

        if (numberOfIngredients >= 3)
        {
            readyForNothing = true;
        }

        if (readyForNothing)
        {
            readyForNuke = false;
            readyForPopper = false;
            readyForDeath = false;
        }
    }

    public void AddToIngredients(Sprite ingredient)
    {
        numberOfIngredients++;
        
        if (ingredient == refUranium)
        {
            containsUranium = true;
        }

        if (ingredient == eyes)
        {
            containsEyes = true;
        }

        if (ingredient == mushrooms)
        {
            containsMushrooms = true;
        }

        if (ingredient == bones)
        {
            containsBones = true;
        }

        if (ingredient == glitter)
        {
            containsGlitter = true;
        }
    }

    public void EmptyCouldron()
    {
        numberOfIngredients = 0;
        containsUranium = false;
        containsEyes = false;
        containsMushrooms = false;
        containsBones = false;
        containsGlitter = false;

        readyForNuke = false;
        readyForPopper = false;
        readyForDeath = false;
        readyForNothing = false;
    }

    [System.Obsolete]
    private void SetColor()
    {
        if (readyForNuke)
        {
            boiling1.startColor = nuke;
            boiling2.startColor = nuke;
        }
        else if (readyForPopper)
        {
            boiling1.startColor = popper;
            boiling2.startColor = popper;
        }
        else if (readyForDeath)
        {
            boiling1.startColor = death;
            boiling2.startColor = death;
        }
        else if (readyForNothing)
        {
            boiling1.startColor = nothing;
            boiling2.startColor = nothing;
        }
        else
        {
            boiling1.startColor = Color.gray;
            boiling2.startColor = Color.gray;
        }
    }
}
