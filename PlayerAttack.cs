using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour, AttackInterface
{
    bool CanAttack;
    public float TimeBetweenAttacks;
    float NextAttack;
    public GameObject AttackObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckAttack();
        if (CanAttack)
        {
            Attack();
        }
    }

    public void CheckAttack()
    {
        if (NextAttack < Time.time)
        {
            CanAttack = true;
        }
    }

    public void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(AttackTime());
        }

    }

    public IEnumerator AttackTime()
    {
        AttackObject.SetActive(true);
        NextAttack = TimeBetweenAttacks + Time.time;
        CanAttack = false;
        yield return new WaitForSeconds(1 / 3f);
        AttackObject.SetActive(false);

    }

    
}
