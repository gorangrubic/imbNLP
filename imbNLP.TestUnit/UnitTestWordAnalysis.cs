using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using imbNLP.PartOfSpeech.analysis;
using imbSCI.Core.files.folders;
using System.IO;
using System.Text;

namespace imbNLP.TestUnit
{
        [TestClass]
    public class UnitTestWordAnalysis
    {
        [TestMethod]
        public void TestNGramsAndSimilarity()
        {
            folderNode folder = new folderNode();
            folder = folder.Add("NLP\\WordAnalysis", "Word analysis", "Folder with results of word analysis tests");

            String[] words = new String[] { "ormar", "orman", "rashladni", "konstrukcija", "elektroinstalacija", "elektromotor", "motorno", "građevina", "građevinski", "metalni", "metalno", "metal", "aluminijum", "aluminijumski", "zgrada", "kotao", "kotlovski", "kotlarnica", "peć", "dimnjak", "cevovodi", "vod", "linija", "stanica",
            "elektrana", "elektrogradnja", "izgradnja", "gradjevinsko", "grejanje", "grejno", "gorivo", "goriva", "pelet", "panel", "polica", "stolica", "bakarni", "bronzani",
            "centrala", "obezbeđenje", "klimatizacija", "klimatizacioni", "ventilacija", "ventilacioni", "gorionik", "vatra", "voda", "cev", "proizvod", "proizvodni", "laser", "proizvodnja", "lasersko", "sečenje", "plazma", "merdevine", "čunak", "štednjak", "radijator", "elektro", "induktivno", "transformator", "transformatorska", "dalekovod", "elektrovod", "mašina", "šinski", "voz", "nadzemno", "visokogradnja", "podzemno", "transport", "prevoz", "izolacija","plastika", "guma", "štender",
            "vitrina", "zamrzivač", "protivpožarna", "zaštita", "prodajna", "kontaktirajte", "kontakt", "kontakti", "telefon", "svetlo", "rasveta", "javna", "kompanija", "firma", "preduzeće", "društvo", "izvoz", "sto", "radni", "snaga", "napon", "krovni", "krov", "konstrukcioni", "konstruisanje", "tehničko", "tehnika", "zaposleni", "radnici", "reference", "kupci", "prodajni", "prodaja", "razvojni", "razvoj", "industrijski", "snabdevanje", "kućni", "nameštaj", "kancelarijski", "prostor", "podno", "pekara", "hleb", "pica", "peći", "pećnica", "žardinjera", "ograda", "čelična", "čelik", "galanterija", "stepenice", "nadvožnjak", "pešački", "saobraćajni", "znak", "tabla", "bilbord", "reklamni", "redni", "fluid", "hlađenje", "zagrevanje", "sagorevanje", "čvrsto", "pirolitički", "parni", "dim", "pepeo", "dopremanje", "čišćenje", "održavanje", "inoks", "inoksni", "inoksa", "razmenjivač", "toplote"};

            StringBuilder sb = new StringBuilder();

            foreach (String word in words)
            {
                sb.AppendLine(wordAnalysisTools.getNGramsDescriptiveLine(word, 2, nGramsModeEnum.overlap));
                sb.AppendLine(wordAnalysisTools.getNGramsDescriptiveLine(word, 2, nGramsModeEnum.ordinal));
            }

            String sbp = folder.pathFor("ngrams.txt", imbSCI.Data.enums.getWritableFileMode.autoRenameThis, "ngrams");
            File.WriteAllText(sbp, sb.ToString());

            wordSimilarityComponent component = new wordSimilarityComponent();
            component.N = 2;
            component.gramConstruction = nGramsModeEnum.overlap;
            component.treshold = 0.6;
            component.equation = nGramsSimilarityEquationEnum.DiceCoefficient;

            var result01 = component.GetResult(words);

            String p = folder.pathFor("result01.txt", imbSCI.Data.enums.getWritableFileMode.autoRenameThis, "TestNGrams", false);
            File.WriteAllText(p, result01.ToString());


            component.equation = nGramsSimilarityEquationEnum.JaccardIndex;

            var result02 = component.GetResult(words);

            p = folder.pathFor("result02.txt", imbSCI.Data.enums.getWritableFileMode.autoRenameThis, "TestNGrams", false);
            File.WriteAllText(p, result02.ToString());


            component.equation = nGramsSimilarityEquationEnum.continualOverlapRatio;

            var result03 = component.GetResult(words);

            p = folder.pathFor("result03.txt", imbSCI.Data.enums.getWritableFileMode.autoRenameThis, "TestNGrams", false);
            File.WriteAllText(p, result03.ToString());

        }
    }

}