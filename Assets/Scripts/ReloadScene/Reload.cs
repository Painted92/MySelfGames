using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reload : MonoBehaviour
{




    private void Awake()
    {
        MazeGenerator generator = new MazeGenerator();
        generator.Height++;
        generator.Width++;
    }
    private void OnTriggerStay(Collider other)
    {
       if(other.tag == "Player")
        {
           
            SceneManager.LoadScene(0);
           
        }
        
           
           
        
    }
}
