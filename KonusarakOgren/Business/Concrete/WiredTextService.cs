using Business.Abstract;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.WiredDtos;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class WiredTextService : IWiredTextService
    {
        IWiredTextDal _wiredTextDal;
        public WiredTextService(IWiredTextDal wiredTextDal)
        {
            _wiredTextDal = wiredTextDal;
        }
        public WiredText GetWiredText(int id)
        {
            return _wiredTextDal.GetById(id);
        }
        public List<WiredDto> GetWiredTexts()
        {
            var lastWiredList = _wiredTextDal.Table.Where(x => x.CreatedDate >= DateTime.Today).Select(x => new WiredDto
            {
                WiredTextId = x.Id,
                Title = x.Title,
                WiredUrl = x.TextUrl
            }).OrderBy(x => x.WiredTextId).Skip(0).Take(5).ToList();
            if (lastWiredList.Count() == 5)
            {
                return lastWiredList;
            }
            var urlList = GetWiredLastFiveText();
            foreach (var url in urlList)
            {
                try
                {
                    var checkWiredUrl = lastWiredList.Where(x => x.WiredUrl == url.Url).FirstOrDefault();
                    if (checkWiredUrl == null)
                    {
                        string body = GetWiredTextInUrl(url.Url);
                        WiredText wiredText = new WiredText
                        {
                            Text = body,
                            TextUrl = url.Url,
                            Title = url.Title
                        };
                        _wiredTextDal.Add(wiredText);
                    }
                }
                catch (Exception)
                {

                    continue;
                }

            }
            lastWiredList = _wiredTextDal.Table.Where(x => x.CreatedDate >= DateTime.Today).Select(x => new WiredDto
            {
                WiredTextId = x.Id,
                Title = x.Title,
                WiredUrl = x.TextUrl
            }).OrderBy(x => x.WiredTextId).Skip(0).Take(5).ToList();
            return lastWiredList;
        }
        public string GetWiredTextInUrl(string url)
        {
            try
            {
                WebClient client = new WebClient();
                client.Headers.Add("Accept: text/html, application/xhtml+xml, */*");
                client.Headers.Add("User-Agent: Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; WOW64; Trident/5.0)");
                client.Encoding = Encoding.UTF8;
                string raw = client.DownloadString(url);
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(raw);

                HtmlNodeCollection subjectText = doc.DocumentNode.SelectNodes("//div[@class='body__inner-container']");
                string body = "";
                if (subjectText != null)
                {
                    foreach (var item in subjectText)
                    {
                        foreach (var paragrph in item.SelectNodes("p"))
                        {
                            body += "<p>" + paragrph.InnerHtml + "</p>";

                        }
                    }
                }
                else
                {
                    subjectText = doc.DocumentNode.SelectNodes("//article");
                    if (subjectText != null)
                    {
                        foreach (var item in subjectText)
                        {
                            if (item.SelectNodes("p") != null)
                            {
                                foreach (var paragrph in item.SelectNodes("p"))
                                {
                                    body += "<p>" + paragrph.InnerHtml + "</p>";

                                }
                            }
                            else
                            {
                                var pDiv = doc.DocumentNode.SelectSingleNode("//*[@id='main-content']/article/div[2]/div[1]/div[1]/div[1]/div/div[1]/div");
                                if (pDiv != null)
                                {
                                        foreach (var paragrph in pDiv.SelectNodes("p"))
                                        {
                                            body += "<p>" + paragrph.InnerHtml + "</p>";

                                        }
                                    
                                    

                                }
                                break;
                            }

                        }

                    }
                   
                   

                }

                return body;
            }
            catch (Exception)
            {

                return "";
            }

        }
        public List<WiredUrlDto> GetWiredLastFiveText()
        {
            string url = "https://www.wired.com";


            System.Net.WebClient client = new System.Net.WebClient();
            client.Headers.Add("Accept: text/html, application/xhtml+xml, */*");
            client.Headers.Add("User-Agent: Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; WOW64; Trident/5.0)");
            client.Encoding = Encoding.UTF8;
            string raw = client.DownloadString(url);
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(raw);
            List<WiredUrlDto> titleList = new List<WiredUrlDto>();
            HtmlNodeCollection titles = doc.DocumentNode.SelectNodes("//li[@class='card-component__description card-component__description--standard']");
            if (titles != null)
            {
                var titleA = titles[0].SelectNodes("a")[1];
                WiredUrlDto titles1 = new WiredUrlDto
                {
                    Title = titleA.InnerText,
                    Url = url + titleA.Attributes["href"].Value
                };
                titleList.Add(titles1);
            }
            HtmlNodeCollection titlesnarrow = doc.DocumentNode.SelectNodes("//li[@class='card-component__description card-component__description--narrow']");
            if (titlesnarrow != null)
            {
                var titleA = titlesnarrow[0].SelectNodes("a")[1];
                WiredUrlDto titles1 = new WiredUrlDto
                {
                    Title = titleA.InnerText,
                    Url = url + titleA.Attributes["href"].Value
                };
                titleList.Add(titles1);
            }
            HtmlNodeCollection titlesSmall = doc.DocumentNode.SelectNodes("//li[@class='card-component__description card-component__description--small']");
            if (titlesSmall != null)
            {
                var titleA = titlesSmall[0].SelectNodes("a")[1];
                WiredUrlDto titles1 = new WiredUrlDto
                {
                    Title = titleA.InnerText,
                    Url = url + titleA.Attributes["href"].Value
                };
                titleList.Add(titles1);
            }
            HtmlNodeCollection titlesText = doc.DocumentNode.SelectNodes("//li[@class='card-component__description card-component__description--text']");
            if (titlesText != null)
            {
                var titleA = titlesText[0].SelectNodes("a")[1];
                WiredUrlDto titles1 = new WiredUrlDto
                {
                    Title = titleA.InnerText,
                    Url = url + titleA.Attributes["href"].Value
                };
                titleList.Add(titles1);
            }
            HtmlNodeCollection titlesSmallReserved = doc.DocumentNode.SelectNodes("//li[@class='card-component__description card-component__description--small-reversed']");
            if (titlesSmallReserved != null)
            {
                var titleA = titlesSmallReserved[0].SelectNodes("a")[1];
                WiredUrlDto titles1 = new WiredUrlDto
                {
                    Title = titleA.InnerText,
                    Url = url + titleA.Attributes["href"].Value
                };
                titleList.Add(titles1);
            }

            return titleList;
        }

        public Dto UpdateWiredText(int id, string text)
        {
            var wiredText = _wiredTextDal.GetById(id);
            if (wiredText == null)
            {
                return new Dto
                {
                    Status = false,
                    StatusCode = "error",
                    ResponseMessage = "WiredText Sistemde Bulunamadı"
                };
            }
            wiredText.Text = text;
            _wiredTextDal.Update(wiredText);
            return new Dto
            {
                Status = true,
                StatusCode = "success",
                ResponseMessage = "WiredText Güncellendi"
            };
        }
    }
}
