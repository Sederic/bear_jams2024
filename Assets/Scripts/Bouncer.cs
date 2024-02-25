using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bouncer : MonoBehaviour
{
    [SerializeField] SpriteRenderer checkIdImage;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckID()
    {
        checkIdImage.enabled = true;

        if (checkIdImage.enabled)
        {
            checkIdImage.enabled = false;
        }
        else
            checkIdImage.enabled = true;
    }


}
