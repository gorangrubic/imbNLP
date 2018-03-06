using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using imbNLP.PartOfSpeech.analysis;
using imbSCI.Core.files.folders;
using System.IO;
using System.Text;
using imbNLP.PartOfSpeech.TFModels.semanticCloudWeaver;
using imbNLP.PartOfSpeech.TFModels.semanticCloud;
using imbSCI.Core.files;

namespace imbNLP.TestUnit
{

    [TestClass]
    public class UnitTestCloudWeaver
    {
        [TestMethod]
        public void TestCloudWeaver()
        {

            folderNode folder = new folderNode();

            folderNode weaverFolder = folder.Add("NLP\\CloudWeaver", "Cloud Weaver", "Folder with results of cloud weaver tests");
            folderNode cloudFolder = folder.Add("Clouds", "Test resources", "");
            folderNode resourceFolder = folder.Add("resources", "Test resources", "");

            lemmaSemanticWeaver weaver = new lemmaSemanticWeaver();
            weaver.prepare(resourceFolder, null);


            weaver.useSimilarity = true;
            weaver.similarWords.N = 2;
            weaver.similarWords.gramConstruction = nGramsModeEnum.overlap;
            weaver.similarWords.treshold = 0.6;
            weaver.similarWords.equation = nGramsSimilarityEquationEnum.DiceCoefficient;

            weaver.useDictionary = false;

            var cloudPaths = cloudFolder.findFiles("*_initialCloud.xml", SearchOption.TopDirectoryOnly);

            foreach (String path in cloudPaths)
            {
                lemmaSemanticCloud testCloud = lemmaSemanticCloud.Load<lemmaSemanticCloud>(path);

                testCloud.GetSimpleGraph(false).Save(weaverFolder.pathFor(testCloud.className + "_initial.dgml", imbSCI.Data.enums.getWritableFileMode.overwrite), imbSCI.Data.enums.getWritableFileMode.overwrite);

                var report = weaver.Process(testCloud, null);
                report.Save(weaverFolder, "DiceCoefficient");

            }

            weaver.similarWords.equation = nGramsSimilarityEquationEnum.JaccardIndex;
            
            foreach (String path in cloudPaths)
            {
                lemmaSemanticCloud testCloud = lemmaSemanticCloud.Load<lemmaSemanticCloud>(path);

                var report = weaver.Process(testCloud, null);
                report.Save(weaverFolder, "JaccardIndex");

            }

            weaver.similarWords.equation = nGramsSimilarityEquationEnum.continualOverlapRatio;

            foreach (String path in cloudPaths)
            {
                lemmaSemanticCloud testCloud = lemmaSemanticCloud.Load<lemmaSemanticCloud>(path);

                var report = weaver.Process(testCloud, null);
                report.Save(weaverFolder, "ContinualOverlap");

                objectSerialization.saveObjectToXML(testCloud, weaverFolder.pathFor(testCloud.className + "_weaved.xml", imbSCI.Data.enums.getWritableFileMode.overwrite, "Processed cloud"));

                testCloud.GetSimpleGraph(false).Save(weaverFolder.pathFor(testCloud.className + "_weaved.dgml", imbSCI.Data.enums.getWritableFileMode.overwrite), imbSCI.Data.enums.getWritableFileMode.overwrite);
            }


            //weaver.similarWords.equation = nGramsSimilarityEquationEnum.continualOverlapRatio;
            //weaver.useDictionary = true;

            //foreach (String path in cloudPaths)
            //{
            //    lemmaSemanticCloud testCloud = lemmaSemanticCloud.Load<lemmaSemanticCloud>(path);

            //    var report = weaver.Process(testCloud, null);
            //    report.Save(weaverFolder, "JaccardIndexAndApertium");

               

            //}

            folder.generateReadmeFiles(new imbSCI.Core.data.aceAuthorNotation());
        }
    }

}