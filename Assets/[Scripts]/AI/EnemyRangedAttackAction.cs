using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangedAttackAction : MonoBehaviour, Action
{
    public bool hasLOS;
    [Range(1, 100)] 
    public int fireDelay = 20;
    public Transform bulletSpawn;
    public Vector2 targetOffset;
    public BulletManager bulletManager;

    // Start is called before the first frame update
    void Start()
    {
        bulletManager = FindObjectOfType<BulletManager>();
    }

    // Update is called once per frame
    void Update()
    {
        hasLOS = transform.parent.GetComponentInChildren<PlayerDetection>().LOS;
    }

    void FixedUpdate()
    {
        if(hasLOS && Time.frameCount % fireDelay == 0)
        {
            Execute();
        }
    }

    public void Execute()
    {
        var bullet = bulletManager.GetBullet(bulletSpawn.position);
        bullet.GetComponent<BulletController>().direction =
            transform.parent.GetComponentInChildren<PlayerDetection>().playerDirectionVector + targetOffset;
        bullet.GetComponent<BulletController>().Activate();
    }
}
