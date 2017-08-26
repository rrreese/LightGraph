using System;

namespace LightGraph.Core
{
    public class Photo
    {
        public double Aperture { get; set; }
        public DateTime TakenAt { get; set; }
        public int FocalLength { get; set; }
        public int IsoSpeedRating { get; set; }
        public double ShutterSpeed { get; set; }
        public string Body { get; set; }
        public string Lens { get; set; }
        public double CropMultiplier { get; set; }
    }
}