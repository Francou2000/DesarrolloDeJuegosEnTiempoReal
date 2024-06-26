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
                    StartCoroutine(ColorFeedBack(0.3f, Color.green));
                    break;
                case ItemEffect.SpeedUp:
                    StartCoroutine(movePlayer.GetComponent<PlayerMovement>().SpeedUp(other.ItemsData.EffectStrength));
                    StartCoroutine(ColorFeedBack(other.ItemsData.EffectStrength, new Color32(110, 255, 250, 255)));
                    break;
                case ItemEffect.Invincibility:
                    StartCoroutine(Invencible(other.ItemsData.EffectStrength));
                    break;
                case ItemEffect.StrengthUp:
                    StartCoroutine(attackREFF.GetComponent<PlayerActions>().StrengthUp(other.ItemsData.EffectStrength));
                    StartCoroutine(ColorFeedBack(other.ItemsData.EffectStrength, new Color32(255, 200, 110, 255)));
                    break;
                default:
                    Debug.Log("CCCCC");
                    break;
            }
            other.PlaySoundEffect();
            Destroy(collision.gameObject);
            Debug.Log("AAAAAAAAAAAAAA");
        }
    }

    public void GetDamage(int damage)
    {
        if (!isInvencible)
        {
            StartCoroutine(ColorFeedBack(0.5f, Color.red));
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
        movePlayer.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 150);
        isInvencible = true;
        yield return new WaitForSeconds(duration);
        isInvencible = false;
        movePlayer.GetComponent<SpriteRenderer>().color = Color.white;
    }

    public IEnumerator ColorFeedBack(float duration, Color feedbackColor)
    {
        movePlayer.GetComponent<SpriteRenderer>().color = feedbackColor;
        yield return new WaitForSeconds(duration);
        movePlayer.GetComponent<SpriteRenderer>().color = Color.white;
    }
    
}
