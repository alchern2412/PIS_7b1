using DictionaryInterface;
using JsonRepo;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace lab7b
{
    [WebService(Namespace = "http://belstu.by/")] // Пространство имен
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)] // Спецификация совместимости web-служб
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Dictionary : System.Web.Services.WebService
    {
        IPhoneDictionary dictRepository = new JsonRepository();
        private static Random random = new Random();

        [WebMethod(Description = "Geg full Dictionary")]
        public List<Record> GetDict()
        {
            return dictRepository.GetRecords();
        }

        // AddDict(P)
        [WebMethod(Description = "Add record to the Dictionary")]
        public void AddDict(String name, string number)
        {
            Record record = new Record(random.Next(), name, number);
            dictRepository.AddRecord(record);
        }

        // UpdDict(P)
        [WebMethod(Description = "Update record in the Dictionary")]
        public void UpdDict(int id, String name, string number)
        {
            Record record = new Record(id, name, number);
            dictRepository.Update(record);
        }

        // DelDict(P)
        [WebMethod(Description = "Delete record from the Dictionary")]
        public void DelDict(int id)
        {
            dictRepository.Delete(id);
        }

    }
}
