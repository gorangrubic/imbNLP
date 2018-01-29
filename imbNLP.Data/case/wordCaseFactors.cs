// --------------------------------------------------------------------------------------------------------------------
// <copyright file="wordCaseFactors.cs" company="imbVeles" >
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

namespace imbNLP.Data.@case
{
    #region imbVELES USING

    using System;
    using System.ComponentModel;
    using imbNLP.Data.@case.enums;

    #endregion

    public class wordCaseFactors : imbBindable
    {
      
      

        #region -----------  wordNumber  -------  [Gramaticki broj u kome se nalazi rec]

        private number _wordNumber = number.undefined; // = new number();

        /// <summary>
        /// Gramaticki broj u kome se nalazi rec
        /// </summary>
        // [XmlIgnore]
        [Category("wordCase")]
        [DisplayName("wordNumber")]
        [Description("Gramaticki broj u kome se nalazi rec")]
        public number wordNumber
        {
            get { return _wordNumber; }
            set
            {
                _wordNumber = value;
                OnPropertyChanged("wordNumber");
            }
        }

        #endregion

        #region -----------  wordFace  -------  [Gramaticko lice u kome se nalazi rec]

        private face _wordFace = face.undefined; // = new face();

        /// <summary>
        /// Gramaticko lice u kome se nalazi rec
        /// </summary>
        // [XmlIgnore]
        [Category("wordCase")]
        [DisplayName("wordFace")]
        [Description("Gramaticko lice u kome se nalazi rec")]
        public face wordFace
        {
            get { return _wordFace; }
            set
            {
                _wordFace = value;
                OnPropertyChanged("wordFace");
            }
        }

        #endregion

        #region -----------  wordGenre  -------  [Gramaticki rod u kome se nalazi rec]

        private genre _wordGenre = genre.undefined; // = new genre();

        /// <summary>
        /// Gramaticki rod u kome se nalazi rec
        /// </summary>
        // [XmlIgnore]
        [Category("wordCase")]
        [DisplayName("wordGenre")]
        [Description("Gramaticki rod u kome se nalazi rec")]
        public genre wordGenre
        {
            get { return _wordGenre; }
            set
            {
                _wordGenre = value;
                OnPropertyChanged("wordGenre");
            }
        }

        #endregion

        #region -----------  wordForm  -------  [Kog je oblika trenutna rec]

        private wordForms _wordForm = wordForms.undefined; // = new wordForms();

        /// <summary>
        /// Kog je oblika trenutna rec
        /// </summary>
        // [XmlIgnore]
        [Category("wordCase")]
        [DisplayName("wordForm")]
        [Description("Kog je oblika trenutna rec")]
        public wordForms wordForm
        {
            get { return _wordForm; }
            set
            {
                _wordForm = value;
                OnPropertyChanged("wordForm");
            }
        }

        #endregion

        #region -----------  wordGramaticalCase  -------  [Padez u kome se nalazi rec]

        private gramaticalCase _wordGramaticalCase = gramaticalCase.undefined; // = new gramaticalCase();

        /// <summary>
        /// Padez u kome se nalazi rec
        /// </summary>
        // [XmlIgnore]
        [Category("wordCase")]
        [DisplayName("wordGramaticalCase")]
        [Description("Padez u kome se nalazi rec")]
        public gramaticalCase wordGramaticalCase
        {
            get { return _wordGramaticalCase; }
            set
            {
                _wordGramaticalCase = value;
                OnPropertyChanged("wordGramaticalCase");
            }
        }

        #endregion

        #region -----------  root  -------  [Koren reci koji predlaze analiza ]

        private String _root; // = new String();

        /// <summary>
        /// Koren reci koji predlaze analiza 
        /// </summary>
        // [XmlIgnore]
        [Category("wordCase")]
        [DisplayName("root")]
        [Description("Koren reci koji predlaze analiza ")]
        public String root
        {
            get { return _root; }
            set
            {
                _root = value;
                OnPropertyChanged("root");
            }
        }

        #endregion

        #region -----------  infinitiveRoot  -------  [Koren infinitiva]

        private String _infinitiveRoot; // = new String();

        /// <summary>
        /// Koren infinitiva
        /// </summary>
        // [XmlIgnore]
        [Category("wordCase")]
        [DisplayName("infinitiveRoot")]
        [Description("Koren infinitiva")]
        public String infinitiveRoot
        {
            get { return _infinitiveRoot; }
            set
            {
                _infinitiveRoot = value;
                OnPropertyChanged("infinitiveRoot");
            }
        }

        #endregion

        #region -----------  infinitiveSufix  -------  [Infinitivni sufix]

        private String _infinitiveSufix; // = new String();

        /// <summary>
        /// Infinitivni sufix
        /// </summary>
        // [XmlIgnore]
        [Category("wordCase")]
        [DisplayName("infinitiveSufix")]
        [Description("Infinitivni sufix")]
        public String infinitiveSufix
        {
            get { return _infinitiveSufix; }
            set
            {
                _infinitiveSufix = value;
                OnPropertyChanged("infinitiveSufix");
            }
        }

        #endregion

        #region -----------  presentRoot  -------  [Koren u prezentu]

        private String _presentRoot; // = new String();

        /// <summary>
        /// Koren u prezentu
        /// </summary>
        // [XmlIgnore]
        [Category("wordCase")]
        [DisplayName("presentRoot")]
        [Description("Koren u prezentu")]
        public String presentRoot
        {
            get { return _presentRoot; }
            set
            {
                _presentRoot = value;
                OnPropertyChanged("presentRoot");
            }
        }

        #endregion
    }
}