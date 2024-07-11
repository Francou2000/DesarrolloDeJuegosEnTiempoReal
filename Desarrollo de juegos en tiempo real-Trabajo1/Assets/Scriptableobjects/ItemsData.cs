using UnityEngine;

[CreateAssetMenu(fileName = "NewItemData", menuName = "Data/ItemsData")]

public class ItemsData : ScriptableObject
{
    float rotationSpeed = 10;
    float bouncinessSpeed = 0.1f;
    [SerializeField] ItemEffect effect;
    [SerializeField] int effectStrength;
    [SerializeField] AudioClip soundEffect;

    public float RotationSpeed => rotationSpeed;
    public float BouncinessSpeed => bouncinessSpeed;
    public ItemEffect Effect => effect;
    public int EffectStrength => effectStrength;
    public AudioClip SoundEffect => soundEffect;

}

public enum ItemEffect
{
    Heal,
    SpeedUp,
    Invincibility,
    StrengthUp
}