using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickShoot : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject CharacterModel;
    private GameObject CurrentBullet;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("Tried to fire shot");
            String location = "Character/Weapons/Glock19/Bullet";
            GameObject ammoPrefab = Resources.Load<GameObject>(location);
            Transform GunObject = GameObject.Find("Hitman").transform.Find("Weapon").transform;
            CurrentBullet = Instantiate(ammoPrefab,GunObject.position,GunObject.rotation);
            CurrentBullet.transform.localScale = new Vector3(0.08f, 0.08f, 0.08f);
            CurrentBullet.transform.parent = GameObject.Find("Projectiles").transform;
            CurrentBullet.AddComponent<MoveProjectile>();
            MoveProjectile movScript = CurrentBullet.GetComponent<MoveProjectile>();
        }
    }
}
