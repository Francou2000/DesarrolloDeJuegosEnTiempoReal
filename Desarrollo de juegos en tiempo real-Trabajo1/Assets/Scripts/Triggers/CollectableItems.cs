using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CollectableItems : MonoBehaviour, IColectableItem
{
    [SerializeField] private ItemsData itemsData;
    public ItemsData ItemsData => itemsData;
    private AudioSource audioSource;


    private bool isGoingUp = true;
    float time = 0;
    float timer = 1;
    float rotationSpeed = 10;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = itemsData.SoundEffect;
    }


    void Update()
    {
        Bounce();
    }

    private void Bounce() 
    {
        if (isGoingUp)
        {
            transform.Translate(0, itemsData.BouncinessSpeed * Time.deltaTime, 0);
            time += Time.deltaTime;
            if (time > timer)
            {
                isGoingUp=false;
                time = 0;
            }
        }
        else
        {
            transform.Translate(0, - itemsData.BouncinessSpeed * Time.deltaTime, 0);
            time += Time.deltaTime;
            if (time > timer)
            {
                isGoingUp = true;
                time = 0;
            }
        }

        rotationSpeed += itemsData.RotationSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0, rotationSpeed , 0);

    }

    public IEnumerator PlaySoundEffect()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        audioSource.Play();
        yield return new WaitForSeconds(audioSource.clip.length);
        Destroy(gameObject);
    }


}
