using Anbe.Areas.AnbeAdmin.Models.ViewModels;
using Anbe.Areas.Identity.Data;
using Anbe.Data;
using Anbe.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stimulsoft.Base;
using Stimulsoft.Base.Drawing;
using Stimulsoft.Report;
using Stimulsoft.Report.Components;
using Stimulsoft.Report.Components.Table;
using Stimulsoft.Report.Dictionary;
using Stimulsoft.Report.Mvc;
using Stimulsoft.System.Windows.Forms;
using System;
using System.Data;
using System.Drawing;
using System.Linq;

namespace Anbe.Controllers
{
    public class CheckListController : Controller
    {
        private readonly AnbeContext _context;
        private readonly UserManager<ApplicationUser> _um;

        public CheckListController(AnbeContext context, UserManager<ApplicationUser> um)
        {
            StiLicense.LoadFromString("6vJhGtLLLz2GNviWmUTrhSqnOItdDwjBylQzQcAOiHl2AD0gPVknKsaW0un+3PuM6TTcPMUAWEURKXNso0e5OJN40hx" +
                              "JjK5JbrxU+NrJ3E0OUAve6MDSIxK3504G4vSTqZezogz9ehm+xS8zUyh3tFhCWSvIoPFEEuqZTyO744uk+ezyGDj7C5" +
                              "jJQQjndNuSYeM+UdsAZVREEuyNFHLm7gD9OuR2dWjf8ldIO6Goh3h52+uMZxbUNal/0uomgpx5NklQZwVfjTBOg0xKB" +
                              "LJqZTDKbdtUrnFeTZLQXPhrQA5D+hCvqsj+DE0n6uAvCB2kNOvqlDealr9mE3y978bJuoq1l4UNE3EzDk+UqlPo8KwL" +
                              "1XM+o1oxqZAZWsRmNv4Rr2EXqg/RNUQId47/4JO0ymIF5V4UMeQcPXs9DicCBJO2qz1Y+MIpmMDbSETtJWksDF5ns6+" +
                              "B0R7BsNPX+rw8nvVtKI1OTJ2GmcYBeRkIyCB7f8VefTSOkq5ZeZkI8loPcLsR4fC4TXjJu2loGgy4avJVXk32bt4FFp" +
                              "9ikWocI9OQ7CakMKyAF6Zx7dJF1nZw");
            _context = context;
            _um = um;
        }

        public IActionResult ShowPrint(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            TempData["id"] = id;
            return View("ShowPrint");
        }

        public  IActionResult Print()
        {


            StiReport report = new StiReport();
            report.Load("wwwroot/Reports/Report.mrt");

            string id = TempData["id"].ToString();
            var ColorList = _context.Products.Where(x=>x.ApplicationUsersId == id).Select(y => new ProductReportViewModel
            {
                ProductName = y.ProductName,
                PricetoziKonande = y.PriceToziKonande.ToString("#,0")
                ,
                Granty = y.Granty ?? "ندارد"
                ,
                Id = y.ProductID
                ,
                NameMaqaze = y.ApplicationUsers.NameMaqaze,
                ProductCategoryName = (y.book_Categories.Select(p => p.Category.CategoryName).FirstOrDefault()) ??  "samsung" ,
                Colors = String.Join(",", y.ProductColors.Select(p => p.Colors.EsmeRang).ToList()) 
            }).ToList();
          
            report.RegData("dt", ColorList);



            //report.Dictionary.Synchronize();

            //StiPage page = report.Pages.Items[0];


            //StiHeaderBand headerBand = new StiHeaderBand();
            //headerBand.Name = "HeaderBand";
            //page.Components.Add(headerBand);

            //// Create Databand
            //StiDataBand dataBand = new StiDataBand();
            //dataBand.DataSourceName = "dt";
            //dataBand.Height = 0.5f;
            //dataBand.Name = "DataBand";
            //page.Components.Add(dataBand);

            //StiDataSource dataSource = report.Dictionary.DataSources[0];

            //Double pos = 0;
            //Double columnWidth = StiAlignValue.AlignToMinGrid(page.Width / dataSource.Columns.Count, 0.1, true);
            //int nameIndex = 1;
            //foreach (StiDataColumn column in dataSource.Columns)
            //{
            //    if (column.Name == "_ID" || column.Name == "_Current") continue;

            //    // Create text on header
            //    StiText headerText = new StiText(new RectangleD(pos, 0, page.Width, 0.5f));
            //    headerText.Text.Value = column.Name;
            //    headerText.HorAlignment = StiTextHorAlignment.Center;
            //    headerText.Name = "HeaderText" + nameIndex.ToString();
            //    headerText.Brush = new StiSolidBrush(Color.MediumSeaGreen);
            //    headerText.Border.Side = StiBorderSides.All;
            //    headerBand.Components.Add(headerText);






            //    // Create text on Data Band
            //    StiText dataText = new StiText(new RectangleD(pos, 0, page.Width, 0.5f));
            //    dataText.Text.Value = "{dt." + column.Name + "}";
            //    dataText.Name = "DataText" + nameIndex.ToString();
            //    dataText.Border.Side = StiBorderSides.All;
                               
            //        dataText.Brush = new Stimulsoft.Base.Drawing.StiSolidBrush(Color.Blue);
            //    dataBand.Components.Add(dataText);



            //    pos += columnWidth;

            //    nameIndex++;
            //}

            //// Create FooterBand
            //StiFooterBand footerBand = new StiFooterBand();
            //footerBand.Height = 0.5f;
            //footerBand.Name = "FooterBand";
            //page.Components.Add(footerBand);

            //// Create text on footer
            //StiText footerText = new StiText(new RectangleD(0, 0, page.Width, 0.5f));
            //footerText.Text.Value = "Count - {Count()}";
            //footerText.HorAlignment = StiTextHorAlignment.Right;
            //footerText.Name = "FooterText";
            
            
            //    footerText.Brush = new StiSolidBrush(Color.LightGreen);
            
            
            //footerBand.Components.Add(footerText);







            return StiNetCoreViewer.GetReportResult(this, report);
        }

        public IActionResult ViewEvent()
        {
            return StiNetCoreViewer.ViewerEventResult(this);
        }


    }
}
