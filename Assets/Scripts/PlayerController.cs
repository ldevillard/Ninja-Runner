using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    static public PlayerController Mine;

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

    bool inStarting;

    bool isAlive;
    public GameObject Target;
    public GameObject BloodEffect;
    bool lerp;


    static public GameObject Weapon; //When shop will be enable, use an array to throw the weapon chosen by the player
    public float CDWeapon;
    float saveCD;
    bool canAttack;

    //SWIPE SYSTEM
    private Vector2 startTouchPosition;
    private Vector2 currentPosition;
    private Vector2 endTouchPosition;
    private bool stopTouch = false;

    public float swipeRange;
    public float tapRange;
    //

    public GameObject CoinEffect;

    //Tuto
    int movement;
    int tutoKill = 0;
    public GameObject ArrowTuto;
    public GameObject PointTuto;
    public GameObject Canvas;
    public GameObject LetsGo;

    /*0 = jump
      1 = swipe left
      2 = swipe right
      3 = dash down
      4 = attack
    */

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Obstacles" || collision.collider.tag == "Ennemy")
            Dead();
        else if (!(collision.collider.tag == "SmallRoof" || collision.collider.tag == "BigRoof"))
            AudioFX.Mine.RunSource.volume = 0;
        if (collision.collider.tag == "Tuto1")
            StartCoroutine(FirstAction());
        else if (collision.collider.tag == "Tuto2")
            StartCoroutine(SecAction());
        else if (collision.collider.tag == "Tuto3")
            StartCoroutine(ThirdAction());
        else if (collision.collider.tag == "Tuto4")
            StartCoroutine(ThourthAction());
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.collider.tag == "SmallRoof" || collision.collider.tag == "BigRoof")
            AudioFX.Mine.RunSource.volume = AudioFX.Mine.SFX.volume;
    }

    void OnCollisionExit(Collision collision)
    {
        AudioFX.Mine.RunSource.volume = 0;

        /*if (collision.collider.tag == "Tuto1")
            Time.timeScale = 0.9f;
        else if (collision.collider.tag == "Tuto2")
            Time.timeScale = 0.9f;
        else if (collision.collider.tag == "Tuto3")
            Time.timeScale = 0.9f;
        else if (collision.collider.tag == "Tuto4")
            Time.timeScale = 0.9f;*/
    }

    void Start()
    {
        Mine = this;

        isAlive = true;
        lerp = true;
        anim = GetComponent<Animator>();
        trans = GetComponent<Transform>();
        rig = GetComponent<Rigidbody>();

        //Load random dance at start
        int i = Random.Range(0, 2);
        switch (i)
        {
            case 0:
                anim.SetBool("Dance1", true);
                break;
            case 1:
                anim.SetBool("Dance2", true);
                break;
        }

        getTeleport = false;
        canAttack = true;
        inStarting = false;
        saveCD = CDWeapon;

        Weapon = PlayerSkinManager.Mine.SkinsWeapon[PlayerSkinManager.Mine.idxWep];

        //tuto
        movement = -1;
    }

    void Update()
    {
        if (GameManager.Mine.GameStarted && isAlive )
        {
            Swipe();
            ComputerInputs();
        }
        else if (!isAlive)
        {
            if (Vector3.Distance(transform.position, Target.transform.position) > 1f && lerp)
            {
                transform.position = Vector3.Lerp(transform.position, Target.transform.position, 2 * Time.deltaTime);
                transform.rotation = Quaternion.Lerp(transform.rotation, Target.transform.rotation, 2 * Time.deltaTime);
            }
            else
            {
                lerp = false;
                transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y - 4, transform.position.z), 1 * Time.deltaTime);
            }
        }

        if (StartingPoint.StartingGame && !inStarting)
            StartCoroutine(Starting());

        float x = transform.position.x;
        float y = transform.position.y;
        float z = transform.position.z;

        if (getTeleport)
            StartCoroutine(Teleporting(x, y, z));
        //Throw a raycast to check if we can jump
        RaycastRoof();
        WeaponCD();

    }

    IEnumerator FirstAction()
    {
        while (Time.timeScale > 0.05f)
        {
            Time.timeScale -= 0.05f;
            yield return new WaitForEndOfFrame();
        }
        Time.timeScale = 0.02f;
        GameObject Arr = Instantiate(ArrowTuto, Canvas.transform);
        yield return new WaitUntil(() => movement == 0);
        Destroy(Arr);
        Time.timeScale = 0.9f;
        movement = -1;

        yield return new WaitForSeconds(0.2f);

        while (Time.timeScale > 0.05f)
        {
            Time.timeScale -= 0.05f;
            yield return new WaitForEndOfFrame();
        }
        Time.timeScale = 0.02f;
        GameObject Arr2 = Instantiate(ArrowTuto, Canvas.transform);
        Arr2.transform.rotation = new Quaternion(0, 0, 1, Arr2.transform.rotation.w);
        yield return new WaitUntil(() => movement == 1);
        Destroy(Arr2);
        Time.timeScale = 0.9f;
        movement = -1;
    }

    IEnumerator SecAction()
    {
        while (Time.timeScale > 0.05f)
        {
            Time.timeScale -= 0.05f;
            yield return new WaitForEndOfFrame();
        }
        Time.timeScale = 0.02f;
        GameObject Arr2 = Instantiate(ArrowTuto, Canvas.transform);
        Arr2.transform.rotation = new Quaternion(0, 0, -1, Arr2.transform.rotation.w);
        yield return new WaitUntil(() => movement == 2);
        Destroy(Arr2);
        Time.timeScale = 0.9f;
        movement = -1;
    }

    IEnumerator ThirdAction()
    {
        while (Time.timeScale > 0.05f)
        {
            Time.timeScale -= 0.05f;
            yield return new WaitForEndOfFrame();
        }
        Time.timeScale = 0.02f;
        GameObject Arr = Instantiate(ArrowTuto, Canvas.transform);
        yield return new WaitUntil(() => movement == 0);
        Destroy(Arr);
        Time.timeScale = 0.9f;
        movement = -1;
    }

    IEnumerator ThourthAction()
    {
        while (Time.timeScale > 0.05f)
        {
            Time.timeScale -= 0.05f;
            yield return new WaitForEndOfFrame();
        }
        Time.timeScale = 0.02f;
        GameObject Point = Instantiate(PointTuto, Canvas.transform);
        yield return new WaitUntil(() => movement == 4);
        Destroy(Point);
        Time.timeScale = 0.9f;
        movement = -1;

        tutoKill++;
        if (tutoKill == 2)
        {
            PlayerPrefs.SetInt("tuto", 1);
            LetsGo.SetActive(true);
        }
    }

    void Dead()
    {
        if (isAlive)
        {
            anim.SetBool("Dead", true);
            isAlive = false;
            GameManager.Mine.GameStarted = false;
            rig.isKinematic = true;
            AudioFX.Mine.SFXKilled();
            Instantiate(BloodEffect, transform);
        }
    }

    void ComputerInputs()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) && Direction == 1)
            SwitchLeft();
        else if (Input.GetKeyDown(KeyCode.RightArrow) && Direction == 0)
            SwitchRight();
        else if (Input.GetKeyDown(KeyCode.UpArrow) && ((!inJump && Roof != -1) || ((!PlayerPrefs.HasKey("tuto")) && !inJump)))
            Jump(JumpForce);
        else if (Input.GetKeyDown(KeyCode.DownArrow))
            DownDash();
        else if (Input.GetKeyDown(KeyCode.Space))
            ThrowWeapon();
    }

    IEnumerator Starting()
    {
        inStarting = true;
        yield return new WaitForSeconds(0.8f);
        Render.SetActive(false);
        transform.position = new Vector3(1, -1, 6.6f);
        transform.rotation = new Quaternion(0, 0, 0, 0);
        Render.SetActive(true);
        InitPoint();
        if (Roof == 0)
            transform.position = new Vector3(transform.position.x, -4, transform.position.z);
        else if (Roof == 1)
            transform.position = new Vector3(transform.position.x, -1, transform.position.z);
        Instantiate(Teleport, transform);
        AudioFX.Mine.SFXSwitch();
        anim.SetBool("StartGame", true);
        GameManager.Mine.GameStarted = true;
        while (Time.timeScale > 0.5f)
        {
            Time.timeScale -= 0.05f;
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForSeconds(1f);
        if (PlayerPrefs.HasKey("time"))
        {
            Time.timeScale = PlayerPrefs.GetFloat("time");
            PlayerPrefs.DeleteKey("time");
        }
        else
            Time.timeScale = 0.9f;
    }

    IEnumerator Teleporting(float x, float y, float z)
    {
        getTeleport = false;
        Render.SetActive(false);
        Instantiate(Teleport, transform);
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

    void InitPoint()
    {
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
    }

    void ResetAnim()
    {
        anim.SetBool("Roll", false);
        anim.SetBool("Roll2", false);
        anim.SetBool("Jump1", false);
        anim.SetBool("Jump2", false);
        anim.SetBool("Flip", false);
        anim.SetBool("ThrowWeapon", false);
    }

    void SwitchLeft()
    {
        AudioFX.Mine.SFXSwitch();
        Direction = 0;
        getTeleport = true;
        if (Roof == 1)
            anim.SetBool("Roll", true);
        movement = 1;
    }

    void SwitchRight()
    {
        AudioFX.Mine.SFXSwitch();
        Direction = 1;
        getTeleport = true;
        if (Roof == 1)
            anim.SetBool("Roll2", true);
        movement = 2;
    }

    void Jump(float force)
    {
        inJump = true;
        rig.velocity = new Vector3(0, force, 0);
        AudioFX.Mine.SFXJump();
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

        movement = 0;
    }

    void    DownDash()
    {
        rig.velocity = new Vector3(0, -JumpForce * 2, 0);
        if (Direction == 1)
            anim.SetBool("Roll2", true);
        else
            anim.SetBool("Roll", true);

    }

    void WeaponCD()
    {
        if (!canAttack && CDWeapon > 0)
            CDWeapon -= Time.deltaTime;
        else
        {
            canAttack = true;
            CDWeapon = saveCD;
        }
    }

    void ThrowWeapon()
    {
        if (!canAttack)
            return;
        AudioFX.Mine.SFXAttack();
        anim.SetBool("ThrowWeapon", true);
        GameObject wep = Instantiate(Weapon, trans.parent);
        wep.transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z + 1);
        canAttack = false;
        movement = 4;
    }

    public void GenerateCoinFX()
    {
        GameObject FX = Instantiate(CoinEffect, transform);
        FX.transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f , transform.position.z);
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
                    //Debug.Log("Left");

                    if (Direction == 1)
                        SwitchLeft();
                    stopTouch = true;
                }
                else if (Distance.x > swipeRange)
                {
                   // Debug.Log("Right");

                    if (Direction == 0)
                        SwitchRight();
                    stopTouch = true;
                }
                else if (Distance.y > swipeRange)
                {
                    //Debug.Log("Up");
                    if (!inJump && Roof != -1)
                        Jump(JumpForce);
                    else if (PlayerPrefs.HasKey("tuto") == false)
                        Jump(JumpForce);
                    stopTouch = true;
                }
                else if (Distance.y < -swipeRange)
                {
                    //Debug.Log("Down");
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
                //Debug.Log("Tap");

                ThrowWeapon();
            }
             else
                ResetAnim();
         }

    }
}
