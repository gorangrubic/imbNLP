// --------------------------------------------------------------------------------------------------------------------
// <copyright file="lemmaSemanticCloud.cs" company="imbVeles" >
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
using imbNLP.PartOfSpeech.map;
// using imbNLP.PartOfSpeech.TFModels.semanticCloud.core;
using imbSCI.Core.extensions.data;
using imbSCI.Data;
using imbSCI.Data.collection.nested;
using imbSCI.Core.files;
using imbSCI.Core.files.folders;
using imbSCI.DataComplex.special;
using System.Text;
using imbSCI.Core.math;
using System.Xml.Serialization;
using imbACE.Network.extensions;
using System.IO;
using imbSCI.Core.reporting;
using imbNLP.PartOfSpeech.pipelineForPos.subject;
using imbSCI.Graph.Converters;
using imbNLP.PartOfSpeech.TFModels.webLemma.table;
using imbSCI.Graph.FreeGraph;

namespace imbNLP.PartOfSpeech.TFModels.semanticCloud
{
    [Flags]
    public enum lemmaExpansionOptions
    {
        none=0,
        weightAsSemanticDistanceFromParent=1,
        initialWeightToOne = 2,
        initialWeightFromParent = 4,

        divideWeightByNumberOfSynonims = 8,
        weightAsSemanticDistanceThatIsSumOfLinkWeights = 16
    }


    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="imbNLP.PartOfSpeech.TFModels.semanticCloud.core.freeGraph" />
    public class lemmaSemanticCloud:freeGraph
    {


        public static freeGraphToDMGL GetDGMLConverter()
        {
            freeGraphToDMGL converterToDMGL = new freeGraphToDMGL(new imbSCI.Graph.Converters.tools.GraphStylerSettings());
            converterToDMGL.Categories.Add(new imbSCI.Graph.DGML.core.Category(0, "Reserve Term", ""));
            converterToDMGL.Categories.Add(new imbSCI.Graph.DGML.core.Category(1, "Secondary Term", ""));
            converterToDMGL.Categories.Add(new imbSCI.Graph.DGML.core.Category(2, "Primary Term", ""));

            return converterToDMGL;
        }

        



        /// <summary>
        /// Initializes a new instance of the <see cref="lemmaSemanticCloud"/> class.
        /// </summary>
        public lemmaSemanticCloud()
        {

        }


        public List<String> primaryChunks { get; set; } = new List<String>();
        
        public List<String> secondaryChunks { get; set; } = new List<String>();


        /// <summary>
        /// Name of assigned documentSetClass
        /// </summary>
        /// <value>
        /// The name of the class.
        /// </value>
        public String className { get; set; } = "";

        /// <summary>
        /// Gets the web lemma.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <param name="node">The node.</param>
        /// <param name="options">The options.</param>
        /// <returns></returns>
        public static webLemmaTerm GetWebLemma(webLemmaTerm parent, freeGraphNodeBase node, lemmaExpansionOptions options)
        {
            webLemmaTerm term = new webLemmaTerm();
            term.name = node.name;
            term.nominalForm = node.name;
            term.weight = node.weight;

            if (options.HasFlag(lemmaExpansionOptions.initialWeightToOne))
            {
                term.weight = 1;
            }

            if (options.HasFlag(lemmaExpansionOptions.initialWeightFromParent))
            {
                term.weight = parent.weight;
            }

            if (options.HasFlag(lemmaExpansionOptions.weightAsSemanticDistanceFromParent))
            {
                Double distanceFactor = node.distance.GetRatio(1);
                term.weight = term.weight * distanceFactor;
            }

            return term;
        }

        /// <summary>
        /// Gets the web lemma dictionary.
        /// </summary>
        /// <param name="nodes">The nodes.</param>
        /// <returns></returns>
        public static Dictionary<String, webLemmaTerm> GetWebLemmaDictionary(IEnumerable<freeGraphNodeBase> nodes)
        {
            Dictionary<String, webLemmaTerm> outputDictionary = new Dictionary<string, webLemmaTerm>();

            foreach (var node in nodes)
            {
                outputDictionary.Add(node.name, GetWebLemma(node));
            }
            return outputDictionary;
        }

        /// <summary>
        /// Converts the graph node into <see cref="webLemmaTerm"/> instance
        /// </summary>
        /// <param name="node">The node.</param>
        /// <returns></returns>
        public static webLemmaTerm GetWebLemma(freeGraphNodeBase node)
        {
            webLemmaTerm term = new webLemmaTerm();
            term.name = node.name;
            term.nominalForm = node.name;
            term.weight = node.weight;
            return term;
        }





        /// <summary>
        /// Creates a semantic cloud subset by expanding received lemmas by specified expansionSteps and lemmaExpansionOptions
        /// </summary>
        /// <param name="lemmas">The lemmas.</param>
        /// <param name="expansionSteps">The expansion steps.</param>
        /// <param name="typeToMin">if set to <c>true</c> [type to minimum].</param>
        /// <param name="options">The options.</param>
        /// <returns></returns>
        public lemmaSemanticCloud ExpandTermsToCloud(IEnumerable<webLemmaTerm> lemmas, Int32 expansionSteps, Boolean typeToMin, lemmaExpansionOptions options)
        {
            List<String> lms = new List<string>();
            foreach (var t in lemmas)
            {
                if (ContainsNode(t.name))
                {
                    lms.Add(t.name);
                }
            }
            return ExpandTermsToCloud(lms, expansionSteps, typeToMin, options);
        }





        /// <summary>
        /// Gets the SSRM - computes the SSRM Similarity
        /// </summary>
        /// <param name="lemmas">The lemmas.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="debug">The debug.</param>
        /// <returns></returns>
        public Double GetSSRM(webLemmaTermPairCollection lemmas, ILogBuilder logger = null, SSRMComputation debug=null)
        {

            Double upper = 0;
            Double lowerA = 0;

            Int32 i = 0;
            foreach (webLemmaTermPair wlta in lemmas)
            {
                //foreach (webLemmaTermPair wltb in lemmas)
                //{
                    if (ContainsNode(wlta.entryA.name))
                    {
                        i++;
                        var node = GetNode(wlta.entryA.name);

                        upper += wlta.entryA.weight * wlta.entryB.weight*node.weight;
                        lowerA += wlta.entryA.weight * wlta.entryB.weight;

                        if (debug != null)
                        {
                            debug.printTerm(i, wlta.entryA.name, wlta.entryA.weight, wlta.entryB.weight, node.weight, upper, lowerA);
                        }
                    }
                //}
            }

            
            Double output = upper.GetRatio(lowerA);

            if (debug != null)
            {
                debug.upper = upper;
                debug.lower = lowerA;
                debug.similarity = output;
                debug.terms = i;

                debug.printFinale();
            }


            if (output == 0)
            {
                logger.log("Semantic similarity returned 0 score!");
            }

            return output;

        }

        internal void AddOrUpdateNode(freeGraphNodeBase node, freeGraphLink link, freeGraphNodeAndLinks links, Boolean typeToMin, lemmaExpansionOptions options)
        {
            if (ContainsNode(node.name, true))
            {
                var nd = GetNode(node.name, true);
                if (options.HasFlag(lemmaExpansionOptions.divideWeightByNumberOfSynonims))
                {
                    nd.weight = nd.weight + (node.weight.GetRatio(links.linkedNodeClones.Count));
                }
                else if (options.HasFlag(lemmaExpansionOptions.weightAsSemanticDistanceThatIsSumOfLinkWeights))
                {
                    nd.weight = nd.weight + node.weight.GetRatio(node.distance);
                    if (nd.distance > 1)
                    {
                        nd.distance = Math.Min(nd.distance, node.distance + link.linkBase.weight);
                    } else
                    {
                        nd.distance = node.distance + link.linkBase.weight;
                    }
                } else
                {
                    nd.weight = nd.weight + node.weight;
                }
                
                if (typeToMin)
                {
                    nd.type = Math.Min(nd.type, node.type);
                }
                else
                {
                    nd.type = Math.Max(nd.type, node.type);
                }
            }
            else
            {
                if (options.HasFlag(lemmaExpansionOptions.divideWeightByNumberOfSynonims))
                {
                    AddNode(node.name, node.weight.GetRatio(links.linkedNodeClones.Count), node.type);
                }
                else if(options.HasFlag(lemmaExpansionOptions.weightAsSemanticDistanceThatIsSumOfLinkWeights))
                {
                    AddNode(node.name, node.weight.GetRatio(node.distance), node.type).distance = node.distance + link.linkBase.weight; 
                } else
                {
                    AddNode(node.name, node.weight, node.type);
                }
            }
        }

        /// <summary>
        /// Returns expanded cloud from given lemma list - only for matched lemmas
        /// </summary>
        /// <param name="lemmas">The lemmas.</param>
        /// <param name="expansionSteps">The expansion steps.</param>
        /// <param name="options">The options.</param>
        /// <returns></returns>
        public lemmaSemanticCloud ExpandTermsToCloud(IEnumerable<String> lemmas, Int32 expansionSteps, Boolean typeToMin=true, lemmaExpansionOptions options = lemmaExpansionOptions.initialWeightFromParent | lemmaExpansionOptions.weightAsSemanticDistanceFromParent)
        {
            lemmaSemanticCloud output = new lemmaSemanticCloud();
            output.name = name + "_subset_exp" + expansionSteps;
            output.DisableCheck = true;
            StringBuilder sb = new StringBuilder();
            sb.Append("Subset expanded from matched query lemmas [");


            List<String> nextTerms = new List<string>();
            List<String> allTerms = new List<string>();

            foreach (String t in lemmas)
            {
                if (ContainsNode(t))
                {
                    sb.Append(t + " ");

                    var l = GetNode(t);
                    

                    output.AddNode(l.name, l.weight, 0).distance = 1;
                    nextTerms.Add(t);
                    allTerms.Add(t);
                }
                
            }

            sb.Append("] using cloud [" + name + "]");
            output.description = sb.ToString();


            Int32 exp_i = 1;

            while (nextTerms.Any())
            {
                List<String> newNextTerms = new List<string>();
                foreach (String t in nextTerms)
                {

                    freeGraphNodeAndLinks links = new freeGraphNodeAndLinks();

                    if (options.HasFlag(lemmaExpansionOptions.weightAsSemanticDistanceFromParent))
                    {
                        links = GetLinks(t, true, false, 1.GetRatio(exp_i), exp_i, true, options.HasFlag(lemmaExpansionOptions.initialWeightFromParent));
                    } else if (options.HasFlag(lemmaExpansionOptions.weightAsSemanticDistanceThatIsSumOfLinkWeights))
                    {
                        var nd = output.GetNode(t, true);
                        links = GetLinks(t, true,false, 1, exp_i, true, options.HasFlag(lemmaExpansionOptions.initialWeightFromParent));
                    } else 
                    {
                        links = GetLinks(t, true, false, 1, exp_i, true, options.HasFlag(lemmaExpansionOptions.initialWeightFromParent));
                    }



                    foreach (freeGraphLink link in links)
                    {
                        if (!allTerms.Contains(link.nodeA.name))
                        {
                            newNextTerms.Add(link.nodeA.name);
                            allTerms.Add(link.nodeA.name);
                        }

                        if (link.nodeA.name != t)
                        {
                            output.AddOrUpdateNode(link.nodeA, link, links, typeToMin, options);
                        }

                        if (!allTerms.Contains(link.nodeB.name))
                        {
                            newNextTerms.Add(link.nodeB.name);
                            allTerms.Add(link.nodeB.name);
                        }

                        if (link.nodeB.name != t)
                        {
                            output.AddOrUpdateNode(link.nodeB, link, links, typeToMin, options);
                        }


                    }

                    foreach (freeGraphLink link in links)
                    {
                        if (!output.ContainsLink(link.linkBase.nodeNameA, link.linkBase.nodeNameB))
                        {
                            output.AddLink(link.linkBase.nodeNameA, link.linkBase.nodeNameB, Math.Max(link.linkBase.weight, 1), link.linkBase.type);
                            //var nd = output.GetNode(link.nodeB.name);
                            //nd.weight = nd.weight + (link.nodeB.weight.GetRatio(links.linkedNodeClones.Count));
                            //nd.type = Math.Max(nd.type, link.nodeB.type);
                        }
                        else
                        {
                            var lnk = output.GetLink(link.linkBase.nodeNameA, link.linkBase.nodeNameB);
                            lnk.weight += link.linkBase.weight;
                            if (typeToMin)
                            {
                                lnk.type = Math.Min(link.linkBase.type, lnk.type);
                            }
                            else
                            {
                                lnk.type = Math.Max(link.linkBase.type, lnk.type);
                            }
                            
                        }
                    }
                }
                nextTerms = newNextTerms;
                exp_i++;
                if (exp_i > expansionSteps)
                {
                    break;
                }
            }

            output.DisableCheck = false;
            output.RebuildIndex();
            

            return output;

        }

        /// <summary>
        /// Expands the terms.
        /// </summary>
        /// <param name="lemmas">The lemmas.</param>
        /// <param name="expansionSteps">The expansion steps.</param>
        /// <param name="options">The options.</param>
        /// <returns></returns>
        public List<webLemmaTerm> ExpandTerms(IEnumerable<webLemmaTerm> lemmas, Int32 expansionSteps, lemmaExpansionOptions options = lemmaExpansionOptions.initialWeightFromParent | lemmaExpansionOptions.weightAsSemanticDistanceFromParent)
        {
            Dictionary<String, webLemmaTerm> lemmaDictionary = lemmas.GetLemmaDictionary();
            Dictionary<String, webLemmaTerm> outputDictionary = new Dictionary<string, webLemmaTerm>();

            aceDictionarySet<String, webLemmaTerm> lemmaSet = new aceDictionarySet<string, webLemmaTerm>();

            List<String> terms = lemmaDictionary.Keys.ToList();

            List<webLemmaTerm> output = new List<webLemmaTerm>();

            foreach (String term in terms)
            {
                lemmaSet[term].Add(lemmaDictionary[term]);
                
            }

            foreach (String term in terms)
            {
                webLemmaTerm parent = lemmaDictionary[term];
                freeGraphQueryResult termResult = GetLinkedNodes(new String[] { term }, expansionSteps, true, false);
                foreach (freeGraphNodeBase node in termResult)
                {
                    webLemmaTerm lem = GetWebLemma(parent, node, options);
                    
                    if (options.HasFlag(lemmaExpansionOptions.divideWeightByNumberOfSynonims))
                    {
                        lem.weight = lem.weight.GetRatio(termResult.Count);
                    }
                    lemmaSet.Add(node.name, lem);
                    if (!outputDictionary.ContainsKey(node.name))
                    {
                        outputDictionary.Add(node.name, lem);
                    }
                }
            }

            foreach (String key in lemmaSet.Keys)
            {
                Double weight = 0;
                webLemmaTerm firstLemma = null;

                foreach (webLemmaTerm lem in lemmaSet[key])
                {
                    weight += lem.weight;
                    firstLemma = lem;
                }
                if (!outputDictionary.ContainsKey(key)) outputDictionary.Add(key, firstLemma);
                outputDictionary[key].weight = weight;
            }
            return outputDictionary.Values.ToList();
           
        }

        /// <summary>
        /// Gets the matching terms against list of nodes.
        /// </summary>
        /// <param name="lemmas">The lemmas.</param>
        /// <returns></returns>
        public webLemmaTermPairCollection GetMatchingTerms(IEnumerable<webLemmaTerm> lemmas, Boolean reverse=false)
        {
            webLemmaTermPairCollection output = new webLemmaTermPairCollection();

            Dictionary<String, webLemmaTerm> lemmaDictionary = lemmas.GetLemmaDictionary();

            List<freeGraphNodeBase> result = GetNodes(lemmaDictionary.Keys);

            Dictionary<String, webLemmaTerm> secondDictionary = GetWebLemmaDictionary(result);

            foreach (String key in secondDictionary.Keys)
            {
                if (lemmaDictionary.ContainsKey(key)) {
                    if (reverse)
                    {
                        output.Add(secondDictionary[key], lemmaDictionary[key]);
                    }
                    else
                    {
                        output.Add(lemmaDictionary[key], secondDictionary[key]);
                    }
                }
            
            }

            return output;
        }

        public override void OnBeforeSave(folderNode folder)
        {
            base.OnBeforeSave(folder);

            if (primaryNodes.Any())
            {
                String fnp = className + "_" + name + "_primary.txt";
                fnp = folder.pathFor(fnp.getCleanFileName(false), imbSCI.Data.enums.getWritableFileMode.none, "List of lemma nodes in the Semantic Cloud [" + name + "] that are in Primary Term category");

                List<String> primary = new List<string>();
                primaryNodes.ForEach(x => primary.Add(x.name));

                File.WriteAllLines(fnp, primary);
            }

            if (secondaryNodes.Any())
            {
                String fns = className + "_" + name + "_secondary.txt";
                fns = folder.pathFor(fns.getCleanFileName(false), imbSCI.Data.enums.getWritableFileMode.none, "List of lemma nodes in the Semantic Cloud [" + name + "] that are in Secondary Term category");
                List<String> secondary = new List<string>();
                secondaryNodes.ForEach(x => secondary.Add(x.name));

                File.WriteAllLines(fns, secondary);
            }
        }

        public lemmaSemanticCloud Clone()
        {
            var output = this.CloneIntoType<lemmaSemanticCloud>(true);
            output.primaryChunks = this.primaryChunks.ToList();
            output.secondaryChunks = this.secondaryChunks.ToList();
            output.primaryNodes = this.primaryNodes.ToList();
            output.secondaryNodes = this.secondaryNodes.ToList();
            return output;
        }


        public List<freeGraphNodeBase> primaryNodes { get; set; } = new List<freeGraphNodeBase>();

        
        public List<freeGraphNodeBase> secondaryNodes { get; set; } = new List<freeGraphNodeBase>();


        public override void RebuildIndex()
        {
            base.RebuildIndex();
            primaryNodes.Clear();
            secondaryNodes.Clear();
            foreach (var node in nodes)
            {
                if (node.type == 2) primaryNodes.Add(node);
                if (node.type == 1) secondaryNodes.Add(node);
            }
        }

       
    }

}