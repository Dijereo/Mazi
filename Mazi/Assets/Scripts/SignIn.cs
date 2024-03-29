﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class SignIn : MonoBehaviour
{
	public TMP_Text usernameText;
	public TMP_Text passwordText;

    static string hostURL = "http://127.0.0.1:8000";
    static string signUpURL = hostURL + "/api/accounts/signup/";
    static string signInURL = hostURL + "/api/accounts/signin/";

    public void signIn() {
    	StartCoroutine(signInRequest(usernameText.text, passwordText.text));
    }

   	IEnumerator signInRequest(string username, string password) {
    	List<IMultipartFormSection> wwwform = new List<IMultipartFormSection>();
    	wwwform.Add(new MultipartFormDataSection("username", username));
    	wwwform.Add(new MultipartFormDataSection("password", password));

    	UnityWebRequest www = UnityWebRequest.Post(signInURL, wwwform);

    	yield return www.SendWebRequest();

    	if (www.isNetworkError || www.isHttpError) {
    	}
    	else {
    		string result = www.downloadHandler.text;
            AuthToken.SaveToFile(result);
            string token = AuthToken.LoadFromFile();
            Debug.Log(token);
    		SceneManager.LoadScene("MainMenuScene");
    	}
    }

	public void backToMainMenu()
	{
    	SceneManager.LoadScene("MainMenuScene");
	}
}
