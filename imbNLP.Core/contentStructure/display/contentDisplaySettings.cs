// --------------------------------------------------------------------------------------------------------------------
// <copyright file="contentDisplaySettings.cs" company="imbVeles" >
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
namespace imbNLP.Core.contentStructure.display
{
    #region imbVELES USING

    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Xml.Serialization;
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
    using imbSCI.Data.data;
    using imbSCI.Data.enums.reporting;
    using imbSCI.DataComplex.extensions.data.formats;
    using imbSCI.DataComplex.extensions.text;
    using imbSCI.DataComplex.special;
    using imbNLP.Data.enums;

    //using imbSemanticEngine.imbNLP.context.semanticEditor;

    #endregion

    /// <summary>
    /// Podesavanja prikaza 
    /// </summary>
    public class contentDisplaySettings : imbBindable
    {
        #region -----------  colorMode  -------  [rezim prikaza boja]

        private contentEditorColorMode _colorMode = contentEditorColorMode.tosTypesAndSemanticFlags; // = new String();

        /// <summary>
        /// rezim prikaza boja
        /// </summary>
        // [XmlIgnore]
        [XmlIgnore]
        [Category("Editor")]
        [DisplayName("colorMode")]
        [Description("rezim prikaza boja")]
        public contentEditorColorMode colorMode
        {
            get { return _colorMode; }
            set
            {
                _colorMode = value;
                OnPropertyChanged("colorMode");
            }
        }

        #endregion

        #region -----------  showTosMark  -------  [Da li da prikaže TOS oznaku]

        private bool _showTosMark; // = new Boolean();

        /// <summary>
        /// Da li da prikaže TOS oznaku
        /// </summary>
        // [XmlIgnore]
        [XmlIgnore]
        [Category("Editor")]
        [DisplayName("showTosMark")]
        [Description("Da li da prikaže TOS oznaku")]
        public bool showTosMark
        {
            get { return _showTosMark; }
            set
            {
                _showTosMark = value;
                OnPropertyChanged("showTosMark");
            }
        }

        #endregion

        #region -----------  showContent  -------  [da li da prikaže content]

        private bool _showContent = true; // = new Boolean();

        /// <summary>
        /// da li da prikaže content
        /// </summary>
        // [XmlIgnore]
        [XmlIgnore]
        [Category("Editor")]
        [DisplayName("showContent")]
        [Description("da li da prikaže content")]
        public bool showContent
        {
            get { return _showContent; }
            set
            {
                _showContent = value;
                OnPropertyChanged("showContent");
            }
        }

        #endregion

        #region -----------  showGenericTypeMark  -------  [Da li da prikaže generic type mark]

        private bool _showGenericTypeMark; // = new Boolean();

        /// <summary>
        /// Da li da prikaže generic type mark
        /// </summary>
        // [XmlIgnore]
        [XmlIgnore]
        [Category("Editor")]
        [DisplayName("showGenericTypeMark")]
        [Description("Da li da prikaže generic type mark")]
        public bool showGenericTypeMark
        {
            get { return _showGenericTypeMark; }
            set
            {
                _showGenericTypeMark = value;
                OnPropertyChanged("showGenericTypeMark");
            }
        }

        #endregion
    }
}