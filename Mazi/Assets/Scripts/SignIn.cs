using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SignIn : MonoBehaviour
{
	public Text usernameText;
	public Text passwordText;

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
    		SceneManager.LoadScene(0);
    	}
    }

	public void backToMainMenu()
	{
		Debug.Log("Hello");
    	SceneManager.LoadScene(0);
	}
}
