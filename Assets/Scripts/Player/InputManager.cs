
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerControls _playerControls;

    public float thrust;
    public float roll;
    public float pitch;
    public float yaw;
    
    private void OnEnable()
    {
        if (_playerControls == null)
        {
            _playerControls = new PlayerControls();
            _playerControls.Flight.Enable();
        }
    }
    private void OnDisable() => _playerControls.Disable();
    
   public void OnThrust(InputAction.CallbackContext context)
   {
       thrust = context.ReadValue<float>();
   }
   
   public void OnPitch(InputAction.CallbackContext context)
   {
       pitch = context.ReadValue<float>();
   }

   public void OnYaw(InputAction.CallbackContext context)
   {
       yaw = context.ReadValue<float>();
   }
   
   public void OnRoll (InputAction.CallbackContext context)
   {
       roll = context.ReadValue<float>();
   }
   
}
