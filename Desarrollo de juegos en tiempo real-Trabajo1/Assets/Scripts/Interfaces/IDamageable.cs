using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    public void GetDamage(int damage);
    void GetKilled();
}
