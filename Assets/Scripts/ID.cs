using UnityEngine;
using UnityEngine.SceneManagement;

public class ID : MonoBehaviour
{
    [SerializeField] Sprite id00;
    [SerializeField] Sprite id01;
    [SerializeField] Sprite id02;
    [SerializeField] Sprite id03;
    [SerializeField] Sprite id04;

    [SerializeField] SpriteRenderer IDRenderer;


    //ID Trackign
    public int currentPlayerID;
    int scenesLoadedCount = 0;
    public int maxScenesToPersist = 2;


    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        currentPlayerID = Random.Range(0, 4);
        UpdateIDs(currentPlayerID);
        SceneManager.sceneLoaded += OnSceneLoaded;

    }

    private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        scenesLoadedCount++;

        if (scenesLoadedCount > maxScenesToPersist)
        {
            Destroy(gameObject);

            SceneManager.sceneLoaded -= OnSceneLoaded; 
        }
    }

    public void DestroyIDManager()
    {
        Destroy(this.gameObject);
    }


    public void TurnOffSprite()
    {
        IDRenderer.gameObject.SetActive(false);
    }

    public void UpdateIDs(int id)
    {
        Sprite[] IDSprites = new Sprite[]
        {id00, id01, id02, id03};
        
        IDRenderer.sprite = IDSprites[id];
    }



}
