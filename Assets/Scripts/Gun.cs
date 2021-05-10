using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Gun : MonoBehaviour
{
    public float damage = 20f;
    public float range = 100f;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public int counterNum = 0;
    public Text scoreText;

    public float ammo = 50f;
    public Text ammoText;

    public GameObject reloadText;
    
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && ammo >= 1f)
        {
            Shoot();
            ammo -= 1;
            AudioManager.instance.Play("Gunshot");
        }

        if (Input.GetButtonDown("Fire1") && ammo == 0f)
        {
            AudioManager.instance.Play("Empty Gun");
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }

        if (ammo == 0f)
        {
            reloadText.SetActive (true);
        }
        else
        {
            reloadText.SetActive (false);
        }
       

        //string myString = myInt.ToString();
        scoreText.text = counterNum.ToString();
        
        ammoText.text = ammo.ToString();

    }

    void Shoot()
    {
        muzzleFlash.Play();
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();

            if (target != null)
            {
                target.TakeDamage(damage);
                counterNum += 1;
            }
        }


    }

    void Reload()
    {
        Debug.Log("reload");
        ammo = 50f;
    }
}
