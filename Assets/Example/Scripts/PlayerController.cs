using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using OpenAI_Unity;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public InputField questionInput;
    public float speakRange = 10;

    private Rigidbody rb;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();

        questionInput.onEndEdit.AddListener((string data) =>
        {
            if (!string.IsNullOrEmpty(data))
            {
                Collider[] surroundingColliders = Physics.OverlapSphere(this.transform.position, this.speakRange);
                foreach (Collider c in surroundingColliders)
                {
                    var ai = c.GetComponent<OAICharacter>();
                    if (ai)
                    {
                        ai.AddToStory(data);
                    }
                }
            }
            questionInput.text = "";
        });
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            questionInput.Select();
            questionInput.ActivateInputField();
        }

        //Lock and hide the cursor in the center of the screen
        Cursor.lockState = CursorLockMode.Locked;
        //Setting this to false makes sure it's also invisible in the build
        Cursor.visible = false;

        //Gets the input from A/D or Left/Right Arrow. Gives a value between -1 and 1
        float horizontalInput = questionInput.isFocused ? 0 : Input.GetAxis("Horizontal");
        float verticalInput = questionInput.isFocused ? 0 : Input.GetAxis("Vertical");

        //When creating the input Vector, we set the y-velocity to the original velocity
        //This way, it does not reset to 0 every frame
        Vector3 input = new Vector3(horizontalInput * speed, rb.velocity.y, verticalInput * speed);

        //This rotates the input Vector based on the rotation of our transform
        Vector3 rotatedInput = transform.TransformVector(input);

        //We set the velocity of the object, so we do NOT need Time.deltaTime
        //When moving an object with a Rigidbody, we should always use the velocity/forces, NOT transform.Translate
        rb.velocity = rotatedInput;

        //This will get the DELTA position (=movement) of the Mouse 
        float mouseXMovement = Input.GetAxis("Mouse X");
        float mouseYMovement = Input.GetAxis("Mouse Y");

        //We rotate the character around it's y-axis
        transform.Rotate(0, mouseXMovement, 0);

        //We rotate the PARENT of the Camera. This is the CamPivot
        //The CamPivot is placed above the teddy, so when it rotates, the camera rotates along but keeps the teddy in view
        Camera.main.transform.parent.Rotate(-mouseYMovement, 0, 0);

        //We send the horizontal & vertical input to our animator, so it can play the right animation (E.g. run)
        anim.SetFloat("HorizontalSpeed", horizontalInput);
        anim.SetFloat("VerticalSpeed", verticalInput);
    }


    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(this.transform.position, speakRange);
    }

}
