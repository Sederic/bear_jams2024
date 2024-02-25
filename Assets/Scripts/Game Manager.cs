using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Cache;
using System.Text;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.Networking;

public class GameManager : MonoBehaviour {
    public Dialogue dialogueClass;
    public TextMeshProUGUI playerInputTextBox;
    public string playerText;
    public int currentId = 0;
    public string playerInput;
    public string conversation;


    public string selectedBot = "bot1";
    private string bot1URL = "https://chatbot-bjornwilliams1.replit.app/chat/bot1";
    private string bot2URL = "https://chatbot-bjornwilliams1.replit.app/chat/bot2";
    public string botReply;
/*    public string[] names = new string[] { "Example" };
    public string[] DOB = new string [] {"Feb 22, 1997" };
    public string[] Location = new string [] {"Canada" };
    public string[] IDType = new string [] {"Student ID" };
    public string[] phys_feature = new string [] {"a big Nose" };*/


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

        StartCoroutine(PostMessage(bot1URL, "Hello"));

}

// Update is called once per frame
void Update()
    {
        SendInput();
        ReturningBotReply();
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
            botReply = request.downloadHandler.text;
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

    private string FormPlayerSentences()
    {
        string[] names = { "Example" };
        string[] DOB = { "Feb 22, 1997" };
        string[] Location = { "Canada" };
        string[] IDType = { "Student ID" };
        string[] phys_feature = new string[] { "a big Nose" };


        playerInput = $"{names[0]} born on {DOB[0]} who has an ID from {Location[0]}. Their ID photo features a person with {phys_feature[0]}. The ID is a {IDType[0]}. They just said: {playerText}";
        Debug.Log(playerInput);
        return playerInput;
    }

    private void SendInput()
    {
        

        // If the text box is not empty and the player presses 'Enter' key
        if (playerInputTextBox.text != null && (Input.GetKeyDown(KeyCode.Return)))
        {

            playerText = playerInputTextBox.text;
            // *** BJORN CODE HERE ***

;

            StartCoroutine(PostMessage(bot1URL, FormPlayerSentences())); 


            //After input has been sent, reset input box back to empty
            Debug.Log(playerText);
        }
    }


    private void ReturningBotReply()
    // Accesses the Dialogue Script (which is presents the NPC dialogue) and makes string[] linesOfDialogue equal to what the Bot says
    {
        // *** BJORN CODE HERE ***


        // Whatever the bot returns, let's assign it to this string below.
        
        // The string will be cut up into lines of dialogue so they display neatly on the GUI
        string[] dialogueLines = botReply.Split('\n','.');

        // This updates the 
        dialogueClass.UpdateDialogue(dialogueLines);
    }
}


[System.Serializable]
public class ResponseData {
    public string response;
}