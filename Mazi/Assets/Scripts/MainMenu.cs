﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    readonly string searchMatchURL = "http://127.0.0.1:8000/api/games/search/";

	public void SignOut() {
        // SceneManager.LoadScene("SignInScene");
	}

    public void ManageDecks()
    {
    	SceneManager.LoadScene("DecksScene");
    }

    public void SearchGame() {
        StartCoroutine(SearchGameRequest("dionrecai", 0));
    }

    IEnumerator SearchGameRequest(string username, int deckid) {
        List<IMultipartFormSection> wwwform = new List<IMultipartFormSection>();
        wwwform.Add(new MultipartFormDataSection("username", username));
        wwwform.Add(new MultipartFormDataSection("deckid", deckid.ToString()));
        UnityWebRequest www = UnityWebRequest.Post(searchMatchURL, wwwform);
        yield return www.SendWebRequest();
        if (www.isNetworkError || www.isHttpError) {
        }
        else {
            string result = www.downloadHandler.text;
            AuthToken atok = AuthToken.FromJson(result);
            string token = atok.token;
            Debug.Log(token);
            // SceneManager.LoadScene("MainMenuScene");
        }
    }
}
