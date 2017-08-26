using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace LightGraph.Core.Tests
{
    [TestFixture]
    public class PhotoConverterTests
    {
        private readonly Dictionary<string, double> _conversions = new Dictionary<string, double>() { { "Canon 6D", 1 }, { "Canon 300D", 0.6 } };

        [Test]
        [TestCase("Canon 6D", 1)]
        [TestCase("Canon 300D", 0.6)]
        [TestCase("Canon 7D", 1)]
        public void Convert_WithBodyName_CalculatesCropMultiplier(string body, double expectedConversion)
        {
            var converter = new PhotoConverter(_conversions);

            converter.Convert(new PhotoDto { Body = body,DateYear = 2000,DateMonth = 07,DateDay = 03 })
                     .CropMultiplier
                     .Should()
                     .Be(expectedConversion);
        }

        [Test]
        public void Convert_WithDto_CreatesPhoto()
        {
            var converter = new PhotoConverter(_conversions);

            var body = "Canon 6D";
            var aperture = 4;
            var shutterSpeed = 200;
            var focalLength = 35;
            var lens = "EF 35mm";
            var isoSpeedRating = 100;

            var photo = converter.Convert(new PhotoDto
            {
                Body = body,
                DateYear = 2000,
                DateMonth = 07,
                DateDay = 03,
                Aperture = aperture,
                ShutterSpeed = shutterSpeed,
                FocalLength = focalLength,
                Lens = lens,
                IsoSpeedRating = isoSpeedRating
            });

            photo.Body.Should().Be(body);
            photo.TakenAt.Should().Be(DateTime.Parse("03-July-2000"));
            photo.Aperture.Should().Be(aperture);
            photo.ShutterSpeed.Should().Be(shutterSpeed);
            photo.FocalLength.Should().Be(focalLength);
            photo.Lens.Should().Be(lens);
            photo.IsoSpeedRating.Should().Be(isoSpeedRating);
        }
    }
}
