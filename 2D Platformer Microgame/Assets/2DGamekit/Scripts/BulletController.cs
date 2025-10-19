using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gamekit2D;

public class BulletController : MonoBehaviour
{
    public GameObject bullet;
    private GameObject bulletSpawned;

    public Transform leftPoint;
    public Transform rightPoint;
    public PlayerCharacter playerCharacter;

    private Transform spawnPoint;

    private bool direction = false;

    public Transform parentTransform;

    public float speed = 7f;

    private Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = speed * Vector3.right * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            spawnPoint = rightPoint;
            if (playerCharacter.GetFacing() == -1)
            {
                spawnPoint = leftPoint;
                //direction = true;
            }
            // spawnPoint = playerCharacter.GetFacing() == -1 ? leftPoint : rightPoint;

            bulletSpawned = Instantiate(bullet, spawnPoint.position, Quaternion.identity);
            bulletSpawned.GetComponent<BulletController>().speed *= -1;
            bulletSpawned.GetComponent<SpriteRenderer>().flipX = true;
            /*if (direction)
            {
                bulletSpawned.GetComponent<Bullet>().speed *= -1;
                bulletSpawned.GetComponent<SpriteRenderer>().flipX = true;
            }*/
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
