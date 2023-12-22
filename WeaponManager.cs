using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class WeaponManager : MonoBehaviour
{
    public GameObject CharacterModel;
    void Start()
    {
        SpawnGun();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject Guns = GameObject.Find("WorldGuns");
        foreach (Transform weapon in Guns.transform)
        {
            BoxCollider2D collider = weapon.GetComponent<BoxCollider2D>();
            CapsuleCollider2D playerCollider = CharacterModel.GetComponent<CapsuleCollider2D>();
            if ( collider.IsTouching(playerCollider) )
            {
                Debug.Log("Touched gun");
            }

        }

    }

    void SpawnGun()
    {
        PlayerControls playerController = CharacterModel.GetComponent<PlayerControls>();
        String weapon = playerController.weapon;
        if (weapon != null)
        {
            Debug.Log("Weapon was not null: " + playerController.weapon.ToString());
            if (weapon == "Glock19")
            {
                String location = "Character/Weapons/Glock19/Weapon";
                Vector2 localP = new Vector2(1.45f, 2.04f);
                Quaternion rotation = Quaternion.Euler(0, 0, 0);
                Vector2 scale = new Vector2(0.25f, 0.25f);
                GameObject weaponPrefab = Resources.Load<GameObject>(location);
                GameObject weaponClone = Instantiate(weaponPrefab, localP, rotation);
                weaponClone.name = "Weapon";
                weaponClone.transform.SetParent(CharacterModel.transform, false);
                weaponClone.transform.localPosition = localP;
                weaponClone.transform.localRotation = rotation;
                weaponClone.transform.localScale = scale;
            }
        }
    }
}
