// --------------------------------------------------------------------------------------------------------------------
// <copyright file="contentTokenCollection.cs" company="imbVeles" >
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

    public class contentTokenCollection : contentCollectionBase<IContentToken>
        //contentCollectionBase<IContentToken, nlpTokenGenericType>
    {

       

        public virtual void Add(IContentToken item)
        {
            int co = 0;
            co = Count;
            base.Add(item);
            if (co == Count)
            {

            }

            //Add(item);
        }

        //public void CollectAll(IEnumerable items) // where T:class,IContentToken, new()
        //{
        //    if (items != null)
        //    {

        //        foreach (Object en in items)
        //        {
        //            if (en is IContentSubSentence)
        //            {
        //                IContentSubSentence icss = en as IContentSubSentence;
        //                Add(icss.items);
        //            } else
        //            {
        //                Add(en as IContentToken);    
        //            }

        //        }
        //    }
        //}


        public List<IContentToken> this[contentTokenFlag flag]
        {
            get
            {
                if (Enumerable.Any(this, x => x.flags.HasFlag(flag)))
                {
                    return Enumerable.Where(this, x => x.flags.HasFlag(flag)).ToList();
                }
                else
                {
                    return new List<IContentToken>();
                }
            }
        }

        public List<IContentToken> this[params contentTokenFlag[] flag]
        {
            get
            {
                return Enumerable.Where(this, x => x.flags.getEnumListFromFlags().ContainsOneOrMore(flag)).ToList();
            }
        }

       
    }
}