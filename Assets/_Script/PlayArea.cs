using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayArea : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
       // Debug.Log("Object Exited Game Area");
        Destroy(other.gameObject); 
    }
}
