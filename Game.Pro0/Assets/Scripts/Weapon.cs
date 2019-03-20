using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public int damage = 40;
    public GameObject Bullet;
    public GameObject Player;



    public int maxAmmo = 10;
    private int currentAmmo;
    public float reloadTime = 1f;
    private bool isReloading = false;

    private void Start()
    {
        currentAmmo = maxAmmo;
       
    }

    // Update is called once per frame
    void Update()
    {

        if (isReloading)
            return;
        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }


        if (Input.GetButtonDown("Fire1") && maxAmmo > 0)
        {

            Shoot();
            //Debug.Log("shoot");
        }
    }
    IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("Reload...");

        yield return new WaitForSeconds(reloadTime);
        currentAmmo = maxAmmo;
        isReloading = false;
    }



    void Shoot ()
    {
        maxAmmo--;

        FindObjectOfType<AudioManager>().Play("BulletShot");
        Instantiate(Bullet, firePoint.position, firePoint.rotation);
        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right);

        if (hitInfo)
        {
            Enemy enemy = hitInfo.transform.GetComponent<Enemy>();
            if(enemy != null)
            {
                enemy.TakeDamage(damage);
            }
            Debug.Log(hitInfo.transform.name);
        }
    }
}
