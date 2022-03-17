using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
   // [SerializeField] float max, min;
    [SerializeField] Text scoreText;
    public float speed = 15.0f;
    public float horizontalSpeed = .5f;
   // private CharacterController myCharacterController;
    public int score = 0;
    private float startTime;
    void Start()
    {
      //  myCharacterController = GetComponent<CharacterController>();
        score = 0;
        startTime = Time.time;
    }
    void Update()
    {
       // myCharacterController.SimpleMove(new Vector3(0f, 0f, 0f));
       // myCharacterController.Move(transform.forward * speed * Time.deltaTime);

        ProcessEverything();
    }

    private void onFallDead()
    {
        if (transform.position.y < -5f)
        {
            Destroy(gameObject);
        }
    }

    private void ProcessEverything()
    {
        ProcessRotationLeft();
        ProcessRotationRight();
        //ProcessMovement();
        ProcessScore();
        onFallDead();
    }


    private void LateUpdate()
    {
        ProcessMovement();
    }
    private void ProcessScore()
    { 
        PlayerPrefs.SetInt("Score", score);
        scoreText.text =score.ToString();
    }
    public void ProcessRotationLeft()
    {
        transform.Rotate(new Vector3(0, -90f, 0));
    }
    public void ProcessRotationRight()
    {
        transform.Rotate(new Vector3(0, 90f, 0));
    }
    private void ProcessMovement()
    {
        transform.Translate(transform.forward * Time.deltaTime * speed, Space.World);
        if (Input.touchCount > 0)
        {
            
            Touch t = Input.GetTouch(0);
            float toucPos = t.deltaPosition.x;
            // if (t.phase == TouchPhase.Moved)
            //{
            //Vector3 playerPos = new Vector3(transform.localPosition.x + t.deltaPosition.x * Time.deltaTime, transform.localPosition.y, transform.localPosition.z);
            //playerPos.x = Mathf.Clamp(playerPos.x, min, max);
            //transform.localPosition = playerPos;
            // }
            if (toucPos > 0)
            {
                transform.Translate(transform.right * Time.deltaTime * horizontalSpeed, Space.World);
            }
            else if (toucPos < 0)
            {
                transform.Translate(-transform.right * Time.deltaTime * horizontalSpeed, Space.World);
            }
            else { }      
        } 
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Obstacle")
        {
             Destroy(gameObject);  
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        score += 1;
    }
}

