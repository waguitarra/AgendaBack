using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Dtos.NsfwSpyP
{
    public class NsfwSpyPDto
    {
        /// <summary>
        /// The hentai probability score between 0 and 1.
        /// </summary>
        public float Hentai { get; set; }

        /// <summary>
        /// The neutral probability score between 0 and 1.
        /// </summary>
        public float Neutral { get; set; }

        /// <summary>
        /// The pornography probability score between 0 and 1.
        /// </summary>
        public float Pornography { get; set; }

        /// <summary>
        /// The sexy probability score between 0 and 1.
        /// </summary>
        public float Sexy { get; set; }

        /// <summary>
        /// The most likely predicted value.
        /// </summary>
        public string PredictedLabel { get; set; }

        /// <summary>
        /// Whether the image is likely to be explicit. True if the sum of pornography, hentai and sexy is equal to or above 0.5.
        /// </summary>
        public bool IsNsfw { get; set; }

        //url de imagens imgur
        public string LinkImgur { get; set; }

        // estatus de envio de imagens em imgur
        public string statusImgur { get; set; }

    }
}
