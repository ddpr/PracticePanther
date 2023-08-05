using PracticeManagement.Library.Models;
using PracticePanther.Library.Services;
using ProjectPanther.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPanther.Library.Services
{
    public class BillService
    {
        private static BillService? instance;
        private static object _lock = new object();
        private List<Bill> billList;


        public static BillService Current
        {
            get
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = new BillService();
                    }
                }
                return instance;

            }
        }

        private BillService()
        {
            billList = new List<Bill>();
        }

        public List<Bill> Bills
        {
           get { return billList; }
        }

        public List<Bill> Search(Project project)
        {
            return billList.Where(b => b.linkedProject.Equals(project)).ToList();
        }

        public void Add(Bill? bill)
        {
            if(bill != null)
            {
                billList.Add(bill);
            }
        }

        public void Refresh()
        {
            foreach(var bill in billList)
            {
                bill.TotalAmount = bill.calculateTotal();
            }
        }
    }
}
