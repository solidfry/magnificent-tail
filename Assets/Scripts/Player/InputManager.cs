
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerControls _playerControls;

    public float thrust;
    public float roll;
    public Vector2 pitchYaw;
    
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
   
   public void OnLookMovement(InputAction.CallbackContext context)
   {
       pitchYaw = context.ReadValue<Vector2>();
   }
   
   public void OnRoll (InputAction.CallbackContext context)
   {
       roll = context.ReadValue<float>();
   }
   
}
