using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;

namespace CoreFramework.Reporter
{
    internal class HtmlReport
    {
        private static ExtentTest? _extentTestSuite;
        private static ExtentTest? _extentTestCase;
        private static int testCaseIndex;
        private static ExtentReports _report;

        //singleton
        public static ExtentReports createReport()
        {
            if (_report == null)
            {
                _report = createInstance();
            }
            return _report;
        }
        private static ExtentReports createInstance()
        {
            HtmlReportDirectory.InitReportDirection(); ;
            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(HtmlReportDirectory.REPORT_FILE_PATH);
            htmlReporter.Config.DocumentTitle = "Automation Test Report";
            htmlReporter.Config.ReportName = "Automation Test Report";
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Standard;
            htmlReporter.Config.Encoding = "UTF-8";

            ExtentReports report = new ExtentReports();
            report.AttachReporter(htmlReporter);
            return report;
        }
        public static void flush() // gen htmlreport
        {
            if (_report != null)
            {
                _report.Flush();
            }
        }
        public static ExtentTest createTest(string className, string classDescription = "")
        {
            if (_report == null)
            {
                _report = createInstance();
            }
            _extentTestSuite = _report.CreateTest(className, classDescription);

            return _extentTestSuite;
        }
        public static ExtentTest createNode(string className, string testcase, string description = "")
        {
            if (_extentTestSuite == null)
            {
                _extentTestSuite = createTest(className);
            }
            _extentTestCase = _extentTestSuite.CreateNode(testcase, description);

            return _extentTestCase;
        }

        public static ExtentTest GetParent()
        {
            return _extentTestSuite;
        }
        public static ExtentTest GetNode()
        {
            return _extentTestCase;
        }
        public static ExtentTest GetTest()
        {
            if (GetNode() == null)
            {
                return GetParent();
            }
            return GetNode();
        }
        public static void Pass(string des)
        {
            GetTest().Pass(des);
            TestContext.WriteLine(des);
        }
        public static void Fail(string des)
        {
            GetTest().Fail(des);
            TestContext.WriteLine(des);
        }
        public static void Fail(string des, string path)
        {
            GetTest().Fail(des).AddScreenCaptureFromPath(path);
            TestContext.WriteLine(des);
        }
        public static void Fail(string des, string ex, string path)
        {
            GetTest().Fail(des).Fail(ex).AddScreenCaptureFromPath(path);
            TestContext.WriteLine(des);
        }
        public static void Info(string des)
        {
            GetTest().Info(des);
            TestContext.WriteLine(des);
        }
        public static void Warning(string des)
        {
            GetTest().Warning(des);
            TestContext.WriteLine(des);
        }
        public static void Skip(string des)
        {
            GetTest().Skip(des);
            TestContext.WriteLine(des);
        }
    }
}
