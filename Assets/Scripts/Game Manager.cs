using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Text;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;

public class GameManager : MonoBehaviour
{
    public Dialogue dialogueClass;
    public TextMeshProUGUI playerInputTextBox;
    public string playerInput;

    public string selectedBot = "bot1";
    private string bot1URL = "https://chatbot-bjornwilliams1.replit.app/chat/bot1";
    private string bot2URL = "https://chatbot-bjornwilliams1.replit.app/chat/bot2";

    private string json = @"{
        'values': {
        'AppName': 'Test001',
        'AppUser': 'Rein'
    },
    'consentAccepted': true,
    'consentToken': 't65wRU6rttK1klzu768'
    }";

    // Start is called before the first frame update
    void Start()
    {
        dialogueClass = FindObjectOfType<Dialogue>();


        StartCoroutine(PostMessage(bot1URL, "how are you??"));

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

    IEnumerator PostMessage(string url, string message)
    {
        // Create JSON data
        string json = "{\"message\": \"" + message + "\"}";

        // Create UnityWebRequest
        UnityWebRequest request = new UnityWebRequest(url, "POST");
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(json);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        // Send request
        yield return request.SendWebRequest();

        // Check for errors
        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Error: " + request.error);
        }
        else
        {
            // Log response
            Debug.Log("Response: " + request.downloadHandler.text);

            // Parse JSON response
            string responseJson = request.downloadHandler.text;
            ResponseData responseData = JsonUtility.FromJson<ResponseData>(responseJson);

            // Log the response message
            Debug.Log("Bot1 Response: " + responseData.response);
        }
    }


    [Serializable]
    private class BotResponse {
        public string response;
    }

    private void SendInput()
    {
        // If the text box is not empty and the player presses 'Enter' key
        if (playerInputTextBox.text != null && (Input.GetKeyDown(KeyCode.Return)))
        {
            playerInput = playerInputTextBox.text;
            // *** BJORN CODE HERE ***
               

            //After input has been sent, reset input box back to empty
            Debug.Log(playerInput);
        }
    }

    private void RecieveDialogue()
    // Accesses the Dialogue Script (which is presents the NPC dialogue) and makes string[] linesOfDialogue equal to what the Bot says
    {
        // *** BJORN CODE HERE ***

        // Whatever the bot returns, let's assign it to this string below.
        string botReply = "This string was sent from the bot and into the dialogue script.  " +
            "I am testing to see if the lines will be added properly." +
            "It should print out a new lines at ever 'return' key or every dot.";

        // The string will be cut up into lines of dialogue so they display neatly on the GUI
        string[] dialogueLines = botReply.Split('\n','.');

        // This updates the 
        dialogueClass.UpdateDialogue(dialogueLines);
    }
}

[System.Serializable]
public class Root {
    public string response { get; set; }
}

[System.Serializable]
public class ResponseData {
    public string response;
}