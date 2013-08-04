using NUnit.Framework;
using System;
using System.Collections;
using UnityEngine;

namespace NUnitLite.Unity
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
	public class TestDriverAttribute : NUnitAttribute
	{
	}
}


