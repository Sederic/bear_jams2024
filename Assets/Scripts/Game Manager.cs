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
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    // Dialogue System
    public Dialogue dialogueClass;
    public TextMeshProUGUI playerInputTextBox;
    public string playerText;
    
    public string playerData;
    public string botReply;
    public string botReply2;
    public string botMessage;
    public string conversation = "";
    public string fullConversation = "";


    // Bot Variables
    public string selectedBot = "bot1";
    private string bot1URL = "https://chatbot-bjornwilliams1.replit.app/chat/bot1";
    private string bot2URL = "https://chatbot-bjornwilliams1.replit.app/chat/bot2";


    //Level & ID tracking
    int currentLevelScene = 0;
    int currentId = 0;
    int playerResponseIndex = 0;
    


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
        EndCondition();
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
            if (url == bot1URL)
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
            else if (url == bot2URL)
            {
                // Log response
                Debug.Log("Bot2: " + request.downloadHandler.text);
                botReply2 = request.downloadHandler.text;
                ReturningBotReply();
                // Parse JSON response
                string responseJson = request.downloadHandler.text;
                //ResponseData responseData = JsonUtility.FromJson<ResponseData>(responseJson);

                // Log the response message
                //Debug.Log("Bot1 Response: " + responseData.response);
            }

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


        playerData = $"{names[currentId]} born on {DOB[currentId]} who has an ID from {Location[currentId]}. Their ID photo features a person with {phys_feature[currentId]}. The ID is a {IDType[currentId]}.";

        //Previous Conversations\"{conversation}\"
        conversation = conversation + playerText;
        fullConversation = fullConversation + conversation;
        Debug.Log(fullConversation);
        return playerData + playerText;
    }

    void EndCondition()
    { 

        if (botReply2 == "yes")
        {
            SceneManager.LoadScene(3);
        }
        else if (botReply2 == "no") 
        {
            SceneManager.LoadScene(4);

        }
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
            playerResponseIndex++;

            if (playerResponseIndex == 3)
            {
                Debug.Log("Bot 2 Called");
                StartCoroutine(PostMessage(bot2URL, fullConversation));
            }
        }
    }


    public void ReturningBotReply()
    // Accesses the Dialogue Script (which is presents the NPC dialogue) and makes string[] linesOfDialogue equal to what the Bot says
    {
        // Whatever the bot returns, let's assign it to this string below.
        
        // The string will be cut up into lines of dialogue so they display neatly on the GUI
        string[] dialogueLines = botReply.Split('\n','.');
        Debug.Log(LogConversation());

        // This updates the 
        dialogueClass.UpdateDialogue(dialogueLines);
    }

    public string LogConversation()
    {
        return fullConversation;
    }
}


[System.Serializable]
public class ResponseData {
    public string response;
}