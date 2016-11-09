using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
    #region movement
    public float movementSpeed = 10f;
    public float rotationSpeed = 10f;
    public float jumpHeight = 2f;
    private bool isGrounded = false;
    private Rigidbody rigid = null;
    public bool isCannon = true;
    #endregion
    // Use this for initialization
    void Start () {
        rigid = GetComponentInParent<Rigidbody>();
    }
	
	// Update is called once per frame
	void LateUpdate () {
        
            HandleInput();
           
    }
    void HandleInput()
    {
        KeyCode[] keys =
        {
            KeyCode.W,
            KeyCode.S,
            KeyCode.A,
            KeyCode.D,
            KeyCode.Space
        };

        foreach (var key in keys)
        {
            if (Input.GetKey(key))
            {
                Move(key);
            }

        }
    }

    //seperate move function for moving player
    void Move(KeyCode key)
    {
        Vector3 position = rigid.position;
        Quaternion rotation = rigid.rotation;
        if (isCannon)
        {

            switch (key)
            {
                case KeyCode.W:
                    position += transform.forward * movementSpeed * Time.deltaTime;
                    break;
                case KeyCode.S:
                    position += -transform.forward * movementSpeed * Time.deltaTime;
                    break;
                case KeyCode.A:
                    position += -transform.right * movementSpeed * Time.deltaTime;
                    break;
                case KeyCode.D:
                    position += transform.right * movementSpeed * Time.deltaTime;
                    break;
                case KeyCode.Space:
                    if (isGrounded)
                    {
                        //Add force to stimulate jumping
                        rigid.AddForce(Vector3.up * 5, ForceMode.Impulse);
                        isGrounded = false;
                    }
                    break;

            }
        }

            rigid.MovePosition(position);
            rigid.MoveRotation(rotation);
        
    }
    //making sure player is grounded to jump again
    void OnCollisionEnter(Collision col)
    {
        
        isGrounded = true;
        isCannon = true;
    }
}
