using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;
using Unity.Collections.LowLevel.Unsafe;

public class Dialogue : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMeshProUGUI;
    public string[] linesOfDialogue;
    [SerializeField] float textSpeed;

    int index;


    // Start is called before the first frame update
    void Start()
    {
        //textMeshProUGUI.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(textMeshProUGUI.text == linesOfDialogue[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textMeshProUGUI.text = linesOfDialogue[index];
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
        foreach (char c in linesOfDialogue[index].ToCharArray())
        {
            textMeshProUGUI.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < linesOfDialogue.Length - 1)
        {
            index++;
            textMeshProUGUI.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            //gameObject.SetActive(false);
        }
    }

    public void UpdateDialogue(string[] lines)
    { 
        linesOfDialogue = lines;

    }
}
