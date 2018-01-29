// --------------------------------------------------------------------------------------------------------------------
// <copyright file="htmlLinkNode.cs" company="imbVeles" >
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
namespace imbNLP.Core.contentStructureHtml.elements
{
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
	using imbSCI.Core.extensions.data;
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
    using imbNLP.Data.enums.flags;

    /// <summary>
    /// 
    /// </summary>
    public class htmlLinkNode 
	{
		/// <summary>
		/// 
		/// </summary>
		public bool isInnerLink { get; set; }


		/// <summary>
		/// 
		/// </summary>
		public bool isPrimary { get; set; }


		/// <summary>
		/// 
		/// </summary>
		public int score { get; set; } = 0;


		/// <summary>
		/// 
		/// </summary>
		public string xpath { get; set; }


		/// <summary>
		/// 
		/// </summary>
		public htmlTokenList scoped { get; set; }


		/// <summary>
		/// 
		/// </summary>
		public string url { get; set; }


		public htmlLinkNode(IHtmlContentElement __linkRoot)
		{
			linkRootParent = __linkRoot;
			evaluate();
		}


		protected void evaluate()
		{

			xpath = linkRootParent.htmlNode.XPath;

			url = linkRootParent.htmlNode.GetAttributeValue("href", "");
			if (!url.Contains("://")) isInnerLink = false;
			

			score = 0;

			scoped = new htmlTokenList();

			scoped.Add(linkRootParent);


			scoped.AddMulti(linkRootParent.getChildern(null, 5));

			//foreach (IHtmlContentElement chld in linkRootParent.items)
			//{
			//    target.Add(chld);
			//}

			isPrimary = false;
			isInnerLink = false;

			int known = 0;
			int notknown = 0;
			int other = 0;
			foreach (var trg in scoped)
			{

				if (trg is htmlContentParagraph)
				{
					htmlContentParagraph trg_htmlContentParagraph = (htmlContentParagraph)trg;
					if (trg_htmlContentParagraph.flags.HasFlag(contentParagraphFlag.navigation)) score++;
					if (trg_htmlContentParagraph.flags.HasFlag(contentParagraphFlag.heading)) score++;
				}


				if (trg is htmlContentSentence)
				{
					htmlContentSentence trg_htmlContentSentence = (htmlContentSentence)trg;
					if (trg_htmlContentSentence.sentenceFlags.HasFlag(contentSentenceFlag.titleForLink)) score++;

				}


				if (trg is htmlContentToken)
				{
					htmlContentToken trg_htmlContentToken = (htmlContentToken)trg;
					if (trg_htmlContentToken.flags.HasFlag(contentTokenFlag.languageKnownWord))
					{
						known++;
					}
					else if (trg_htmlContentToken.flags.HasFlag(contentTokenFlag.languageUnknownWord))
					{
						notknown++;
					} else
					{
						other++;
					}
				}
	
			}

			if ((known > 0) && (notknown ==0))
			{
				isPrimary = true;
				score = score + 5;
			} else if ((known > 0) && (notknown > 0))
			{
				isPrimary = true;
				score = score + 1;
			} else
			{
				isPrimary = false;
			}

			


			
		
		}

		/// <summary>
		/// 
		/// </summary>
		public IHtmlContentElement linkRootParent { get; set; }
	}
}
