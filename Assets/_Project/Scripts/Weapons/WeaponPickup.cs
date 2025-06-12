using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    [SerializeField] private GameObject weaponPrefab;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameObject newWeapon = Instantiate(weaponPrefab, collision.transform);

            Destroy(gameObject); // Rimuove il pickup dal mondo
        }
    }
}
