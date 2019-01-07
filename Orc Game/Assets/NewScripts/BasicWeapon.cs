using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicWeapon : MonoBehaviour
{

    public Transform bulletStart;
    public GameObject bullet;

    public float TimeBetweenShots = 0.5f;
    public float startTimeBetweenShots;

    private void Start()
    {
        startTimeBetweenShots = TimeBetweenShots;
    }


    // Update is called once per frame
    void Update () {

        if (TimeBetweenShots <= 0)
        {
            if (Input.GetKey(KeyCode.I) && Input.GetKey(KeyCode.L))
            {
                bulletStart.rotation = Quaternion.Euler(0f, 0f, 45f);

                Instantiate(bullet, bulletStart.position, bulletStart.rotation);

            }
            else if (Input.GetKey(KeyCode.I) && Input.GetKey(KeyCode.J))
            {
                bulletStart.rotation = Quaternion.Euler(0f, 0f, 135f);

                Instantiate(bullet, bulletStart.position, bulletStart.rotation);

            }
            else if (Input.GetKey(KeyCode.L) && Input.GetKey(KeyCode.K))
            {
                bulletStart.rotation = Quaternion.Euler(0f, 0f, -45f);

                Instantiate(bullet, bulletStart.position, bulletStart.rotation);
            }
            else if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.K))
            {
                bulletStart.rotation = Quaternion.Euler(0f, 0f, -135f);

                Instantiate(bullet, bulletStart.position, bulletStart.rotation);
            }
            else if (Input.GetKey(KeyCode.L))
            {
                bulletStart.rotation = Quaternion.Euler(0f, 0f, 0f);
                Instantiate(bullet, bulletStart.position, bulletStart.rotation);
            }
            else if (Input.GetKey(KeyCode.I))
            {
                bulletStart.rotation = Quaternion.Euler(0f, 0f, 90f);

                Instantiate(bullet, bulletStart.position, bulletStart.rotation);
            }
            else if (Input.GetKey(KeyCode.J))
            {
                bulletStart.rotation = Quaternion.Euler(0f, 0f, 180f);

                Instantiate(bullet, bulletStart.position, bulletStart.rotation);
            }
            else if (Input.GetKey(KeyCode.K))
            {
                bulletStart.rotation = Quaternion.Euler(0f, 0f, -90f);

                Instantiate(bullet, bulletStart.position, bulletStart.rotation);
            }

            TimeBetweenShots = startTimeBetweenShots;
        }
        else
        {
            TimeBetweenShots -= Time.deltaTime;
        }
		
    }

	
	
}
