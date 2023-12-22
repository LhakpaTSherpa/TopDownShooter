using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    // Start is called before the first frame update
    private Animation anim;
    void Start()
    {
        anim = GetComponent<Animation>();
    }
    public void OnAnimationComplete()
    {
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        anim.Play();
    }
}
