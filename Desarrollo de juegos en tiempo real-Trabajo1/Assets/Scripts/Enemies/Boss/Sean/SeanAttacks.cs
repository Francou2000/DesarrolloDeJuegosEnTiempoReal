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
    }

    public void MeleeAttack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        if (colInfo != null)
        {
            colInfo.GetComponent<PlayerHealth>().GetDamage(meleeAttackDamage);
        }
    }

    public void SpawnRangeAttack()
    {
        Instantiate(bullet, bulletSpawnPoint.transform.position, Quaternion.identity);
    }

    void OnDrawGizmosSelected()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Gizmos.DrawWireSphere(pos, attackRange);
    }
}
