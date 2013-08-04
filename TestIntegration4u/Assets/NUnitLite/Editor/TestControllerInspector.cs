using UnityEngine;
using UnityEditor;
using System.Collections;

namespace NUnitLite.Unity
{
	[CustomEditor(typeof(TestController))]
	public class TestControllerInspector : Editor
	{
		#region inner classes, enum, and structs
		#endregion

		#region constants
		#endregion

		#region properties
		#endregion

		#region public methods
		#endregion

		#region override unity methods
		public override void OnInspectorGUI()
		{
			TestController controller = target as TestController;
			GUILayout.Label("Select Test Driver");
			controller.SelectedDriversIndex = GUILayout.SelectionGrid(controller.SelectedDriversIndex, controller.DriverSelection.ToArray(), 1, "toggle");
		}
		#endregion

		#region methods
		#endregion
	}

}
