using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField] int maxHealth;
    [SerializeField] int actualHealth;

    bool isInvencible = false;
    public GameObject movePlayer;
    public GameObject attackREFF;

    private AudioSource myAudioSource;

    public UnityEvent OnDeath = new UnityEvent();

    public HealthBar healthBar;

    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
        myAudioSource.volume = VolumeController.Instance.SFXVolume;
        actualHealth = maxHealth;
        SetSFXVolume();
        VolumeController.Instance.volumeUpdate.AddListener(SetSFXVolume);
        healthBar.SetMaxHealth(maxHealth);
    }

    private void SetSFXVolume()
    {
        myAudioSource.volume = VolumeController.Instance.SFXVolume;
    }

public void OnTriggerEnter2D(Collider2D collision)
    {
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
            StartCoroutine(other.PlaySoundEffect());
            
        }
    }

    public void GetDamage(int damage)
    {
        if (!isInvencible)
        {
            StartCoroutine(PlayerFlinch());
            StartCoroutine(ColorFeedBack(0.5f, Color.red));
            actualHealth -= damage;
            if (actualHealth <= 0)
            {
                GetKilled();
            }
            healthBar.SetHealth(actualHealth);
        }
        
    }

    public void GetKilled()
    {
        actualHealth = 0;
        healthBar.SetHealth(actualHealth);
        OnDeath.Invoke();
    }

    public void Heal(int heal)
    {
        actualHealth += heal;
        if (actualHealth > maxHealth)
        {
            actualHealth = maxHealth;
            
        }
        healthBar.SetHealth(actualHealth);
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

    public IEnumerator PlayerFlinch()
    {
        movePlayer.GetComponent<PlayerMovement>().CanMove = false;
        isInvencible = true;
        myAudioSource.Play();
        movePlayer.GetComponent<PlayerMovement>().MyAnimatorController.TriggerAnimation("GetDamage");
        yield return new WaitForSeconds(movePlayer.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
        movePlayer.GetComponent<PlayerMovement>().CanMove = true;
        isInvencible = false;
    }
    
}
