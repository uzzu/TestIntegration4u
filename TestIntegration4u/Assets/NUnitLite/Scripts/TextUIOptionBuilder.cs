using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using UnityEngine;

namespace NUnitLite.Unity
{
	public class TextUIOptionBuilder
	{

		#region inner classes, enum, and structs
		public enum XmlReportFormat : int
		{
			NUnit2,
			NUnit3
		}

		#endregion
	
		#region constants
		#endregion
	
		#region properties
		public List<string> AssembleFileNames { get; private set; }

		public string ReportFileName { get; private set; }

		public TextUIOptionBuilder.XmlReportFormat ReportFormat { get; private set; }

		public bool FullPrinting { get; private set; }

		public bool NoHeader { get; private set; }

		public string OutputFileName { get; private set; }

		public string IncludeCategory { get; private set; }

		public string ExcludeCategory { get; private set; }

		#endregion
	
		#region public methods
		public TextUIOptionBuilder()
		{
			AssembleFileNames = new List<string>();
			ReportFileName = string.Empty;
			ReportFormat = TextUIOptionBuilder.XmlReportFormat.NUnit2;
			FullPrinting = true;
			NoHeader = false;
			OutputFileName = string.Empty;
			IncludeCategory = string.Empty;
			ExcludeCategory = string.Empty;
		}

		public string[] Build()
		{
			// default assemble files
			if (AssembleFileNames.Count == 0)
			{
				AssembleFileNames.Add(Assembly.GetCallingAssembly().FullName);
			}

			// required
			List<string> options = new List<string>(AssembleFileNames.ToArray());
			string reportFileName = BuildReportFileName(ReportFileName);
			options.Add(reportFileName);
			string format = BuildFormat(ReportFormat);
			options.Add(format);

			// optionals
			string fullPrinting = BuildFullPrinting(FullPrinting);
			if (fullPrinting != string.Empty)
			{
				options.Add(fullPrinting);
			}
			string noHeader = BuildNoHeader(NoHeader);
			if (noHeader != string.Empty)
			{
				options.Add(noHeader);
			}
			string outputFileName = BuildOutPutFileName(OutputFileName);
			if (outputFileName != string.Empty)
			{
				options.Add(outputFileName);
			}
			string includeCategory = BuildIncludeCategory(IncludeCategory);
			if (includeCategory != string.Empty)
			{
				options.Add(includeCategory);
			}
			string excludeCategory = BuildExcludeCategory(ExcludeCategory);
			if (excludeCategory != string.Empty)
			{
				options.Add(excludeCategory);
			}

			return options.ToArray();
		}

		public TextUIOptionBuilder AddAssembleFileName(string value)
		{
			AssembleFileNames.Add(value);
			return this;
		}

		public TextUIOptionBuilder SetReportFileName(string value)
		{
			ReportFileName = value;
			return this;
		}

		public TextUIOptionBuilder SetReportFormat(TextUIOptionBuilder.XmlReportFormat value)
		{
			ReportFormat = value;
			return this;
		}

		public TextUIOptionBuilder SetFullPrinting(bool value)
		{
			FullPrinting = value;
			return this;
		}

		public TextUIOptionBuilder SetNoHeader(bool value)
		{
			NoHeader = value;
			return this;
		}

		public TextUIOptionBuilder SetOutputFileName(string value)
		{
			OutputFileName = value;
			return this;
		}

		public TextUIOptionBuilder SetIncludeCategory(string value)
		{
			IncludeCategory = value;
			return this;
		}

		public TextUIOptionBuilder SetExcludeCategory(string value)
		{
			ExcludeCategory = value;
			return this;
		}
		#endregion

		#region override unity methods
		#endregion

		#region methods
		string BuildReportFileName(string value)
		{
			if (string.IsNullOrEmpty(value))
			{
				throw new ArgumentException("Invalid required argument => " + value.ToString());
			}
			StringBuilder builder = new StringBuilder();
			builder.AppendFormat("-result:{0}", value);
			return builder.ToString();
		}

		string BuildFormat(TextUIOptionBuilder.XmlReportFormat value)
		{
			string result = string.Empty;
			switch (value)
			{
				case TextUIOptionBuilder.XmlReportFormat.NUnit2:
					result = "-format:nunit2";
					break;
				case TextUIOptionBuilder.XmlReportFormat.NUnit3:
					result = "-format:nunit3";
					break;
				default:
					throw new ArgumentException("The argument format was not supported => " + value.ToString());
			}
			return result;
		}

		string BuildFullPrinting(bool value)
		{
			return value ? "-full" : string.Empty;
		}

		string BuildNoHeader(bool value)
		{
			return value ? "-noheader" : string.Empty;
		}

		string BuildOutPutFileName(string value)
		{
			if (string.IsNullOrEmpty(value))
			{
				return string.Empty;
			}
			StringBuilder builder = new StringBuilder();
			builder.AppendFormat("-out:{0}", value);
			return builder.ToString();
		}

		string BuildIncludeCategory(string value)
		{
			if (string.IsNullOrEmpty(value))
			{
				return string.Empty;
			}
			StringBuilder builder = new StringBuilder();
			builder.AppendFormat("-include:{0}", value);
			return builder.ToString();
		}

		string BuildExcludeCategory(string value)
		{
			if (string.IsNullOrEmpty(value))
			{
				return string.Empty;
			}
			StringBuilder builder = new StringBuilder();
			builder.AppendFormat("-exclude:{0}", value);
			return builder.ToString();
		}
		#endregion
	}

}