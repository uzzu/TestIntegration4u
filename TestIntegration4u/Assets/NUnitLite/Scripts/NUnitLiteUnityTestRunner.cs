using NUnitLite.Runner;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using UnityEngine;

namespace NUnitLite.Unity
{
	public class NUnitLiteUnityTestRunner
	{
		#region inner classes, enum, and structs
		#endregion

		#region constants
		#endregion

		#region properties
		#endregion

		#region public methods
		public NUnitLiteUnityTestRunner()
		{
		}

		public void RunWithNUnitStreamUI()
		{
			RunWithNUnitStreamUI(Assembly.GetCallingAssembly());
		}

		public void RunWithNUnitStreamUI(Assembly assembly)
		{
			if (assembly == null)
			{
				throw new ArgumentNullException("assembly was null.");
			}

			using (var sw = new StringWriter())
			{
				NUnitStreamUI runner = new NUnitStreamUI(sw);
				runner.Execute(assembly);
				ResultSummary resultSummary = runner.Summary;
				string resultText = sw.GetStringBuilder().ToString();
				if (resultSummary.ErrorCount > 0 || resultSummary.FailureCount > 0)
				{
					Debug.LogWarning(resultText);
				}
				else
				{
					Debug.Log(resultText);
				}
			}
		}

		public void RunWithTextUI()
		{
			RunWithTextUI(Assembly.GetCallingAssembly());
		}

		public void RunWithTextUI(Assembly assembly)
		{
			RunWithTextUI(Assembly.GetCallingAssembly(), GetDefaultReportFileName());
		}

		public void RunWithTextUI(string reportFileName)
		{
			RunWithTextUI(Assembly.GetCallingAssembly(), reportFileName);
		}

		public void RunWithTextUI(Assembly assembly, string reportFileName, TextUIOptionBuilder.XmlReportFormat format = TextUIOptionBuilder.XmlReportFormat.NUnit2)
		{
			if (assembly == null)
			{
				throw new ArgumentNullException("assembly was null.");
			}

			using (var sw = new StringWriter())
			{
				TextUI runner = new TextUI(sw);
				TextUIOptionBuilder builder = new TextUIOptionBuilder();
				builder.AddAssembleFileName(assembly.FullName)
					.SetReportFileName(reportFileName)
					.SetReportFormat(format);
				string[] option = builder.Build();
				runner.Execute(option);
				Debug.Log(sw.GetStringBuilder().ToString());
			}
		}
		#endregion

		#region override unity methods
		#endregion

		#region methods
		string GetDefaultReportFileName()
		{
#if UNITY_EDITOR
			string reportFileName = Application.dataPath + "/../nunit-result.xml";
#else
			string reportFileName = Application.dataPath + "/nunit-result.xml";
#endif
			return reportFileName;
		}
		#endregion
	}
}