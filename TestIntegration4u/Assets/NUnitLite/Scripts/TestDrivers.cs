using UnityEngine;

namespace NUnitLite.Unity
{
	[TestDriver]
	public class TestDriverSimple
	{
		public TestDriverSimple()
		{
			new NUnitLiteUnityTestRunner().RunWithNUnitStreamUI();
		}
	}

	[TestDriver]
	public class TestDriverNUnit2Report
	{
		public TestDriverNUnit2Report()
		{
			new NUnitLiteUnityTestRunner().RunWithTextUI();
		}
	}
}
