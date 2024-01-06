using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootEnemy : MonoBehaviour
{
    [SerializeField] float damage = 10;//serialize field makes a variable visible in unity editor without making it public(just learned hehe) 
    [SerializeField] float delay = 0.5f;
    [SerializeField] Image c1, c2, c3, c4;
    [SerializeField] float maxCrosshairMove = 7f;
    [SerializeField] GameObject tracer,GunBarrelTip,bullet;
    [SerializeField] Vector2 pistolPitchRange;
    int defaultLayerMask = 1 << 0;
    int layerMask = 1 << 6;
    bool EnemyInSight = false;
    bool isEnemyInLine = false;
    bool isWallInLine = false;
    bool shootBuffer = false;
    bool shooting = false;
    bool singleShotWeapon = true;
    RaycastHit hitNonEnemy;
    RaycastHit hitEnemy;
    LineRenderer bulletTraceRenderer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastEnemy();
        //Found if Enemy on Crosshair
        
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            print("ButtonDown");
            AudioManager.Instance.playPistolShootSound();
            Shoot();
            if (EnemyInSight)
            {
                DamageEnemy();
            }
        }
    }

    void RaycastEnemy() {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hitEnemy, Mathf.Infinity, layerMask))
        {
            isEnemyInLine = true;

        }
        else
        {
            isEnemyInLine = false;
        }
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hitNonEnemy, Mathf.Infinity, defaultLayerMask))
        {
            isWallInLine = true;
        }
        else
        {
            isWallInLine = false;
        }
        if (isEnemyInLine)
        {
            if (isWallInLine)
            {
                if (hitEnemy.distance < hitNonEnemy.distance)
                {
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hitEnemy.distance, Color.yellow);
                    EnemyInSight = true;
                }
                else
                {
                    EnemyInSight = false;
                }
            }
            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hitEnemy.distance, Color.yellow);
                EnemyInSight = true;
            }
        }
        else
        {
            EnemyInSight = false;
        }
    }

    void Shoot()
    {
        shooting = true;
        StartCoroutine(CrosshairMove());
        //StartCoroutine(TraceBullet());
        StartCoroutine(ShootDelay());
        /*if (singleShotWeapon)
        {
            CheckFireButtonUp();
        }
        else {
            StartCoroutine(ShootDelay());
        }*/
    }

   
    IEnumerator ShootDelay()
    {
        yield return new WaitForSeconds(delay);
        shootBuffer = false;
    }

    void CheckFireButtonUp()
    {
        if (Input.GetMouseButtonUp(0))
        {
            shootBuffer = false;
        }
    }

    /*IEnumerator TraceBullet() {
        tracer.SetActive(true);
        yield return new WaitForSeconds(0.05f);
        tracer.SetActive(false);
    }*/

    IEnumerator CrosshairMove() {
        float n = maxCrosshairMove;
        while (n > 5.4)
        {
            n -= 0.1f;
            CrosshairTransition(n);
            if (shooting) {
                n = maxCrosshairMove;
                CrosshairTransition(6.4f);
                shooting = false;
            }
            yield return new WaitForFixedUpdate();
        }
    }

    void CrosshairTransition(float n)
    {
        c1.rectTransform.localPosition = new Vector3(0, n, 0) ;
        c2.rectTransform.localPosition = new Vector3(0, -n, 0);
        c3.rectTransform.localPosition = new Vector3(-n, 0, 0);
        c4.rectTransform.localPosition = new Vector3(n, 0, 0);
    }
    //pulls back crosshair on shoot

    

    void DamageEnemy()
    {
        if (!shootBuffer)
        { //Left click
            GameObject enemy = hitEnemy.collider.gameObject;
            enemy.GetComponent<Enemy>().health.takeDamage(damage);//call damage function in enemyHealth      
            shootBuffer = true;
            //StartCoroutine(ShootDelay());
        }
    }
}
