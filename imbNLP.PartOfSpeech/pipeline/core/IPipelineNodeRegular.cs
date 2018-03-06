// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPipelineNodeRegular.cs" company="imbVeles" >
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
using System;
using System.Linq;
using System.Collections.Generic;
using imbNLP.PartOfSpeech.lexicUnit;
using imbNLP.PartOfSpeech.pipeline.machine;
using imbSCI.Core.extensions.data;
using imbSCI.Data.collection.graph;
using System.Collections.Concurrent;
using System.Text;

namespace imbNLP.PartOfSpeech.pipeline.core
{

    /// <summary>
    /// Regular node
    /// </summary>
    /// <seealso cref="imbNLP.PartOfSpeech.pipeline.core.IPipelineNode" />
    public interface IPipelineNodeRegular:IPipelineNode
    {


        /// <summary>
        /// Automatically sets label
        /// </summary>
        void SetLabel();

        /// <summary>
        /// Gets or sets the forward predefined - overrides default <see cref="IPipelineNode.forward"/> behaviour
        /// </summary>
        /// <value>
        /// The forward predefined.
        /// </value>
        IPipelineNode forwardPredefined { get; set; }


        /// <summary>
        /// Gets or sets the next predefined - overrides default <see cref="IPipelineNode.next"/> behaviour
        /// </summary>
        /// <value>
        /// The next predefined.
        /// </value>
        IPipelineNode nextPredefined { get; set; }

    }

}