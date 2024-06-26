using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NDoulAttack : MonoBehaviour
{
    public float attackSpeed;

    private float timer;

    private bool firstPhase = true;
    private bool secondPhase = false;

    private bool respawned = false;

    public GameObject bullet;
    public GameObject secondBullet;

    public GameObject SP1;
    public GameObject SP2;
    public GameObject SP3;
    public GameObject SP4;
    public GameObject SP5;
    public GameObject SP6;
    public GameObject SP7;
    public GameObject SP8;
    public GameObject SP9;
    public GameObject SP10;
    public GameObject SP11;
    public GameObject SP12;
    public GameObject SP13;
    public GameObject SP14;
    public GameObject SP15;
    public GameObject SP16;
    public GameObject SP17;
    public GameObject SP18;
    public GameObject SP19;
    public GameObject RespawnPoint;

    private Animator anim;

    public void Start()
    {
        anim = GetComponent<Animator>();   
        GetComponent<BossHealth>().NoLife.AddListener(Deactive);
    }

    void Update()
    {
        timer += Time.deltaTime;

        var bossHealth = GetComponent<BossHealth>();

        if (bossHealth.health <= 50)
        {
            firstPhase = false;
            secondPhase = true;
        }

        if (timer >= attackSpeed && firstPhase == true)
        {
            StartCoroutine(AttackCoroutine());
            timer = 0;
        }

        if (secondPhase == true && respawned == false)
        {
            StartCoroutine(RespawnCoroutine());
        }

        if (timer >= attackSpeed * 1.5f && secondPhase == true && respawned == true && bossHealth.health > 0)
        {
            StartCoroutine(SecondAttackCoroutine());
            timer = 0;
        }
    }

    public void Deactive()
    {
        this.enabled = false; 
    }

    public IEnumerator AttackCoroutine()
    {
        Instantiate(bullet, SP1.transform.position, Quaternion.identity);
        Instantiate(bullet, SP2.transform.position, Quaternion.identity);
        Instantiate(bullet, SP3.transform.position, Quaternion.identity);
        Instantiate(bullet, SP4.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.8f);
        Instantiate(bullet, SP5.transform.position, Quaternion.identity);
        Instantiate(bullet, SP6.transform.position, Quaternion.identity);
        Instantiate(bullet, SP7.transform.position, Quaternion.identity);
        Instantiate(bullet, SP8.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.8f);
        Instantiate(bullet, SP9.transform.position, Quaternion.identity);
        Instantiate(bullet, SP10.transform.position, Quaternion.identity);
        Instantiate(bullet, SP11.transform.position, Quaternion.identity);
        Instantiate(bullet, SP12.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.8f);
        Instantiate(bullet, SP13.transform.position, Quaternion.identity);
        Instantiate(bullet, SP14.transform.position, Quaternion.identity);
        Instantiate(bullet, SP15.transform.position, Quaternion.identity);
        Instantiate(bullet, SP16.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.8f);
    }

    public IEnumerator SecondAttackCoroutine()
    {
        Instantiate(secondBullet, SP17.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1.5f);
        Instantiate(secondBullet, SP18.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1.5f);
        Instantiate(secondBullet, SP19.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1.5f);
    }

    public IEnumerator RespawnCoroutine()
    {
        anim.SetTrigger("Respawn");
        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);
        transform.position = RespawnPoint.transform.position;
        respawned = true;
        yield return null;
    }
}
