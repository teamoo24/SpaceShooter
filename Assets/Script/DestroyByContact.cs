using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {
    public GameObject explosion;
    public GameObject playerExplosion;
    private GameObject gamecontrollerObject;
    public int scoreValue;
    private GameController gameController;

    private void Start()
    {
        gamecontrollerObject = GameObject.FindWithTag("GameController");
        if(gamecontrollerObject != null)
        {
            gameController = gamecontrollerObject.GetComponent<GameController>();
        }
        if(gamecontrollerObject == null)
        {
            Debug.Log("Did not find GameControllerObject!");
        }
    }

    private void OnTriggerEnter(Collider other){
        if (other.tag == "Boundary") {
            return;
        }
        Instantiate(explosion, transform.position, transform.rotation);
        if (other.tag == "Player") {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver();
        }

        gameController.AddScore(scoreValue);
        Debug.Log(other.name);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
