// --------------------------------------------------------------------------------------------------------------------
// <copyright file="contentSentenceCollection.cs" company="imbVeles" >
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
namespace imbNLP.Core.contentStructure.collections
{
    using System;
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
    using imbNLP.Core.contentStructure.interafaces;
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
    using imbNLP.Core.contentExtensions;
    using imbSCI.Core.extensions.data;

    #endregion

    /// <summary>
    /// Kolekcija pod rečenica i rečenica
    /// </summary>
    public class contentSentenceCollection : contentCollectionBase<IContentSentence>
        //contentCollectionBase<IContentSentence, nlpSentenceGenericType>
    {
        public List<IContentSentence> this[contentSentenceFlag flag]
        {
            get
            {
                if (Enumerable.Any(this, x => x.sentenceFlags.HasFlag(flag)))
                {
                    return Enumerable.Where(this, x => x.sentenceFlags.HasFlag(flag)).ToList();
                }
                else
                {
                    return new List<IContentSentence>();
                }
            }
        }

        internal bool TrueForAll(Func<IContentSentence, bool> p)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the <see cref="List{IContentSentence}"/> with the specified flags - any of these will trigger
        /// </summary>
        /// <value>
        /// The <see cref="List{IContentSentence}"/>.
        /// </value>
        /// <param name="flag">The flag.</param>
        /// <returns></returns>
        public List<IContentSentence> this[params contentSentenceFlag[] flag] => Enumerable.Where(this, x => x.sentenceFlags.getEnumListFromFlags().ContainsOneOrMore(flag)).ToList();//turn this.Where(x => x.sentenceFlags.Contains(flag)).ToList();
    }
}