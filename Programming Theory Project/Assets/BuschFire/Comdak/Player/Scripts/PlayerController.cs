using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Variables

    private PlayerInputSystem inputSystem;
    private ShipMotion shipMotion;
    private ActiveWeapon activeWeapon;

    #endregion

    #region Unity Methods
    private void Awake()
    {
        shipMotion = GetComponent<ShipMotion>();
        if (!shipMotion)
            Debug.LogError("Ship motion not found in player controller");
        activeWeapon = GetComponent<ActiveWeapon>();
        if (!activeWeapon)
            Debug.LogError("Active Weapon not found in player controller");

        inputSystem = new PlayerInputSystem();

        //inputSystem.PlayerControl.Move.performed += ctx =>
        //{
        //    var input = ctx.ReadValue<Vector2>();
        //    shipMotion.Thrust(input.y);
        //    shipMotion.Strafe(input.x);
        //};
        //inputSystem.PlayerControl.Move.canceled += ctx =>
        //    {
        //        shipMotion.Thrust(0);
        //        shipMotion.Strafe(0);
        //    };

        //inputSystem.PlayerControl.Turn.performed += ctx =>
        //{
        //    var input = ctx.ReadValue<Vector2>();
        //    shipMotion.Rotate(input.x);
        //};
        //inputSystem.PlayerControl.Turn.canceled += ctx =>
        //{
        //    shipMotion.Rotate(0);
        //};

        inputSystem.PlayerControl.FireWeapon.performed += ctx =>
        {
            activeWeapon.FireWeapon();
        };

        

    }
    private void OnEnable()
    {
        inputSystem.PlayerControl.Enable();
    }

    private void OnDisable()
    {
        inputSystem.PlayerControl.Disable();
    }

    private void Update()
    {
        if(inputSystem.PlayerControl.Move.IsPressed())
        {
            var input = inputSystem.PlayerControl.Move.ReadValue<Vector2>();
            shipMotion.DirectionalThrustInput(input);
            
        }
        if(inputSystem.PlayerControl.Turn.IsPressed())
        {
            var input = inputSystem.PlayerControl.Turn.ReadValue<Vector2>();
            shipMotion.RotationalThrustInput(input.x);
        }
    }

    #endregion
}
