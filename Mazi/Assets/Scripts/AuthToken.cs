using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


[System.Serializable]
public class AuthToken
{
	private static readonly string PATH = Application.persistentDataPath + "/AuthToken.dat";

	public string token;

	public AuthToken()
	{
		token = "none";
	}

	private string ToJson()
	{
		return JsonUtility.ToJson(this);
	}

	private static AuthToken FromJson(string json)
	{
		AuthToken atok =  new AuthToken();
		JsonUtility.FromJsonOverwrite(json, atok);
		return atok;
	}

	public static void SaveToFile(string json)
	{
		StreamWriter writer = new StreamWriter(PATH);
        writer.WriteLine(AuthToken.FromJson(json).token);
        writer.Flush();
        writer.Close();
	}

	public static string LoadFromFile()
	{
        StreamReader reader = new StreamReader(PATH);
        reader.BaseStream.Seek(0, SeekOrigin.Begin);
        string tok = reader.ReadLine(); 
        reader.Close();
        return tok;
	}
}
