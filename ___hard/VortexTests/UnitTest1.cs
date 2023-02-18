namespace VortexTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestcaseSimplest() {
            Vortex Hawat = new(1);
            Hawat.AddToMatrix(new int[] { 1, 2, 3 });
            Hawat.AddToMatrix(new int[] { 4, 5, 6 });
            Hawat.AddToMatrix(new int[] { 7, 8, 9 });
            Hawat.CrankMatrix();
            List<int[]> CorrectResult = new List<int[]>();
            CorrectResult.Add(new int[] { 2, 3, 6 });
            CorrectResult.Add(new int[] { 1, 5, 9 });
            CorrectResult.Add(new int[] { 4, 7, 8 });
            for (int i = 0; i < Hawat.Matrix.Count; i++) {
                bool LineResult = Hawat.Matrix[i].SequenceEqual(CorrectResult[i]);
                if (!LineResult) Console.WriteLine(i);
                Assert.IsTrue(LineResult);
            }
        }
        [TestMethod]
        public void TestcaseExample7x5Matrix() {
            Vortex Hawat = new(2);
            Hawat.AddToMatrix(new int[] { 1, 2, 3, 4, 5, 6, 7 });
            Hawat.AddToMatrix(new int[] { 8, 9, 10, 11, 12, 13, 14 });
            Hawat.AddToMatrix(new int[] { 15, 16, 17, 18, 19, 20, 21 });
            Hawat.AddToMatrix(new int[] { 22, 23, 24, 25, 26, 27, 28 });
            Hawat.AddToMatrix(new int[] { 29, 30, 31, 32, 33, 34, 35 });
            Hawat.CrankMatrix();
            List<int[]> CorrectResult = new List<int[]>();
            CorrectResult.Add(new int[] { 3, 4, 5, 6, 7, 14, 21 });
            CorrectResult.Add(new int[] { 2, 11, 12, 13, 20, 27, 28 });
            CorrectResult.Add(new int[] { 1, 10, 17, 18, 19, 26, 35 });
            CorrectResult.Add(new int[] { 8, 9, 16, 23, 24, 25, 34 });
            CorrectResult.Add(new int[] { 15, 22, 29, 30, 31, 32, 33 });
            for (int i = 0; i < Hawat.Matrix.Count; i++) {
                bool LineResult = Hawat.Matrix[i].SequenceEqual(CorrectResult[i]);
                if (!LineResult) Console.WriteLine(i);
                Assert.IsTrue(LineResult);
            }
        }
        [TestMethod]
        public void JustAn8x12Matrix() {
            Vortex Hawat = new(1);
            Hawat.AddToMatrix(new int[] { -99, -57, 17, -65, -40, 46, 71, 15 });
            Hawat.AddToMatrix(new int[] { -8, -45, -95, -45, -24, 14, -99, -14 });
            Hawat.AddToMatrix(new int[] { 5, 69, -88, 98, -69, -48, 62, 68 });
            Hawat.AddToMatrix(new int[] { 7, 51, 49, 17, -73, -68, 63, 94 });
            Hawat.AddToMatrix(new int[] { -58, 29, 63, 44, 45, 20, 61, -44 });
            Hawat.AddToMatrix(new int[] { -26, -94, -60, 97, -14, -7, 51, 77 });
            Hawat.AddToMatrix(new int[] { 63, 66, 59, 65, 10, 77, 32, 87 });
            Hawat.AddToMatrix(new int[] { 91, 33, 86, -86, 97, -41, -51, 9 });
            Hawat.AddToMatrix(new int[] { -93, 50, 24, 95, -15, -78, -5, 95 });
            Hawat.AddToMatrix(new int[] { -54, 90, 60, 6, 55, 14, -68, -87 });
            Hawat.AddToMatrix(new int[] { -48, -79, -27, 89, -43, 38, -51, -100 });
            Hawat.AddToMatrix(new int[] { -64, 13, -92, 54, 25, 72, 59, -96 });
            Hawat.CrankMatrix();
            List<int[]> CorrectResult = new List<int[]>();
            CorrectResult.Add(new int[] { -57, 17, -65, -40, 46, 71, 15, -14 });
            CorrectResult.Add(new int[] { -99, -95, -45, -24, 14, -99, 62, 68 });
            CorrectResult.Add(new int[] { -8, -45, 98, -69, -48, -68, 63, 94 });
            CorrectResult.Add(new int[] { 5, 69, -88, -73, 45, 20, 61, -44 });
            CorrectResult.Add(new int[] { 7, 51, 49, 17, -14, -7, 51, 77 });
            CorrectResult.Add(new int[] { -58, 29, 63, 44, 10, 77, 32, 87 });
            CorrectResult.Add(new int[] { -26, -94, -60, 97, 97, -41, -51, 9 });
            CorrectResult.Add(new int[] { 63, 66, 59, 65, -15, -78, -5, 95 });
            CorrectResult.Add(new int[] { 91, 33, 86, -86, 95, 14, -68, -87 });
            CorrectResult.Add(new int[] { -93, 50, 24, 60, 6, 55, -51, -100 });
            CorrectResult.Add(new int[] { -54, 90, -79, -27, 89, -43, 38, -96 });
            CorrectResult.Add(new int[] { -48, -64, 13, -92, 54, 25, 72, 59 });
            for (int i = 0; i < Hawat.Matrix.Count; i++) {
                bool LineResult = Hawat.Matrix[i].SequenceEqual(CorrectResult[i]);
                if (!LineResult) Console.WriteLine(i);
                Assert.IsTrue(LineResult);
            }
        }
        [TestMethod]
        public void ManyPixels() {
            Vortex Hawat = new(100);
            Hawat.AddToMatrix(new int[] { 97, 87, -76, -58, 43, -94, 10, 18, 47, -81, -2, -2 });
            Hawat.AddToMatrix(new int[] { -11, -15, -58, 95, 52, 38, 52, -46, -67, -64, 16, -72 });
            Hawat.AddToMatrix(new int[] { 49, 18, 10, -82, 80, 51, 80, -54, 36, 80, 92, 84 });
            Hawat.AddToMatrix(new int[] { -83, 93, 58, 89, -50, 59, -80, 46, -64, 57, 15, 99 });
            Hawat.AddToMatrix(new int[] { -58, -20, 10, -27, -8, 89, -83, -48, -52, -67, 31, 45 });
            Hawat.AddToMatrix(new int[] { -15, 43, -22, 57, -10, 21, -77, -58, -45, -50, 93, -2 });
            Hawat.AddToMatrix(new int[] { 38, 24, 51, 53, -63, -22, 6, 94, 73, -36, 11, 48 });
            Hawat.AddToMatrix(new int[] { 26, -51, 25, 35, 34, -59, -87, 46, -76, -41, -73, -30 });
            Hawat.AddToMatrix(new int[] { -27, -55, -64, -51, -44, -73, 28, 32, 37, 20, 14, -71 });
            Hawat.AddToMatrix(new int[] { -17, 35, 10, -56, 71, 70, 47, -36, -60, -68, -52, -90 });
            Hawat.AddToMatrix(new int[] { 92, -56, -64, 73, -65, 40, 68, -17, -77, 75, 28, -24 });
            Hawat.AddToMatrix(new int[] { -9, -58, -33, -25, -43, -87, -54, -67, 97, -83, -85, -22 });
            Hawat.AddToMatrix(new int[] { 79, -7, -51, -48, -68, 94, -48, 43, -77, -33, -45, 54 });
            Hawat.AddToMatrix(new int[] { 59, -75, 4, 56, 23, 50, -66, -89, 62, -83, -99, -29 });
            Hawat.AddToMatrix(new int[] { -44, 53, 86, 62, 33, -79, -29, 19, 88, 54, 21, 85 });
            Hawat.AddToMatrix(new int[] { -61, -77, 90, 57, 77, 18, -70, 30, 64, 96, 21, -29 });
            Hawat.AddToMatrix(new int[] { -96, 31, 63, 50, 0, 41, -50, 61, -92, 9, 51, -34 });
            Hawat.AddToMatrix(new int[] { 78, -28, 7, 83, -28, 22, -55, 17, -38, -22, 45, 72 });
            Hawat.AddToMatrix(new int[] { 52, -71, -34, -48, -9, 63, -97, -86, 16, 34, 31, 2 });
            Hawat.AddToMatrix(new int[] { -27, 77, -13, 76, 35, 4, -71, -100, -80, -95, -78, 82 });
            Hawat.CrankMatrix();
            List<int[]> CorrectResult = new List<int[]>();
            CorrectResult.Add(new int[] { 77, -27, 52, 78, -96, -61, -44, 59, 79, -9, 92, -17 });
            CorrectResult.Add(new int[] { -13, 43, -20, 93, 18, -15, -58, 95, 52, 38, 52, -27 });
            CorrectResult.Add(new int[] { 76, 24, -41, 20, -68, 75, -83, -33, -83, 54, -46, 26 });
            CorrectResult.Add(new int[] { 35, -51, -36, -25, 73, -56, -51, 35, 53, 96, -67, 38 });
            CorrectResult.Add(new int[] { 4, -55, -50, -48, 18, 77, 33, 23, 57, 9, -64, -15 });
            CorrectResult.Add(new int[] { -71, 35, -67, 56, -70, 21, -77, -68, -27, -22, 16, -58 });
            CorrectResult.Add(new int[] { -100, -56, 57, 62, 30, -22, 6, -43, 89, -38, 92, -83 });
            CorrectResult.Add(new int[] { -80, -58, 80, 57, 19, -59, -87, -65, -50, 17, 15, 49 });
            CorrectResult.Add(new int[] { -95, -7, 36, 50, -89, -73, 28, 71, 59, -55, 31, -11 });
            CorrectResult.Add(new int[] { -78, -75, -54, 0, 43, 70, 47, -44, -80, 22, 93, 97 });
            CorrectResult.Add(new int[] { 82, 53, 80, 41, -67, 40, 68, 34, 46, -28, 11, 87 });
            CorrectResult.Add(new int[] { 2, -77, 51, -50, -17, -87, -54, -63, -64, 83, -73, -76 });
            CorrectResult.Add(new int[] { 72, 31, 80, 61, -36, 94, -48, -10, -52, 7, 14, -58 });
            CorrectResult.Add(new int[] { -34, -28, -82, -92, 32, 50, -66, -8, -45, 63, -52, 43 });
            CorrectResult.Add(new int[] { -29, -71, 10, 64, 46, -79, -29, 89, 73, 90, 28, -94 });
            CorrectResult.Add(new int[] { 85, -34, 58, 88, 94, -58, -48, -83, -76, 86, -85, 10 });
            CorrectResult.Add(new int[] { -29, -48, 10, 62, -77, 97, -77, -60, 37, 4, -45, 18 });
            CorrectResult.Add(new int[] { 54, -9, -22, 51, 25, -64, 10, -64, -33, -51, -99, 47 });
            CorrectResult.Add(new int[] { -22, 63, -97, -86, 16, 34, 31, 45, 51, 21, 21, -81 });
            CorrectResult.Add(new int[] { -24, -90, -71, -30, 48, -2, 45, 99, 84, -72, -2, -2 });
            for (int i = 0; i < Hawat.Matrix.Count; i++) {
                bool LineResult = Hawat.Matrix[i].SequenceEqual(CorrectResult[i]);
                if (!LineResult) Console.WriteLine(i);
                Assert.IsTrue(LineResult);
            }
        }
        [TestMethod]
        public void INSANE() {
            Vortex Hawat = new(100000);
            Hawat.AddToMatrix(new int[] { 7, 7, 4, 0, 0, 0, 2, 9, 1, 7, 0, 5, 3, 6, 3, 5, 5, 7, 7, 4, 6, 9, 1, 5, 1, 0, 3, 8, 3, 1, 7, 2 });
            Hawat.AddToMatrix(new int[] { 0, 8, 7, 5, 2, 4, 1, 9, 7, 9, 1, 1, 8, 6, 9, 1, 5, 7, 6, 4, 6, 1, 2, 7, 0, 6, 8, 0, 7, 3, 0, 5 });
            Hawat.AddToMatrix(new int[] { 2, 9, 7, 3, 0, 2, 9, 5, 0, 6, 8, 6, 0, 7, 3, 8, 0, 4, 5, 2, 4, 7, 6, 4, 4, 2, 7, 9, 6, 6, 1, 6 });
            Hawat.AddToMatrix(new int[] { 6, 4, 4, 3, 5, 3, 9, 3, 0, 1, 6, 3, 8, 2, 4, 2, 2, 6, 7, 1, 1, 0, 9, 1, 0, 8, 3, 5, 0, 2, 2, 6 });
            Hawat.AddToMatrix(new int[] { 2, 3, 2, 2, 7, 2, 4, 9, 3, 0, 0, 7, 9, 5, 0, 2, 8, 4, 4, 0, 1, 3, 0, 7, 0, 3, 8, 1, 1, 6, 5, 4 });
            Hawat.AddToMatrix(new int[] { 1, 1, 4, 4, 1, 5, 1, 6, 2, 1, 3, 6, 4, 4, 8, 2, 8, 8, 4, 9, 1, 2, 1, 3, 5, 5, 3, 4, 5, 3, 0, 4 });
            Hawat.AddToMatrix(new int[] { 9, 8, 3, 1, 3, 6, 3, 5, 7, 2, 9, 9, 2, 4, 2, 4, 1, 2, 0, 5, 7, 1, 9, 7, 7, 3, 6, 2, 3, 1, 0, 2 });
            Hawat.AddToMatrix(new int[] { 2, 3, 1, 4, 9, 9, 5, 4, 4, 1, 6, 1, 9, 1, 0, 9, 4, 3, 0, 9, 9, 2, 6, 2, 2, 9, 4, 2, 2, 4, 1, 1 });
            Hawat.AddToMatrix(new int[] { 2, 5, 8, 0, 5, 8, 0, 2, 7, 6, 9, 4, 8, 9, 2, 6, 8, 4, 9, 4, 3, 4, 3, 4, 4, 7, 6, 2, 0, 9, 4, 0 });
            Hawat.AddToMatrix(new int[] { 5, 1, 3, 4, 9, 8, 2, 8, 4, 1, 4, 0, 6, 7, 2, 1, 0, 7, 6, 0, 5, 8, 5, 9, 3, 6, 0, 5, 8, 2, 3, 6 });
            Hawat.AddToMatrix(new int[] { 7, 5, 6, 9, 1, 6, 6, 0, 2, 0, 2, 0, 9, 1, 1, 0, 8, 6, 8, 3, 3, 6, 7, 3, 6, 2, 1, 8, 6, 3, 0, 6 });
            Hawat.AddToMatrix(new int[] { 7, 1, 6, 9, 1, 8, 9, 7, 0, 7, 0, 1, 8, 7, 5, 2, 3, 3, 8, 0, 9, 6, 4, 5, 7, 2, 3, 7, 6, 5, 4, 0 });
            Hawat.CrankMatrix();
            List<int[]> CorrectResult = new List<int[]>();
            CorrectResult.Add(new int[] { 6, 6, 0, 4, 5, 6, 7, 3, 2, 7, 5, 4, 6, 9, 0, 8, 3, 3, 2, 5, 7, 8, 1, 0, 7, 0, 7, 9, 8, 1, 9, 6 });
            CorrectResult.Add(new int[] { 0, 2, 0, 6, 6, 1, 9, 6, 5, 1, 5, 3, 8, 1, 3, 4, 9, 8, 7, 5, 2, 4, 1, 9, 7, 9, 1, 1, 8, 6, 9, 1 });
            CorrectResult.Add(new int[] { 1, 0, 9, 5, 8, 5, 0, 6, 7, 0, 1, 2, 7, 6, 0, 4, 1, 4, 8, 2, 8, 9, 4, 3, 8, 1, 3, 4, 2, 4, 1, 7 });
            CorrectResult.Add(new int[] { 2, 2, 3, 9, 4, 8, 6, 2, 9, 8, 4, 9, 6, 7, 2, 0, 8, 5, 0, 4, 1, 4, 2, 3, 5, 3, 9, 3, 0, 7, 5, 7 });
            CorrectResult.Add(new int[] { 4, 0, 6, 4, 3, 0, 0, 7, 9, 5, 0, 2, 8, 4, 4, 0, 1, 3, 0, 7, 0, 3, 8, 1, 4, 2, 2, 4, 1, 3, 7, 5 });
            CorrectResult.Add(new int[] { 4, 9, 0, 3, 9, 1, 4, 2, 4, 2, 9, 9, 2, 7, 5, 3, 6, 5, 1, 6, 2, 1, 3, 6, 4, 4, 8, 9, 6, 0, 6, 2 });
            CorrectResult.Add(new int[] { 6, 1, 5, 4, 4, 2, 0, 5, 7, 1, 9, 7, 7, 3, 6, 3, 5, 5, 3, 1, 2, 1, 9, 4, 8, 8, 2, 2, 3, 2, 4, 2 });
            CorrectResult.Add(new int[] { 6, 1, 8, 3, 2, 7, 1, 3, 9, 9, 5, 4, 4, 1, 6, 1, 9, 1, 0, 9, 4, 3, 0, 9, 9, 2, 6, 2, 8, 9, 6, 9 });
            CorrectResult.Add(new int[] { 5, 0, 2, 4, 4, 7, 6, 2, 0, 2, 3, 5, 1, 0, 5, 3, 8, 0, 1, 9, 0, 1, 1, 7, 6, 2, 2, 4, 2, 5, 1, 1 });
            CorrectResult.Add(new int[] { 2, 8, 9, 4, 1, 3, 6, 2, 6, 6, 9, 7, 2, 4, 4, 6, 7, 4, 2, 5, 4, 0, 8, 3, 7, 0, 6, 8, 6, 0, 2, 2 });
            CorrectResult.Add(new int[] { 7, 6, 8, 3, 3, 6, 7, 3, 6, 2, 1, 8, 6, 3, 0, 3, 4, 1, 0, 0, 5, 2, 1, 0, 3, 7, 0, 8, 6, 0, 7, 6 });
            CorrectResult.Add(new int[] { 1, 3, 8, 3, 0, 1, 5, 1, 9, 6, 4, 7, 7, 5, 5, 3, 6, 3, 5, 0, 7, 1, 9, 2, 0, 0, 0, 4, 7, 7, 0, 2 });
            for (int i = 0; i < Hawat.Matrix.Count; i++) {
                bool LineResult = Hawat.Matrix[i].SequenceEqual(CorrectResult[i]);
                if (!LineResult) Console.WriteLine(i);
                Assert.IsTrue(LineResult);
            }
        }




    }
}