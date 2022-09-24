using UnityEngine;

namespace Player
{
    public class Movement : MonoBehaviour
    {
        private InputManager _inputManager;

        [Header("Handling Settings")] [SerializeField]
        private float yawTorque = 500f, pitchTorque = 1000f, rollTorque = 1000f, thrust = 100f;
        private float _glide = 0;
        private Camera mainCam;
        private Rigidbody _rb;
    
        private void Awake()
        {
            mainCam = Camera.main;
            _inputManager = GetComponent<InputManager>();
            _rb = GetComponent<Rigidbody>();
        }

        public void HandleAllMovement()
        {
            _rb.AddRelativeForce(Vector3.forward * _inputManager.thrust);
            HandleThrust();
            HandleRoll();
            HandleYaw();
            HandlePitch();
        }

        private void HandlePitch()
        {
            _rb.transform.Rotate(Vector3.right * (Mathf.Clamp(-_inputManager.pitchYaw.y, -1f, 1f) * pitchTorque * Time.deltaTime));
        }

        private void HandleThrust()
        {
            if (_inputManager.thrust > 0.1f || _inputManager.thrust < -0.1f)
            {
                float currentThrust = _inputManager.thrust;
                _rb.AddRelativeForce(Vector3.forward * (_inputManager.thrust * currentThrust * Time.deltaTime));
                _glide = thrust;
            }
            else
            {
                _rb.AddRelativeForce(Vector3.forward * (_glide * Time.deltaTime));
            }
        }

        private void HandleYaw()
        {
            _rb.transform.Rotate(Vector3.up * (Mathf.Clamp(_inputManager.pitchYaw.x, -1f,1f) * yawTorque * Time.deltaTime));
        }

        void HandleRoll()
        {
            transform.Rotate(0, 0 , -_inputManager.roll * rollTorque * Time.deltaTime);
//            _rb.transform.Rotate(Vector3.forward * (-_inputManager.roll * rollTorque * Time.deltaTime));
        }
    }
}