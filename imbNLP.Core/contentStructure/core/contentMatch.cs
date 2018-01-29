// --------------------------------------------------------------------------------------------------------------------
// <copyright file="contentMatch.cs" company="imbVeles" >
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
// Project: imbNLP.Core
// Author: Goran Grubic
// ------------------------------------------------------------------------------------------------------------------
// Project web site: http://blog.veles.rs
// GitHub: http://github.com/gorangrubic
// Mendeley profile: http://www.mendeley.com/profiles/goran-grubi2/
// ORCID ID: http://orcid.org/0000-0003-2673-9471
// Email: hardy@veles.rs
// </summary>
// ------------------------------------------------------------------------------------------------------------------
namespace imbNLP.Core.contentStructure.core
{
    #region imbVELES USING

    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Xml.Serialization;
    using imbACE.Core.commands.menu;
    using imbACE.Core.core;
    using imbACE.Core.operations;
    using imbACE.Services.console;
    using imbACE.Services.terminal;
    using imbNLP.Core.contentStructure.interafaces;
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
    using imbSCI.Data.data;
    using imbSCI.Data.enums.reporting;
    using imbSCI.DataComplex.extensions.data.formats;
    using imbSCI.DataComplex.extensions.text;
    using imbSCI.DataComplex.special;

    #endregion

    
    /// <summary>
    /// Interni REGEX MATCH 
    /// </summary>
    public class contentMatch : imbBindable
    {
        #region --- name ------- jedinstveno ime 

        private string _name;

        /// <summary>
        /// jedinstveno ime 
        /// </summary>
        public string name
        {
            get
            {
                if (string.IsNullOrEmpty(_name))
                {
                    if (match != null)
                    {
                        _name = match.Index + "_" + match.Length + "_" + associatedKey.toStringSafe("nokey") + "_" +
                                match.Value;
                    }
                }
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged("name");
            }
        }

        #endregion

        public contentMatch(Enum _key, Match _match)
        {
            associatedKey = _key;
            match = _match;
        }

        #region --- associatedKey ------- kljuc koji je dodeljen

        private Enum _associatedKey;

        /// <summary>
        /// kljuc koji je dodeljen
        /// </summary>
        public Enum associatedKey
        {
            get { return _associatedKey; }
            set
            {
                _associatedKey = value;
                OnPropertyChanged("associatedKey");
            }
        }

        #endregion

        #region --- match ------- Bindable property

        private Match _match;

        /// <summary>
        /// Bindable property
        /// </summary>
        public Match match
        {
            get { return _match; }
            set
            {
                _match = value;
                OnPropertyChanged("match");
            }
        }

        #endregion

        #region --- element ------- instanca content elementa koji je rezultat ovog matcha

        private IContentElement _element;

        /// <summary>
        /// instanca content elementa koji je rezultat ovog matcha
        /// </summary>
        public IContentElement element
        {
            get { return _element; }
            set
            {
                _element = value;
                OnPropertyChanged("element");
            }
        }

        #endregion
    }
}