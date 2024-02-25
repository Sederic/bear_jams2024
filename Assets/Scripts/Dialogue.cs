using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;
using Unity.Collections.LowLevel.Unsafe;
using System.Threading;

public class Dialogue : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMeshProUGUI;
    public string[] linesOfDialogue;
    [SerializeField] float textSpeed;
    [SerializeField] float delayBeforeNextLine = 2f;

    int index;
    bool isLineComplete = false;
    float timer = 0f;


    // Start is called before the first frame update
    void Start()
    {
        //textMeshProUGUI.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (isLineComplete)
        {
            timer += Time.deltaTime;
            if (timer >= delayBeforeNextLine)
            {
                NextLine();
                timer = 0f;
            }
        }

    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }
    IEnumerator TypeLine()
    {
        isLineComplete = false;
        foreach (char c in linesOfDialogue[index].ToCharArray())
        {
            textMeshProUGUI.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
        isLineComplete=true;
    }

    void NextLine()
    {
        if (index < linesOfDialogue.Length - 1)
        {
            textMeshProUGUI.text = string.Empty;
            StartCoroutine(TypeLine());
            index++;

        }
    }
    public void UpdateDialogue(string[] lines)
    {
        index = 0;
        linesOfDialogue = lines;
        
    }
}
