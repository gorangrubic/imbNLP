// --------------------------------------------------------------------------------------------------------------------
// <copyright file="languageManagerAlphabet.cs" company="imbVeles" >
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
namespace imbNLP.Data.basic
{
    using imbNLP.Data.extended.dict.core;
    using System;
    using System.IO;
    using System.Text.RegularExpressions;

    public class languageManagerAlphabet : tokenQueryResolverBase
    {
        /// <summary> </summary>
        public FileInfo resource { get; protected set; }

        private static languageManagerAlphabet _manager;
        /// <summary>
        /// static and autoinitiated object
        /// </summary>
        public static languageManagerAlphabet manager
        {
            get
            {
                if (_manager == null)
                {
                    _manager = new languageManagerAlphabet();
                }
                return _manager;
            }
        }

        public override bool isReady
        {
            get
            {
                return (resource != null);
            }
        }


        /// <summary> </summary>
        public Regex regexSelectLetters { get; protected set; } = new Regex("([\\w]+)");


        public override tokenQueryResponse exploreToken(tokenQuery query)
        {
            tokenQueryResponse response = new tokenQueryResponse(query, tokenQuerySourceEnum.ext_dict);

            new NotImplementedException();
            //if (imbLanguageFrameworkManager.serbian.CheckAgainstAlfabet(query.token))
            //{
            //    response.setResponse(tokenQueryResultEnum.accept);
            //} else
            //{
            //    response.setResponse(tokenQueryResultEnum.dismiss);
                
            //}
           // query.responses[tokenQuerySourceEnum.imb_alfabetTest].Add(response);
            return response;
        }

        public override void prepare()
        {
           // imbLanguageFrameworkManager.log.log("Alphabet test manager ready.");
        }
    }
}