using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    [Range(1.0f, 5.0f)]
    public float movementSpeed = 2.5f;

    // define the maxZ and minZ of distance to define the size of the player 
    /*
    public float maxZ;
    public float minZ;
    private float rescaleFactor;
    */

    private bool faceRight = true;
    private Animator playerAnimator;
    private bool canMove = true;

    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        if (playerAnimator == null)
            Debug.LogError("Player.Movement: Cannot find Animator");
    }

	void Update () {
        if(canMove)
            Move();
    }

    void Move()
    {
        // animation walking
        playerAnimator.SetBool("walking", true);
        
        // going left
        if (Input.GetKey(KeyCode.A) || Input.GetAxis("Horizontal") < 0)
        {
            transform.Translate(new Vector3(- movementSpeed * Time.deltaTime, 0));
            if (faceRight)
            {
                faceRight = false;
                this.transform.localScale = new Vector3(
                    this.transform.localScale.x * -1,
                    this.transform.localScale.y);
            }
        }
        
        // going right
        else if (Input.GetKey(KeyCode.D) || Input.GetAxis("Horizontal") > 0)
        {
            transform.Translate(new Vector3(movementSpeed * Time.deltaTime, 0));
            if (!faceRight)
            {
                faceRight = true;
                this.transform.localScale = new Vector3 (
                    this.transform.localScale.x * -1,
                    this.transform.localScale.y);
            }
        }
        else
            playerAnimator.SetBool("walking", false);

        /*
         * Rescale / Z axis not being applied for now
         */
        // for rescale correctly
        
        //int signal = 1;
        //if (!faceright) // positive
        //    signal = -1;

        //// up
        //if (input.getkey(keycode.w))
        //{
        //    float z = this.transform.position.z;
        //    /*if (z < maxz)
        //        z += (rescalefactor);
        //     */
        //    this.transform.position = new vector3 (
        //        this.transform.position.x,
        //        this.transform.position.y + movementspeed * time.deltatime,
        //        z);
        //}

        //// down
        //if (input.getkey(keycode.s))
        //{
        //    float z = this.transform.position.z;
        //    /*if (z > minz)
        //        z -= (rescalefactor);
        //     */
        //    this.transform.position = new vector3 (
        //        this.transform.position.x,
        //        this.transform.position.y - movementspeed * time.deltatime,
        //        z);
        //}
    }

    void pauseAnimation(bool condition)
    {
        if(condition)
            playerAnimator.speed = 0;
        else
            playerAnimator.speed = 1;
        // if pause = true, canMove = false
        canMove = !condition;
    }

}
