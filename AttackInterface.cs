using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface AttackInterface
{
    void Attack();

    IEnumerator AttackTime();

    void CheckAttack();
}
