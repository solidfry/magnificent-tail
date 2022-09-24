
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private PlayerControls _playerControls;

    public Vector2 movementInput;
    public float accelerate;
    public Vector2 directionInput;
    
    
    private void OnEnable()
    {
        if (_playerControls == null)
        {
            _playerControls = new PlayerControls();
            _playerControls.Flight.Enable();
            _playerControls.Flight.Movement.performed += i => movementInput = i.ReadValue<Vector2>();
            _playerControls.Flight.Yaw.performed += i => directionInput = i.ReadValue<Vector2>();
        }
        
    }
    
    private void OnDisable()
    {
        _playerControls.Disable();
    }
    
    public void HandleAllInputs()
    {
        HandleMovementInput();
    }
    
   private void HandleMovementInput()
    {
        accelerate = movementInput.y;
        
    }

   
    
  
}
