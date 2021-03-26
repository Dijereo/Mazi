using System.Collections;
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

    //readonly string signUpURL = "http://127.0.0.1:8000/api/accounts/signup/";
    readonly string signInURL = "http://127.0.0.1:8000/api/api-token-auth/";

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
    		string token = www.downloadHandler.text;
    		SceneManager.LoadScene("MainMenuScene");
    	}
    }

	public void backToMainMenu()
	{
    	SceneManager.LoadScene("MainMenuScene");
	}
}
