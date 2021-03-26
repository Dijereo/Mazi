using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
	private string username;
	private string password;

	public void SignOut() {
        SceneManager.LoadScene("SignInScene");
	}

    public void ManageDecks()
    {
    	SceneManager.LoadScene("DecksScene");
    }

    public void SearchGame()
    {
        SceneManager.LoadScene("SearchGameScene");
    }
}
