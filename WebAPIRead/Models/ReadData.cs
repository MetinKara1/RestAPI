using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;
using Aspose.Cells;

namespace WebAPIRead.Models
{
    public interface IReadData
    {
        List<Person> ReadData(string url);
    }

    public class ReadDataManager
    {
        private readonly IReadData _readData = null;

        public ReadDataManager(IReadData data)
        {
            this._readData = data;
        }

        public List<Person> ReadData(string url)
        {
            var data = _readData.ReadData(url);
            return data;
        }
    }

    public class ReadRestApi : IReadData
    {
        public List<Person> ReadData(string url)
        {
            var webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.Method = "GET";
            webRequest.Credentials = CredentialCache.DefaultCredentials;
            webRequest.ContentType = "application/json";

            HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                
            }

            List<Person> list = new List<Person>();
            using (var st = new StreamReader(response.GetResponseStream()))
            {
                var js = new JavaScriptSerializer();
                list = js.Deserialize<Person[]>(st.ReadToEnd()).ToList();
            }
            return list;
        }

    }

    public class ReadXml : IReadData
    {
        public List<Person> ReadData(string url)
        {
            var list = new List<Person>();
            var ds = new DataSet();
            ds.ReadXml(url);

            foreach (DataRow item in ds.Tables[0].Rows)
            {
                list.Add(new Person
                {
                    Kod = item["id"].ToString(),
                    Name = item["author"].ToString()
                });
            }

            return list;
        }

    }

    public class ReadExcel : IReadData
    {
        public List<Person> ReadData(string url)
        {
            var list = new List<Person>();

            Workbook book = new Workbook(url);
            Worksheet sheet = book.Worksheets[1];

            for (int i = 1; i < sheet.Cells.MaxDataRow + 1; i++)
            {
                list.Add(new Person
                {
                    Kod = sheet.Cells.Rows[i][0].StringValue,
                    Name = sheet.Cells.Rows[i][1].StringValue
                });
            }

            
            return list;
        }

    }
}
