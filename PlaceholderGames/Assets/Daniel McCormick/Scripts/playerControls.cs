using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerControls : MonoBehaviour {

	public float speed = 5.0f;
	public float gravity = -9.8f;
	private CharacterController charCont;
    public eventManager events;
    public Image blackOut;


    public bool fadingToBlack = false;
    public float blackOutTimer = 2f;
    public bool PlayerCanMove = true;

    private float collisionTimer = 1.5f;
	// Use this for initialization
	void Start () {
	charCont = GetComponent<CharacterController>();
        events = GetComponent<eventManager>();
	}
	
	// Update is called once per frame
	void Update () {
		float deltaX = Input.GetAxis("Horizontal") * speed;
		float deltaZ = Input.GetAxis("Vertical") * speed;

		Vector3 movement = new Vector3 (deltaX, 0, deltaZ);

		movement = Vector3.ClampMagnitude(movement, speed);
		movement.y = gravity;

		movement *= Time.deltaTime;
		movement = transform.TransformDirection(movement);

        if (PlayerCanMove)
        {
            charCont.Move(movement);
        }


        Debug.Log(fadingToBlack);
        if (fadingToBlack)
        {
            if(blackOutTimer >= 0)
            {
                blackOut.color = new Color(blackOut.color.r, blackOut.color.g, blackOut.color.b, (2 - blackOutTimer) / 2);
                blackOutTimer -= Time.deltaTime;
            }
            else
            {
                fadingToBlack = false;
                blackOutTimer = 2f;
            }
        }
        if(!fadingToBlack && blackOut.color.a > 0){
            if (blackOutTimer >= 0)
            {
                blackOut.color = new Color(blackOut.color.r, blackOut.color.g, blackOut.color.b, (blackOutTimer) / 2);
                blackOutTimer -= Time.deltaTime;
            }
            else
            {
                blackOut.color = new Color(blackOut.color.r, blackOut.color.g, blackOut.color.b, 0);
                blackOutTimer = 2f;
            }
        }
        
    }

    void OnControllerColliderHit(ControllerColliderHit col)
    {
        if (col.gameObject.CompareTag("AI"))
        {
            if(collisionTimer <= 0)
            {
                col.gameObject.GetComponent<AIMovement>().ChangeLayer();
                collisionTimer = 1.5f;
            }
            else
            {
                collisionTimer -= Time.deltaTime;
            }
        }
        
    }

    public IEnumerator TeleportPlayer(Vector3 position)
    {
        Debug.Log("Stopping Movement");
        FlipPlayerMovement(false);

        Debug.Log("Fading to Black");
        FadeToBlack();

        Debug.Log("Wait 2 Seconds");
        yield return new WaitForSeconds(2);
       
       
        Debug.Log("Move Player");
        gameObject.transform.position = position;
        FlipPlayerMovement(true);
        
    }

    public void FadeToBlack(float time = 0)
    {
        Debug.Log("Setting FadeToBlack to true");
        fadingToBlack = true;
    }
    public void FlipPlayerMovement(bool enabled)
    {
        PlayerCanMove = enabled;
    }
  
}
