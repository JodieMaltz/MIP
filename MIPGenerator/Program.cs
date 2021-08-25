using System;
using System.IO;
using SixLabors.Fonts;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.Processing;

namespace MIPGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入 MIP 获得者的名称:");
            var mipName = Console.ReadLine();

            var backgroundImage = Image.Load(Path.Combine(Directory.GetCurrentDirectory(), "bg.png"));
            var fontFamily = new FontCollection().Install(Path.Combine(Directory.GetCurrentDirectory(), "SourceHanSansSC-VF.ttf"));

            var nameFont = fontFamily.CreateFont(100, FontStyle.Bold);
            var dateFont = fontFamily.CreateFont(40, FontStyle.Bold);

            backgroundImage.Mutate(ctx =>
            {
                ctx.DrawText(new DrawingOptions
                {
                    TextOptions = new TextOptions
                    {
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center
                    }
                }, mipName, nameFont, Color.White, new PointF(1180, 1050));
                ctx.DrawText(new DrawingOptions
                {
                    TextOptions = new TextOptions
                    {
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center
                    }
                }, DateTime.Now.ToString("yyyy.MM.dd"), dateFont, Color.White, new PointF(1180, 1275));
            });

            backgroundImage.SaveAsPng(Path.Combine(Directory.GetCurrentDirectory(), $"{DateTime.Now:yyyyMMddHHmmss}.png"));
        }
    }
}