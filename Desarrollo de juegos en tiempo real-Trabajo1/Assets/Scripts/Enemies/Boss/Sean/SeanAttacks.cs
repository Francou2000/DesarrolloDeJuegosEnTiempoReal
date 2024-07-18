using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;

public class SeanAttacks : MonoBehaviour
{
    public int meleeAttackDamage = 20;
    public int rangeAttackDamage = 40;

    public Vector3 attackOffset;
    public float attackRange = 1f;
    public LayerMask attackMask;

    public GameObject bullet;
    public GameObject bulletSpawnPoint;

    [SerializeField] private BossHealth boss;

    [SerializeField] GameObject target;

    private Animator myAnimator;

    private void Start()
    {
        myAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        boss.SecondPhase.AddListener(EnterSecondPhase);
    }

    public void EnterSecondPhase()
    {
        myAnimator.SetBool("SecondPhase", true);
        myAnimator.SetBool("Movement", false);
    }

    public void MeleeAttack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Collider2D[] colInfo = Physics2D.OverlapCircleAll(pos, attackRange, attackMask);
        foreach (Collider2D collider2D in colInfo) 
        {
            PlayerHealth collider = collider2D.GetComponent<PlayerHealth>();
            if (collider != null)
            {
                collider.GetDamage(meleeAttackDamage);
            }
        }
    }

    public void Deactive()
    {
        this.enabled = false;
    }

    public void SpawnRangeAttack()
    {
        GameObject thisBullet = Instantiate(bullet, bulletSpawnPoint.transform.position, Quaternion.identity);
        thisBullet.GetComponent<Knife>().SetTarget(target);
    }

    void OnDrawGizmosSelected()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Gizmos.DrawWireSphere(pos, attackRange);
    }
}
