using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    /* Script Tasks:
        - Keep track of current ID and info
        - Keep track of current level progress
        - Keep track of current game progress
        - Keep track of everything the player has said
        - Communiate with dialogue script






    */
    // Start is called before the first frame update
    void Start()
    {

        Dictionary<int, string> Name = new Dictionary<int, string>() 
        {
            {1, "Example"},
            {2, "Example"},
            {3, "Example"},
            {4, "Example"},
            {5, "Example"},
            {6, "Example"}
        };


        Dictionary<int, int> Age = new Dictionary<int, int>()
        {
            {1, 24},
            {2, 21},
            {3, 30},
            {4, 28},
            {5, 40},
            {6, 21}
        };

        Dictionary<int, string> Address = new Dictionary<int, string>()
        {
            {1, "Example"},
            {2, "Example"},
            {3, "Example"},
            {4, "Example"},
            {5, "Example"},
            {6, "Example"},
            {7, "Example"}
        };






}

// Update is called once per frame
void Update()
    {
        
    }
}
