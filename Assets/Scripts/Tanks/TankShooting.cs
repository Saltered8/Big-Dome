using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankShooting : MonoBehaviour
{
    // Prefab of the Shell    
    public Rigidbody m_Shell;
    // A child of the tank where the shells are spawned     
    public Transform m_FireTransform;
    // The force given to the shell when firing     
    public float m_LaunchForce = 30f;

    public int numShells;
    public int maxShells = 1;
    public float reloadTime = 2;
    public float reloadTimer;
    public Image reloadClock;

    private void Start() 
    {
        numShells = maxShells;
    }

    // Update is called once per frame    
    private void Update()
    {
        // TODO: Later on, we'll check with the 'Game Manager' to make          
        // sure the game isn't over 

        if (Input.GetButtonUp("Fire1"))
        {
            Fire();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            reloadTimer = reloadTime;
        }

        {
            if (reloadTimer > 0)
            {
                //count down
                reloadTimer -= Time.deltaTime;
                if (reloadTimer <= 0)
                {
                    numShells = maxShells;
                }
            }
        }
        {
            if (reloadClock) 
            {
                reloadClock.fillAmount = 1- reloadTimer / reloadTime;
                if (numShells == 0 && reloadTimer <=0) reloadClock.fillAmount = 0;
            }
        }
    }

    private void Fire()
    {
        if (numShells <= 0)
            return;

        numShells--;
        // Create an instance of the shell and store a reference to its rigidbody         
        Rigidbody shellInstance = Instantiate(m_Shell,
            m_FireTransform.position,
            m_FireTransform.rotation) as Rigidbody;

        // Set the shell's velocity to the launch force in the fire   
        // position's forward direction         
        shellInstance.velocity = m_LaunchForce * m_FireTransform.forward;
    }
}
