// --------------------------------------------------------------------------------------------------------------------
// <copyright file="contentTokenFlag.cs" company="imbVeles" >
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

namespace imbNLP.Data.enums.flags
{
    using System;

    #region imbVELES USING

    #endregion

    /// <summary>
    /// Flagovi - contentTokenFlag
    /// </summary>
    [Flags]
    public enum contentTokenFlag
    {
        none = 0,

        empty = 1,

        languageWord = 2,

        languageKnownWord = languageWord | known,

        languageUnknownWord = languageWord | unknown,

        /// <summary>
        /// Exists in knowledge base
        /// </summary>
        known = 4,
        /// <summary>
        /// Possible oposite interpretation
        /// </summary>
        unknown = 8,
        /// <summary>
        /// Positive claim: wasn-t known but now it is
        /// </summary>
        discovered = 16,

        acronim = 32,

        acronimKnown = acronim | known,

        acronimDiscovered = acronim | discovered,

        namedEntity = 64,

        namedEntityKnown = namedEntity | known,

        namedEntityDiscovered = namedEntity | discovered,


        namedEntityAsAcronim = namedEntity | acronim,

        languageId = namedEntity | language,

        countryId = namedEntity | country,


        singleWord = 128,

        navigation = 256,

        regular = 512,
        irregular = 1024,


        /// <summary>
        /// predstavlja deo naziva linka ili nekod entiteta - iz vise reci
        /// </summary>
        title = 2048,

        /// <summary>
        /// naziv linka ili nekog entiteta - iz jedne reci
        /// </summary>
        titleOneWord = title | singleWord,

        /// <summary>
        /// deo natpisa na linku
        /// </summary>

        titleNavigation = title | navigation,

        caseLower = 4096,

        caseAllUpper = 8192,

        caseFirstUpper = caseLower | regular,



        caseIrregular = caseLower | irregular,


        /// <summary>
        /// token se nalazi u enumeration pod recenicui
        /// </summary>
        listed = 16384,


        

        country = 32768,

        personal = 65536,

        lastname = 131072,

        

        personalNameOrLastname = namedEntity | personal,

        personalNameKnown = personalNameOrLastname | known,
        personalLastnameKnown = personalNameOrLastname | lastname | known,

        city = 262144,

        cityName = city | namedEntity,

        cityNameKnown = city | namedEntityKnown,

        /// <summary>
        /// tokeni sa brojem koji je formatiran tipa: +381  ili 25-45
        /// </summary>
        number = 524288,

        formatted = 1048576,
        
        measure = 2097152
,

        unit = 4194304,
            
        ordinal = 8388608,

        year = 16777216 | numberOrdinal,

        numberOrdinal = number | ordinal,


        numberFormatted = number | formatted,

        numberWithUnit = number | unit,


        numberWord = number | languageKnownWord,


        measureUnit = measure | unit,

        measureUnitKnown = measureUnit | known,

        
        yearNumber = number | year,


        zipCodeNumber = city | numberFormatted,


        zipCodeNumberKnown = zipCodeNumber | known | info,

        zipCodeNumberWithCityName = zipCodeNumberKnown | cityNameKnown,

        /// <summary>
        /// The information: in sense of directly applicable information
        /// </summary>
        info = 33554432,

        email = 33554432 | info | formatted,

        phone = info | numberFormatted,

        language = 67108864,

        company = 134217728 | info,

        address = 268435456 |info,

        officePhone = company | phone,

        officeEmail = company | email,

        officeAddress = address | company,
       
        quoted = 536870912,

        subsentence = 1073741824,

        // enbraced,

        subsentence_enumeration = subsentence | listed | info,

        subsentence_information = subsentence | info,

        subsentence_title = subsentence | title,

        subsentence_quoted = subsentence | quoted,
               
        /// <summary>
        /// DIN, ISO itd
        /// </summary>
        internationalStandard = acronim | formatted | number | languageUnknownWord,

        internationalStandardKnown = acronim | formatted | number | languageUnknownWord | known,
        personalTitle = personal | title | info,
        category = 1610612737,
        companyCategory = company | category,
        companyName = company | title,

    }
}