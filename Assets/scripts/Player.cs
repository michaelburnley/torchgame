using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    public float moveSpeed = 3f;
    public float gridSize = 1f;
    private enum Orientation {
        Horizontal,
        Vertical
    };
    private Orientation gridOrientation;
    public bool allowDiagonals = false;
    private bool correctDiagonalSpeed = true;
    private Vector2 input;
    private bool isMoving = false;
    private Vector2 startPosition;
    private Vector2 endPosition;
    private float t;
    private float factor;
    public int gas_cans;

    // Start is called before the first frame update
    void Start()
    {
        gridOrientation = Orientation.Vertical;
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate() {

    }

    void ChangeDirection() {
        if((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S)) && gridOrientation == Orientation.Horizontal) {
            gridOrientation = Orientation.Vertical;
        } else if((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D)) && gridOrientation == Orientation.Vertical) {
            gridOrientation = Orientation.Horizontal;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Rotation();
        ChangeDirection();
        if (!isMoving) {   
            input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            if (!allowDiagonals) {
                if (Mathf.Abs(input.x) > Mathf.Abs(input.y)) {
                    input.y = 0;
                } else {
                    input.x = 0;
                }
            }
 
            if (input != Vector2.zero) {
                
                StartCoroutine(move(transform));
            }
        }
                
    }

    public IEnumerator move(Transform transform) {
        isMoving = true;
        startPosition = transform.position;
        t = 0;
 
        if(gridOrientation == Orientation.Horizontal) {
            endPosition = new Vector2(startPosition.x + System.Math.Sign(input.x) * gridSize,
                startPosition.y + System.Math.Sign(input.y) * gridSize);
        } else {
            endPosition = new Vector2(startPosition.x + System.Math.Sign(input.x) * gridSize,
                startPosition.y + System.Math.Sign(input.y) * gridSize);
        }
 
        if(allowDiagonals && correctDiagonalSpeed && input.x != 0 && input.y != 0) {
            factor = 0.7071f;
        } else {
            factor = 1f;
        }
 
        while (t < 1f) {
            t += Time.deltaTime * (moveSpeed/gridSize) * factor;
            transform.position = Vector2.Lerp(startPosition, endPosition, t);
            yield return null;
        }
 
        isMoving = false;
        yield return 0;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "Gas") {
            Destroy(collision.gameObject);         
            gas_cans += 1;
        }
    }
    
    void Rotation()
    {
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
           
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {

        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {

        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {

        }
    }
}
