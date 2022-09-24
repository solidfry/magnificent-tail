using UnityEngine;

namespace Player
{
    public class Movement : MonoBehaviour
    {
        private InputManager _inputManager;
        
        private Vector3 _moveDirection;
        public float speed = 2f;
        public float rotationSpeed = 15f;
        private Rigidbody _playerRigidbody;
    
        private void Awake()
        {
            _inputManager = GetComponent<InputManager>();
            _playerRigidbody = GetComponent<Rigidbody>();
        }

        public void HandleAllMovement()
        {
            HandleAcceleration();
            HandleYaw();
        }
        
        private void FixedUpdate()
        {
            this.transform.Rotate(_moveDirection.x, _moveDirection.y, _moveDirection.z);
            _playerRigidbody.velocity += _playerRigidbody.velocity * Time.deltaTime * speed;
        }

        private void HandleAcceleration()
        {
            _moveDirection = this.transform.forward * _inputManager.accelerate;
            _moveDirection.Normalize();
            _moveDirection *= speed;
            
            Vector3 moveVelocity = _moveDirection;
            _playerRigidbody.velocity = moveVelocity;
        }

        private void HandleYaw()
        {
            Vector3 targetDirection = _inputManager.directionInput;
            targetDirection.z = 0;
            targetDirection.Normalize();

            if (targetDirection == Vector3.zero)
                targetDirection = transform.forward;

            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            Quaternion playerRotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            transform.rotation = playerRotation;
        }
    }
}