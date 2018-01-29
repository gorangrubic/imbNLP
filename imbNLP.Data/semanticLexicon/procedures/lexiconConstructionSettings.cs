// --------------------------------------------------------------------------------------------------------------------
// <copyright file="lexiconConstructionSettings.cs" company="imbVeles" >
//
// Copyright (C) 2018 imbVeles
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
// Project: imbNLP.Data
// Author: Goran Grubic
// ------------------------------------------------------------------------------------------------------------------
// Project web site: http://blog.veles.rs
// GitHub: http://github.com/gorangrubic
// Mendeley profile: http://www.mendeley.com/profiles/goran-grubi2/
// ORCID ID: http://orcid.org/0000-0003-2673-9471
// Email: hardy@veles.rs
// </summary>
// ------------------------------------------------------------------------------------------------------------------
namespace imbNLP.Data.semanticLexicon.procedures
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Xml.Serialization;
    using BrightstarDB.EntityFramework;
    using imbACE.Core.commands.menu;
    using imbACE.Core.core;
    using imbACE.Core.operations;
    using imbACE.Services.console;
    using imbACE.Services.terminal;
    using imbNLP.Data.extended.domain;
    using imbNLP.Data.extended.unitex;
    using imbNLP.Data.semanticLexicon.core;
    using imbNLP.Data.semanticLexicon.explore;
    using imbNLP.Data.semanticLexicon.morphology;
    using imbNLP.Data.semanticLexicon.source;
    using imbNLP.Data.semanticLexicon.term;
    using imbSCI.Core.extensions.io;
    using imbSCI.Core.extensions.text;
    using imbSCI.Core.files.folders;
    using imbSCI.Core.files.unit;
    using imbSCI.Core.reporting;
    using imbSCI.Data;
    using imbSCI.Data.collection.nested;
    using imbSCI.Data.data;
    using imbSCI.Data.enums.reporting;
    using imbSCI.DataComplex.extensions.data.formats;
    using imbSCI.DataComplex.extensions.text;
    using imbSCI.DataComplex.special;
    using System.IO;

    [XmlInclude(typeof(aceSettingsBase))]
    [XmlInclude(typeof(aceSettingsStandaloneBase))]
    public class lexiconConstructionSettings : aceSettingsStandaloneBase
    {
        /// <summary>
        /// 
        /// </summary>
        public int parallelTake { get; set; } = 10;


        /// <summary>
        /// Path where the settings is saved
        /// </summary>
        public override string settings_filepath
        {
            get
            {
                return  imbACE.Core.application.aceApplicationInfo.FOLDERNAME_CONFIG + Path.DirectorySeparatorChar + "lexiconConstructionSettings.xml";
            }
        }

        /// <summary>
        /// Number of task iterations to pass in order to call save all
        /// </summary>
        [Category("lexiconConsoleSettings")]
        [DisplayName("saveAllIterations")]
        [Description("Number of task iterations to pass in order to call save all")]
        public int saveAllIterations { get; set; } = 25; // = new Int32();



        /// <summary>
        /// Gets or sets the size of the file text search block.
        /// </summary>
        /// <value>
        /// The size of the file text search block.
        /// </value>
        public int fileTextSearchBlockSize { get; set; } = 500;
        

        /// <summary>
        /// Name of the corpus project operation
        /// </summary>
        [Category("lexiconConstructionSettings")]
        [DisplayName("corpusProjectName")]
        [Description("Name of the corpus project operation")]
        public string corpusProjectName { get; set; } = "corpus01"; // = new String();



        /// <summary>
        /// Path of the input corpus 
        /// </summary>
        [Category("lexiconConstructionSettings")]
        [DisplayName("Corpus input path")]
        [Description("Path of the input corpus")]
        public string corpusInput { get; set; } = "resources\\corpus\\sm_corpus_input.csv"; // = new String();

    }
}
