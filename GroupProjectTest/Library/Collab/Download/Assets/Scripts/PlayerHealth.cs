using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {
    public float CurrentHealth { get; set; }
    public float MaxHealth { get; set; }
    public bool hurt = false;
    public Canvas DeathMenu;
    public Slider healthBar;

	// Use this for initialization
	void Start ()
    {
        DeathMenu = DeathMenu.GetComponent<Canvas>();
        MaxHealth = 100f;
        CurrentHealth = MaxHealth;
        healthBar.value = CalculateHealth();
        DeathMenu.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        /*
        if (hurt == true)
        {
            DealDamage(10);
        }
        hurt = false;
        */
        /*
        if (Input.GetKeyDown(KeyCode.H))
        {
            DealDamage(10);
        }
        */
    }

    /*
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Zombie"))
        {
            hurt = true;
        }
    }
    */

    public void DealDamage(float damageVal)
    {
        CurrentHealth -= damageVal;
        healthBar.value = CalculateHealth(); 
        if (CurrentHealth <= 0)
        {
            Die();
        }
    }

    float CalculateHealth()
    {
        return CurrentHealth / MaxHealth;
    }

    void Die()
    {
        CurrentHealth = 0;
        Time.timeScale = 0;
        Destroy(gameObject);
        Debug.Log("You dead fool!");
        DeathMenu.enabled = true;
        
    }

    public void ResetHealth()
    {
        CurrentHealth = MaxHealth;
        healthBar.value = CalculateHealth();
    }
}
