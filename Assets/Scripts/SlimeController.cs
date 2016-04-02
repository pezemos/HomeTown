using UnityEngine;
using UnityEngine.SceneManagement;

public class SlimeController : MonoBehaviour
{
    public float moveSpeed;
    private bool moving;
    public float timeBetweenMove;
    private float timeBetweenMoveCounter;
    public float timeToMove;
    private float timeToMoveCounter;
    public float waitToReload;
    private bool reloading;
    private GameObject thePlayer;

    private Rigidbody2D myRigidbody;
    private Vector3 moveDirection;
    private SlimeStatus slimeStatus; // reference to the slimestatus script (that says if the slime is angry)

    // Use this for initialization
    private void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();

        //_timeBetweenMoveCounter = timeBetweenMove;
        //_timeToMoveCounter = timeToMove;

        timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
        timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeToMove * 1.25f);

        slimeStatus = GetComponent<SlimeStatus>(); // getting slimestatus script
        thePlayer = GameObject.Find("Player"); // the player gameobject
    }

    // Update is called once per frame
    private void Update()
    {
        // When slime is moving his timeToMoveCounter is counting to 0 in this if statement
        if (moving)
        {
            timeToMoveCounter -= Time.deltaTime;
            // If Slime is aggresive then he will move towards player
            if (slimeStatus.isAggressive)
            {
                transform.position = Vector3.MoveTowards(transform.position, thePlayer.transform.position, moveSpeed * Time.deltaTime); // move towards the player at the moveSpeed speed
            }
            // If he is not aggresive than he will move in random direction which is below
            else
            {
                myRigidbody.velocity = moveDirection;
            }

            // There slime stop moving when he's run out of time
            if (timeToMoveCounter < 0f)
            {
                moving = false;
                timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
            }
        }
        // When slime is not moving his velocity is set to 0
        else
        {
            timeBetweenMoveCounter -= Time.deltaTime;
            myRigidbody.velocity = Vector2.zero;

            // If timeBetweenMoveCounter is lower than 0 then slime start moving
            if (timeBetweenMoveCounter < 0f)
            {
                moving = true;
                // There is calculated time that will take slime to move
                timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeToMove * 1.25f);

                moveDirection = new Vector3(Random.Range(-1, 1f) * moveSpeed, Random.Range(-1f, 1f) * moveSpeed, 0f);
            }
        }

        if (reloading)
        {
            waitToReload -= Time.deltaTime;
            if (waitToReload < 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                thePlayer.SetActive(true);
            }
        }
    }
}
