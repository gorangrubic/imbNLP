// --------------------------------------------------------------------------------------------------------------------
// <copyright file="lexiconItemTools.cs" company="imbVeles" >
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

    public static class lexiconItemTools {

        /// <summary>
        /// Determines whether the specified term is match.
        /// </summary>
        /// <param name="lexItem">The lex item.</param>
        /// <param name="term">The term.</param>
        /// <returns>
        ///   <c>true</c> if the specified term is match; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsMatch(this ILexiconItem lexItem, string term)
        {
            if (lexItem == null)
            {
                return false;
            }

            return lexItem.name == term;
        }

        public static string getItemTypeName(this ILexiconItem lexItem)
        {
            if (lexItem is IConcept)
            {
                return nameof(semanticLexicon.Concept);
            }
            if (lexItem is ITermInstance)
            {
                return nameof(TermInstance);
            }
            if (lexItem is ITermLemma)
            {
                return nameof(TermLemma);
            }

            return "";
        }

        /// <summary>
        /// Expands the once.
        /// </summary>
        /// <param name="lexItem">The lex item to expand from</param>
        /// <param name="type">The type of expansion</param>
        /// <param name="exclude">Items not to expand to</param>
        /// <returns></returns>
        public static List<ILexiconItem> expandOnce(this ILexiconItem lexItem, lexiconItemExpandEnum type = lexiconItemExpandEnum.upBelowLateral, List<ILexiconItem> exclude=null)
        {
            string itemType = lexItem.getItemTypeName();
            List<ILexiconItem> output = new List<ILexiconItem>();
            if (exclude == null) exclude = new List<ILexiconItem>();

            if (type.HasFlag(lexiconItemExpandEnum.includeStart)) output.Add(lexItem);

            

            switch (itemType)
            {
                case nameof(semanticLexicon.Concept):

                    IConcept concept = lexItem as IConcept;

                    if (type.HasFlag(lexiconItemExpandEnum.below))
                    {
                        output.AddRangeUnique(concept.lemmas);
                        output.AddRangeUnique(concept.hypoConcepts);
                    }

                    if (type.HasFlag(lexiconItemExpandEnum.lateral))
                    {

                        output.AddRangeUnique(concept.relatedTo);
                        output.AddRangeUnique(concept.relatedFrom);
                    }

                    
                    if (type.HasFlag(lexiconItemExpandEnum.conceptUp))
                    {
                        output.AddUnique(concept.hyperConcept);
                    }
                    break;
                case nameof(TermLemma):

                    
                    ITermLemma lemma = lexItem as ITermLemma;

                    if (lemma == null)
                    {
                        return output;
                    }

                    if (type.HasFlag(lexiconItemExpandEnum.below))
                    {
                        if (lemma.instances != null)
                        {
                            output.AddRange(lemma.instances);
                        }
                    }
                    if (type.HasFlag(lexiconItemExpandEnum.lateral)) {
                        if (lemma.relatedFrom != null)
                        {
                            output.AddRange(lemma.relatedFrom);
                        }
                        if (lemma.relatedTo != null)
                        {
                            output.AddRange(lemma.relatedTo);
                        }
                    }

                    if (type.HasFlag(lexiconItemExpandEnum.up))
                    {
                        if (lemma.concepts != null)
                        {
                            output.AddRangeUnique(lemma.concepts);
                        }
                    }

                    if (type.HasFlag(lexiconItemExpandEnum.compounds))
                    {
                        if (lemma.compounds != null)
                        {
                            output.AddRangeUnique(lemma.compounds);
                        }
                    }

                    break;
                case nameof(TermInstance):

                    ITermInstance instance = lexItem as ITermInstance;

                    if (type.HasFlag(lexiconItemExpandEnum.up))
                    {
                        output.AddUnique(instance.lemma);
                    }
                    break;
            }

            output.RemoveAll(x => exclude.Contains(x));

            return output;

        }
    }

}