using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using dataLayer.Model;
using dataLayer.Repository;
using Microsoft.Extensions.Logging;

namespace dataLayer.Service
{
    public class Provider : IRepository
    {


        public bool Insert(EndPointCoin point)
    {
        try
        {
            using (WriteCoinDBContext writeCoinDbContext = new WriteCoinDBContext())
            {
                writeCoinDbContext.EndPointCoins.Add(point);
                writeCoinDbContext.SaveChanges();
            }
            //log   


            return true;
        }
        catch (Exception e)
        {
            using (WriteCoinDBContext writeCoinDbContext = new WriteCoinDBContext())
            {
                var endPointCoin = new EndPointCoin();
                endPointCoin.Name = "error";
                endPointCoin.Time = DateTime.Now.ToShortTimeString();
                endPointCoin.History=DateTime.Now.Date.ToShortTimeString();
                writeCoinDbContext.EndPointCoins.Add(point);
                writeCoinDbContext.SaveChanges();
            }
            return false;
        }
    }

    public WriteCoinDBContext GetAll()
    {
        throw new NotImplementedException();
    }

    public WriteCoinDBContext DesendingDataBaseContext()
    {
        throw new NotImplementedException();
    }


}
}
