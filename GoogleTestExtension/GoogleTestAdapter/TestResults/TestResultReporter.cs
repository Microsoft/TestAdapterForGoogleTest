﻿using System.Collections.Generic;
using System.Threading;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Adapter;

namespace GoogleTestAdapter.TestResults
{
    public class TestResultReporter
    {
        private const int NrOfTestResultsBeforeWaiting = 1;
        private const int WaitingTime = 1;

        private static readonly object Lock = new object();

        private IFrameworkHandle FrameworkHandle { get; }
        private int NrOfReportedResults { get; set; } = 0;

        public TestResultReporter(IFrameworkHandle frameworkHandle)
        {
            this.FrameworkHandle = frameworkHandle;
        }

        public void ReportTestResults(IEnumerable<TestResult> testResults)
        {
            lock (Lock)
            {
                foreach (TestResult testResult in testResults)
                {
                    ReportTestResult(testResult);
                }
            }
        }

        private void ReportTestResult(TestResult testResult)
        {
            FrameworkHandle.RecordResult(testResult);
            FrameworkHandle.RecordEnd(testResult.TestCase, testResult.Outcome);

            NrOfReportedResults++;
            if (NrOfReportedResults % NrOfTestResultsBeforeWaiting == 0)
            {
                Thread.Sleep(WaitingTime);
            }
        }

    }

}