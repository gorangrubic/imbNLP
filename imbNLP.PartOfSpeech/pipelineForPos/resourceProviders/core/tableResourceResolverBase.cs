// --------------------------------------------------------------------------------------------------------------------
// <copyright file="tableResourceResolverBase.cs" company="imbVeles" >
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
namespace imbNLP.PartOfSpeech.resourceProviders.core
{
    using System.ComponentModel;
    using System.IO;
    using System.Text.RegularExpressions;
    using System.Xml.Serialization;
    using imbNLP.PartOfSpeech.flags.basic;
    using imbSCI.Core.files.search;
    using imbSCI.Core.reporting;
    using imbSCI.Data;
    using imbSCI.Data.data;
    using imbSCI.Data.enums.reporting;
    using imbNLP.PartOfSpeech.lexicUnit;
    using imbSCI.Core.extensions.text;
    using imbSCI.Core.extensions.data;
    using System.Threading.Tasks;
    using System.Data;
    using imbACE.Core;
    
    using imbSCI.DataComplex.extensions.data.formats;
    using imbSCI.Data.enums.tableReporting;

    public abstract class tableResourceResolverBase
    {
        
        protected DataTable sourceTable { get; set; }

        protected String path { get; set; }

        protected void loadTable(ILogBuilder output = null)
        {
            String tableFilePath = appManager.Application.folder_resources.findFile(path, SearchOption.AllDirectories);
            if (!tableFilePath.isNullOrEmpty())
            {

                if (tableFilePath.EndsWith(".xlsx"))
                {
                    sourceTable = tableFilePath.deserializeDataTable(dataTableExportEnum.excel, null, null, dataTableIOFlags.firstRowColumnNames);

                } else if (tableFilePath.EndsWith(".csv"))
                {
                    sourceTable = tableFilePath.deserializeDataTable(dataTableExportEnum.csv, null, null, dataTableIOFlags.firstRowColumnNames);
                }

            }
        }

        
       

        

        public tableResourceResolverBase(String tableResourceFilePath, ILogBuilder output=null)
        {
            path = tableResourceFilePath;

            loadTable(output);
        }

    }

}