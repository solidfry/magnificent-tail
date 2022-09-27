using Unity.VisualScripting;
using UnityEngine;

namespace Player
{
    public class Movement : MonoBehaviour
    {
        private InputManager inputManager;

        [Header("Handling Settings")] 
        [SerializeField] private float yawTorque = 500f;
        [SerializeField] private float pitchTorque = 1000f;
        [SerializeField] private float rollTorque = 1000f;
        [SerializeField] private float thrustMultiplier = 2f; 
        [SerializeField] private float constantThrust = 35f;
        private bool isDead = false;
        private Transform tr;
        private Rigidbody rb;
        public bool IsDead
        {
            get => isDead;
            set => isDead = value;
        }
        
        private void Awake()
        {
            inputManager = GetComponent<InputManager>();
            rb = GetComponent<Rigidbody>();
            tr = GetComponent<Transform>();
        }

        public void HandleAllMovement()
        {
            HandleThrust();
            HandleRoll();
            HandleYaw();
            HandlePitch();
        }

        private void HandlePitch() => 
            rb.transform.Rotate(Mathf.Clamp(inputManager.pitch * pitchTorque * Time.deltaTime, -1f, 1f), 0, 0);

        private void HandleThrust()
        {
            if (isDead) return; 
            
            if (inputManager.thrust > 0.1f)
            {
                rb.AddForce(tr.forward * (constantThrust * thrustMultiplier)) ;
            }
            else if (inputManager.thrust < -0.1f)
            {
                rb.AddForce(tr.forward * (constantThrust / thrustMultiplier));
            }
            else
            {
                rb.AddForce(tr.forward * constantThrust);
            }
        }

        private void HandleYaw() =>
            rb.transform.Rotate(0, Mathf.Clamp(inputManager.yaw, -1f,1f) * yawTorque * Time.deltaTime,0);
        

        void HandleRoll() =>
            rb.transform.Rotate(0, 0 , -inputManager.roll * rollTorque * Time.deltaTime);
        
    }
}