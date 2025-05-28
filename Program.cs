using System.Text;
//
// dotnet run 
//   -count 8 
//   -in "C:\Users\cyqjefe0019\OneDrive - DPDHL\Projekte\4610\Azure\Rapid Response\ServiceHealth_20240423.csv" 
//   -out "C:\Users\cyqjefe0019\OneDrive - DPDHL\Projekte\4610\Azure\Rapid Response\ServiceHealth_20240423_new.csv"
//
namespace ProIT
{
    class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello ProIT!");
            String arg = new String("C:\\Users\\RBO-VS-Admin\\source\\repos\\ProIT\\data\\export_proit_20250527.csv");
            if (args != null && args.Length > 0) {
                try
                {
                    createPlanung(args[0]);
                }
                catch (FileNotFoundException ex) {
                    Console.WriteLine(ex);
                }
            } else {
                usage();
                createPlanung(arg);
            }
        }

        private static void createPlanung(string fin)
        {
            Console.WriteLine("File in:  " + fin);
            StreamReader sr = new StreamReader(fin);
            string[] s = fin.Split('.');
            string fout;
            if (s.Length == 2) {
                fout = s[0] + "_planung.csv";
            } else {
                fout = "C:\\Users\\RBO-VS-Admin\\source\\repos\\ProIT\\data\\export_proit_20250527_planung";
                throw new FileNotFoundException("Input file incorrect");
            }
            StreamWriter sw = new StreamWriter(fout);
            String lineIn = sr.ReadLine();
            int i = 0;
            bool doWrite = false;
            StringBuilder lineOut = new StringBuilder();
            while (lineIn != null) {
                i++;
                if (i == 4) {
                    doWrite = true;
                }
                if (doWrite) {
                    Console.WriteLine(i + " " + lineIn);
                    String[] l = lineIn.Split(';');
                    sw.WriteLine(l[0] + "; 2025-01; " + l[2]  + "; " + l[15]);
                    sw.WriteLine(l[0] + "; 2025-02; " + l[3]  + "; " + l[15]);
                    sw.WriteLine(l[0] + "; 2025-03; " + l[4]  + "; " + l[15]);
                    sw.WriteLine(l[0] + "; 2025-04; " + l[5]  + "; " + l[15]);
                    sw.WriteLine(l[0] + "; 2025-05; " + l[6]  + "; " + l[15]);
                    sw.WriteLine(l[0] + "; 2025-06; " + l[7]  + "; " + l[15]);
                    sw.WriteLine(l[0] + "; 2025-07; " + l[8]  + "; " + l[15]);
                    sw.WriteLine(l[0] + "; 2025-08; " + l[9]  + "; " + l[15]);
                    sw.WriteLine(l[0] + "; 2025-09; " + l[10] + "; " + l[15]);
                    sw.WriteLine(l[0] + "; 2025-10; " + l[11] + "; " + l[15]);
                    sw.WriteLine(l[0] + "; 2025-11; " + l[12] + "; " + l[15]);
                    sw.WriteLine(l[0] + "; 2025-12; " + l[13] + "; " + l[15]);
                }
                lineIn = sr.ReadLine();
            }
            sr.Close();
            sw.Close();
        }

        private static void usage() {
            Console.WriteLine("Missing parameter");
            Console.WriteLine("usage: dotnet run <dir><proit csv datei>");
        }
    }
}