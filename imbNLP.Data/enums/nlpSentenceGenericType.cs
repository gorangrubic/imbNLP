﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="nlpSentenceGenericType.cs" company="imbVeles" >
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
using imbNLP.Data.semanticLexicon.term;
using imbSCI.Core.extensions.io;
using imbSCI.Core.extensions.text;
using imbSCI.Core.files.folders;
using imbSCI.Core.files.unit;
using imbSCI.Core.reporting;
using imbSCI.Data;
using imbSCI.Data.collection.nested;
using imbSCI.Data.collection.nested;
using imbSCI.Data.data;
using imbSCI.Data.enums.reporting;
using imbSCI.DataComplex.extensions.data.formats;
using imbSCI.DataComplex.extensions.text;
using imbSCI.DataComplex.special;

namespace imbNLP.Data.enums
{
    /// <summary>
    /// Podela recenica prema detektovanom tipu generickim algoritmom
    /// </summary>
    public enum nlpSentenceGenericType
    {
        unknown,

        irregular,

        /// <summary>
        /// pocinje sa velikim slovom i zavrsava se tackom
        /// </summary>
        normal,

        /// <summary>
        /// Normalna recenica sa uzvikom na kraju
        /// </summary>
        normal_exclamation,

        /// <summary>
        /// Upitna rečenica
        /// </summary>
        normal_question,

        /// <summary>
        /// Normalna recenica sa nepoznatim zavrsetkom
        /// </summary>
        normal_unknown,

        /// <summary>
        /// zapocinje listu
        /// </summary>
        list_startSentence,


        /// <summary>
        /// ima tri tacke u produzetku
        /// </summary>
        normal_unfinished,

        /// <summary>
        /// predstavlja element liste
        /// </summary>
        list_item,


        /// <summary>
        /// igra ulogu naslova, sve je velikim slovom - ili je role_simpleText za kojim slede normalne recenice!
        /// </summary>
        role_title,

        /// <summary>
        /// jednostavan tekstualni podatak
        /// </summary>
        role_simpleText,
    }
}