using NUnit.Framework;
using NUnit.Framework.Constraints;
using System.Reflection;

namespace NUnitLite.Unity
{
	[TestFixture]
	public class TextUIOptionBuilderTest
	{
		[TestCase("Assembly-CSharp", "/tmp/report.xml", true, false, TextUIOptionBuilder.XmlReportFormat.NUnit3, "/tmp/test-log.txt", "Exceptions", "Spike", TestName="Test Case 1")]
		public void ShouldBeAbleToSetCustomOptions(
			string expectedAssembleFileName,
			string expectedReportFileName,
			bool expectedNoHeader,
			bool expectedFullPrinting,
			TextUIOptionBuilder.XmlReportFormat expectedReportFormat,
			string expectedOutputFileName,
			string expectedIncludeCategory,
			string expectedExcludeCategory)
		{
			TextUIOptionBuilder builder = new TextUIOptionBuilder();
			builder.AddAssembleFileName(expectedAssembleFileName)
				.SetReportFileName(expectedReportFileName)
				.SetNoHeader(expectedNoHeader)
				.SetFullPrinting(expectedFullPrinting)
				.SetReportFormat(expectedReportFormat)
				.SetOutputFileName(expectedOutputFileName)
				.SetIncludeCategory(expectedIncludeCategory)
				.SetExcludeCategory(expectedExcludeCategory);

			Assert.That(builder.AssembleFileNames, new CollectionContainsConstraint(expectedAssembleFileName));
			Assert.That(builder.ReportFileName, Is.EqualTo(expectedReportFileName));
			Assert.That(builder.NoHeader, Is.EqualTo(expectedNoHeader));
			Assert.That(builder.FullPrinting, Is.EqualTo(expectedFullPrinting));
			Assert.That(builder.ReportFormat, Is.EqualTo(expectedReportFormat));
			Assert.That(builder.OutputFileName, Is.EqualTo(expectedOutputFileName));
			Assert.That(builder.IncludeCategory, Is.EqualTo(expectedIncludeCategory));
			Assert.That(builder.ExcludeCategory, Is.EqualTo(expectedExcludeCategory));
		}

		[TestCase(true, ExpectedResult = true, TestName = "Contain -full Option")]
		[TestCase(false, ExpectedResult = false, TestName = "Not Contain -full Option")]
		public bool ShouldBeAbleToChangeFullPrintingOption(bool fullPrinting)
		{
			TextUIOptionBuilder builder = new TextUIOptionBuilder();
			builder.AddAssembleFileName("hogehoge")
				.SetReportFileName("report.xml")
				.SetFullPrinting(fullPrinting);

			string actual = string.Join(" ", builder.Build());
			return actual.Contains("-full");
		}

		[TestCase(true, ExpectedResult = true, TestName = "Contain -noheader Option")]
		[TestCase(false, ExpectedResult = false, TestName = "Not Contain -noheader Option")]
		public bool ShouldBeAbleToChangeNoHeaderOption(bool noHeader)
		{
			TextUIOptionBuilder builder = new TextUIOptionBuilder();
			builder.AddAssembleFileName("hogehoge")
				.SetReportFileName("report.xml")
				.SetNoHeader(noHeader);

			string actual = string.Join(" ", builder.Build());
			return actual.Contains("-noheader");
		}

		[TestCase(TextUIOptionBuilder.XmlReportFormat.NUnit2, ExpectedResult = true, TestName = "Contain -format:nunit2 Option")]
		[TestCase(TextUIOptionBuilder.XmlReportFormat.NUnit3, ExpectedResult = true, TestName = "Contain -format:nunit3 Option")]
		public bool ShouldBeAbleToChangeReportFormat(TextUIOptionBuilder.XmlReportFormat reportFormat)
		{
			string expected = string.Empty;
			if (reportFormat == TextUIOptionBuilder.XmlReportFormat.NUnit2)
			{
				expected = "-format:nunit2";
			}
			else if (reportFormat == TextUIOptionBuilder.XmlReportFormat.NUnit3)
			{
				expected = "-format:nunit3";
			}

			TextUIOptionBuilder builder = new TextUIOptionBuilder();
			builder.AddAssembleFileName("hogehoge")
				.SetReportFileName("report.xml")
				.SetReportFormat(reportFormat);
			string actual = string.Join(" ", builder.Build());
			return actual.Contains(expected);
		}

		[TestCase("hogehoge.txt", ExpectedResult = true, TestName = "Contain -out: Option")]
		[TestCase("", ExpectedResult = false, TestName = "Not contain -out Option")]
		public bool ShouldBeAbleToChangeOutputFileName(string outputFileName)
		{
			TextUIOptionBuilder builder = new TextUIOptionBuilder();
			builder.AddAssembleFileName("hogehoge")
				.SetReportFileName("report.xml")
				.SetOutputFileName(outputFileName);

			string actual = string.Join(" ", builder.Build());
			return actual.Contains("-out:" + outputFileName);
		}
	}
}