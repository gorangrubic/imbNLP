// --------------------------------------------------------------------------------------------------------------------
// <copyright file="chunkConstructorTF.cs" company="imbVeles" >
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
// // using imbMiningContext.TFModels.WLF_ISF;
using imbNLP.PartOfSpeech.TFModels.webLemma.core;
using System.Text;
using imbSCI.Core.data;
using imbSCI.Core.collection;
using imbSCI.Data.collection;
using imbSCI.Data.data;
using imbSCI.DataComplex.tables;
using imbSCI.DataComplex.data;
using imbSCI.DataComplex;
using System.Data;
using imbSCI.DataComplex.extensions.data.modify;
using imbSCI.DataComplex.extensions.data.schema;
using imbSCI.Core.enums;
using imbNLP.PartOfSpeech.resourceProviders.core;
using imbSCI.DataComplex.tf_idf;
using imbSCI.Core.reporting;
using imbSCI.Core.extensions.data;
using imbMiningContext.MCDocumentStructure;
using imbNLP.PartOfSpeech.pipelineForPos.subject;
using imbNLP.PartOfSpeech.flags.token;
using imbSCI.Core.math;
using imbNLP.PartOfSpeech.lexicUnit;
using imbNLP.PartOfSpeech.pipeline.machine;
using imbSCI.Data;
using imbNLP.PartOfSpeech.pipelineForPos.render;
using System.ComponentModel;
using imbNLP.PartOfSpeech.TFModels.webLemma.table;

namespace imbNLP.PartOfSpeech.TFModels.webLemma
{

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="imbNLP.PartOfSpeech.TFModels.webLemma.core.IWLFConstructor" />
    public class chunkConstructorTF:ConstructorTFIDFBase, IWLFConstructor
    {
        /// <summary>
        /// Creates multi-line description of current configuration
        /// </summary>
        /// <returns>List of description lines</returns>
        public override List<string> DescribeSelf()
        {
            List<String> output = new List<string>();

            output.Add("## Chunk TF-IDF constructor");

            output.Add(" > Constructs TF-IDF table for extracted POS chunks, in order to calculate weights and other statistics." );

            output.AddRange(settings.DescribeSelf());


            return output;
        }

        public chunkConstructorTF()
        {

        }

        public wlfConstructorSettings settings { get; set; } = new wlfConstructorSettings();







        private Object tknsLock = new Object();




        /// <summary>
        /// Processes the specified source.
        /// </summary>
        /// <param name="chunks">The source.</param>
        /// <param name="document_level">The document level.</param>
        /// <param name="table">The table.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="forSingleWebSite">if set to <c>true</c> [for single web site].</param>
        /// <returns></returns>
        public webLemmaTermTable process(IEnumerable<IPipelineTaskSubject> chunks, cnt_level document_level, webLemmaTermTable table,ITextResourceResolver parser = null, ILogBuilder logger = null, Boolean forSingleWebSite = false)
        {

           // List<pipelineTaskMCPageSubject> MCPageSubjects = new List<pipelineTaskMCPageSubject>();

            TFDFCounter counter = new TFDFCounter();


            foreach (pipelineTaskSubjectContentToken mcSubject in chunks)
            {
                //var page = mcSubject.GetParentOfType<pipelineTaskMCPageSubject>();

                //if (!MCPageSubjects.Contains(page))
                //{
                //    MCPageSubjects.Add(page);
                //    counter.NextDocument();
                //}
                
                if (mcSubject.contentLevelType == cnt_level.mcChunk)
                {
                    counter.Add(mcSubject.currentForm, mcSubject);
                }
            }
               
                
            return process(counter, logger, table, forSingleWebSite);
        }

        /// <summary>
        /// Constructs the webLemmaTable
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="parser">The parser.</param>
        /// <param name="counter">The counter.</param>
        /// <param name="logger">The logger.</param>
        /// <returns></returns>
        public webLemmaTermTable process(TFDFCounter counter, ILogBuilder logger, webLemmaTermTable table, Boolean forSingleWebSite=false)
        {
            List<String> tfdfList = counter.GetIndexForms();
            Int32 i = 0;
            Int32 c = 0;
            Int32 li = 0;
            Int32 limit = tfdfList.Count() + 100;

          
            List<webLemmaTerm> lemmas = new List<webLemmaTerm>();
            Int32 startIndex = tfdfList.Count();
            Int32 cycleLength = startIndex / 5;

            foreach (String term in tfdfList)
            {
                if (term != null)
                {

                    List<imbMCDocumentElement> documentSet = new List<imbMCDocumentElement>();
                    List<imbMCDocumentElement> documents = new List<imbMCDocumentElement>();

                    Double documentFrequency = 0;
                    Double termFrequency = 0;

                    TFDFContainer cn = counter.GetContainer(term);


                    webLemmaTerm lemma = new webLemmaTerm();
                    lemma.nominalForm = cn.indexForm;
                    lemma.name = cn.indexForm;

                    if (cn != null)
                    {
                        foreach (pipelineTaskSubjectContentToken cntPair in cn.items)
                        {
                            imbMCDocument document = cntPair.mcElement.GetParentOfType<imbMCDocument>();
                            documents.AddUnique(document);


                            imbMCDocumentSet docSet = document.parent as imbMCDocumentSet;
                            if (docSet != null)
                            {
                                documentSet.AddUnique(docSet);
                            }

                            if (cntPair.flagBag.Contains(cnt_containerType.link))
                            {
                                termFrequency += settings.anchorTextFactor;
                            }
                            else if (cntPair.flagBag.Contains(cnt_containerType.title))
                            {
                                termFrequency += settings.titleTextFactor;
                            }
                            else
                            {
                                termFrequency += settings.contentTextFactor;
                            }

                            lemma.otherForms.AddUnique(cntPair.initialForm);
                        }

                        lemma.otherForms.AddUnique(cn.indexForm);
                    }
                    else
                    {
                        //lemma.otherForms.AddUnique(cn.items);
                    }

                    lemma.documentSetFrequency = documentSet.Count;
                    lemma.AFreqPoints = cn.items.Count();
                    lemma.documentFrequency = documents.Count;
                    lemma.termFrequency = termFrequency;
                    lemmas.Add(lemma);
                    



                    li++;
                    i = i + 1;
                    c = c + 1;


                    if (c > cycleLength)
                    {
                        c = 0;
                        logger.AppendLine();
                        logger.log("Chunk TF processing: _" + i.GetRatio(startIndex).ToString("P2") + "_ ");
                        logger.AppendLine();

                    }

                    if (li > limit)
                    {

                        logger.log("Limit broken at processing Chunk Lemma Frequency table at [" + li.ToString() + "]");
                        break;
                    }
                }

            }


           // table.WriteOnlyMode = false;
           

            recompute(table, logger, forSingleWebSite, lemmas);


           // table.ReadOnlyMode = true;


            return table;
        }
    }

}