using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.VersionControl;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float speed = 200.0f;
    private Rigidbody2D rb;
    public string weapon;

    void spawnGun()
    {
        if (weapon != null)
        {

        }
        else
        {
            Debug.LogError("No weapon assigned");
        }
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.interpolation = RigidbodyInterpolation2D.Interpolate;

    }
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = transform.position.z;
        Vector2 direction = mousePos - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        angle -= 90f;
        rb.rotation = angle;//Quaternion.Euler(0, 0, angle);

        float hInput = Input.GetAxisRaw("Horizontal");
        float vInput = Input.GetAxisRaw("Vertical");

        if (Mathf.Abs(hInput) > 0 || Mathf.Abs(vInput) > 0)
        {
            Vector2 direction2 = new Vector2(hInput, vInput).normalized;
            Vector2 movement = direction2 * speed;
            rb.velocity = movement;
            rb.angularVelocity = 0f;
        }
        else
        {
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;
        }
    }
}