using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cherry : MonoBehaviour
{
    public static int currentLevel = 0;
    public int targetScore;
    private Vector2 screenBounds;

    // Start is called before the first frame update
    void Start()
    {

        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < screenBounds.y)
    {
        Destroy(this.gameObject);
    }
    }
    private void OnCollisionEnter2D(Collision2D collision) //If another GameObject with a 2D Collider on it hits this GameObject's collider
    {
        GameManager.instance.Score++; //increase the player's score using the Singleton!
        Debug.Log("Score: " + GameManager.instance.Score); //print the score to console, using the Singleton
        transform.position = new Vector2(Random.Range(-12, 1), Random.Range(2, 5)); //teleport to a random location
        
        if (GameManager.instance.Score > targetScore) //if the current score >  the targetScore
        {
            currentLevel++; //increate the level number
            SceneManager.LoadScene(currentLevel); //go to the next level
        }
    }
}
