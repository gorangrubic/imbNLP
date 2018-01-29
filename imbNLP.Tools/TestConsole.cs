// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestConsole.cs" company="imbVeles" >
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
namespace imbNLP.Tools
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using imbACE.Services.console;
    using imbACE.Services.application;
    using imbNLP.Data.consolePlugins;
    using imbNLP.PartOfSpeech.resourceProviders;
    using imbNLP.PartOfSpeech.pipeline.plugin;

    public class TestConsole : aceAdvancedConsole<TestState, TestWorkspace>
    {
        public override string consoleTitle { get { return "Test Console"; } }

        public TestConsole() : base()
        {


        }

        private pipelineModelConsolePlugin _mcPipelinePlugin = null;
        /// <summary>
        /// Part-of-speech resolver plugin
        /// </summary>
        /// <value>
        /// Instance of POS resolver
        /// </value>
        public pipelineModelConsolePlugin mcPipelinePlugin
        {
            get
            {
                if (_mcPipelinePlugin == null) _mcPipelinePlugin = new pipelineModelConsolePlugin(this);
                return _mcPipelinePlugin;
            }
        }



        private posResolverPlugin _posPlugin = null;
        /// <summary>
        /// Part-of-speech resolver plugin
        /// </summary>
        /// <value>
        /// Instance of POS resolver
        /// </value>
        public posResolverPlugin posPlugin
        {
            get
            {
                if (_posPlugin == null) _posPlugin = new posResolverPlugin(this);
                return _posPlugin;
            }
        }


        /// <summary>
        /// Gets the workspace.
        /// </summary>
        /// <value>
        /// The workspace.
        /// </value>
        public override TestWorkspace workspace
        {
            get
            {
                if (_workspace == null)
                {
                    _workspace = new TestWorkspace(this);
                }
                return _workspace;
            }
        }

        public override aceCommandConsoleIOEncode encode
        {
            get
            {
                return aceCommandConsoleIOEncode.dos;
            }
        }
        

        public override void onStartUp()
        {
            base.onStartUp();
        }

        protected override void doCustomSpecialCall(aceCommandActiveInput input)
        {

        }
    }

}