using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parts : MonoBehaviour
{
    [SerializeField] int damage = 50;
    [SerializeField] int speed = -4;
    [SerializeField] int destroyCountDown = 5;

    public Sprite[] partSprites;


    // Start is called before the first frame update
    void Start()
    {
        SetSprite();
        Destroy(this.gameObject, destroyCountDown);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, speed * Time.deltaTime, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var pj = collision.GetComponent<PlayerHealth>();
        if (pj)
        {
            pj.GetDamage(damage);
        }
    }

    void SetSprite()
    {
        GetComponent<SpriteRenderer>().sprite = partSprites[Random.Range(0, partSprites.Length - 1)];
    }
}
