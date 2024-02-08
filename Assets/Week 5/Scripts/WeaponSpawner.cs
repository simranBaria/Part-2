using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
    public GameObject weapon;

    public void SpawnWeapon()
    {
        Vector3 spawnLocation = new Vector3 (11, Random.Range(-5, 5));
        Instantiate(weapon, spawnLocation, weapon.transform.rotation);
    }
}
