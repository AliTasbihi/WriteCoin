using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using dataLayer.Model;


//using dataLayer.Model;

namespace dataLayer.Repository
{
    internal interface IRepository
    {
        bool Insert(EndPointCoin addPoint);
        WriteCoinDBContext GetAll();
        WriteCoinDBContext DesendingDataBaseContext();

    }
}
