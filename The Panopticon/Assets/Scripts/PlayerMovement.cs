using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    // --- BASIC PLAYER MOVEMENT SETUP ---
    public CharacterController playCont;

    public Rigidbody playerRB;

    public float speed = 10f;
    public float gravity = -9.81f * 2;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 4f;
    public LayerMask groundMask;

    Vector3 velocity;

    public bool isGrounded;

    // --- MATCH LOGIC ---

    public bool matchLit;
    public int matchNumber;
    public GameObject matchPrefab;
    public TextMeshProUGUI matchCount;

    // --- KEY LOGIC ---

    public int keyNumber;
    public GameObject keyGet;
    public ElevatorTag elevatorTag;
    public Image crosshair;
    public TextMeshProUGUI keyCount;
    public int keyGoal;
    public GameObject elevatorSound;
    bool elevatorReady;
    bool lightOK;

    // --- UI/GAMESTATE LOGIC ---
    public bool isDead;
    public Image killScreen;
    float killTransparency = 0;
    public GameObject gorePrefab;
    int sceneID;

    private void Awake()
    {
        playerRB = GetComponent<Rigidbody>();
        killScreen.color = new Color(0,0,0,0);
        lightOK = true;
        elevatorReady = false;
    }

    void Update()
    {
        if (isDead)
        {
            killScreen.color = new Color(0, 0, 0, killTransparency);
            killTransparency = killTransparency + Time.deltaTime;
            playerRB.isKinematic = true;
        }
        if ((Physics.Raycast(groundCheck.position, Vector3.down, out RaycastHit hit, groundDistance)) && (hit.transform.GetComponent<FloorTag>()))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        if ((Physics.Raycast(groundCheck.position, Vector3.down, out RaycastHit die, groundDistance)) && (hit.transform.GetComponent<WinTag>()))
        {
            SceneManager.LoadScene(0);
        }

        if (keyNumber == keyGoal)
        {
            elevatorReady = true;
            if (elevatorReady==true)
            {
                if (lightOK == true)
                {
                    StartCoroutine(ElevatorGood());
                }
            }
        }

        keyCount.text = "Keys: " + keyNumber.ToString();
        matchCount.text = "Matches: " + matchNumber.ToString();

        Vector3 rayAlways = transform.TransformDirection(Vector3.forward) * 3;
        Debug.DrawRay(Camera.main.transform.position, rayAlways, Color.green);
        if (Physics.Raycast(Camera.main.transform.position, rayAlways, out RaycastHit hoverObject, 3))
        {

            if (hoverObject.transform.GetComponent<KeyTag>() != null)
            {
                crosshair.color = new Color(1,1,1,1);
            }
            else if (hoverObject.transform.GetComponent<ElevatorTag>() != null)
            {
                if (elevatorTag.keysRequired == keyNumber)
                {
                    crosshair.color = new Color(0, 1, 0, 1);
                }
                else
                {
                    crosshair.color = new Color(1,0,0,1);
                }
            }
            else
            {
                crosshair.color = new Color(1, 1, 1, 0.05f);
            }
        }
        else
        {
            crosshair.color = new Color(1, 1, 1, 0.05f);
        }

        if (!isGrounded && velocity.y < -1 && velocity.y > -19.62f)
        {
            velocity.y = velocity.y - Time.deltaTime;
        }
        else if (velocity.y < -19.62f)
        {
            velocity.y = -19.62f;
        }

        if (!isDead)
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
            Vector3 globalForward = Vector3.Cross(transform.right, Vector3.up);


            Vector3 move = transform.right * x + globalForward * z;
            move.y = 0;

            playCont.Move(move * speed * Time.deltaTime);

            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }

            if (Input.GetKey(KeyCode.E))
            {
                if (!matchLit)
                {
                    if (matchNumber > 0)
                    {
                        matchNumber--;
                        matchLit = true;
                        Instantiate(matchPrefab,this.transform.position,Quaternion.identity);
                        StartCoroutine(MatchBurnout());
                    }
                }
            }

            if (Input.GetMouseButtonDown(0))
            {
                Vector3 rayForward = transform.TransformDirection(Vector3.forward) * 3;
                Debug.DrawRay(Camera.main.transform.position, rayForward, Color.green);
                if (Physics.Raycast(Camera.main.transform.position, rayForward, out RaycastHit hitObject,3))
                {
                    Debug.Log(hitObject.transform.name);
                    if (hitObject.transform.GetComponent<KeyTag>() != null)
                    {
                        Instantiate(keyGet,hitObject.transform.position,Quaternion.identity);
                        Destroy(hitObject.transform.gameObject);
                        keyNumber++;
                    }
                    else if (hitObject.transform.GetComponent<ElevatorTag>() != null)
                    {
                        if (elevatorTag.keysRequired <= keyNumber)
                        {
                            keyNumber = 0;
                            Debug.Log("YO WINAER");
                            StartCoroutine(WinStage());
                        }
                    }
                }
            }

            velocity.y += gravity * Time.deltaTime;

            playCont.Move(velocity * Time.deltaTime);
        }
    }


    private void OnTriggerEnter(Collider thing)
    {

        if (thing.GetComponent<Chaser>() != null)
        {
            if (!isDead)
            {
                if (!matchLit)
                {
                    isDead = true;
                    StartCoroutine(KillPlayer());
                }
            }
        }
    }

    IEnumerator KillPlayer()
    {
        Instantiate(gorePrefab,transform.position, Quaternion.identity);
        yield return new WaitForSeconds(3);
        sceneID = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneID);
    }

    IEnumerator WinStage()
    {
        yield return new WaitForSeconds(1);
        sceneID = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(sceneID);
    }

    IEnumerator MatchBurnout()
    {
        yield return new WaitForSeconds(10);
        matchLit = false;
    }

    IEnumerator ElevatorGood()
    {
        lightOK = false;
        yield return new WaitForSeconds(1);
        Instantiate(elevatorSound, new Vector3(0,3.5f,-52.5f), Quaternion.identity);
    }
}
