// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IContentPage.cs" company="imbVeles" >
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
    using imbNLP.Core.contentStructure.collections;
    
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
    using imbACE.Core.cache;
    using imbCommonModels;
    using imbSCI.Core.attributes;
    using imbACE.Network.tools;
    using imbCommonModels.structure;

    #endregion

    [imb(imbAttributeName.collectionDisablePrimaryKey)]
    public interface IContentPage : IContentElement //, ICacheEnabled
    {
        IContentProject project { get; }

        IContentDocument document { get; }

        // imbStringBuilder makeReport(imbStringBuilder sb = null);

        contentBlockCollection blocks { get; set; }
       
        contentTokenCollection headTokens { get; set; }

       // FlowDocument makeFlowDocument(FlowDocument flowReport = null);

        /// <summary>
        /// Blokovi sadrzaja
        /// </summary>
        [XmlIgnore]
        [Category("nlpContent")]
        [DisplayName("paragraphs")]
        [Description("Blokovi sadrzaja")]
        contentParagraphCollection paragraphs { get; set; }

        /// <summary>
        /// Sve rečenice u nlpContent-u
        /// </summary>
        [XmlIgnore]
        [Category("Misc")]
        [DisplayName("sentences")]
        [Description("Sve rečenice u nlpContent-u")]
        contentSentenceCollection sentences { get; set; }

        /// <summary>
        /// Svi chunkovi
        /// </summary>
        [XmlIgnore]
        [Category("Misc")]
        [DisplayName("chunks")]
        [Description("Svi chunkovi")]
        contentChunkCollection chunks { get; set; }

        /// <summary>
        /// Svi tokeni pronadjeni u nlpContentu
        /// </summary>
        [XmlIgnore]
        [Category("Misc")]
        [DisplayName("tokens")]
        [Description("Svi tokeni pronadjeni u nlpContentu")]
        contentTokenCollection tokens { get; set; }


        //[Category("contentPage")]
        //[DisplayName("contentSource")]
        //[Description("Text/kodni sadrzaj na osnovu koga je uradjena tokenizacija")]
        //String contentSource { get; set; }

        /// <summary>
        /// Naziv sadrzaja
        /// </summary>
// [XmlIgnore]
        [Category("contentPage")]
        [DisplayName("contentTitle")]
        [Description("Naziv sadrzaja")]
        string contentTitle { get; set; }

        /// <summary>
        /// Adresa stranice
        /// </summary>
// [XmlIgnore]
        [Category("contentPage")]
        [DisplayName("contentUrl")]
        [Description("Adresa stranice")]
        string contentUrl { get; set; }

        /// <summary>
        /// Content Tree Builder reference
        /// </summary>
      //  contentTreeBuilder treeBuilder { get; set; }

       
        /// <summary>
        /// Informacije o domenu
        /// </summary>
// [XmlIgnore]
        domainAnalysis domainInfo { get; set; }
       // object blocks { get; set; }

        /// <summary>
        /// Popunjava kolekcije> paragraphs, sentences, tokens
        /// </summary>
        void recountItems();

        /// <summary>
        /// Preuzima opisne podatke iz node/crawledpage objekta -- poziva se iz tokenizatora, ne prenosi sam asdrza
        /// </summary>
        /// <param name="sourcePage"></param>
        void acceptSourcePage(node sourcePage);
    }
}