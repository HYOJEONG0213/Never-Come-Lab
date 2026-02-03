using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBullet : BaseBullet
{
    private void Start()
    {
        speed = 5f;
        maxRange = 5f;
    }

    protected override void OnHit(Monster monster)
    {
        monster.TakeDamage();
        monster.SetPlayerDetected(true);
    }

}
