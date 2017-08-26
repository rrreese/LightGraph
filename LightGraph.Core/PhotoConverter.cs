using System;
using System.Collections.Generic;

namespace LightGraph.Core
{
    public class PhotoConverter : IPhotoConverter
    {
        private readonly Dictionary<string, double> _conversions;

        public PhotoConverter(Dictionary<string, double> conversions)
        {
            _conversions = conversions;
        }

        public Photo Convert(PhotoDto photo)
        {
            return new Photo
            {
                Aperture = photo.Aperture,
                Body = photo.Body,
                FocalLength = photo.FocalLength,
                IsoSpeedRating = photo.IsoSpeedRating,
                Lens = photo.Lens,
                ShutterSpeed = photo.ShutterSpeed,
                TakenAt = new DateTime(photo.DateYear, photo.DateMonth, photo.DateDay),
                CropMultiplier = GetCropFactor(photo.Body)
            };
        }

        private double GetCropFactor(string body)
        {
            return _conversions.ContainsKey(body) ? _conversions[body] : 1;
        }
    }
}