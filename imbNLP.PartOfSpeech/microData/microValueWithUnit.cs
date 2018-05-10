using imbNLP.PartOfSpeech.flags.data;
using imbNLP.PartOfSpeech.microData.core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace imbNLP.PartOfSpeech.microData
{



    public class microValueWithUnit:microDataBase
    {

        public String unitOfMeasure { get; set; } = "";

        /// <summary>
        /// Numeric value
        /// </summary>
        /// <value>
        /// The numeric value.
        /// </value>
        public Double numericValue { get; set; } = 0;
    }
}
