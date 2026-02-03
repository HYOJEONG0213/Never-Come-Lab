using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BindBullet : BaseBullet
{
    // Start is called before the first frame update
    private void Start()
    {
        speed = 15f;
        maxRange = 10f;
    }

    protected override void OnHit(Monster monster)
    {
        monster.TakeSleep();
        monster.SetPlayerDetected(true);
    }

}
