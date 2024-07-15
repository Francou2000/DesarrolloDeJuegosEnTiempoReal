using System;
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

    private int playerLayer;
    private int enemyLayer;

    private float invinTimer = 2f;

    CharacterMovement movimientos;

    public UnityEvent OnDeath = new UnityEvent();

    void Start()
    {
        health = maxHealth;
        movimientos = GetComponent<CharacterMovement>();
        healthBar.SetMaxHealth(maxHealth);

        playerLayer = LayerMask.NameToLayer("Player");
        enemyLayer = LayerMask.NameToLayer("Enemy");
    }

    
  
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PowerUpRotation>())
        {
            SumarHP(50);
            Destroy(other.gameObject);
        }
        if (other.GetComponent<Partes>())
        {
            other.GetComponent<BoxCollider2D>().enabled = false;
            RestarHP(5);
            
        }
    }

    public void TriggerInvincibility() 
    {
        StartCoroutine(InvincibilityRoutine());
    }

    private IEnumerator InvincibilityRoutine()
    {
        Physics2D.IgnoreLayerCollision(playerLayer, enemyLayer);
        yield return new WaitForSeconds(invinTimer);
        Physics2D.IgnoreLayerCollision(playerLayer, enemyLayer, false);
    }

    public void RestarHP(int damage)
    {
        health -= damage;

        if (health <= minHealth)
        {
            health = minHealth;
            movimientos.enabled = false;

            movimientos.animar.SetFloat("Movimiento", 0);
            movimientos.animar.SetBool("Muerte", true);
            OnDeath.Invoke();
            //MUERTE
        }

        AtkDeff defensa;
        defensa = GetComponentInChildren<AtkDeff>();
        defensa.Defender();

        movimientos.Defender = true;
        healthBar.SetHealth(health);
    }

    public void SumarHP(int damage)
    {
        health += damage;

        if (health > maxHealth)
        {
            health = maxHealth;
        }

        healthBar.SetHealth(health);
    }

}
