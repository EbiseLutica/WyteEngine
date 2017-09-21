using UnityEngine;
using System;
using System.Linq;
using System.Collections.Generic;
using UObject = UnityEngine.Object;

public class KeyGet 
{

	public static IEnumerable<KeyCode> GetAllKey()
	{
		if (!Input.anyKey) return Enumerable.Empty<KeyCode>();
		return (Enum.GetValues(typeof(KeyCode)) as KeyCode[]).Where(p => Input.GetKey(p));
	}

	public static IEnumerable<KeyCode> GetAllKeyDown()
	{
		if (!Input.anyKeyDown) return Enumerable.Empty<KeyCode>();
		return (Enum.GetValues(typeof(KeyCode)) as KeyCode[]).Where(p => Input.GetKeyDown(p));
	}
}
