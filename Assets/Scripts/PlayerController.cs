using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Animator anim;
    private Transform trans;
    private Rigidbody rig;

    public GameObject Render;
    public GameObject Teleport;
    bool getTeleport;

    public int JumpForce;
    public int Direction;
    public int Roof;

    bool inJump;

    //SWIPE SYSTEM
    private Vector2 startTouchPosition;
    private Vector2 currentPosition;
    private Vector2 endTouchPosition;
    private bool stopTouch = false;

    public float swipeRange;
    public float tapRange;
    //

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Obstacles")
            SceneManager.LoadScene(1);
    }

    void Start()
    {
        anim = GetComponent<Animator>();
        trans = GetComponent<Transform>();
        rig = GetComponent<Rigidbody>();
        Teleport.SetActive(false);

        //Init player position to be on a big roof at start point
        RaycastRoof();

        if (Roof == -1)
        {
            Direction = 0;
            trans.position = new Vector3(-3, trans.position.y, trans.position.z);
        }
        else
        {
            Direction = 1;
            trans.position = new Vector3(1, trans.position.y, trans.position.z);
        }

        getTeleport = false;
    }

    void Update()
    {
        if (GameManager.Mine.GameStarted)
            Swipe();

        /*if (Input.GetKeyDown(KeyCode.Space) && !inJump && Roof != -1)
            Jump(JumpForce);
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && Direction == 1)
            SwitchLeft();
        else if (Input.GetKeyDown(KeyCode.RightArrow) && Direction == 0)
            SwitchRight();
        else
            ResetAnim();*/

        float x = transform.position.x;
        float y = transform.position.y;
        float z = transform.position.z;

        if (getTeleport)
            StartCoroutine(Teleporting(x, y, z));
        /*
        if (Direction == 0 && x > -3.2f)
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(-3f, y, z), 40 * Time.deltaTime);
        if (Direction == 1 && x < 1.2f)
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(1f, y, z), 40 * Time.deltaTime);
        */

        //Throw a raycast to check if we can jump
        RaycastRoof();
    }

    IEnumerator Teleporting(float x, float y, float z)
    {
        getTeleport = false;
        Render.SetActive(false);
        Teleport.SetActive(true);
        if (Direction == 0)
            transform.position = new Vector3(-3f, y, z);
        else
            transform.position = new Vector3(1, y, z);
        yield return new WaitForSeconds(0.1f);
        Render.SetActive(true);
    }

    void RaycastRoof()
    {
        Debug.DrawRay(transform.position, Vector3.down * 5, Color.magenta); //Draw a debug cast
        Ray ray = new Ray(transform.position, Vector3.down);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit) && hit.collider.tag == "SmallRoof")
        {
            Roof = 0;
            if (hit.distance < 0.6f)
                inJump = false;
            else
                inJump = true;
        }
        else if (Physics.Raycast(ray, out hit) && hit.collider.tag == "BigRoof")
        {
            Roof = 1;
            if (hit.distance < 0.6f)
                inJump = false;
            else
                inJump = true;

        }
        else
            Roof = -1;
    }

    void ResetAnim()
    {
        anim.SetBool("Roll", false);
        anim.SetBool("Roll2", false);
        anim.SetBool("Jump1", false);
        anim.SetBool("Jump2", false);
        anim.SetBool("Flip", false);
    }

    void SwitchLeft()
    {
        Direction = 0;
        getTeleport = true;
        if (Roof == 1)
            anim.SetBool("Roll", true);
    }

    void SwitchRight()
    {
        Direction = 1;
        getTeleport = true;
        if (Roof == 1)
            anim.SetBool("Roll2", true);
    }

    void Jump(float force)
    {
        inJump = true;
        rig.velocity = new Vector3(0, force, 0);

        int i;

        if (Roof == 1)
            i = Random.Range(0, 3);
        else
            i = Random.Range(1, 3);
        switch (i)
        {
            case 0:
                anim.SetBool("Flip", true);
                break;
            case 1:
                anim.SetBool("Jump1", true);
                break;
            case 2:
                anim.SetBool("Jump2", true);
                break;
        }
    }

    void    DownDash()
    {
        rig.velocity = new Vector3(0, -JumpForce * 2, 0);
        if (Direction == 1)
            anim.SetBool("Roll2", true);
        else
            anim.SetBool("Roll", true);
    }

    public void Swipe()
    {
         if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
         {
             startTouchPosition = Input.GetTouch(0).position;
         }
     
         if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
         {
             currentPosition = Input.GetTouch(0).position;
             Vector2 Distance = currentPosition - startTouchPosition;
     
             if (!stopTouch)
             {

                if (Distance.x < -swipeRange)
                {
                    Debug.Log("Left");

                    if (Direction == 1)
                        SwitchLeft();
                    stopTouch = true;
                }
                else if (Distance.x > swipeRange)
                {
                    Debug.Log("Right");

                    if (Direction == 0)
                        SwitchRight();
                    stopTouch = true;
                }
                else if (Distance.y > swipeRange)
                {
                    Debug.Log("Up");
                    stopTouch = true;
                }
                else if (Distance.y < -swipeRange)
                {
                    Debug.Log("Down");
                    DownDash();
                    stopTouch = true;
                }
     
             }
     
         }
         else
            ResetAnim();

         
         if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
         {
             stopTouch = false;

             endTouchPosition = Input.GetTouch(0).position;

             Vector2 Distance = endTouchPosition - startTouchPosition;

             if (Mathf.Abs(Distance.x) < tapRange && Mathf.Abs(Distance.y) < tapRange)
             {
                Debug.Log("Tap");

                if (!inJump && Roof != -1)
                    Jump(JumpForce);
             }
             else
                ResetAnim();
         }

    }
}
