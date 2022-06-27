using Aspose.Words;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Lab15TextStakan
{
    class Program
    {
        static string aposhin = @"D:\University\6_sem\Крипта\lr_15\Lab15TextStakan\input.docx";
        static string outFileName = @"D:\University\6_sem\Крипта\lr_15\Lab15TextStakan\aposhenc.docx";

        static string sizeIN = @"D:\University\6_sem\Крипта\lr_15\Lab15TextStakan\input.docx";
        static string sizeOUT = @"D:\University\6_sem\Крипта\lr_15\Lab15TextStakan\output.docx";


        static void Main(string[] args)
        {
            AposhEncryption();
            AposhDecryption();

            SizeEncryption();
            SizeDecryption();
        }

        public static void AposhEncryption()
        {
            Document inDoc = new Document(aposhin);
            Document outDoc = new Document(outFileName);
            outDoc.RemoveAllChildren();

            DocumentBuilder builder = new DocumentBuilder(outDoc);
            string inText = "";
            var runs = inDoc.GetChildNodes(NodeType.Run, true);
            for (int i=1;i< runs.Count - 1; i++)
            {
                inText+=runs[i].GetText();
            }

            BitArray bits = new BitArray(Encoding.UTF8.GetBytes("liza kubik"));
            for (int i = 0; i < bits.Length && i < inText.Length; i++)
            {
                Font font = builder.Font;
                font.Spacing = bits[i]?1:0.5;
                builder.Write(inText[i].ToString());
            }

            outDoc.Save(outFileName, SaveFormat.Docx);
        }
        public static void AposhDecryption()
        {
            Document inDoc = new Document(outFileName);

            var runs = inDoc.GetChildNodes(NodeType.Run, true);
            List<bool> bits = new List<bool>();
            for (int i = 1; i < runs.Count - 1; i++)
            {
                bits.Add(((Run)runs[i]).Font.Spacing == 1);
            }
            BitArray ba = new BitArray(bits.ToArray());
            byte[] bytes = new byte[(int)Math.Ceiling((double)ba.Length / 8)];
            ba.CopyTo(bytes, 0);
            Console.WriteLine("decryption: " + Encoding.UTF8.GetString(bytes));

        }
        public static void SizeDecryption()
        {
            Document document = new Document(sizeOUT);
            DocumentBuilder builder = new DocumentBuilder(document);

            int lines_count = document.Sections[0].Body.Paragraphs.Count;
            String arr = "";
            int size = 0;

            for (int i = 0; i < lines_count; i++)
            {
                if (document.Sections[0].Body.Paragraphs[i].Runs[0].Text.Contains("  "))
                {
                    size = i;
                    break;
                }

                if (document.Sections[0].Body.Paragraphs[i].Runs[0].Text.EndsWith(' '))
                {
                    arr += '1';
                }
                else
                {
                    arr += '0';
                }
            }

            //Console.WriteLine("decryption: " + BinaryToString(arr));
        }
        public static void SizeEncryption()
        {
            Document document = new Document(sizeIN);
            DocumentBuilder builder = new DocumentBuilder(document);
            double lines_count = document.Sections[0].Body.Paragraphs.Count;
            String bin = StringToBinary("liza");
            if (bin.Length > Math.Round(lines_count))
            {
                Console.WriteLine("Message length is more than possible");
                return;
            }
            for (int i = 0; i < bin.Length; i++)
            {
                String additional = bin[i] == '0' ? "" : " ";
                document.Sections[0].Body.Paragraphs[i].Runs[0].Text += additional;

                if (i + 1 == bin.Length)
                {
                    document.Sections[0].Body.Paragraphs[i + 1].Runs[0].Text += "  ";
                }
            }
            document.Save(sizeOUT);
        }
        public static string StringToBinary(string data)
        {
            String sb = "";

            foreach (char c in data.ToCharArray())
            {
                sb += Convert.ToString(c, 2).PadLeft(8, '0');
            }

            while (sb.Length % 8 != 0)
            {
                sb = "0" + sb;
            }

            return sb;
        }
        public static string BinaryToString(string data)
        {
            List<Byte> byteList = new List<Byte>();

            for (int i = 0; i + 8 - 1 <= data.Length; i += 8)
            {
                byteList.Add(Convert.ToByte(data.Substring(i, 8), 2));
            }
            return Encoding.ASCII.GetString(byteList.ToArray());
        }
    }
}
