using UnityEngine;


public class Bouncer : MonoBehaviour
{
    [SerializeField] SpriteRenderer checkIdImage;

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
