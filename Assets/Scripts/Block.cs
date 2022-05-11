using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    private bool isColider = false;
    private MeshRenderer meshRenderer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player") 
        {
            if (isColider == false && collision.gameObject.tag == "Player")
            {

                GetComponent<MeshRenderer>().material.color = Color.red;
                ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
                scoreManager.score -= 1;
                isColider = true;
            }
        }
       
    }
}
