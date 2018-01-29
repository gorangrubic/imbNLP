// --------------------------------------------------------------------------------------------------------------------
// <copyright file="plainTextTokenizator.cs" company="imbVeles" >
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
namespace imbNLP.Core.contentStructure.tokenizator
{
    #region imbVELES USING

    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Security;
    using System.Xml.Serialization;
    using imbACE.Core.commands.menu;
    using imbACE.Core.core;
    using imbACE.Core.operations;
    using imbACE.Services.console;
    using imbACE.Services.terminal;
    using imbNLP.Core.contentStructure.elements;
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
    using imbNLP.Data.basic;
    using imbCommonModels.structure;
    using imbSCI.Core.extensions.data;
    using imbNLP.Core.contentPreprocess;
    using System.Text;

    //using imbSemanticEngine.nlp.context.structure;

    #endregion

    /// <summary>
    /// 2016:C PRIMARNI TOKENIZATOR
    /// Experimentalni plain text tokenizator
    /// </summary>
    public class plainTextTokenizator : tokenizatorBase
    {
        public plainTextTokenizator(nlpTokenizatorSettings __settings) : base(__settings)
        {
        }


        /// <summary>
        /// Vrsi tokenizaciju String/PlainText sadrzaja.
        /// </summary>
        /// <param name="resources">Preporuceni resursi: String content, basicLanguage language, node page </param>
        /// <returns></returns>
        public IContentPage tokenizeContent(params object[] resources)
        {
            string content = resources.getFirstOfType<string>();
            basicLanguage language = resources.getFirstOfType<basicLanguage>();
            node page = resources.getFirstOfType<node>();


            contentPage output = new contentPage();

           // output.sourceContent = content;

            output.acceptSourcePage(page);
            

            try
            {
                string source = content;

                // preprocess
                source = compressNewLines(source);
                output.sourceContent = source;
              //  source = imbFilterModuleEngine.executeSimple(settings.contentFilter, source);

                output.content = source;


                string[] blocks = source.Split(new string[] {Environment.NewLine + Environment.NewLine},
                                               StringSplitOptions.RemoveEmptyEntries);

                if (blocks.Count() == 0)
                {
                    blocks[0] = source;
                }
                List<contentParagraph> pars = null;
                foreach (string bl in blocks)
                {
                    string blc = bl.StripHTML();

                   // blc = imbStringReporting.imbHtmlDecode(blc);
                   
                    blc = SecurityElement.Escape(blc);

                    contentBlock tmpBlock = new contentBlock();
                    tmpBlock.sourceContent = blc;

                    tmpBlock.content = blc;
                    output.items.Add(tmpBlock);
                }

                foreach (IContentBlock bl in output.items)
                {
                    // getting paragraphs
                    string[] paragraphs = bl.sourceContent.Split(new string[] {Environment.NewLine},
                                                                 StringSplitOptions.RemoveEmptyEntries);
                    foreach (string par in paragraphs)
                    {
                        if (string.IsNullOrEmpty(par)) continue;

                        contentParagraph po = new contentParagraph(par, output);

                        po.setParagraphFromContent<contentSentence, contentSubSentence, contentToken>(output, paragraphDetectionFlag.dropSentenceWithNoToken,
                                                                                              sentenceDetectionFlag.
                                                                                                  setSentenceToParagraph,
                                                                                              sentenceDetectionFlag.
                                                                                                  preprocessParagraphContent,
                                                                                              tokenDetectionFlag.standardDetection,
                                                                                              contentPreprocessFlag.standard);

                        if (po.items.Any())
                        {
                            output.paragraphs.Add(po);

                            foreach (IContentSentence sn in po.items)
                            {
                                output.sentences.Add(sn);
                                foreach (IContentToken tk in sn.items)
                                {
                                    output.tokens.Add(tk);
                                }
                            }
                            //output.tokens.AddRange();
                            bl.setItem(po);
                        }
                    }
                }



                output.primaryFlaging(resources);

                output.secondaryFlaging(resources);

                output.generalSemanticsFlaging(resources);

                output.specialSematicsFlaging(resources);



                //tokenCategorization.tokenAnalysis(output, settings, language);

                //if (settings.doTokenTypeDetection_basic)
                //{
                //    
                //}

                //if (settings.doSentenceDetection)
                //{
                //    blokCategorization.sentenceAnalysis(output, settings, language);
                //}
            }
            catch (Exception ex)
            {
                var isb = new StringBuilder();
                isb.AppendLine("plainTextTokenizator error");
                isb.AppendLine("Language: "+ language.toStringSafe());
               // devNoteManager.note(this, ex, isb.ToString(), "plainTextTokenizator", devNoteType.tokenization);
            }

            return output;
        }
    }
}