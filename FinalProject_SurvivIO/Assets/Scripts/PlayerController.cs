using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject playerModel;

    [SerializeField] private FixedJoystick joystickMovement;
    [SerializeField] private FixedJoystick joystickAim;

    [SerializeField] public Ammo ammoPistol = new Ammo(15, 90);
    [SerializeField] public Ammo ammoRifle = new Ammo(30, 120);
    [SerializeField] public Ammo ammoShotgun = new Ammo(2, 60);


    public float speed = 1f;


    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        //Non Rigidbody Controls
        //player.transform.position += new Vector3(joystickMovement.Horizontal * speed * Time.deltaTime, joystickMovement.Vertical * speed * Time.deltaTime);

        //Rigidbody Joystick controls
        Vector3 force = new Vector3(joystickMovement.Horizontal, joystickMovement.Vertical) * speed;
        player.GetComponent<Rigidbody2D>().velocity = force;

        if (joystickAim.Horizontal != 0 && joystickAim.Vertical != 0)
        playerModel.transform.right = new Vector3(joystickAim.Horizontal, joystickAim.Vertical);
    }
}
