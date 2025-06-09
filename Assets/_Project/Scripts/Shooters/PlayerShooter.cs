using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : AbstractShooter
{
    private Camera _cam;

    private void Awake()
    {
        _cam = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && CanShoot())
        {
            Vector3 screenPos = Input.mousePosition;
            screenPos.z = _cam.nearClipPlane;

            Vector3 worldPos = _cam.ScreenToWorldPoint(screenPos);
            //worldPos.z = 0; // <- in un gioco 2D molto probabilmente posso ridurre a 0 la Z
            worldPos.z = transform.position.z; // <- stessa coordinata Z di questo oggetto

            Vector3 shootDirection = worldPos - transform.position;

            Shoot(transform.position, shootDirection);
        }
    }
}
