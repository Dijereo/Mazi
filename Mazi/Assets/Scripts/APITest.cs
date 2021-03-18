using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class APITest : MonoBehaviour
{
    public Text messageText;

    //readonly string signUpURL = "http://127.0.0.1:8000/api/accounts/signup/";
    readonly string signInURL = "http://127.0.0.1:8000/api/api-token-auth/";

    private void Start() {
    	messageText.text = "Hello";
    }

    public void signIn() {
    	messageText.text = "Signing in";
    	StartCoroutine(signInRequest("dijereo", "12345678"));
    }

    IEnumerator signInRequest(string username, string password) {
    	List<IMultipartFormSection> wwwform = new List<IMultipartFormSection>();
    	wwwform.Add(new MultipartFormDataSection("username", username));
    	wwwform.Add(new MultipartFormDataSection("password", password));

    	UnityWebRequest www = UnityWebRequest.Post(signInURL, wwwform);

    	yield return www.SendWebRequest();

    	if (www.isNetworkError || www.isHttpError) {
    		messageText.text = www.error;
    	}
    	else {
    		messageText.text = www.downloadHandler.text;
    	}
    }
}
