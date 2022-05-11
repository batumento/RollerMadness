using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public bool gameOver = false;
    public bool gameFinished = false;
    [SerializeField] private float levelFinishedTime= 10f;
    [SerializeField] private Text textTime;

    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject losePanel;

    [SerializeField] private List<GameObject> destroyAfterGame = new List<GameObject>();
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver == false && gameFinished == false)
        {
            UpdateTheTime();
        }
            
        if (Time.timeSinceLevelLoad >= levelFinishedTime && gameOver == false)
        {
            
            gameFinished = true;
            winPanel.gameObject.SetActive(true);
            losePanel.gameObject.SetActive(false);
            UpdateObjectList("Objects");
            UpdateObjectList("Enemy");
            foreach (GameObject allObjects in destroyAfterGame)
            {
                Destroy(allObjects);
            }
        }
        if (gameOver == true)
        {
            winPanel.gameObject.SetActive(false);
            losePanel.gameObject.SetActive(true);
            UpdateObjectList("Objects");
            UpdateObjectList("Enemy");
            foreach (GameObject allObjects in destroyAfterGame)
            {
                Destroy(allObjects);
            }
        }
    }

    private void UpdateObjectList(string tag)
    {
        destroyAfterGame.AddRange(GameObject.FindGameObjectsWithTag(tag));
    }

    private void UpdateTheTime()
    {
            textTime.text = "Time: " + (int)Time.timeSinceLevelLoad;
    }
}
