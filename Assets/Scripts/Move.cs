using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private Vector3 movement;
    [SerializeField] private float speed = 0;
    private Rigidbody rigidbody;
    private TimeManager timeManager;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        timeManager = FindObjectOfType<TimeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeManager.gameOver == false && timeManager.gameFinished == false)
        {
            MoveThePlayer();
        }

        if (timeManager.gameOver || timeManager.gameFinished)
        {
            rigidbody.isKinematic = true;
        }
        
    }

    private void MoveThePlayer()
    {
        float x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float z = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        movement = new Vector3(x, 0f, z);
        rigidbody.AddForce(movement);
    }
}
