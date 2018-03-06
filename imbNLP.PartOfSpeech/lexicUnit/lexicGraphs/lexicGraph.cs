// --------------------------------------------------------------------------------------------------------------------
// <copyright file="lexicGraph.cs" company="imbVeles" >
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
// Project: imbNLP.PartOfSpeech
// Author: Goran Grubic
// ------------------------------------------------------------------------------------------------------------------
// Project web site: http://blog.veles.rs
// GitHub: http://github.com/gorangrubic
// Mendeley profile: http://www.mendeley.com/profiles/goran-grubi2/
// ORCID ID: http://orcid.org/0000-0003-2673-9471
// Email: hardy@veles.rs
// </summary>
// ------------------------------------------------------------------------------------------------------------------
namespace imbNLP.PartOfSpeech.lexicUnit
{
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
    using imbNLP.PartOfSpeech.flags.basic;
    using imbSCI.Data.collection.graph;
    using imbSCI.Data.interfaces;

    [Serializable]
    public abstract class lexicGraph:graphNodeCustom // :graphWrapNode<lexicUnit>
    {
        /// <summary>
        /// Gets or sets the lexical definition line.
        /// </summary>
        /// <value>
        /// The lexical definition line.
        /// </value>
        public String lexicalDefinitionLine { get; set; } = "";

        protected override bool doAutorenameOnExisting { get { return true; } }

        protected override bool doAutonameFromTypeName { get { return true; } }

        protected lexicGraph()
        {
            pathSeparator = "->";
        }

        public lexicGraphNodeType nodeType { get; set; } = lexicGraphNodeType.none;

       

    }

}