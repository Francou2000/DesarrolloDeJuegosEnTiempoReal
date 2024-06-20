using UnityEngine;

[CreateAssetMenu(fileName = "NewItemData", menuName = "Data/ItemsData")]

public class ItemsData : ScriptableObject
{
    [SerializeField] float rotationSpeed;
    [SerializeField] float bouncinessSpeed;
    [SerializeField] ItemEffect effect;

}

public enum ItemEffect
{
    Heal,
    Speed,
    Invincibility
}