using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryBoundary : MonoBehaviour {
    private void OnTriggerExit(Collider other)
    {
        Debug.Log(other.tag);
        if (other.tag != "Player")
        {
            Destroy(other.gameObject);
        }
    }
}
