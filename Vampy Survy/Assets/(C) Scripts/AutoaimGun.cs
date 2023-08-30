using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoaimGun : MonoBehaviour
{
    public static AutoaimGun Instance { private set; get; }
    [SerializeField] private GameObject bullet;
    private float fireTime;
    [SerializeField] private float fireRate = 1f;
    public float fireRateMulti = 1f;
    public float damageMulti = 1f;    

    private void Awake()
    {
        if (Instance != null) Destroy(gameObject);
        else Instance = this;
    }

    private void Update()
    {
        fireTime += Time.deltaTime;
        if (fireTime > fireRate * fireRateMulti && GameManager.Instance.enemyList.Count > 0)
        {
            Bullet spawnedBullet = Instantiate(bullet, transform.position, Quaternion.identity).GetComponent<Bullet>();
            spawnedBullet.ResetBullet((GameManager.Instance.enemyList[ChooseTarget()].position-transform.position),damageMulti);
            fireTime = 0;
        }
    }

    //Assumes there is at least one target
    public int ChooseTarget()
    {
        float minDistanceSqr = ((Vector2)(GameManager.Instance.enemyList[0].position-transform.position)).sqrMagnitude;
        int minIndex = 0;
        for(int i = 1; i < GameManager.Instance.enemyList.Count; i++)
        {
            float cDistSqr = ((Vector2)(GameManager.Instance.enemyList[i].position - transform.position)).sqrMagnitude;
            if (cDistSqr < minDistanceSqr)
            {
                minDistanceSqr = cDistSqr;
                minIndex = i;
            }
        }
        return minIndex;
    }

}
