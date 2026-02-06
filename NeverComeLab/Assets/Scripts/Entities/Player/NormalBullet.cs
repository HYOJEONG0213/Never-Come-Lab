using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBullet : BaseBullet
{

    protected override void OnHit(Monster monster)
    {
        monster.TakeDamage();
        monster.SetPlayerDetected(true);
    }

}
