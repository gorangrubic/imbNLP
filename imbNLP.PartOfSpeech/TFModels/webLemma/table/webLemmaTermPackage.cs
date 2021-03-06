// --------------------------------------------------------------------------------------------------------------------
// <copyright file="webLemmaTermPackage.cs" company="imbVeles" >
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
using imbMiningContext.TFModels.core;
using imbSCI.Core.extensions.data;
using imbSCI.Core.extensions.io;
using imbSCI.Core.files;
using imbSCI.Core.files.folders;
using imbSCI.Core.math;
using imbSCI.Core.reporting;
using imbSCI.Data.enums;
using imbSCI.DataComplex.tables;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Threading;

namespace imbNLP.PartOfSpeech.TFModels.webLemma.table
{

    /// <summary>
    /// Package used to store web lemmas just before serialization. Used only as storage
    /// </summary>
    public class webLemmaTermPackage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="webLemmaTermPackage"/> class.
        /// </summary>
        public webLemmaTermPackage()
        {

        }

        public webLemmaTermPackage(String _name, String _description)
        {
            name = _name;
            description = _description;
        }

        public String name { get; set; } = "";

        public String description { get; set; } = "";
        
        /// <summary>
        /// List with stored lemmas
        /// </summary>
        /// <value>
        /// The lemmas.
        /// </value>
        public List<webLemmaTerm> lemmas { get; set; } = new List<webLemmaTerm>();

    }

}