using System;
using System.Collections.Generic;
using System.Text;
using Core.Libs.Integration.GoogleMap.Models.Places.Geocoding;

namespace Core.Libs.Integration.Test.Manual
{
    partial class Program
    {
        static void Main(string[] args)
        {
            // TestGoogleMap();

            // TestHamilton();

            // StringTest();

            var polylineString = "a~l~Fjk~uOwHJy@P";

            var a = Decode(polylineString);
        }

        static void StringTest()
        {
            var str1 = "Thành phố Bảo Lộc";
            var str2 = "tp. Bảo Lộc";

            var a = 0;

            if (string.Compare(str1, str2, true) == 0)
                a = 1;
        }

        static IEnumerable<Location> Decode(string polylineString)
        {
            if (string.IsNullOrEmpty(polylineString))
                throw new ArgumentNullException(nameof(polylineString));

            var polylineChars = polylineString.ToCharArray();
            var index = 0;

            var currentLat = 0;
            var currentLng = 0;

            while (index < polylineChars.Length)
            {
                // Next lat
                var sum = 0;
                var shifter = 0;
                int nextFiveBits;
                do
                {
                    nextFiveBits = polylineChars[index++] - 63;
                    sum |= (nextFiveBits & 31) << shifter;
                    shifter += 5;
                } while (nextFiveBits >= 32 && index < polylineChars.Length);

                if (index >= polylineChars.Length)
                    break;

                currentLat += (sum & 1) == 1 ? ~(sum >> 1) : (sum >> 1);

                // Next lng
                sum = 0;
                shifter = 0;
                do
                {
                    nextFiveBits = polylineChars[index++] - 63;
                    sum |= (nextFiveBits & 31) << shifter;
                    shifter += 5;
                } while (nextFiveBits >= 32 && index < polylineChars.Length);

                if (index >= polylineChars.Length && nextFiveBits >= 32)
                    break;

                currentLng += (sum & 1) == 1 ? ~(sum >> 1) : (sum >> 1);

                yield return new Location
                {
                    lat = Convert.ToDouble(currentLat) / 1E5,
                    lng = Convert.ToDouble(currentLng) / 1E5
                };
            }
        }

        static string Encode(IEnumerable<Location> locations)
        {
            var str = new StringBuilder();

            var encodeDiff = (Action<int>)(diff =>
            {
                var shifted = diff << 1;
                if (diff < 0)
                    shifted = ~shifted;

                var rem = shifted;

                while (rem >= 0x20)
                {
                    str.Append((char)((0x20 | (rem & 0x1f)) + 63));

                    rem >>= 5;
                }

                str.Append((char)(rem + 63));
            });

            var lastLat = 0;
            var lastLng = 0;

            foreach (var point in locations)
            {
                var lat = (int)Math.Round(point.lat.Value * 1E5);
                var lng = (int)Math.Round(point.lng.Value * 1E5);

                encodeDiff(lat - lastLat);
                encodeDiff(lng - lastLng);

                lastLat = lat;
                lastLng = lng;
            }

            return str.ToString();
        }
    }
}