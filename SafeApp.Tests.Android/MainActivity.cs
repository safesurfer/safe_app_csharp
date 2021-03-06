﻿// ***********************************************************************
// Copyright (c) 2017 Charlie Poole
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// ***********************************************************************

using Android.App;
using Android.Content.PM;
using Android.OS;
using NUnit.Runner;
using NUnit.Runner.Services;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace SafeApp.Tests.Android {
  [Activity(
    Label = "SafeApp.Tests.Android",
    Icon = "@drawable/icon",
    Theme = "@android:style/Theme.Holo.Light",
    MainLauncher = true,
    ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
  // ReSharper disable once UnusedMember.Global
  public class MainActivity : FormsApplicationActivity {
    protected override void OnCreate(Bundle savedInstanceState) {
      base.OnCreate(savedInstanceState);

      Forms.Init(this, savedInstanceState);

      // This will load all tests within the current project
      var nunit = new App {
        Options = new TestOptions {
          // If True, the tests will run automatically when the app starts
          // otherwise you must run them manually.
          AutoRun = false

          // If True, the application will terminate automatically after running the tests.
          //TerminateAfterExecution = true,

          // Information about the tcp listener host and port.
          // For now, send result as XML to the listening server.
          //TcpWriterParameters = new TcpWriterInfo("192.168.0.108", 13000),

          // Creates a NUnit Xml result file on the host file system using PCLStorage library.
          // CreateXmlResultFile = true,

          // Choose a different path for the xml result file
          // ResultFilePath = Path.Combine(Environment.ExternalStorageDirectory.Path, Environment.DirectoryDownloads, "Nunit", "Results.xml")
        }
      };

      // If you want to add tests in another assembly
      //nunit.AddTestAssembly(typeof(MyTests).Assembly);

      // Available options for testing

      LoadApplication(nunit);
    }
  }
}
