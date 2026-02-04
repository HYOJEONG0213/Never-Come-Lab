using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BindBullet : BaseBullet
{

    protected override void OnHit(Monster monster)
    {
        monster.TakeSleep();
        monster.SetPlayerDetected(true);
    }

}
