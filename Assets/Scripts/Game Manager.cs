using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Dialogue dialogueClass;
    public TextMeshProUGUI playerInputTextBox;
    public string playerInput;

    // Start is called before the first frame update
    void Start()
    {
        dialogueClass = FindObjectOfType<Dialogue>();
        RecieveDialogue();


        Dictionary<int, string> Name = new Dictionary<int, string>()
        {
            {1, "Example"},
            {2, "Example"},
            {3, "Example"},
            {4, "Example"},
            {5, "Example"},
            {6, "Example"}

        };

        Dictionary<int, string> Age = new Dictionary<int, string>()
        {
            {1, "24"},
            {2, "22"},
            {3, "23"},
            {4, "21"},
            {5, "30"},
            {6, "Example"}

        };
    }

    // Update is called once per frame
    void Update()
    {
        SendInput();
    }

    private void SendInput()
    {
        // If the text box is not empty and the player presses 'Enter' key
        if (playerInputTextBox.text != null && (Input.GetKeyDown(KeyCode.Return)))
        {
            playerInput = playerInputTextBox.text;
            // *** BJORN CODE HERE ***
            /*
             - Send (string) playerInput to the Bot
             */    

            //After input has been sent, reset input box back to empty
            Debug.Log(playerInput);
        }
    }

    private void RecieveDialogue()
    // Accesses the Dialogue Script (which is presents the NPC dialogue) and makes string[] linesOfDialogue equal to what the Bot says
    {
        // *** BJORN CODE HERE ***


        // After 
        string botReply = "This string was sent from the bot and into the dialogue script.  " +
            "I am testing to see if the lines will be added properly." +
            "It should print out a new lines at ever 'return' key or every dot.";

        string[] dialogueLines = botReply.Split('\n','.');

        dialogueClass.UpdateDialogue(dialogueLines);


    }
}
