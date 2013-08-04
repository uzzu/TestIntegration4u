using UnityEngine;
using System;
using System.Collections;
using System.Reflection;

namespace NUnitLite.Unity
{
	public interface IUnitTestingSupport
	{
	}
	
	public static class UnitTestingSupport
	{
		#region public methods
		public static void DestroyObject(this IUnitTestingSupport obj, UnityEngine.Object instance)
		{
#if UNITY_EDITOR
			UnityEngine.GameObject.DestroyImmediate(instance);
#else
			UnityEngine.GameObject.Destroy(TreeInstance);
#endif
		}
		#endregion
	}
}
