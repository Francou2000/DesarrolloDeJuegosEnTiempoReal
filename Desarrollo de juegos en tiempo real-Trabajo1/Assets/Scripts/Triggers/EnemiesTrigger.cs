using UnityEngine;

public class EnemiesTrigger : MonoBehaviour
{
    [SerializeField] public GameObject[] enemies;

    private void ActivateEnemies()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            var enemy = enemies[i];
            enemy.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ActivateEnemies();

        Destroy(gameObject);
    }
}
