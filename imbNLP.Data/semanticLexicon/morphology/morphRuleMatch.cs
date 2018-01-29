// --------------------------------------------------------------------------------------------------------------------
// <copyright file="morphRuleMatch.cs" company="imbVeles" >
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
namespace imbNLP.Data.semanticLexicon.morphology
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text.RegularExpressions;
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

    public class morphRuleMatch
    {

        /// <summary>
        /// Creates the explore item.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <returns></returns>
        public termExploreModel createExploreItem(string token)
        {

            //termExploreItem output = new termExploreItem(token);

            Match m = ruleSet.regex.Match(token);
            root = m.Groups[1].Value;
            stem = m.Groups[2].Value;
            sufix = m.Groups[3].Value;

            //output.gramSet = ruleSet.GetGramSet(this);

            
            morphRule rule = ruleSet.rules.First();

            string lemmaForm = rule.GetForm(this);

            termExploreModel model = new termExploreModel(lemmaForm);
            model.gramSet = ruleSet.GetGramSet(rule.sufix);

            model.instances.AddRangeUnique(ruleSet.GetItems(this, lemmaForm));

            model.lemma = new termExploreItem(lemmaForm);
            model.lemma.gramSet = model.gramSet;

            model.rootWord = root;


            return model;

        }

        public morphRuleSet ruleSet { get; set; }
        public termExploreModel item { get; set; }

        /// <summary>
        /// Gets or sets the root part of the word (first regex group
        /// </summary>
        /// <value>
        /// The root.
        /// </value>
        public string root { get; set; }

        /// <summary>
        /// Gets or sets the stem part of the word - connecting root and sufix
        /// </summary>
        /// <value>
        /// The stem.
        /// </value>
        public string stem { get; set; }

        /// <summary>
        /// Gets or sets the sufix part of the word
        /// </summary>
        /// <value>
        /// The sufix.
        /// </value>
        public string sufix { get; set; }

    }

}