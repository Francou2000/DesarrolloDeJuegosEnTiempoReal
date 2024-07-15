using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyData", menuName = "Data/EnemyData")]

public class EnemyData : ScriptableObject
{
    [SerializeField] int maxHealth;
    [SerializeField] float movementSpeed;
    [SerializeField] float chaseDistance;
    [SerializeField] float attackDistance;
    [SerializeField] int damage;

    public int MaxHealth => maxHealth;
    public float MovementSpeed => movementSpeed;
    public float ChaseDistance => chaseDistance;
    public float AttackDistance => attackDistance;
    public int Damage => damage;

}