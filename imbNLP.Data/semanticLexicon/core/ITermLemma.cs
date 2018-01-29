// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ITermLemma.cs" company="imbVeles" >
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
namespace imbNLP.Data.semanticLexicon.core
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

    [Entity]
    public interface ITermLemma:ILexiconItem
    {
        /// <summary>
        /// Get the persistent identifier for this entity
        /// </summary>
      //  [Identifier("http://imb.veles.rs/sm-ltsd-lexicon/", KeyProperties = new[] { "name", "type" }, KeySeparator = "_")]
        string Id { get; }

        // TODO: Add other property references here

        /// <summary>
        /// Name contains the Lemma form of a word
        /// </summary>
        /// <value>
        /// Lemmatic form of a word
        /// </value>
        string name { get; set; }

       

        [InverseProperty("lemma")]
        ICollection<ITermInstance> instances { get; set; }


        /// <summary>
        /// Used for Phrase
        /// </summary>
        /// <value>
        /// The compounds.
        /// </value>
        ICollection<ITermLemma> compounds { get; set; }


        [InverseProperty("relatedFrom")]
        ICollection<ITermLemma> relatedTo { get; set; }

        ICollection<ITermLemma> relatedFrom { get; set; }

        [InverseProperty("lemmas")]
        ICollection<IConcept> concepts { get; set; }

        string type { get; set; }

        string gramSet { get; set; }
    }





}