// --------------------------------------------------------------------------------------------------------------------
// <copyright file="pipelineTaskMCRepoSubject.cs" company="imbVeles" >
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
using imbMiningContext.MCRepository;
using imbNLP.PartOfSpeech.flags.token;
using imbNLP.PartOfSpeech.lexicUnit;
using imbNLP.PartOfSpeech.pipeline.core;
using imbSCI.Core.files.fileDataStructure;
using imbSCI.Data.collection.graph;
using System.Text;
using imbMiningContext.MCWebSite;

namespace imbNLP.PartOfSpeech.pipelineForPos.subject
{
    public class pipelineTaskMCRepoSubject : pipelineTaskSubjectContentToken
    {
        public pipelineTaskMCRepoSubject()
        {
            contentLevelType = cnt_level.mcRepo;
        }

        public String MCRepoName { get; set; } = "";

        public List<String> MCSiteTargets { get; set; } = new List<string>();

        public imbMCRepository MCRepo { get; set; }


        public List<String> WebSiteSample { get; set; } = new List<string>();

    }

}