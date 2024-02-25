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

    // Dialogue System
    public Dialogue dialogueClass;
    public TextMeshProUGUI playerInputTextBox;
    public string playerText;
    
    public string playerInput;
    public string botReply;
    public string conversation = "";


    // Bot Variables
    public string selectedBot = "bot1";
    private string bot1URL = "https://chatbot-bjornwilliams1.replit.app/chat/bot1";
    private string bot2URL = "https://chatbot-bjornwilliams1.replit.app/chat/bot2";


    //Level & ID tracking
    int currentLevelScene = 0;
    int currentId = 0;


    public int ReturnCurrentLevel()
    {
        return currentLevelScene;
    }


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
    }

    int ReturnLevelID()
    {
        return currentId;
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
            ReturningBotReply();
            // Parse JSON response
            string responseJson = request.downloadHandler.text;
            //ResponseData responseData = JsonUtility.FromJson<ResponseData>(responseJson);

            // Log the response message
            //Debug.Log("Bot1 Response: " + responseData.response);
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


        playerInput = $"{names[currentId]} born on {DOB[currentId]} who has an ID from {Location[currentId]}. Their ID photo features a person with {phys_feature[currentId]}. The ID is a {IDType[currentId]}. They just said: {playerText}. ";

        //Previous Conversations\"{conversation}\"
        conversation = conversation + playerInput;
        Debug.Log(conversation);
        return playerInput;
    }

    private void SendInput()
    {
        // If the text box is not empty and the player presses 'Enter' key
        if (playerInputTextBox.text != null && (Input.GetKeyDown(KeyCode.Return)))
        {
            playerText = playerInputTextBox.text;
            playerInputTextBox.text = string.Empty;
       
            StartCoroutine(PostMessage(bot1URL, FormPlayerSentences()));
            //After input has been sent, reset input box back to empty
            Debug.Log(playerText);
        }
    }


    public void ReturningBotReply()
    // Accesses the Dialogue Script (which is presents the NPC dialogue) and makes string[] linesOfDialogue equal to what the Bot says
    {
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