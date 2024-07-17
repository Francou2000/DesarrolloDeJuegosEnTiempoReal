using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerActions : MonoBehaviour
{
    private InputManager myInputManager = new InputManager();
    private PlayerAnimatorController myAnimatorController;
    private Collider2D myAttackCollider;
    private bool canAttack = true;
    public int attackDamage;

    AudioSource myAudioSource;
    [SerializeField] AudioClip attackClip1;
    [SerializeField] AudioClip attackClip2;
    public UnityEvent OnHit = new UnityEvent();

    public bool CanAttack { set { canAttack = value; } }
    void Start()
    {
        myAnimatorController = new PlayerAnimatorController(GetComponent<Animator>());
        myAttackCollider = GetComponent<Collider2D>();
        myAudioSource = GetComponent<AudioSource>();
        VolumeController.Instance.volumeUpdate.AddListener(SetSFXVolume);
        SetSFXVolume();
    }

    private void SetSFXVolume()
    {
        myAudioSource.volume = VolumeController.Instance.SFXVolume;
    }


    void Update()
    {
        if (canAttack)
        {
            myInputManager.ActionsInput();
            BasicAttack();
            //ZaWarudo();
        }

    }

    void BasicAttack()
    {
        if (myInputManager.Punch)
        {
            myAnimatorController.TriggerAnimation("Attack");
            StartCoroutine(AttackColliderCoroutine());
        }
    }

    public IEnumerator AttackColliderCoroutine()
    {
        myAudioSource.clip = attackClip1;
        canAttack = false;
        GetComponentInParent<PlayerMovement>().CanMove = false;
        transform.position = new Vector3(transform.position.x + 0.15f * myInputManager.MovHorizontal, transform.position.y, 1);
        yield return new WaitForSeconds(0.4f);
        myAudioSource.Play();
        transform.position = new Vector3(transform.position.x + 0.15f * myInputManager.MovHorizontal, transform.position.y, 1);
        yield return new WaitForSeconds(0.6f);
        myAttackCollider.enabled = true;
        OnHit.Invoke();
        yield return new WaitForSeconds(0.5f);
        myAttackCollider.enabled = false;
        GetComponentInParent<PlayerMovement>().CanMove = true;
        transform.position = new Vector3(transform.position.x - 0.3f * myInputManager.MovHorizontal, transform.position.y, 1);
        canAttack = true;
    }

    public IEnumerator StrengthUp(int duration)
    {
        attackDamage *= 2;
        yield return new WaitForSeconds(duration);
        attackDamage /= 2;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable other = collision.GetComponent<IDamageable>();
        if (other != null)
        {
            other.GetDamage(attackDamage);
        }
    }

    //void ZaWarudo()
    //{

    //}
}
