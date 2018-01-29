// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TermLemma.cs" company="imbVeles" >
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
using imbSCI.Core.extensions.data;
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

namespace imbNLP.Data.semanticLexicon
{
    using System;

    public partial class TermLemma : BrightstarEntityObject, ITermLemma 
    {
        public TermLemma(BrightstarEntityContext context, BrightstarDB.Client.IDataObject dataObject) : base(context, dataObject) { }
        public TermLemma(BrightstarEntityContext context) : base(context, typeof(TermLemma)) { }
        public TermLemma() : base() { }
        public string Id { get {return GetKey(); } set { SetKey(value); } }
        #region Implementation of imbLanguageFramework.semanticLexicon.core.ITermLemma
    
        public string name
        {
            get { return GetRelatedProperty<string>("name"); }
            set { SetRelatedProperty("name", value); }
        }
        public ICollection<ITermInstance> instances
        {
            get { return GetRelatedObjects<ITermInstance>("instances"); }
            set { if (value == null) throw new ArgumentNullException("value"); SetRelatedObjects("instances", value); }
        }
        public ICollection<ITermLemma> compounds
        {
            get { return GetRelatedObjects<ITermLemma>("compounds"); }
            set { if (value == null) throw new ArgumentNullException("value"); SetRelatedObjects("compounds", value); }
        }
        public ICollection<ITermLemma> relatedTo
        {
            get { return GetRelatedObjects<ITermLemma>("relatedTo"); }
            set { if (value == null) throw new ArgumentNullException("value"); SetRelatedObjects("relatedTo", value); }
        }
        public ICollection<ITermLemma> relatedFrom
        {
            get { return GetRelatedObjects<ITermLemma>("relatedFrom"); }
            set { if (value == null) throw new ArgumentNullException("value"); SetRelatedObjects("relatedFrom", value); }
        }
        public ICollection<IConcept> concepts
        {
            get { return GetRelatedObjects<IConcept>("concepts"); }
            set { if (value == null) throw new ArgumentNullException("value"); SetRelatedObjects("concepts", value); }
        }
    
        public string type
        {
            get { return GetRelatedProperty<string>("type"); }
            set { SetRelatedProperty("type", value); }
        }
    
        public string gramSet
        {
            get { return GetRelatedProperty<string>("gramSet"); }
            set { SetRelatedProperty("gramSet", value); }
        }
        #endregion
    }
}