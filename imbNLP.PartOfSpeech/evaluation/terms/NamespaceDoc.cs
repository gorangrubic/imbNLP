using System;
using System.Linq;
using System.Collections.Generic;
using imbNLP.PartOfSpeech.TFModels.semanticCloudWeaver;
using imbSCI.Data;
using System.Text;
using System.IO;
using imbNLP.PartOfSpeech.analysis;

namespace imbNLP.PartOfSpeech.evaluation.termTruthTable
{

    /// <summary>
    /// <para>Mechanism for category - industry - term evaluation, combines simple truth table with word similarity computation</para>
    /// </summary>
    /// <remarks>
    /// <para><see cref="termQualificationComponent"/> performs the evaluation and stores the configuration parameters</para>
    /// <list>
    /// 	<listheader>
    ///			<term>Evaluate a word</term>
    ///			<description><see cref="termQualificationComponent.Evaluate(string)"/></description>
    ///		</listheader>
    ///		<item>
    ///			<term>Adjust the <see cref="termQualificationComponent.treshold"/> for similarity computation</term>
    ///		</item>
    ///		<item>
    ///			<term>Change the similarity equation</term>
    ///			<description><see cref="termQualificationComponent.similarity"/></description>
    ///		</item>
    /// </list>
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    class NamespaceDoc
    {
    }

}