using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController characterController;
    public float playerSpeed;
    public float backSpeed;
    public float turnSpeed;
    Animator anim;
    ScoreManager score;
    public GameObject ScoreM;
    public Transform cam;
    private float rotateXspeed = 4.0f;
    public float gravity;
    public float smoothtime = 0.1f;
    float turnSmoothVelocity;
   
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
        score = ScoreM.GetComponent<ScoreManager>();
    }
    void Update()
    {
        
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        var mouseHorizontal = Input.GetAxis("Mouse X");
        var mouseVectical = Input.GetAxis("Mouse Y");
        var movement = new Vector3(horizontal, 0, vertical);
        //movement.y-=gravity;
        anim.SetFloat("Speed", movement.magnitude);
        this.transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y + mouseHorizontal * rotateXspeed, transform.localEulerAngles.z);

        //transform.Rotate(Vector3.up, horizontal * turnSpeed * Time.deltaTime);
        if (movement.magnitude >=0.1f)
        {
            print(movement.magnitude);
            float targetangle = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg +cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetangle, ref turnSmoothVelocity,smoothtime);
            transform.rotation = Quaternion.Euler(0f, targetangle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetangle, 0f) * Vector3.forward;
            float moveSpeed = (vertical > 0) ? playerSpeed : backSpeed;
            characterController.SimpleMove( moveDir * moveSpeed);
            //audioSource.clip = audioClip;
            //audioSource.Play();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bottle")
        {
            print("Bottle");
            other.gameObject.transform.parent.gameObject.SetActive(false);
            score.BottleScore();
        }
        if (other.gameObject.tag == "Coin")
        {
            print("Coin");
            other.gameObject.transform.parent.gameObject.SetActive(false);
            score.CoinScore();
        }
    }
}
