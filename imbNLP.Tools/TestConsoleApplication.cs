// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestConsoleApplication.cs" company="imbVeles" >
//
// Copyright (C) 2017 imbVeles
//
// This program is free software: you can redistribute it and/or modify
// it under the +terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see http://www.gnu.org/licenses/. 
// </copyright>
// <summary>
// Project: imbNLP.Tools
// Author: Goran Grubic
// ------------------------------------------------------------------------------------------------------------------
// Project web site: http://blog.veles.rs
// GitHub: http://github.com/gorangrubic
// Mendeley profile: http://www.mendeley.com/profiles/goran-grubi2/
// ORCID ID: http://orcid.org/0000-0003-2673-9471
// Email: hardy@veles.rs
// </summary>
// ------------------------------------------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;
namespace imbNLP.Tools
{
    using System.Text;
    using imbACE.Services.console;
    using imbACE.Services.application;


    public class TestConsoleApplication : aceConsoleApplication<TestConsole>
    {
        public static void Main(String[] args) {

            var app = new TestConsoleApplication();

            // entering the application loop
            app.StartApplication(args);

            // exit point here

        }


        public override void setAboutInformation()
        {
            appAboutInfo = new imbACE.Core.application.aceApplicationInfo {
                applicationVersion = "0.1v",
                author = "Goran Grubić",
                software = "imbNLP Text console application",
                organization = "imbVeles",
                license = "GNU GPL v3.0",
                copyright = "Copyright (C) 2017",
                welcomeMessage = "Purpose of this console is to allow access to test and explore tools that are under development",
                comment = ""
            };

        }
    }

}