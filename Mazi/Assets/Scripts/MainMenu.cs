using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
	private string username;
	private string password;

	public void signOut() {
        SceneManager.LoadScene(2);
	}

    public void searchGame()
    {

    }

    public void manageDecks ()
    {
    	SceneManager.LoadScene(1);
    }
}
