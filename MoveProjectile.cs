using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveProjectile : MonoBehaviour
{
    // Start is called before the first frame update
    public float BulletSpeed = 10.0f;
    public float bulletLife = 1.0f;
    // Update is called once per frame
    Vector3 direction;
    private void Start()
    {
        direction = transform.up;
    }
    void FixedUpdate()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = direction * 10.0f;
        StartCoroutine(deleteOnTime(bulletLife));
    }
    IEnumerator deleteOnTime(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector3 hitp = collision.GetContact(0).point;
        hitp = new Vector2(hitp.x, hitp.y);
        GameObject ExplosionVFX = Resources.Load<GameObject>("Character/Animations/explosion");
        GameObject ExploVFX = Instantiate(ExplosionVFX, hitp, Quaternion.identity);
        Destroy(gameObject);
    }
}
