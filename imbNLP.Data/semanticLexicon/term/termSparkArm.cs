// --------------------------------------------------------------------------------------------------------------------
// <copyright file="termSparkArm.cs" company="imbVeles" >
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
namespace imbNLP.Data.semanticLexicon.term
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
    using imbNLP.Data.semanticLexicon.procedures;
    using imbNLP.Data.semanticLexicon.source;
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
    using imbSCI.DataComplex;

    /// <summary>
    /// One instance of the termSpark
    /// </summary>
    /// <seealso cref="imbSCI.DataComplex.IWeightTableTerm" />
    public class termSparkArm : IWeightTableTerm
    {
        public void Define(string __name, string __nominalform)
        {
            name = __name;
            //nominalForm = __nominalform;
        }

        /// <summary>
        /// 
        /// </summary>
        public ILexiconItem lexItem { get; set; }

        protected IConcept lexConcept
        {
            get
            {
                return (IConcept)lexItem;
            }
        }

        protected ITermLemma lexLemma
        {
            get
            {
                return (ITermLemma)lexItem;
            }
        }

        protected ITermInstance lexInstance
        {
            get
            {
                return (ITermInstance)lexItem;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public double weight { get; set; }

        public int Count
        {
            get
            {
                return 1;
            }
        }


        private string _name;
        /// <summary>
        /// 
        /// </summary>
        public string name
        {
            get {
                if (lexItem != null) return lexItem.name;
                return _name; }
            set { _name = value; }
        }


        /// <summary>
        /// Frequency points that should be added to the term
        /// </summary>
        /// <value>
        /// a freq points.
        /// </value>
        public int AFreqPoints { get; set; } = 1;

        public string nominalForm
        {
            get
            {
                return name;
            }
        }

        public termSparkArm(string __name, ILexiconItem __lexItem, double __weight)
        {
            lexItem = __lexItem;
            name = __name;
            weight = __weight;
        }

        public termSparkArm(string __name)
        {
            weight = 1;
            name = __name;
            //var itms = semanticLexiconManager.manager.getLexiconItems(__name);
            //if (itms.Count() > 0)
            //{
            //    lexItem = itms.First();
            //}
        }
        public termSparkArm()
        {

        }

        public List<string> GetAllForms(bool includingNominalForm = true)
        {
            var output = new List<string>();
            if (includingNominalForm) output.Add(nominalForm);
            
            return output;
        }

        public void SetOtherForms(IEnumerable<string> instances)
        {
            // do not support instances
        }

        public bool isMatch(IWeightTableTerm other)
        {

            if (other is termSparkArm)
            {
                termSparkArm other_termSparkArm = (termSparkArm)other;
                if (other_termSparkArm.name.ToLower() == name.ToLower())
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }


            if (other is termSpark)
            {
                termSpark other_termSpark = (termSpark)other;
                if (other_termSpark.isMatch(this))
                {
                    return true;
                } else
                {
                    return false;
                }

            }


            if (other is weightTableGenericTerm)
            {
                weightTableGenericTerm other_weightTableGenericTerm = (weightTableGenericTerm)other;
                if (other_weightTableGenericTerm.name.ToLower() == name.ToLower())
                {
                    return true;
                } else
                {
                    return false;
                }

            }

            return (other.name.ToLower() == name.ToLower());


        }
    }

}