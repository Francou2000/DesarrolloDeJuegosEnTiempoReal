using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int maxHealth;
    [SerializeField] int actualHealth;

    
    void Start()
    {
        actualHealth = maxHealth;
    }

   

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("BBBBB");
        var other = collision.GetComponent<CollectableItems>();
        if (other)
        {
            switch (other.ItemsData.Effect)
            {
                case ItemEffect.Heal:
                    Heal(other.ItemsData.EffectStrength);
                    break;
                case ItemEffect.SpeedUp:

                    break;
                case ItemEffect.Invincibility: 

                    break;
                case ItemEffect.StrengthUp:

                    break;
            }
            Debug.Log("AAAAAAAAAAAAAA");
        }
    }

    public void GetDamage(int damage)
    {
        actualHealth -= damage;
        if (actualHealth < 0)
        {
            actualHealth = 0;
            //Además se muere
        }
    }

    public void Heal(int heal)
    {
        actualHealth += heal;
        if (actualHealth > maxHealth)
        {
            actualHealth = maxHealth;
        }
    }
}
