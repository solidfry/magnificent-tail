using UnityEngine;

namespace Player
{
    public class Movement : MonoBehaviour
    {
        private InputManager _inputManager;

        [Header("Handling Settings")] 
        [SerializeField] private float yawTorque = 500f;
        [SerializeField] private float pitchTorque = 1000f;
        [SerializeField] private float rollTorque = 1000f;
        [SerializeField] private float thrustMultiplier = 2f; 
        [SerializeField] private float constantThrust = 35f;
//        private Camera mainCam;
        private Transform _tr;
        private Rigidbody _rb;
    
        private void Awake()
        {
//            mainCam = Camera.main;
            _inputManager = GetComponent<InputManager>();
            _rb = GetComponent<Rigidbody>();
            _tr = GetComponent<Transform>();
        }

        public void HandleAllMovement()
        {
            HandleThrust();
            HandleRoll();
            HandleYaw();
            HandlePitch();
        }

        private void HandlePitch()
        {
            _rb.transform.Rotate(Mathf.Clamp(_inputManager.pitch * pitchTorque * Time.deltaTime, -1f, 1f), 0, 0);
        }

        private void HandleThrust()
        {
            if (_inputManager.thrust > 0.1f || _inputManager.thrust < -0.1f)
            {
                _rb.AddForce(_tr.forward * (constantThrust * thrustMultiplier)) ;
            }
            else
            {
                _rb.AddForce(_tr.forward * constantThrust);
            }
        }

        private void HandleYaw()
        {
            _rb.transform.Rotate(0, Mathf.Clamp(_inputManager.yaw, -1f,1f) * yawTorque * Time.deltaTime,0);
        }

        void HandleRoll()
        {
            _rb.transform.Rotate(0, 0 , -_inputManager.roll * rollTorque * Time.deltaTime);
        }
    }
}