using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {
    public float CurrentHealth { get; set; }
    public float MaxHealth { get; set; }
    public bool hurt = false;
    public Slider healthBar;

    public GameObject deathMenu;
    public GameObject buttonManager;

	// Use this for initialization
	void Start ()
    {
        MaxHealth = 100f;
        CurrentHealth = MaxHealth;
        healthBar.value = CalculateHealth();
        deathMenu = GameObject.Find("DeathMenu");
        deathMenu.SetActive(false);
        buttonManager = GameObject.Find("ButtonManager");
        deathMenu.SetActive(false);
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
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        deathMenu.SetActive(true);
        buttonManager.SetActive(true);
        Destroy(gameObject);
        Debug.Log("You dead fool!"); 
    }

    public void ResetHealth()
    {
        CurrentHealth = MaxHealth;
        healthBar.value = CalculateHealth();
    }
}
