using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoaimGun : MonoBehaviour
{
    public static AutoaimGun instance { private set; get; }
    [SerializeField] private GameObject bullet;
    private float timeOfLastFire;
    [SerializeField] private float timeBetweenFire=2f;
    public float fireRateMulti = 1f;
    public float damageMulti=1f;    
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        if (Time.timeSinceLevelLoad - timeOfLastFire > timeBetweenFire * fireRateMulti&&GameManager.Instance.enemyList.Count>0)
        {
            Bullet spawnedBullet = Instantiate(bullet, transform.position, Quaternion.identity).GetComponent<Bullet>();
            spawnedBullet.Reset((Vector2)(GameManager.Instance.enemyList[ChooseTarget()].position-transform.position),damageMulti);
            timeOfLastFire = Time.timeSinceLevelLoad;
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
