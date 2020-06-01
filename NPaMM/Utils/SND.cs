using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPaMM.Utils {
  /// <summary>
  /// Standard Normal Distribution
  /// </summary>
  static class SND {
    public static List<float[]> table { get; } = new List<float[]>() {
      new float[] { 0.1f, 0,0797f },
      new float[] { 0.2f, 0,1585f },
      new float[] { 0.3f, 0.23587f },
      new float[] { 0.4f, 0.3108f },
      new float[] { 0.5f, 0.3829f },
      new float[] { 0.6f, 0.4515f },
      new float[] { 0.7f, 0.5161f },
      new float[] { 0.8f, 0.5763f },
      new float[] { 0.9f, 0.6319f },
      new float[] { 1.0f, 0.6827f },
      new float[] { 1.1f, 0.7287f },
      new float[] { 1.2f, 0.7699f },
      new float[] { 1.3f, 0.8064f },
      new float[] { 1.4f, 0.8385f },
      new float[] { 1.5f, 0.8664f },
      new float[] { 1.6f, 0.8904f },
      new float[] { 1.7f, 0.9104f },
      new float[] { 1.8f, 0.9281f },
      new float[] { 1.9f, 0.9545f },
      new float[] { 2.0f, 0.9643f },
      new float[] { 2.1f, 0.9722f },
      new float[] { 2.2f, 0.9786f },
      new float[] { 2.3f, 0.9836f },
      new float[] { 2.4f, 0.9876f },
      new float[] { 2.5f, 0.9907f },
      new float[] { 2.6f, 0.9931f },
      new float[] { 2.7f, 0.9949f },
      new float[] { 2.8f, 0.9963f },
    };


    public static float GetChance(float z) {
      var chance = 0.5f;

      if (z < 0) {
        chance *= -1;
      }

      var n = Math.Abs(z);
      var numRound = (float)Math.Round(n, 1);

      if (n < table.First()[0]) {
        chance *= 0.0f;

      } else if (n > table.Last()[0]) {
        chance *= 1.0f;
      } else {
        var lineTable = table.Find((el) => el.First() == numRound);
        chance *= lineTable[1];
      }

      return 0.5f + chance;
    }

    public static float? GetZ(float chance) {
      if (chance < 0 || chance > 100) {
        return null;
      }

      var c = chance / 100;

      foreach (var item in table) {
        var round = (float)Math.Round(item[1], 2);

        if (c <= round) {
          return item[0];
        }
      }

      return null;
    }

    //var num1 = 1 / Math.Sqrt(2 * Math.PI);
    //var num2 = -(Math.Pow(num, 2) / 2);

    //return (float)(num1 * Math.Exp(num2));
  }
}
