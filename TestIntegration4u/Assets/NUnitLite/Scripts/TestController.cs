using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace NUnitLite.Unity
{
	public class TestController : MonoBehaviour
	{
		#region inner classes, enum, and structs
		#endregion

		#region constants
		#endregion

		#region properties
		public int SelectedDriversIndex = 0;
		public List<Type> Drivers = ExtractDrivers();
		public List<string> DriverSelection = TypesToStrings(ExtractDrivers());
		#endregion

		#region public methods
		#endregion

		#region override unity methods
		void Start()
		{
			RunTests();
		}
		#endregion

		#region methods
		static List<Type> ExtractDrivers()
		{
			List<Type> types = (
					from type in Assembly.GetCallingAssembly().GetTypes()
					where type.IsDefined(typeof(TestDriverAttribute), true)
					select type
				).ToList();
			return types;
		}

		static List<string> TypesToStrings(List<Type> types)
		{
			List<string> strings = new List<string>();
			foreach (Type type in types)
			{
				strings.Add(type.FullName);
			}
			return strings;
		}

		void RunTests()
		{
			Debug.Log("Running UnitTests...");
			Type driver = Drivers[SelectedDriversIndex];
			driver.GetConstructor(new Type[] {}).Invoke(new object[] {});
		}
		#endregion
	}
}
