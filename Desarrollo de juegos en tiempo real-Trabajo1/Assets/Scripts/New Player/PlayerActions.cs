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

    public GameObject hitboxEffect;

    public Vector3 attackOffset;
    public float attackRange = 1f;

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

    public void ShowEffect()
    {
        hitboxEffect.SetActive(true);
    }

    public void HideEffect()   
    { 
        hitboxEffect.SetActive(false);
    }

    public void MeleeAttack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Collider2D[] colInfo = Physics2D.OverlapCircleAll(pos, attackRange);
        foreach (Collider2D collider2D in colInfo)
        {
            IDamageable other = collider2D.GetComponent<IDamageable>();
            if (other != null)
            {
                other.GetDamage(attackDamage);
            }
        }
    }

    void BasicAttack()
    {
        if (myInputManager.Punch)
        {
            StartCoroutine(AttackColliderCoroutine());
        }
    }

    public IEnumerator AttackColliderCoroutine()
    {
        myAnimatorController.TriggerAnimation("Attack");
        myAudioSource.clip = attackClip1;
        canAttack = false;
        GetComponentInParent<PlayerMovement>().CanMove = false;
        myAudioSource.Play();
        OnHit.Invoke();
        yield return new WaitForSeconds(myAnimatorController.GetAnimationLenght());
        GetComponentInParent<PlayerMovement>().CanMove = true;
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

    void OnDrawGizmosSelected()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Gizmos.DrawWireSphere(pos, attackRange);
    }

    //void ZaWarudo()
    //{

    //}
}
