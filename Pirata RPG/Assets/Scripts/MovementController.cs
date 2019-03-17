using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    Vector3 maxWalkSpeed = new Vector3(2, 2), maxRunSpeed = new Vector3(4, 4), currentMovementSpeed;
    Vector3 deltaPos, enemyOrientation;
    bool isRunning, isAttacking;
    Animator currentAnimator;
    SpriteRenderer currentSpriteRenderer;
    bool isBlockedLeft, isBlockedRight, isBlockedTop, isBlockedBottom;

    private void Awake()
    {
        currentAnimator = GetComponent<Animator>();
        currentSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if(gameObject.tag == "Player")
        {
            Camera.main.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -10);
            Camera.main.transform.SetParent(gameObject.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.tag == "Player")
        {
            isRunning = Input.GetButton("Fire3");
            isAttacking = Input.GetButton("Fire1");

            currentMovementSpeed = new Vector3(Input.GetAxis("Horizontal") * (isRunning ? maxRunSpeed.x : maxWalkSpeed.x), Input.GetAxis("Vertical") * (isRunning ? maxRunSpeed.x : maxWalkSpeed.y));
        }
        else if (gameObject.tag == "Enemy" && Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, gameObject.transform.position) < 5 && Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, gameObject.transform.position) > 2)
        {
            isRunning = false;
            isAttacking = false;

            enemyOrientation = Vector3.zero;

            if (GameObject.FindGameObjectWithTag("Player").transform.position.x > gameObject.transform.position.x)
                enemyOrientation.x = 0.7f;
            else
                enemyOrientation.x = -0.7f;

            if (GameObject.FindGameObjectWithTag("Player").transform.position.y > gameObject.transform.position.y)
                enemyOrientation.y = 0.7f;
            else
                enemyOrientation.y = -0.7f;

            currentMovementSpeed = new Vector3(enemyOrientation.x * (isRunning ? maxRunSpeed.x : maxWalkSpeed.x), enemyOrientation.y * (isRunning ? maxRunSpeed.x : maxWalkSpeed.y));
        }
        else if (gameObject.tag == "Enemy" && Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, gameObject.transform.position) <= 2)
        {
            // ¡Attack!
            currentMovementSpeed = Vector3.zero;
            isAttacking = true;
        }
        else
        {
            currentMovementSpeed = Vector3.zero;
            isRunning = false;
        }

        currentAnimator.SetBool("isAttacking", isAttacking);

        deltaPos = currentMovementSpeed * Time.deltaTime;

        currentAnimator.SetFloat("moveSpeed", currentMovementSpeed.magnitude);

        gameObject.GetComponent<Rigidbody>().velocity = currentMovementSpeed;
        currentSpriteRenderer.flipX = currentMovementSpeed.x < 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag != "Tree" && other.gameObject.tag != "Rock" && other.gameObject.tag != "Wall")
            return;

        if (other.gameObject.transform.position.x > gameObject.transform.position.x)
            isBlockedRight = false;
        if (other.gameObject.transform.position.y > gameObject.transform.position.y)
            isBlockedTop = false;
        if (other.gameObject.transform.position.x < gameObject.transform.position.x)
            isBlockedLeft = false;
        if (other.gameObject.transform.position.y < gameObject.transform.position.y)
            isBlockedBottom = false;
    }
}
