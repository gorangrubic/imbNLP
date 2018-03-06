using System;
using System.Linq;
using System.Collections.Generic;
namespace imbNLP.PartOfSpeech.providers.dictionary.apertium
{
    using System.Text.RegularExpressions;
    using System.Xml;
    using imbSCI.Data;
    using imbSCI.Core.files.search;
    using imbSCI.Data.extensions.data;
    using imbACE.Core;
    using System.IO;
    using imbSCI.Core.reporting;
    using imbACE.Core.core;
    using imbNLP.PartOfSpeech.flags.basic;
    using imbSCI.Core.extensions.enumworks;
    using imbSCI.DataComplex.special;
    using imbSCI.Core.extensions.data;


    /// <summary>
    /// Configuration for <see cref="dictionaryResourceApertium"/>
    /// </summary>
    public class dictionaryResourceSetup
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="dictionaryResourceSetup"/> class.
        /// </summary>
        public dictionaryResourceSetup()
        {

        }


        /// <summary>
        /// Search pattern to be used when searching for Apertium dictionary file
        /// </summary>
        /// <value>
        /// The file name search pattern.
        /// </value>
        public String fileNameSearchPattern { get; set; } = "apertium-hbs-eng.hbs-eng.dix";

        /// <summary>
        /// If <c>true</c> it will use text search to find match in the dictionary, otherwise navigates the XML tree
        /// </summary>
        /// <value>
        ///   <c>true</c> if [use text instead of XML]; otherwise, <c>false</c>.
        /// </value>
        public Boolean useTextInsteadOfXML { get; set; } = true;

    }

}