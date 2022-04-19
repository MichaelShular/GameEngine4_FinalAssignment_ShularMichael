using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WandComponent : WeaponComponent
{
    Vector3 hitLocation;
    public GameObject manaBall;


    protected override void FireWeapon()
    {


        if (weaponStats.bulletsInClip > 0 && !isReloading)
        {
            //base.FireWeapon();
            //if (firingEffect)
            //{
            //    firingEffect.Play();
            //}
            //Ray screenRay = mainCamera.ViewportPointToRay(new Vector2(0.5f, 0.5f));
            //if (Physics.Raycast(screenRay, out RaycastHit hit, weaponStats.fireDistance, weaponStats.weaponsHitLayers))
            //{
            //    hitLocation = hit.point;
            //    DealDamage(hit);
            //    Vector3 hitDirection = hit.point - mainCamera.transform.position;
            //    Debug.DrawRay(mainCamera.transform.position, hitDirection.normalized * weaponStats.fireDistance, Color.red, 1);


            //}
            
            GameObject temp = Instantiate(manaBall);
            temp.transform.position = this.gameObject.transform.position;
            temp.transform.forward = mainCamera.transform.forward;
            temp.GetComponent<ManaBallMovement>().damage = weaponStats.damage;

        }
        else if (weaponStats.bulletsInClip <= 0)
        {
            weaponHolder.StartReloading();
        }

    }

    void DealDamage(RaycastHit hitInfo)
    {
        IDamagable damagable = hitInfo.collider.GetComponent<IDamagable>();
        damagable?.TakeDamage(weaponStats.damage);
    }

   

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(hitLocation, 0.1f);
    }
}
