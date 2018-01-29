// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IContentToken.cs" company="imbVeles" >
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
// Project: imbNLP.Core
// Author: Goran Grubic
// ------------------------------------------------------------------------------------------------------------------
// Project web site: http://blog.veles.rs
// GitHub: http://github.com/gorangrubic
// Mendeley profile: http://www.mendeley.com/profiles/goran-grubi2/
// ORCID ID: http://orcid.org/0000-0003-2673-9471
// Email: hardy@veles.rs
// </summary>
// ------------------------------------------------------------------------------------------------------------------
namespace imbNLP.Core.contentStructure.interafaces
{
    #region imbVELES USING

    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Xml.Serialization;
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
    using imbNLP.Data.semanticLexicon.procedures;
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
    using imbNLP.Data.enums.flags;
    using imbNLP.Data.enums;
    using imbNLP.Core.contentPreprocess;
    using imbSCI.Core.attributes;
    

    #endregion

    [imb(imbAttributeName.collectionDisablePrimaryKey)]
    public interface IContentToken : IContentElement, IQuerableElement<contentTokenFlag>
    {
        /// <summary>
        /// tip tokena na generičkom nivou - predstavlja polaznu tačku za dalje analize na osnovu semantičkog modela
        /// </summary>
        // [XmlIgnore]
        [Category("Token")]
        [DisplayName("genericType")]
        [Description("tip tokena na generičkom nivou - predstavlja polaznu tačku za dalje analize na osnovu semantičkog modela")]
        //  nlpTokenGenericType genericType { get; set; }
        contentTokenFlag flags { get; set; }

        tokenDetectionFlag detectionFlags { get; set; }

        contentTokenOrigin origin { get; set; }

        /// <summary>
        /// First tosInstance - 
        /// </summary>
      //  tosElementBase tosInstance { get; set; }

        /// <summary>
        /// Da li ima tosInstance?
        /// </summary>
        bool has_tosInstance { get; }

        ///// <summary>
        ///// Svi elementi: tosInstances
        ///// </summary>
        //List<tosElementBase> tosInstances { get; set; }

        /// <summary>
        /// Referenca prema instanci u recniku
        /// </summary>
      //  dictionaryEntry dictionaryInstance { get; set; }

        /// <summary>
        /// referenca prema language element instanci
        /// </summary>
      //  elementEntry elementInstance { get; set; }

        /// <summary>
        /// osnovna klasifikacija tokena
        /// </summary>
        nlpTokenBaseType baseType { get; set; }
        nlpTokenGenericType genericType { get; set; }

        /// <summary>
        /// vrsta reci
        /// </summary>
        // tosWordType wordType { get; set; }

        /*
        /// <summary>
        /// Da li postoje neregularni SYllable
        /// </summary>
        // [XmlIgnore]
        [Category("nlpToken")]
        [DisplayName("hasIrregular")]
        [Description("Da li postoje neregularni SYllable")]
        Boolean hasIrregular { get; set; }

        /// <summary>
        /// U kom je CASE-u sadržaj
        /// </summary>
        // [XmlIgnore]
        [Category("Metrics")]
        [DisplayName("letterCase")]
        [Description("U kom je CASE-u sadržaj")]
        nlpTextCase letterCase { get; set; }



        nlpTokenBaseType tokenBaseType { get; }

        /// <summary>
        /// pod FAZA 2.a: detektovanje slogova - poziva ga faza 2, nema potrebe posebno pozivati
        /// </summary>
        /// <param name="token"></param>
        /// <param name="language"></param>
        void syllablesDetection(nlpTokenizatorSettings settings);
         * */
    }
}