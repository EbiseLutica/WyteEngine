using System.IO;
using UnityEngine;

public static class SaveDataHelper
{
	public static void Save(string relativePath, object data) => File.WriteAllText(Combine(relativePath), JsonUtility.ToJson(data));

	public static T Load<T>(string relativePath) => File.Exists(Combine(relativePath)) ? JsonUtility.FromJson<T>(File.ReadAllText(Combine(relativePath))) : default(T);

	private static string Combine(string relativePath) => Path.Combine(Application.persistentDataPath, relativePath);
}


public abstract class BaseBehaviour : MonoBehaviour
{
	protected Keys KeyBind => KeyBinding.Instance.Binding;
}

public abstract class SingletonBaseBehaviour<T> : BaseBehaviour where T : SingletonBaseBehaviour<T>
{
	protected static T instance;
	public static T Instance
	{
		get
		{
			if (instance == null)
			{
				instance = FindObjectOfType<T>();

				if (instance == null)
				{
					Debug.LogWarning(typeof(T) + "is nothing");
				}
			}

			return instance;
		}
	}

	protected void Awake()
	{
		CheckInstance();
	}

	protected bool CheckInstance()
	{
		if (instance == null)
		{
			instance = (T)this;
			return true;
		}
		else if (Instance == this)
		{
			return true;
		}

		Destroy(this);
		return false;
	}
}