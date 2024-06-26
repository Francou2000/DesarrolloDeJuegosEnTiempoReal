using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int maxHealth;
    [SerializeField] int actualHealth;

    bool isInvencible = false;
    public GameObject movePlayer;
    public GameObject attackREFF;

    void Start()
    {
        actualHealth = maxHealth;
    }

   

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("BBBBB");
        var other = collision.GetComponent<CollectableItems>();
        if (other is CollectableItems)
        {
            switch (other.ItemsData.Effect)
            {
                case ItemEffect.Heal:
                    Heal(other.ItemsData.EffectStrength);
                    break;
                case ItemEffect.SpeedUp:
                    StartCoroutine(movePlayer.GetComponent<PlayerMovement>().SpeedUp(other.ItemsData.EffectStrength));
                    break;
                case ItemEffect.Invincibility:
                    StartCoroutine(Invencible(other.ItemsData.EffectStrength));
                    break;
                case ItemEffect.StrengthUp:
                    StartCoroutine(attackREFF.GetComponent<PlayerActions>().StrengthUp(other.ItemsData.EffectStrength));
                    break;
                default:
                    Debug.Log("CCCCC");
                    break;
            }
            Destroy(collision.gameObject);
            Debug.Log("AAAAAAAAAAAAAA");
        }
    }

    public void GetDamage(int damage)
    {
        if (!isInvencible)
        {
            actualHealth -= damage;
            if (actualHealth < 0)
            {
                actualHealth = 0;
                //Además se muere
            }
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

    public IEnumerator Invencible(int duration)
    {
        isInvencible = true;
        yield return new WaitForSeconds(duration);
        isInvencible = false;
    }

    
}
