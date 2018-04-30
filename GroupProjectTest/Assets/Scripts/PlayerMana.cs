using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerMana : MonoBehaviour {

    public float CurrentMana { get; set; }
    public float MaxMana { get; set; }
    public Slider manaBar;
    Animator animator;

    // Use this for initialization
    void Start()
    {
        animator = GetComponentInParent<Animator>();
        MaxMana = 100f;
        CurrentMana = MaxMana;
        manaBar.value = CalculateMana();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !animator.GetBool("Shoot"))
        {
            TakeMana(10);
        }
    }

    void TakeMana(float manaVal)
    {
        CurrentMana -= manaVal;
        manaBar.value = CalculateMana();
        if (CurrentMana <= 0)
        {
            OutOfMana();
        }
    }

    float CalculateMana()
    {
        return CurrentMana / MaxMana;
    }

    void OutOfMana()
    {
        CurrentMana = 0;
        Debug.Log("You outta mana fool!");
    }

    public bool IsManaEmpty()
    {
        if (CurrentMana == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void ResetMana()
    {
        CurrentMana = MaxMana;
        manaBar.value = CalculateMana();
    }

    public void AddMaxMana()
    {
        MaxMana += 2;
    }
}
