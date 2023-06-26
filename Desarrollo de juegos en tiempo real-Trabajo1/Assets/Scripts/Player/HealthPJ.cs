using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;


public class HealthPJ : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public int minHealth;
    public HealthBar healthBar;

    CharacterMovement movimientos;

    public UnityEvent OnDeath = new UnityEvent();

    void Start()
    {
        health = maxHealth;
        movimientos = GetComponent<CharacterMovement>();
        healthBar.SetMaxHealth(maxHealth);
    }

    
    void Update()
    {

        if (health <= minHealth)
        {
            health = minHealth;
            movimientos.enabled = false;

            movimientos.animar.SetFloat("Movimiento", 0);
            movimientos.animar.SetBool("Muerte", true);
            OnDeath.Invoke();
            //MUERTE
        }
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }
  
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PowerUp>())
        {
            SumarHP(50);
            Destroy(other.gameObject);
        }

    }

    public void RestarHP(int damage)
    {
        health -= damage;
        healthBar.SetHealth(health);

        AtkDeff defensa;
        defensa = GetComponentInChildren<AtkDeff>();
        defensa.Defender();

        movimientos.Defender = true;
    }

    public void SumarHP(int damage)
    {
        health += damage;
        healthBar.SetHealth(health);
    }

}
