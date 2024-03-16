using System.Collections;
using System.Text;

namespace DonutMath;

public class Donut : IEnumerable<string>
{
    public IEnumerator<string> GetEnumerator()
    {
        var b = new int[1760];
        var z = new int[1760];
        var sA = 1024;
        var sB = 1024;
        var cA = 0;
        var cB = 0;
        var sb = new StringBuilder(1761);

        while (true)
        {
            Array.Fill(b, 32);
            Array.Fill(z, 127);

            var sj = 0;
            var cj = 1024;
            for (var j = 0; j < 90; j++)
            {
                int si = 0, ci = 1024;
                for (var i = 0; i < 324; i++)
                {
                    var R1 = 1;
                    var R2 = 2048;
                    var K2 = 5120 * 1024;
                    var x0 = R1 * cj + R2;
                    var x1 = ci * x0 >> 10;
                    var x2 = cA * sj >> 10;
                    var x3 = si * x0 >> 10;
                    var x4 = R1 * x2 - (sA * x3 >> 10);
                    var x5 = sA * sj >> 10;
                    var x6 = K2 + R1 * 1024 * x5 + cA * x3;
                    var x7 = cj * si >> 10;
                    var x = 40 + 30 * (cB * x1 - sB * x4) / x6;
                    var y = 12 + 15 * (cB * x4 + sB * x1) / x6;
                    var N = (-cA * x7 - cB * ((-sA * x7 >> 10) + x2) - ci * (cj * sB >> 10) >> 10) - x5 >> 7;
                    var o = x + 80 * y;
                    var zz = (x6 - K2) >> 15;
                    if (22 > y && y > 0 && x > 0 && 80 > x && zz < z[o])
                    {
                        z[o] = zz;
                        b[o] = ".,-~:;=!*#$@"[N > 0 ? N : 0];
                    }

                    R(5, 8, ref ci, ref si);
                }

                R(9, 7, ref cj, ref sj);
            }

            for (var k = 0; k < 1761; k++)
            {
                sb.Append(k % 80 != 0 ? (char) b[k] : '\n');
            }

            yield return sb.ToString();

            R(5, 7, ref cA, ref sA);
            R(5, 8, ref cB, ref sB);

            sb.Clear();
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private static void R(int mul, int shift, ref int x, ref int y)
    {
        var _ = x;
        x -= mul * y >> shift;
        y += mul * _ >> shift;
        _ = 3145728 - x * x - y * y >> 11;
        x = x * _ >> 10;
        y = y * _ >> 10;
    }
}
