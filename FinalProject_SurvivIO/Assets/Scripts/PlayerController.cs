using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject playerModel;

    [SerializeField] private PlayerInventory inventory;

    [SerializeField] private FixedJoystick joystickMovement;
    [SerializeField] private FixedJoystick joystickAim;
    [SerializeField] private HUD hud;

    public float speed = 1f;
    private bool isReloading;

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

    public void Shoot()
    {
        if (!isReloading)
        {
            if (inventory.EquippedGun)
            {
                Debug.Log("Player Input Fired");
                inventory.EquippedGun.GetComponent<Gun>().Fire();

            }

            else
                Debug.Log("No Gun");
        }
    }

    public void Reload()
    {
        if (!isReloading) {

            if (!inventory.EquippedGun.GetComponent<Gun>().gunAmmo.isTotallyEmpty())
            {
                StartCoroutine(CO_Reload());
            }

            else if (!inventory.EquippedGun)
                Debug.Log("No Gun to Reload");

            else
            {
                Debug.Log("Gun Totally Empty");
            }
        }
    }

    public void SwitchWeapon()
    {
        inventory.SwitchWeapon();
    }

    IEnumerator CO_Reload()
    {
        Debug.Log("Reloading...");
        isReloading = true;
        yield return new WaitForSeconds(1.5f);

        inventory.EquippedGun.GetComponent<Gun>().Reload();
        isReloading = false;
        Debug.Log("Reloaded");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Damage Code
    }
}
