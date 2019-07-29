using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    Rigidbody2D myRigidBody;
    [SerializeField] float health = 100;
    [SerializeField] float shotCounter;
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 3f;


    //[Header("Projectile")]
    //[SerializeField] GameObject enemyLaser;
    //[SerializeField] float projectileSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
       
    }

    // Update is called once per frame
    void Update()
    {
        //checks if enemy has been flipped
        if (IsFacingRight())
        { 
        myRigidBody.velocity = new Vector2(moveSpeed, 0f);
        }
        else
        {
            myRigidBody.velocity = new Vector2(-moveSpeed, 0f);
        }

        //CountDownandShoot();
    }

    //private void CountDownandShoot()
    //{
    //    shotCounter -= Time.deltaTime;
    //    if (shotCounter <= 0f)
    //    {
    //        Fire();
    //    }
    //}

    //private void Fire()
    //{
    //    if (Input.GetButtonDown("Fire1"))
    //    {
    //        GameObject fireLaser = Instantiate(
    //            enemyLaser,
    //            transform.position,
    //            Quaternion.identity) as GameObject;
    //        fireLaser.GetComponent<Rigidbody2D>().velocity = new Vector2(-projectileSpeed, 0);

    //    }
    //}
    bool IsFacingRight()
    {
        return transform.localScale.x > 0;
    }

    //flips the enemy when it collides 
    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.localScale = new Vector2(-(Mathf.Sign(myRigidBody.velocity.x)), 1f);

    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();

        ProcessHit(damageDealer);
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        if (health <= 0)
        {
            Destroy(gameObject);

        }
    }
}
