using UnityEngine;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    public class ThirdPersonUserControl : MonoBehaviour
    {
        private ThirdPersonCharacter m_Character; // A reference to the ThirdPersonCharacter on the object.
        private Transform m_Cam;                  // A reference to the main camera in the scenes transform.
        private Vector3 m_CamForward;             // The current forward direction of the camera.
        private Vector3 m_Move;
        private bool m_Jump;                      // The world-relative desired move direction, calculated from the camForward and user input.
        
        private void Start()
        {
            // Get the transform of the main camera.
            if (Camera.main != null)
            {
                m_Cam = Camera.main.transform;
            }
            else
            {
                Debug.LogWarning("Warning: no main camera found. Third person character needs a Camera tagged \"MainCamera\", for camera-relative controls.", gameObject);
                // We use self-relative controls in this case, which probably isn't what the user wants, but hey, we warned them!
            }

            // Get the third person character (this should never be null due to require component).
            m_Character = GetComponent<ThirdPersonCharacter>();
        }

        private void Update()
        {
            if (!m_Jump)
            {
                m_Jump = Input.GetKeyDown(KeyCode.Space);
            }
        }

        // Fixed update is called in sync with physics.
        private void FixedUpdate()
        {
            // Read inputs.
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            bool crouch = Input.GetKey(KeyCode.C);

            // Calculate move direction to pass to character.
            if (m_Cam != null)
            {
                // Calculate camera relative direction to move:
                m_CamForward = Vector3.Scale(m_Cam.forward, new Vector3(1, 0, 1)).normalized;
                m_Move = v*m_CamForward + h*m_Cam.right;
            }
            else
            {
                // We use world-relative directions in the case of no main camera.
                m_Move = v*Vector3.forward + h*Vector3.right;
            }
#if !MOBILE_INPUT
            // Walk speed multiplier.
            if (Input.GetKey(KeyCode.LeftShift)) m_Move *= 1;
            else m_Move *= 0.5f;
#endif

            // Pass all parameters to the character control script.
            m_Character.Move(m_Move, crouch, m_Jump);
            m_Jump = false;
        }
    }
}
