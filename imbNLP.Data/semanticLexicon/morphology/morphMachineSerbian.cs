// --------------------------------------------------------------------------------------------------------------------
// <copyright file="morphMachineSerbian.cs" company="imbVeles" >
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
    using imbNLP.Data.semanticLexicon.posCase;
    using imbNLP.Data.semanticLexicon.procedures;
    using imbNLP.Data.semanticLexicon.source;
    using imbNLP.Data.semanticLexicon.term;
    using imbNLP.PartOfSpeech.flags.basic;
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

    /// <summary>
    /// Enables morphology and term resolution based on Serbian morphology rules
    /// </summary>
    /// <seealso cref="morphMachine" />
    public class morphMachineSerbian : morphMachine
    {
        public morphMachineSerbian(folderNode input) : base(input)
        {
        }

        public override void SetRuleSets()
        {
            Add<morphRuleSetAdjective>("([\\w]+)(st)(a|e|i|o|u)\\b", pos_type.A).SetRules();
            Add<morphRuleSetAdjective>("([\\w]+)((?:š|s)k)(a|e|o|i|e)\\b", pos_type.A).SetRules();
            Add<morphRuleSetNoun>("([\\w]+)((?:e|o)r)(i|u|e|ima)?\\b", pos_type.N).SetRules(pos_gender.m, pos_nounGroup.firstGroup);
            Add<morphRuleSetNoun>("([\\w]+)(ij)(a|e|i|o|u)\\b", pos_type.N).SetRules(pos_gender.f, pos_nounGroup.thirdGroup);
            Add<morphRuleSetNoun>("([\\w]+)(?:(a|e|i|o|u)nj)(a|e|u|em|ima)\\b", pos_type.N).SetRules(pos_gender.n, pos_nounGroup.secondGroup);
            Add<morphRuleSetNoun>("([\\w]+)(st)(a|e|i|o|u)\\b", pos_type.N).SetRules(pos_gender.f, pos_nounGroup.thirdGroup);
        }
    }

}