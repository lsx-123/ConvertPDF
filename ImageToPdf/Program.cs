using System;
using System.IO;

namespace ImageToPdf
{
    class Program
    {
        static void Main(string[] args)
        {
            string imgpath = @"D:\myImage";
            int imgCnt = 203;
            string pdffile = @"D:\myImage.pdf";

            iTextSharp.text.Document document = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 25, 25, 25, 25);
            try
            {
                iTextSharp.text.pdf.PdfWriter.GetInstance(document, new FileStream(pdffile, FileMode.Create, FileAccess.ReadWrite));
                document.Open();
                iTextSharp.text.Image image;
                for (int i = 0; i < imgCnt; i++)
                {
                    //if (String.IsNullOrEmpty(files[i])) break;

                    string imgfile = string.Format(@"{0}\A{1}.jpeg", imgpath, i+1);
                    image = iTextSharp.text.Image.GetInstance(imgfile);

                    if (image.Height > iTextSharp.text.PageSize.A4.Height - 25)
                    {
                        image.ScaleToFit(iTextSharp.text.PageSize.A4.Width - 25, iTextSharp.text.PageSize.A4.Height - 25);
                    }
                    else if (image.Width > iTextSharp.text.PageSize.A4.Width - 25)
                    {
                        image.ScaleToFit(iTextSharp.text.PageSize.A4.Width - 25, iTextSharp.text.PageSize.A4.Height - 25);
                    }
                    image.Alignment = iTextSharp.text.Image.ALIGN_MIDDLE;
                    document.NewPage();
                    document.Add(image);
                    //iTextSharp.text.Chunk c1 = new iTextSharp.text.Chunk("Hello World");
                    //iTextSharp.text.Phrase p1 = new iTextSharp.text.Phrase();
                    //p1.Leading = 150;      //行间距
                    //document.Add(p1);
                }
                Console.WriteLine("转换成功！");
            }
            catch (Exception ex)
            {
                Console.WriteLine("转换失败，原因：" + ex.Message);
            }
            document.Close();
            Console.ReadKey();
        }
    }
}
